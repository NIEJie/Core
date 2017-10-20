using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using LRSystemClient;
using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LRSystem
{
    public partial class Frm_PropertyComCard : XtraForm
    {
        #region 变量
        private PropertyClient propertyClient = new PropertyClient();
        //private PublicClass publicClass = new PublicClass();公共方法没有配置
        private List<MyPropertyType> propertyTypeList = new List<MyPropertyType>();
        private string DBOperType = string.Empty; //I : insert ; U : update
        MyPropertyType propertyType = new MyPropertyType();
        MyPropertyInfo propertyInfo = new MyPropertyInfo();
        MyPropertyData propertyData = new MyPropertyData();
        //选中树节点时查询数据条件
        public string objectTypeId = string.Empty;
        public string objectId = string.Empty;
        private string typeId = string.Empty;
        private string infoId = string.Empty;
        #endregion

        #region 构造函数
        public Frm_PropertyComCard()
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
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.PROPERTYTYPE_ID, item.PROPERTYTYPE_CODE, item.PROPERTYTYPE_NAME, item.PROPERTYTYPE_PARENTID, item.PROPERTYTYPE_IFDETAIL, item.PROPERTYTYPE_GRADE, item.PROPERTYTYPE_IFINVALID,item.PROPERTYTYPE_NOTE, item.PROPERTYTYPE_CREATETIME, item.PROPERTYTYPE_LASTMODIFIEDTIME, item.PROPERTYTYPE_MODIFICATIONTIMES,"PropertyType" }, null);
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
                //根据属性获取信息数据
                if (selTreeLNode.GetValue("NodeType").ToString() == "PropertyType")
                {
                    //MessageBox.Show("选择的是属性类型");
                    return;
                }
                else if (selTreeLNode.GetValue("NodeType").ToString() == "PropertyInfo")
                {
                    typeId = selTreeLNode.GetValue("PROPERTYTYPE_PARENTID").ToString();
                    infoId = selTreeLNode.GetValue("PROPERTYTYPE_ID").ToString();
                    propertyData = propertyClient.GetPropertyDataCard(objectTypeId, objectId, typeId, infoId);
                    if (propertyData != null)
                    {
                        DBOperType = "U";
                        this.textEdit_Code.EditValue = propertyData.PROPERTYDATA_CODE;
                        this.textEdit_Name.EditValue = propertyData.PROPERTYDATA_NAME;
                        this.textEdit_CreateTime.EditValue = propertyData.PROPERTYDATA_CREATETIME;
                        this.textEdit_LastModifiedTime.EditValue = propertyData.PROPERTYDATA_LASTMODIFIEDTIME;
                        this.textEdit_ModificationTimes.EditValue = propertyData.PROPERTYDATA_MODIFICATIONTIMES;
                        this.memoEdit_Note.EditValue = propertyData.PROPERTYDATA_NOTE;
                    }
                    else
                    {
                        DBOperType = "I";
                    }
                }

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

        #region 取消
        private void barButtonItem_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeCardState(false);

            this.Frm_PropertyList_Load(null, null);
        }
        #endregion

        #region 关闭
        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 编辑
        //如果没有编辑直接点保存，会导致数据修改，应该有对保存按钮有所限制
        private void barButtonItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeCardState(true);
        }
        #endregion

        #region 保存
        private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode selTreeLNode = TreeList_Property.FocusedNode;
            propertyData.PROPERTYDATA_CODE = this.textEdit_Code.ToString();
            propertyData.PROPERTYDATA_NAME = this.textEdit_Name.ToString();
            propertyData.PROPERTYDATA_NOTE = this.memoEdit_Note.ToString();

            if (this.DBOperType == "I")
            {
                propertyData.PROPERTYDATA_CREATETIME = System.DateTime.Now.ToString();
                propertyData.PROPERTYDATA_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                propertyData.PROPERTYDATA_MODIFICATIONTIMES = "1";
                propertyData.PROPERTYDATA_ID = System.Guid.NewGuid().ToString();
                propertyData.PROPERTYDATA_IFINVALID = "T";
                propertyData.PROPERTYDATA_INFOID = infoId;
                propertyData.PROPERTYDATA_TYPEID = typeId;
                propertyData.PROPERTYDATA_OBJECTID = objectId;
                propertyData.PROPERTYDATA_OBJECTTYPEID = objectTypeId;
            }
            else if (this.DBOperType == "U")
            {
                //update的时候，不需要！！！将类型下的属性全部赋值一遍，因为只需要update修改的这些
                propertyData.PROPERTYDATA_ID = selTreeLNode.GetValue("PROPERTYTYPE_ID").ToString();
                propertyData.PROPERTYDATA_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                propertyData.PROPERTYDATA_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes) + 1);
            }
            propertyClient.SavePropertyDataCard(this.DBOperType, propertyData);
            ChangeCardState(false);
        }
        #endregion

        

    }
}
