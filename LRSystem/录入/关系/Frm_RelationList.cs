using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using LRSystemClient;
using LRSystemSPI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LRSystem.录入.关系
{
    public partial class Frm_RelationList : XtraForm
    {
        #region 变量
        private RelationClient relationClient = new RelationClient();
        //private PublicClass publicClass = new PublicClass();公共方法没有配置
        //private List<MyRelationType> relationTypeList = new List<MyRelationType>();
        private string DBOperType = string.Empty; //I : insert ; U : update
        private string addflage = string.Empty; // 0 : 同级增加类型 ; 1 :下级增加类型
        //MyRelationType g_relationType = new MyRelationType();
        MyRelationInfo g_relationInfo = new MyRelationInfo();
        #endregion

        //关系目前录入的方式：：：
        #region 构造函数
        public Frm_RelationList()
        {
            InitializeComponent();
        }
        #endregion

        #region 表单加载
        private void Frm_RelationsList_Load(object sender, EventArgs e)
        {

            relationTypeList = relationClient.GetRelationType();
            if (relationTypeList.Count > 0)
            {
                this.BindTree(TreeList_Relation, relationTypeList);
            }

        }
        #endregion

        #region 类型及信息树的绑定方法


        /// <summary>
        /// 绑定treelist
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="relationTypeList"></param>
        private void BindTree(DevExpress.XtraTreeList.TreeList treeList, List<MyRelationType> relationTypeList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            foreach (MyRelationType item in relationTypeList)
            {
                //树的第一级节点，进入递归
                if (item.RELATIONTYPE_GRADE == 1)
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.RELATIONTYPE_ID,item.RELATIONTYPE_CODE,item.RELATIONTYPE_NAME,item.RELATIONTYPE_PARENTID,item.RELATIONTYPE_IFDETAIL,item.RELATIONTYPE_GRADE,item.RELATIONTYPE_IFINVALID,item.RELATIONTYPE_NOTE,item.RELATIONTYPE_CREATETIME,item.RELATIONTYPE_LASTMODIFIEDTIME,item.RELATIONTYPE_MODIFICATIONTIMES,"RelationType"},null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子类型
                    LoadTypeTreeNode(treeList, node, item, relationTypeList);
                    LoadInfoTreeNode(treeList, node, item.RELATIONTYPE_RELATIONINFO);
                }
            }
            treeList.EndUpdate();
        }

        /// <summary>
        /// 循环绑定类型树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="relationType"></param>
        /// <param name="relationTypeList"></param>
        private void LoadTypeTreeNode(DevExpress.XtraTreeList.TreeList treeList,TreeListNode treeNode, MyRelationType relationType, List<MyRelationType> relationTypeList)
        {
            int grade = relationType.RELATIONTYPE_GRADE;
            string parentid = relationType.RELATIONTYPE_PARENTID;
            foreach (MyRelationType item in relationTypeList)
            {
                if (item.RELATIONTYPE_PARENTID == parentid && item.RELATIONTYPE_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.RELATIONTYPE_ID, item.RELATIONTYPE_CODE, item.RELATIONTYPE_NAME, item.RELATIONTYPE_PARENTID, item.RELATIONTYPE_IFDETAIL, item.RELATIONTYPE_GRADE, item.RELATIONTYPE_IFINVALID,item.RELATIONTYPE_NOTE, item.RELATIONTYPE_CREATETIME, item.RELATIONTYPE_LASTMODIFIEDTIME, item.RELATIONTYPE_MODIFICATIONTIMES,"RelationType" }, treeNode);
                    typeNode.StateImageIndex = 0;
                    //循环绑定子类型
                    LoadTypeTreeNode(treeList, typeNode, item, relationTypeList);
                    LoadInfoTreeNode(treeList, typeNode, item.RELATIONTYPE_RELATIONINFO);
                }
            }
        }

        /// <summary>
        /// 循环绑定信息树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="relationInfoList"></param>
        private void LoadInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, List<MyRelationInfo> relationInfoList)
        {
            if (relationInfoList != null && relationInfoList.Count > 0)
            {
                foreach (MyRelationInfo item in relationInfoList)
                {
                    //父节点ID：item类型id；是否明细：是；级数：父节点级数+1
                    int i = Convert.ToInt32(treeNode.GetValue("RELATIONTYPE_GRADE")) + 1;
                    TreeListNode infoNode = treeList.AppendNode(new object[] { item.RELATIONINFO_ID, item.RELATIONINFO_CODE, item.RELATIONINFO_NAME, item.RELATIONINFO_TYPEID, "1", i,item.RELATIONINFO_IFINVALID, item.RELATIONINFO_NOTE, item.RELATIONINFO_CREATETIME, item.RELATIONINFO_LASTMODIFIEDTIME, item.RELATIONINFO_MODIFICATIONTIMES, "RelationInfo" }, treeNode);
                    infoNode.StateImageIndex = 1;
                }
            }
        }



        #endregion

        #region Node操作

        private void relationTreeList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (TreeList_Relation.FocusedNode == null) return;


            TreeListNode selTreeLNode = TreeList_Relation.FocusedNode;
            //TreeListNode selTreeLParNode = relationTreeList.FocusedNode.ParentNode;
            if (selTreeLNode != null)
            {
                this.textEdit_Code.EditValue = selTreeLNode.GetValue("RELATIONTYPE_CODE");
                this.textEdit_Name.EditValue = selTreeLNode.GetValue("RELATIONTYPE_NAME");
                this.textEdit_CreateTime.EditValue = selTreeLNode.GetValue("RELATIONTYPE_CREATETIME");
                this.textEdit_LastModifiedTime.EditValue = selTreeLNode.GetValue("RELATIONTYPE_LASTMODIFIEDTIME");
                this.textEdit_ModificationTimes.EditValue = selTreeLNode.GetValue("RELATIONTYPE_MODIFIEDTIMES");
                this.memoEdit_Note.EditValue = selTreeLNode.GetValue("RELATIONTYPE_NOTE");
            }
        }

        private void relationTreeList_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            //不懂。。。。这几句是什么意思？
            TreeListNode tn = e.OldNode;
            if (tn == null) return;
            TreeList_Relation.CloseEditor();
        }





        #endregion

        #region 新增类型
        //主要自动得到id、parentid、isdetail、grade
        private void barButtonItem_CreateType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            g_relationType = new MyRelationType();
            TreeListNode node = this.TreeList_Relation.FocusedNode;
            this.DBOperType = "I";
            //this.addflage = "0";
            //无数据
            if (node == null)
            {
                g_relationType.RELATIONTYPE_ID = Guid.NewGuid().ToString();
                g_relationType.RELATIONTYPE_PARENTID = "";
                g_relationType.RELATIONTYPE_IFDETAIL = "F";
                g_relationType.RELATIONTYPE_GRADE = 1;
            }
            //一级节点
            if (node != null && node.ParentNode == null)
            {
                g_relationType.RELATIONTYPE_ID = Guid.NewGuid().ToString();
                g_relationType.RELATIONTYPE_PARENTID = "";
                g_relationType.RELATIONTYPE_IFDETAIL = "F";
                g_relationType.RELATIONTYPE_GRADE = 1;
            }
            //非一级节点
            if (node != null && node.ParentNode != null)
            {
                g_relationType.RELATIONTYPE_ID = Guid.NewGuid().ToString();
                g_relationType.RELATIONTYPE_PARENTID = node.GetValue("RELATIONTYPE_PARENTID").ToString();
                g_relationType.RELATIONTYPE_IFDETAIL = "F";
                g_relationType.RELATIONTYPE_GRADE = Convert.ToInt32(node.GetValue("RELATIONTYPE_GRADE"));
            }

            //状态修改
            ChangeCardState(true);
        }

        #endregion


        #region 新增下级类型
        //跟新增类型没区别，只是父节点和级数有变化
        private void barButtonItem_CreateSonType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            g_relationType = new MyRelationType();
            TreeListNode node = this.TreeList_Relation.FocusedNode;
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
                g_relationType.RELATIONTYPE_ID = Guid.NewGuid().ToString();
                g_relationType.RELATIONTYPE_PARENTID = node.GetValue("RELATIONTYPE_ID").ToString();
                g_relationType.RELATIONTYPE_IFDETAIL = "F";
                g_relationType.RELATIONTYPE_GRADE = 2;
            }
            //非一级节点
            if (node != null && node.ParentNode != null)
            {
                g_relationType.RELATIONTYPE_ID = Guid.NewGuid().ToString();
                g_relationType.RELATIONTYPE_PARENTID = node.GetValue("RELATIONTYPE_ID").ToString();
                g_relationType.RELATIONTYPE_IFDETAIL = "F";
                g_relationType.RELATIONTYPE_GRADE = Convert.ToInt32(node.GetValue("RELATIONTYPE_GRADE")) + 1;
            }

            //状态修改
            ChangeCardState(true);
        }
        #endregion

        #region 保存类型
        private void barButtonItem_SaveType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode selTreeLNode = TreeList_Relation.FocusedNode;
            g_relationType.RELATIONTYPE_CODE = this.textEdit_Code.ToString();
            g_relationType.RELATIONTYPE_NAME = this.textEdit_Name.ToString();

            if (this.DBOperType == "I")
            {
                g_relationType.RELATIONTYPE_CREATETIME = System.DateTime.Now.ToString();
                g_relationType.RELATIONTYPE_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                g_relationType.RELATIONTYPE_MODIFICATIONTIMES = "1";
                if (this.memoEdit_Note.EditValue == null)
                {
                    MessageBox.Show("请写NOTE");
                    return;
                }
                g_relationType.RELATIONTYPE_NOTE = this.memoEdit_Note.EditValue.ToString();
                this.relationTypeList.Add(g_relationType);
            }
            else if(this.DBOperType == "U")
            {
                //update的时候，不需要！！！将类型下的属性全部赋值一遍，因为只需要update修改的这些
                g_relationType.RELATIONTYPE_ID = selTreeLNode.GetValue("RELATIONTYPE_ID").ToString();
                g_relationType.RELATIONTYPE_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                g_relationType.RELATIONTYPE_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes) + 1);
                if (this.memoEdit_Note.EditValue == null)
                {
                    MessageBox.Show("请写NOTE");
                    return;
                }
                g_relationType.RELATIONTYPE_NOTE = this.memoEdit_Note.ToString();

                foreach(MyRelationType item in relationTypeList)
                {
                    if(item.RELATIONTYPE_ID == g_relationType.RELATIONTYPE_ID)
                    {
                        relationTypeList.Remove(item);
                        break;
                    }
                    this.relationTypeList.Add(g_relationType);
                }

            }
            relationClient.SaveRelationType(this.DBOperType, g_relationType);

            this.BindTree(TreeList_Relation, relationTypeList);
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

        #region 编辑关系
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
            this.Frm_RelationsList_Load(null, null);
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
            TreeListNode selTreeLNode = TreeList_Relation.FocusedNode;
            if(selTreeLNode !=null)
            {
                foreach(MyRelationType item in relationTypeList)
                {
                    if (item.RELATIONTYPE_ID == selTreeLNode.GetValue("RELATIONTYPE_ID").ToString()) item.RELATIONTYPE_IFINVALID = "T";
                }
            }
            g_relationType.RELATIONTYPE_IFINVALID = "T";
        }
        #endregion

        #region 新增关系
        private void barButtonItem_CreateInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeList_Relation.FocusedNode == null) return;
            TreeListNode node = this.TreeList_Relation.FocusedNode;
            Frm_RelationCard card = new Frm_RelationCard();
            if (node.GetValue("NodeType").ToString() == "RelationType")
            {
                card.relationInfo.RELATIONINFO_TYPEID = node.GetValue("RELATIONTYPE_ID").ToString();
            }
            else if(node.GetValue("NodeType").ToString() == "RelationInfo")
            {
                card.relationInfo.RELATIONINFO_TYPEID = node.GetValue("RELATIONTYPE_PARENTID").ToString();
            }
            card.relationInfo.RELATIONINFO_CREATETIME = DateTime.Now.ToString();
            card.relationInfo.RELATIONINFO_ID = Guid.NewGuid().ToString();
            card.relationInfo.RELATIONINFO_IFINVALID = "F";
            card.relationInfo.RELATIONINFO_LASTMODIFIEDTIME = card.relationInfo.RELATIONINFO_CREATETIME;
            card.relationInfo.RELATIONINFO_MODIFICATIONTIMES = "0";
            if(card.ShowDialog() == DialogResult.OK)
            {
                this.Frm_RelationsList_Load(null, null);
            }
        }
        #endregion

        #region 编辑关系
        private void barButtonItem_EditInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeList_Relation.FocusedNode == null) return;
            TreeListNode node = this.TreeList_Relation.FocusedNode;
            Frm_RelationCard card = new Frm_RelationCard();
            if (node.GetValue("NodeType").ToString() == "RelationType")
            {
                MessageBox.Show("选择的是关系");
            }
            else if (node.GetValue("NodeType").ToString() == "RelationInfo")
            {
                card.relationInfo.RELATIONINFO_TYPEID = node.GetValue("RELATIONTYPE_PARENTID").ToString();
            }
            card.relationInfo.RELATIONINFO_CREATETIME = node.GetValue("RELATIONTYPE_CREATETIME").ToString();
            card.relationInfo.RELATIONINFO_ID = node.GetValue("RELATIONTYPE_ID").ToString();
            card.relationInfo.RELATIONINFO_IFINVALID = node.GetValue("RELATIONTYPE_IFINVALID").ToString();
            card.relationInfo.RELATIONINFO_LASTMODIFIEDTIME = node.GetValue("RELATIONTYPE_LASTMODIFIEDTIME").ToString();
            card.relationInfo.RELATIONINFO_MODIFICATIONTIMES = node.GetValue("RELATIONTYPE_MODIFICATIONTIMES").ToString();
            if(card.ShowDialog() == DialogResult.OK)
            {
                this.Frm_RelationsList_Load(null, null);
            }
        }
        #endregion
    }
}
