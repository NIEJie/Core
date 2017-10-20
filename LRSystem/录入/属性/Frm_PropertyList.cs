using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using LRSystem.录入.属性;
using LRSystemClient;
using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRSystem
{
    public partial class Frm_PropertyList : XtraForm
    {
        #region 变量
        private PropertyClient propertyClient = new PropertyClient();
        //private PublicClass publicClass = new PublicClass();公共方法没有配置
        private List<MyPropertyType> propertyTypeList = new List<MyPropertyType>();
        private string DBOperType = string.Empty; //I : insert ; U : update
        private string addflage = string.Empty; // 0 : 同级增加类型 ; 1 :下级增加类型
        MyPropertyType g_propertyType = new MyPropertyType();
        MyPropertyInfo g_propertyInfo = new MyPropertyInfo();
        #endregion

        #region 构造函数
        public Frm_PropertyList()
        {
            InitializeComponent();
        }
        #endregion

        #region 表单加载
        private void Frm_PropertyList_Load(object sender, EventArgs e)
        {

            propertyTypeList = propertyClient.GetPropertyType();
            if (propertyTypeList.Count > 0)
            {
                this.BindTree(TreeList_Property, propertyTypeList);
            }

        }
        #endregion

        #region 类型及信息树的绑定方法


        /// <summary>
        /// 绑定treelist
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="propertyTypeList"></param>
        private void BindTree(DevExpress.XtraTreeList.TreeList treeList, List<MyPropertyType> propertyTypeList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            foreach (MyPropertyType item in propertyTypeList)
            {
                //树的第一级节点，进入递归
                if (item.PROPERTYTYPE_GRADE == 1)
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.PROPERTYTYPE_ID,item.PROPERTYTYPE_CODE,item.PROPERTYTYPE_NAME,item.PROPERTYTYPE_PARENTID,item.PROPERTYTYPE_IFDETAIL,item.PROPERTYTYPE_GRADE,item.PROPERTYTYPE_IFINVALID,item.PROPERTYTYPE_NOTE,item.PROPERTYTYPE_CREATETIME,item.PROPERTYTYPE_LASTMODIFIEDTIME,item.PROPERTYTYPE_MODIFICATIONTIMES,"PropertyType"},null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子类型
                    LoadTypeTreeNode(treeList, node, item, propertyTypeList);
                    LoadInfoTreeNode(treeList, node, item.PROPERTYTYPE_PROPERTYINFO);
                }
            }
            treeList.EndUpdate();
        }

        /// <summary>
        /// 循环绑定类型树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="propertyType"></param>
        /// <param name="propertyTypeList"></param>
        private void LoadTypeTreeNode(DevExpress.XtraTreeList.TreeList treeList,TreeListNode treeNode, MyPropertyType propertyType, List<MyPropertyType> propertyTypeList)
        {
            int grade = propertyType.PROPERTYTYPE_GRADE;
            string parentid = propertyType.PROPERTYTYPE_PARENTID;
            foreach (MyPropertyType item in propertyTypeList)
            {
                if (item.PROPERTYTYPE_PARENTID == parentid && item.PROPERTYTYPE_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.PROPERTYTYPE_ID, item.PROPERTYTYPE_CODE, item.PROPERTYTYPE_NAME, item.PROPERTYTYPE_PARENTID, item.PROPERTYTYPE_IFDETAIL, item.PROPERTYTYPE_GRADE, item.PROPERTYTYPE_IFINVALID,item.PROPERTYTYPE_NOTE, item.PROPERTYTYPE_CREATETIME, item.PROPERTYTYPE_LASTMODIFIEDTIME, item.PROPERTYTYPE_MODIFICATIONTIMES,"PropertyType" }, treeNode);
                    typeNode.StateImageIndex = 0;
                    //循环绑定子类型
                    LoadTypeTreeNode(treeList, typeNode, item, propertyTypeList);
                    LoadInfoTreeNode(treeList, typeNode, item.PROPERTYTYPE_PROPERTYINFO);
                }
            }
        }

        /// <summary>
        /// 循环绑定信息树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="propertyInfoList"></param>
        private void LoadInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, List<MyPropertyInfo> propertyInfoList)
        {
            if (propertyInfoList != null && propertyInfoList.Count > 0)
            {
                foreach (MyPropertyInfo item in propertyInfoList)
                {
                    //父节点ID：item类型id；是否明细：是；级数：父节点级数+1
                    int i = Convert.ToInt32(treeNode.GetValue("PROPERTYTYPE_GRADE")) + 1;
                    TreeListNode infoNode = treeList.AppendNode(new object[] { item.PROPERTYINFO_ID, item.PROPERTYINFO_CODE, item.PROPERTYINFO_NAME, item.PROPERTYINFO_TYPEID, "1", i,item.PROPERTYINFO_IFINVALID, item.PROPERTYINFO_NOTE, item.PROPERTYINFO_CREATETIME, item.PROPERTYINFO_LASTMODIFIEDTIME, item.PROPERTYINFO_MODIFICATIONTIMES, "PropertyInfo" }, treeNode);
                    infoNode.StateImageIndex = 1;
                }
            }
        }



        #endregion

        #region Node操作

        private void propertyTreeList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (TreeList_Property.FocusedNode == null) return;


            TreeListNode selTreeLNode = TreeList_Property.FocusedNode;
            //TreeListNode selTreeLParNode = propertyTreeList.FocusedNode.ParentNode;
            if (selTreeLNode != null)
            {
                this.textEdit_Code.EditValue = selTreeLNode.GetValue("PROPERTYTYPE_CODE");
                this.textEdit_Name.EditValue = selTreeLNode.GetValue("PROPERTYTYPE_NAME");
                this.textEdit_CreateTime.EditValue = selTreeLNode.GetValue("PROPERTYTYPE_CREATETIME");
                this.textEdit_LastModifiedTime.EditValue = selTreeLNode.GetValue("PROPERTYTYPE_LASTMODIFIEDTIME");
                this.textEdit_ModificationTimes.EditValue = selTreeLNode.GetValue("PROPERTYTYPE_MODIFIEDTIMES");
                this.memoEdit_Note.EditValue = selTreeLNode.GetValue("PROPERTYTYPE_NOTE");
            }
        }

        private void propertyTreeList_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            //不懂。。。。这几句是什么意思？
            TreeListNode tn = e.OldNode;
            if (tn == null) return;
            TreeList_Property.CloseEditor();
        }





        #endregion

        #region 新增类型
        //主要自动得到id、parentid、isdetail、grade
        private void barButtonItem_CreateType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            g_propertyType = new MyPropertyType();
            TreeListNode node = this.TreeList_Property.FocusedNode;
            this.DBOperType = "I";
            //this.addflage = "0";
            //无数据
            if (node == null)
            {
                g_propertyType.PROPERTYTYPE_ID = Guid.NewGuid().ToString();
                g_propertyType.PROPERTYTYPE_PARENTID = "";
                g_propertyType.PROPERTYTYPE_IFDETAIL = "F";
                g_propertyType.PROPERTYTYPE_GRADE = 1;
            }
            //一级节点
            if (node != null && node.ParentNode == null)
            {
                g_propertyType.PROPERTYTYPE_ID = Guid.NewGuid().ToString();
                g_propertyType.PROPERTYTYPE_PARENTID = "";
                g_propertyType.PROPERTYTYPE_IFDETAIL = "F";
                g_propertyType.PROPERTYTYPE_GRADE = 1;
            }
            //非一级节点
            if (node != null && node.ParentNode != null)
            {
                g_propertyType.PROPERTYTYPE_ID = Guid.NewGuid().ToString();
                g_propertyType.PROPERTYTYPE_PARENTID = node.GetValue("PROPERTYTYPE_PARENTID").ToString();
                g_propertyType.PROPERTYTYPE_IFDETAIL = "F";
                g_propertyType.PROPERTYTYPE_GRADE = Convert.ToInt32(node.GetValue("PROPERTYTYPE_GRADE"));
            }

            //状态修改
            ChangeCardState(true);
        }

        #endregion


        #region 新增下级类型
        //跟新增类型没区别，只是父节点和级数有变化
        private void barButtonItem_CreateSonType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            g_propertyType = new MyPropertyType();
            TreeListNode node = this.TreeList_Property.FocusedNode;
            this.DBOperType = "I";
            //this.addflage = "0";
            //无数据
            if (node == null)
            {
                MessageBox.Show("请先选择类型");
            }
            //一级节点
            if (node != null && node.ParentNode == null)
            {
                g_propertyType.PROPERTYTYPE_ID = Guid.NewGuid().ToString();
                g_propertyType.PROPERTYTYPE_PARENTID = node.GetValue("PROPERTYTYPE_ID").ToString();
                g_propertyType.PROPERTYTYPE_IFDETAIL = "F";
                g_propertyType.PROPERTYTYPE_GRADE = 2;
            }
            //非一级节点
            if (node != null && node.ParentNode != null)
            {
                g_propertyType.PROPERTYTYPE_ID = Guid.NewGuid().ToString();
                g_propertyType.PROPERTYTYPE_PARENTID = node.GetValue("PROPERTYTYPE_ID").ToString();
                g_propertyType.PROPERTYTYPE_IFDETAIL = "F";
                g_propertyType.PROPERTYTYPE_GRADE = Convert.ToInt32(node.GetValue("PROPERTYTYPE_GRADE")) + 1;
            }

            //状态修改
            ChangeCardState(true);
        }
        #endregion

        #region 保存类型
        private void barButtonItem_SaveType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode selTreeLNode = TreeList_Property.FocusedNode;
            g_propertyType.PROPERTYTYPE_CODE = this.textEdit_Code.ToString();
            g_propertyType.PROPERTYTYPE_NAME = this.textEdit_Name.ToString();

            if (this.DBOperType == "I")
            {
                g_propertyType.PROPERTYTYPE_CREATETIME = System.DateTime.Now.ToString();
                g_propertyType.PROPERTYTYPE_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                g_propertyType.PROPERTYTYPE_MODIFICATIONTIMES = "1";
                if(this.memoEdit_Note.EditValue == null)
                {
                    MessageBox.Show("请写NOTE");
                    return;
                }
                g_propertyType.PROPERTYTYPE_NOTE = this.memoEdit_Note.EditValue.ToString();
                this.propertyTypeList.Add(g_propertyType);
            }
            else if(this.DBOperType == "U")
            {
                //update的时候，不需要！！！将类型下的属性全部赋值一遍，因为只需要update修改的这些
                g_propertyType.PROPERTYTYPE_ID = selTreeLNode.GetValue("PROPERTYTYPE_ID").ToString();
                g_propertyType.PROPERTYTYPE_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                g_propertyType.PROPERTYTYPE_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes) + 1);
                if (this.memoEdit_Note.EditValue == null)
                {
                    MessageBox.Show("请写NOTE");
                    return;
                }
                g_propertyType.PROPERTYTYPE_NOTE = this.memoEdit_Note.EditValue.ToString();

                foreach(MyPropertyType item in propertyTypeList)
                {
                    if(item.PROPERTYTYPE_ID == g_propertyType.PROPERTYTYPE_ID)
                    {
                        propertyTypeList.Remove(item);
                        break;
                    }
                }
                this.propertyTypeList.Add(g_propertyType);
            }
            propertyClient.SavePropertyType(this.DBOperType, g_propertyType);

            this.BindTree(TreeList_Property, propertyTypeList);
            ChangeCardState(false);
        }
        #endregion

        #region 卡片状态修改
        private void ChangeCardState(bool state)
        {
            this.textEdit_Name.Enabled = state;
            this.textEdit_Code.Enabled = state;
            this.memoEdit_Note.Enabled = state;
        }
        #endregion

        #region 菜单按钮状态修改
        private void ChangeBarState(bool state)
        {

        }

        #endregion

        #region 编辑属性
        private void barButtonItem_EditType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeCardState(true);
            this.DBOperType = "U";
        }
        #endregion

        #region 取消
        private void barButtonItem_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ChangeCardState(false);
            this.Frm_PropertyList_Load(null, null);
        }
        #endregion

        #region 关闭
        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 作废
        //改状态并刷新
        private void barButtonItem_Invalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode selTreeLNode = TreeList_Property.FocusedNode;
            if(selTreeLNode!= null)
            {
                foreach(MyPropertyType item in propertyTypeList)
                {
                    if (item.PROPERTYTYPE_ID == selTreeLNode.GetValue("PROPERTYTYPE_ID").ToString()) item.PROPERTYTYPE_IFINVALID = "T";
                }
            }
        }
        #endregion

        #region 新增属性
        private void barButtonItem_CreateInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeList_Property.FocusedNode == null) return;
            TreeListNode node = this.TreeList_Property.FocusedNode;
            Frm_PropertyCard card = new Frm_PropertyCard();
            if (node.GetValue("NodeType").ToString() == "PropertyType")
            {
                card.propertyInfo.PROPERTYINFO_TYPEID = node.GetValue("PROPERTYTYPE_ID").ToString();
            }
            else if(node.GetValue("NodeType").ToString() == "PropertyInfo")
            {
                card.propertyInfo.PROPERTYINFO_TYPEID = node.GetValue("PROPERTYTYPE_PARENTID").ToString();
            }
            card.propertyInfo.PROPERTYINFO_CREATETIME = DateTime.Now.ToString();
            card.propertyInfo.PROPERTYINFO_ID = Guid.NewGuid().ToString();
            card.propertyInfo.PROPERTYINFO_IFINVALID = "F";
            card.propertyInfo.PROPERTYINFO_LASTMODIFIEDTIME = card.propertyInfo.PROPERTYINFO_CREATETIME;
            card.propertyInfo.PROPERTYINFO_MODIFICATIONTIMES = "0";
            if(card.ShowDialog() == DialogResult.OK)
            {
                this.Frm_PropertyList_Load(null, null);
            }
        }
        #endregion

        #region 编辑属性
        private void barButtonItem_EditInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeList_Property.FocusedNode == null) return;
            TreeListNode node = this.TreeList_Property.FocusedNode;
            Frm_PropertyCard card = new Frm_PropertyCard();
            if (node.GetValue("NodeType").ToString() == "PropertyType")
            {
                MessageBox.Show("选择的是类型");
            }
            else if (node.GetValue("NodeType").ToString() == "PropertyInfo")
            {
                card.propertyInfo.PROPERTYINFO_TYPEID = node.GetValue("PROPERTYTYPE_PARENTID").ToString();
            }
            card.propertyInfo.PROPERTYINFO_CREATETIME = node.GetValue("PROPERTYTYPE_CREATETIME").ToString();
            card.propertyInfo.PROPERTYINFO_ID = node.GetValue("PROPERTYTYPE_ID").ToString();
            card.propertyInfo.PROPERTYINFO_IFINVALID = node.GetValue("PROPERTYTYPE_IFINVALID").ToString();
            card.propertyInfo.PROPERTYINFO_LASTMODIFIEDTIME = node.GetValue("PROPERTYTYPE_LASTMODIFIEDTIME").ToString();
            card.propertyInfo.PROPERTYINFO_MODIFICATIONTIMES = node.GetValue("PROPERTYTYPE_MODIFICATIONTIMES").ToString();
            if(card.ShowDialog() == DialogResult.OK)
            {
                this.Frm_PropertyList_Load(null, null);
            }
        }
        #endregion
    }
}
