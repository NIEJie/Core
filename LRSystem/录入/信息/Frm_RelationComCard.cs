using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
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
    public partial class Frm_RelationShipComCard : XtraForm
    {
        #region 变量
        private RelationClient relationClient = new RelationClient();
        private PropertyClient propertyClient = new PropertyClient();
        //private PublicClass publicClass = new PublicClass();公共方法没有配置
        private List<MyRelationType> relationTypeList = new List<MyRelationType>();
        private List<MyPropertyType> fpropertyTypeList = new List<MyPropertyType>();
        private List<MyPropertyType> spropertyTypeList = new List<MyPropertyType>();
        private string DBOperType = string.Empty; //I : insert ; U : update
        private List<MyRelationData> relationDataList = new List<MyRelationData>();//从list里传过来的


        //选中树节点时查询数据条件
        public string lobjectId = string.Empty;//左边的是从list上传的
        public string robjectId = string.Empty;//右边的是选择的
        #endregion

        public Frm_RelationShipComCard()
        {
            InitializeComponent();
        }

        //三个list只是提供相关字段值，对象来源于上一个卡片和选择按钮，所以可以直接获取全部属性和关系挂接
        private void Frm_RelationShipComCard_Load(object sender, EventArgs e)
        {
            relationTypeList = relationClient.GetRelationType();
            fpropertyTypeList = propertyClient.GetPropertyType();
            spropertyTypeList = propertyClient.GetPropertyType();
            if (relationTypeList.Count > 0)
            {
                this.BindRelationTree(treeList_RelationList, relationTypeList);
            }
            if (fpropertyTypeList.Count > 0)
            {
                this.BindPropertyTree(treeList_FPropertyList, fpropertyTypeList);
            }
            if (spropertyTypeList.Count > 0)
            {
                this.BindPropertyTree(treeList_SPropertyList, spropertyTypeList);
            }
            this.gridControl_RelationData.DataSource = relationDataList;
        }


        #region 属性树操作

        #region 类型及信息树的绑定方法


        /// <summary>
        /// 绑定treelist
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="propertyTypeList"></param>
        private void BindPropertyTree(DevExpress.XtraTreeList.TreeList treeList, List<MyPropertyType> propertyTypeList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            foreach (MyPropertyType item in propertyTypeList)
            {
                //树的第一级节点，进入递归
                if (item.PROPERTYTYPE_IFDETAIL == "T")
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.PROPERTYTYPE_ID, item.PROPERTYTYPE_CODE, item.PROPERTYTYPE_NAME, item.PROPERTYTYPE_PARENTID, item.PROPERTYTYPE_IFDETAIL, item.PROPERTYTYPE_GRADE, item.PROPERTYTYPE_IFINVALID, item.PROPERTYTYPE_NOTE, item.PROPERTYTYPE_CREATETIME, item.PROPERTYTYPE_LASTMODIFIEDTIME, item.PROPERTYTYPE_MODIFICATIONTIMES, "PropertyType" }, null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子类型
                    LoadPropertyTypeTreeNode(treeList, node, item, propertyTypeList);
                    LoadPropertyInfoTreeNode(treeList, node, item.PROPERTYTYPE_PROPERTYINFO);
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
        private void LoadPropertyTypeTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, MyPropertyType propertyType, List<MyPropertyType> propertyTypeList)
        {
            int grade = propertyType.PROPERTYTYPE_GRADE;
            string parentid = propertyType.PROPERTYTYPE_PARENTID;
            foreach (MyPropertyType item in propertyTypeList)
            {
                if (item.PROPERTYTYPE_PARENTID == parentid && item.PROPERTYTYPE_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.PROPERTYTYPE_ID, item.PROPERTYTYPE_CODE, item.PROPERTYTYPE_NAME, item.PROPERTYTYPE_PARENTID, item.PROPERTYTYPE_IFDETAIL, item.PROPERTYTYPE_GRADE, item.PROPERTYTYPE_IFINVALID, item.PROPERTYTYPE_NOTE, item.PROPERTYTYPE_CREATETIME, item.PROPERTYTYPE_LASTMODIFIEDTIME, item.PROPERTYTYPE_MODIFICATIONTIMES, "PropertyType" }, null);
                    typeNode.StateImageIndex = 0;
                    //循环绑定子类型
                    LoadPropertyTypeTreeNode(treeList, typeNode, item, propertyTypeList);
                    LoadPropertyInfoTreeNode(treeList, typeNode, item.PROPERTYTYPE_PROPERTYINFO);
                }
            }
        }

        /// <summary>
        /// 循环绑定信息树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="propertyInfoList"></param>
        private void LoadPropertyInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, List<MyPropertyInfo> propertyInfoList)
        {
            if (propertyInfoList != null && propertyInfoList.Count > 0)
            {
                foreach (MyPropertyInfo item in propertyInfoList)
                {
                    //父节点ID：item类型id；是否明细：是；级数：父节点级数+1
                    int i = Convert.ToInt32(treeNode.GetValue("PROPERTYTYPE_GRADE")) + 1;
                    TreeListNode infoNode = treeList.AppendNode(new object[] { item.PROPERTYINFO_ID, item.PROPERTYINFO_CODE, item.PROPERTYINFO_NAME, item.PROPERTYINFO_TYPEID, "1", i, item.PROPERTYINFO_IFINVALID, item.PROPERTYINFO_NOTE, item.PROPERTYINFO_CREATETIME, item.PROPERTYINFO_LASTMODIFIEDTIME, item.PROPERTYINFO_MODIFICATIONTIMES, "PropertyInfo" }, treeNode);
                    infoNode.StateImageIndex = 1;
                }
            }
        }



        #endregion

        #endregion

        #region 关系树操作

        #region 类型及信息树的绑定方法


        /// <summary>
        /// 绑定treelist
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="relationTypeList"></param>
        private void BindRelationTree(DevExpress.XtraTreeList.TreeList treeList, List<MyRelationType> relationTypeList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            foreach (MyRelationType item in relationTypeList)
            {
                //树的第一级节点，进入递归
                if (item.RELATIONTYPE_IFDETAIL == "T")
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.RELATIONTYPE_ID, item.RELATIONTYPE_CODE, item.RELATIONTYPE_NAME, item.RELATIONTYPE_PARENTID, item.RELATIONTYPE_IFDETAIL, item.RELATIONTYPE_GRADE, item.RELATIONTYPE_IFINVALID, item.RELATIONTYPE_NOTE, item.RELATIONTYPE_CREATETIME, item.RELATIONTYPE_LASTMODIFIEDTIME, item.RELATIONTYPE_MODIFICATIONTIMES, "RelationType" }, null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子类型
                    LoadRelationTypeTreeNode(treeList, node, item, relationTypeList);
                    LoadRelationInfoTreeNode(treeList, node, item.RELATIONTYPE_RELATIONINFO);
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
        private void LoadRelationTypeTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, MyRelationType relationType, List<MyRelationType> relationTypeList)
        {
            int grade = relationType.RELATIONTYPE_GRADE;
            string parentid = relationType.RELATIONTYPE_PARENTID;
            foreach (MyRelationType item in relationTypeList)
            {
                if (item.RELATIONTYPE_PARENTID == parentid && item.RELATIONTYPE_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.RELATIONTYPE_ID, item.RELATIONTYPE_CODE, item.RELATIONTYPE_NAME, item.RELATIONTYPE_PARENTID, item.RELATIONTYPE_IFDETAIL, item.RELATIONTYPE_GRADE, item.RELATIONTYPE_IFINVALID, item.RELATIONTYPE_NOTE, item.RELATIONTYPE_CREATETIME, item.RELATIONTYPE_LASTMODIFIEDTIME, item.RELATIONTYPE_MODIFICATIONTIMES, "RelationType" }, null);
                    typeNode.StateImageIndex = 0;
                    //循环绑定子类型
                    LoadRelationTypeTreeNode(treeList, typeNode, item, relationTypeList);
                    LoadRelationInfoTreeNode(treeList, typeNode, item.RELATIONTYPE_RELATIONINFO);
                }
            }
        }

        /// <summary>
        /// 循环绑定信息树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="relationInfoList"></param>
        private void LoadRelationInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, List<MyRelationInfo> relationInfoList)
        {
            if (relationInfoList != null && relationInfoList.Count > 0)
            {
                foreach (MyRelationInfo item in relationInfoList)
                {
                    //父节点ID：item类型id；是否明细：是；级数：父节点级数+1
                    int i = Convert.ToInt32(treeNode.GetValue("RELATIONTYPE_GRADE")) + 1;
                    TreeListNode infoNode = treeList.AppendNode(new object[] { item.RELATIONINFO_ID, item.RELATIONINFO_CODE, item.RELATIONINFO_NAME, item.RELATIONINFO_TYPEID, "1", i, item.RELATIONINFO_IFINVALID, item.RELATIONINFO_NOTE, item.RELATIONINFO_CREATETIME, item.RELATIONINFO_LASTMODIFIEDTIME, item.RELATIONINFO_MODIFICATIONTIMES, "RelationInfo" }, treeNode);
                    infoNode.StateImageIndex = 1;
                }
            }
        }



        #endregion

        #endregion

        #region 选择对象
        private void barButtonItem_Event_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_EventList frm = new Frm_EventList();
            frm.ShowDialog();
            this.robjectId = frm.objectid;
        }

        private void barButtonItem_Sentence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_EventCard frm = new Frm_EventCard();
            frm.ShowDialog();
            this.robjectId = frm.objectid;
        }

        private void barButtonItem_Vocabulary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Sentence frm = new Frm_Sentence();
            frm.ShowDialog();
            this.robjectId = frm.objectid;
        }
        #endregion

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem_CreateRelation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode fpnode = treeList_FPropertyList.FocusedNode;
            TreeListNode spnode = treeList_SPropertyList.FocusedNode;
            TreeListNode rnode = treeList_RelationList.FocusedNode;

            MyRelationData relationData = new MyRelationData();
            relationData.RELATIONDATA_ID = System.Guid.NewGuid().ToString();
            relationData.RELATIONDATA_CODE = fpnode.GetValue("PROPERTYTYPE_CODE").ToString() + "-" + rnode.GetValue("RELATIONTYPE_CODE").ToString() + "-" + spnode.GetValue("PROPERTYTYPE_CODE").ToString();
            relationData.RELATIONDATA_NAME = fpnode.GetValue("PROPERTYTYPE_NAME").ToString() + "-" + rnode.GetValue("RELATIONTYPE_NAME").ToString() + "-" + spnode.GetValue("PROPERTYTYPE_NAME").ToString();
            relationData.RELATIONDATA_CREATETIME = DateTime.Now.ToString();
            relationData.RELATIONDATA_FPROPERTYID = fpnode.GetValue("PROPERTYTYPE_ID").ToString();
            relationData.RELATIONDATA_FPROPERTYNAME = fpnode.GetValue("PROPERTYTYPE_NAME").ToString();
            relationData.RELATIONDATA_FPROPERTYTYPEID = fpnode.GetValue("PROPERTYTYPE_PARENTID").ToString();
            relationData.RELATIONDATA_IFINVALID = "T";
            relationData.RELATIONDATA_LASTMODIFIEDTIME = DateTime.Now.ToString();
            relationData.RELATIONDATA_LOBJECTID = lobjectId;
            relationData.RELATIONDATA_MODIFICATIONTIMES = "0";
            relationData.RELATIONDATA_RELATIONID = rnode.GetValue("RELATIONTYPE_ID").ToString();
            relationData.RELATIONDATA_RELATIONNAME = rnode.GetValue("RELATIONTYPE_NAME").ToString();
            relationData.RELATIONDATA_RELATIONTYPEID = rnode.GetValue("RELATIONTYPE_PARENTID").ToString();
            relationData.RELATIONDATA_ROBJECTTYPEID = robjectId;
            relationData.RELATIONDATA_SPROPERTYID = spnode.GetValue("PROPERTYTYPE_ID").ToString();
            relationData.RELATIONDATA_SPROPERTYNAME = spnode.GetValue("PROPERTYTYPE_NAME").ToString();
            relationData.RELATIONDATA_SPROPERTYTYPEID = spnode.GetValue("PROPERTYTYPE_PARENTID").ToString();

            relationDataList.Add(relationData);
            this.gridControl_RelationData.DataSource = relationDataList;
            this.gridControl_RelationData.Refresh();
        }

        private void barButtonItem_EditRelation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode fpnode = treeList_FPropertyList.FocusedNode;
            TreeListNode spnode = treeList_SPropertyList.FocusedNode;
            TreeListNode rnode = treeList_RelationList.FocusedNode;
            if (this.gridView_RelationData.GetFocusedRow() == null) return;
            MyRelationData relationData = this.gridView_RelationData.GetFocusedRow() as MyRelationData;
            relationDataList.Remove(relationData);

            //relationData.RELATIONDATA_ID = System.Guid.NewGuid().ToString();
            relationData.RELATIONDATA_CODE = fpnode.GetValue("PROPERTYTYPE_CODE").ToString() + "-" + rnode.GetValue("RELATIONTYPE_CODE").ToString() + "-" + spnode.GetValue("PROPERTYTYPE_CODE").ToString();
            relationData.RELATIONDATA_NAME = fpnode.GetValue("PROPERTYTYPE_NAME").ToString() + "-" + rnode.GetValue("RELATIONTYPE_NAME").ToString() + "-" + spnode.GetValue("PROPERTYTYPE_NAME").ToString();
            //relationData.RELATIONDATA_CREATETIME = DateTime.Now.ToString();
            relationData.RELATIONDATA_FPROPERTYID = fpnode.GetValue("PROPERTYTYPE_ID").ToString();
            relationData.RELATIONDATA_FPROPERTYNAME = fpnode.GetValue("PROPERTYTYPE_NAME").ToString();
            relationData.RELATIONDATA_FPROPERTYTYPEID = fpnode.GetValue("PROPERTYTYPE_PARENTID").ToString();
            relationData.RELATIONDATA_IFINVALID = "T";
            relationData.RELATIONDATA_LASTMODIFIEDTIME = DateTime.Now.ToString();
            relationData.RELATIONDATA_LOBJECTID = lobjectId;
            relationData.RELATIONDATA_MODIFICATIONTIMES = (Convert.ToInt32(relationData.RELATIONDATA_MODIFICATIONTIMES) + 1).ToString();
            relationData.RELATIONDATA_RELATIONID = rnode.GetValue("RELATIONTYPE_ID").ToString();
            relationData.RELATIONDATA_RELATIONNAME = rnode.GetValue("RELATIONTYPE_NAME").ToString();
            relationData.RELATIONDATA_RELATIONTYPEID = rnode.GetValue("RELATIONTYPE_PARENTID").ToString();
            relationData.RELATIONDATA_ROBJECTTYPEID = robjectId;
            relationData.RELATIONDATA_SPROPERTYID = spnode.GetValue("PROPERTYTYPE_ID").ToString();
            relationData.RELATIONDATA_SPROPERTYNAME = spnode.GetValue("PROPERTYTYPE_NAME").ToString();
            relationData.RELATIONDATA_SPROPERTYTYPEID = spnode.GetValue("PROPERTYTYPE_PARENTID").ToString();

            relationDataList.Add(relationData);
            this.gridControl_RelationData.DataSource = relationDataList;
            this.gridControl_RelationData.Refresh();
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_RelationData.GetFocusedRow() == null) return;
            MyRelationData relationData = this.gridView_RelationData.GetFocusedRow() as MyRelationData;
            relationDataList.Remove(relationData);
        }

        private void barButtonItem_SaveRelation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (relationClient.SaveRelationComCard(relationDataList))
                MessageBox.Show("保存成功");
        }
    }
}
