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
    public partial class Frm_EventList : XtraForm
    {
        #region 变量
        private EventClient eventClient = new EventClient();
        //private PublicClass publicClass = new PublicClass();公共方法没有配置
        private List<MyEventType> eventTypeList = new List<MyEventType>();
        private string DBOperType = string.Empty; //I : insert ; U : update
        private string addflage = string.Empty; // 0 : 同级增加类型 ; 1 :下级增加类型
        MyEventType g_eventType;
        //MyEventInfo eventInfo;

        //对象id
        public string objectid = string.Empty;
        #endregion

        #region 构造函数
        public Frm_EventList()
        {
            InitializeComponent();
        }
        #endregion

        #region 表单加载
        private void Frm_EventList_Load(object sender, EventArgs e)
        {

            eventTypeList = eventClient.GetEventType();
            if (eventTypeList.Count > 0)
            {
                this.BindTree(TreeList_Event, eventTypeList);
            }

        }
        #endregion

        #region 类型及信息树的绑定方法


        /// <summary>
        /// 绑定treelist
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="eventTypeList"></param>
        private void BindTree(DevExpress.XtraTreeList.TreeList treeList, List<MyEventType> eventTypeList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            foreach (MyEventType item in eventTypeList)
            {
                //树的第一级节点，进入递归
                if (item.EVENTTYPE_GRADE == 1)
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.EVENTTYPE_ID,item.EVENTTYPE_CODE,item.EVENTTYPE_NAME,item.EVENTTYPE_PARENTID,item.EVENTTYPE_IFDETAIL,item.EVENTTYPE_GRADE,item.EVENTTYPE_IFINVALID,item.EVENTTYPE_NOTE,item.EVENTTYPE_CREATETIME,item.EVENTTYPE_LASTMODIFIEDTIME,item.EVENTTYPE_MODIFICATIONTIMES,"EventType"},null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子类型
                    LoadTypeTreeNode(treeList, node, item, eventTypeList);
                    LoadInfoTreeNode(treeList, node, item.EVENTTYPE_EVENTINFO);
                }
            }
            treeList.EndUpdate();
        }

        /// <summary>
        /// 循环绑定类型树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="eventType"></param>
        /// <param name="eventTypeList"></param>
        private void LoadTypeTreeNode(DevExpress.XtraTreeList.TreeList treeList,TreeListNode treeNode, MyEventType eventType, List<MyEventType> eventTypeList)
        {
            int grade = eventType.EVENTTYPE_GRADE;
            string parentid = eventType.EVENTTYPE_ID;
            foreach (MyEventType item in eventTypeList)
            {
                if (item.EVENTTYPE_PARENTID == parentid && item.EVENTTYPE_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.EVENTTYPE_ID, item.EVENTTYPE_CODE, item.EVENTTYPE_NAME, item.EVENTTYPE_PARENTID, item.EVENTTYPE_IFDETAIL, item.EVENTTYPE_GRADE, item.EVENTTYPE_IFINVALID,item.EVENTTYPE_NOTE, item.EVENTTYPE_CREATETIME, item.EVENTTYPE_LASTMODIFIEDTIME, item.EVENTTYPE_MODIFICATIONTIMES,"EventType" }, treeNode);
                    typeNode.StateImageIndex = 0;
                    //循环绑定子类型
                    LoadTypeTreeNode(treeList, typeNode, item, eventTypeList);
                    LoadInfoTreeNode(treeList, typeNode, item.EVENTTYPE_EVENTINFO);
                }
            }
        }

        /// <summary>
        /// 循环绑定信息树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="eventInfoList"></param>
        private void LoadInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, List<MyEventInfo> eventInfoList)
        {
            if (eventInfoList != null && eventInfoList.Count > 0)
            {
                foreach (MyEventInfo item in eventInfoList)
                {
                    //父节点ID：item类型id；是否明细：是；级数：父节点级数+1
                    int i = Convert.ToInt32(treeNode.GetValue("EVENTTYPE_GRADE")) + 1;
                    TreeListNode infoNode = treeList.AppendNode(new object[] { item.EVENTINFO_ID, item.EVENTINFO_CODE, item.EVENTINFO_NAME, item.EVENTINFO_TYPEID, "1", i,item.EVENTINFO_IFINVALID, item.EVENTINFO_NOTE, item.EVENTINFO_CREATETIME, item.EVENTINFO_LASTMODIFIEDTIME, item.EVENTINFO_MODIFICATIONTIMES, "EventInfo" }, treeNode);
                    infoNode.StateImageIndex = 1;
                }
            }
        }



        #endregion

        #region Node操作

        private void eventTreeList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (TreeList_Event.FocusedNode == null) return;


            TreeListNode selTreeLNode = TreeList_Event.FocusedNode;
            //TreeListNode selTreeLParNode = eventTreeList.FocusedNode.ParentNode;
            if (selTreeLNode != null)
            {
                this.textEdit_Code.EditValue = selTreeLNode.GetValue("EVENTTYPE_CODE");
                this.textEdit_Name.EditValue = selTreeLNode.GetValue("EVENTTYPE_NAME");
                this.textEdit_CreateTime.EditValue = selTreeLNode.GetValue("EVENTTYPE_CREATETIME");
                this.textEdit_LastModifiedTime.EditValue = selTreeLNode.GetValue("EVENTTYPE_LASTMODIFIEDTIME");
                this.textEdit_ModificationTimes.EditValue = selTreeLNode.GetValue("EVENTTYPE_MODIFICATIONTIMES");
                this.memoEdit_Note.EditValue = selTreeLNode.GetValue("EVENTTYPE_NOTE");
            }
        }

        private void eventTreeList_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            //不懂。。。。这几句是什么意思？
            TreeListNode tn = e.OldNode;
            if (tn == null) return;
            TreeList_Event.CloseEditor();
        }





        #endregion

        #region 新增类型
        //主要自动得到id、parentid、isdetail、grade
        private void barButtonItem_CreateType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            g_eventType = new MyEventType();
            TreeListNode node = this.TreeList_Event.FocusedNode;
            this.DBOperType = "I";
            //this.addflage = "0";
            //无数据
            if (node == null)
            {
                g_eventType.EVENTTYPE_ID = Guid.NewGuid().ToString();
                g_eventType.EVENTTYPE_PARENTID = "";
                g_eventType.EVENTTYPE_IFDETAIL = "F";
                g_eventType.EVENTTYPE_GRADE = 1;
            }
            //一级节点
            if (node != null && node.ParentNode == null)
            {
                g_eventType.EVENTTYPE_ID = Guid.NewGuid().ToString();
                g_eventType.EVENTTYPE_PARENTID = "";
                g_eventType.EVENTTYPE_IFDETAIL = "F";
                g_eventType.EVENTTYPE_GRADE = 1;
            }
            //非一级节点
            if (node != null && node.ParentNode != null)
            {
                g_eventType.EVENTTYPE_ID = Guid.NewGuid().ToString();
                g_eventType.EVENTTYPE_PARENTID = node.GetValue("EVENTTYPE_PARENTID").ToString();
                g_eventType.EVENTTYPE_IFDETAIL = "F";
                g_eventType.EVENTTYPE_GRADE = Convert.ToInt32(node.GetValue("EVENTTYPE_GRADE"));
            }

            //状态修改
            ChangeCardState(true);
        }

        #endregion


        #region 新增下级类型
        //跟新增类型没区别，只是父节点和级数有变化
        private void barButtonItem_CreateSonType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            g_eventType = new MyEventType();
            TreeListNode node = this.TreeList_Event.FocusedNode;
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
                g_eventType.EVENTTYPE_ID = Guid.NewGuid().ToString();
                g_eventType.EVENTTYPE_PARENTID = node.GetValue("EVENTTYPE_ID").ToString();
                g_eventType.EVENTTYPE_IFDETAIL = "F";
                g_eventType.EVENTTYPE_GRADE = 2;
            }
            //非一级节点
            if (node != null && node.ParentNode != null)
            {
                g_eventType.EVENTTYPE_ID = Guid.NewGuid().ToString();
                g_eventType.EVENTTYPE_PARENTID = node.GetValue("EVENTTYPE_ID").ToString();
                g_eventType.EVENTTYPE_IFDETAIL = "F";
                g_eventType.EVENTTYPE_GRADE = Convert.ToInt32(node.GetValue("EVENTTYPE_GRADE")) + 1;
            }

            //状态修改
            ChangeCardState(true);
        }
        #endregion

        #region 保存类型
        private void barButtonItem_SaveType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeListNode selTreeLNode = TreeList_Event.FocusedNode;
            g_eventType.EVENTTYPE_CODE = this.textEdit_Code.EditValue.ToString();
            g_eventType.EVENTTYPE_NAME = this.textEdit_Name.EditValue.ToString();

            if (this.DBOperType == "I")
            {
                g_eventType.EVENTTYPE_CREATETIME = System.DateTime.Now.ToString();
                g_eventType.EVENTTYPE_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                g_eventType.EVENTTYPE_MODIFICATIONTIMES = "1";
                if (this.memoEdit_Note.EditValue == null)
                {
                    MessageBox.Show("请写NOTE");
                    return;
                }
                g_eventType.EVENTTYPE_NOTE = this.memoEdit_Note.EditValue.ToString();
                //新增直接插入
                this.eventTypeList.Add(g_eventType);
            }
            else if(this.DBOperType == "U")
            {
                //update的时候，不需要！！！将类型下的属性全部赋值一遍，因为只需要update修改的这些
                g_eventType.EVENTTYPE_ID = selTreeLNode.GetValue("EVENTTYPE_ID").ToString();
                g_eventType.EVENTTYPE_LASTMODIFIEDTIME = System.DateTime.Now.ToString();
                g_eventType.EVENTTYPE_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);
                if (this.memoEdit_Note.EditValue == null)
                {
                    MessageBox.Show("请写NOTE");
                    return;
                }
                g_eventType.EVENTTYPE_NOTE = this.memoEdit_Note.EditValue.ToString();

                //编辑类型的时候，应该先删除再添加
                foreach (MyEventType item in eventTypeList)
                {
                    if(item.EVENTTYPE_ID == g_eventType.EVENTTYPE_ID)
                    {
                        eventTypeList.Remove(item);
                        break;
                    }
                }
                this.eventTypeList.Add(g_eventType);
            }
            //这个地方是不是需要添加判断？如果是类型那么就保存如果不是那就提示？
            eventClient.SaveEventType(this.DBOperType, g_eventType);

            //修改显示
            this.BindTree(TreeList_Event, eventTypeList);
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

        #region 编辑类型
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
            Frm_EventList_Load(null, null);
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

            TreeListNode selTreeLNode = TreeList_Event.FocusedNode;
            //TreeListNode selTreeLParNode = eventTreeList.FocusedNode.ParentNode;
            if (selTreeLNode != null)
            {
                foreach(MyEventType item in eventTypeList)
                {
                    if(item.EVENTTYPE_ID == selTreeLNode.GetValue("EVENTTYPE_ID").ToString()) item.EVENTTYPE_IFINVALID = "T";
                }
            }
        }
        #endregion

        #region 新增事件
        private void barButtonItem_CreateInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeList_Event.FocusedNode == null) return;
            TreeListNode node = this.TreeList_Event.FocusedNode;
            Frm_EventCard card = new Frm_EventCard();
            if (node.GetValue("NodeType").ToString() == "EventType")
            {
                card.eventInfo.EVENTINFO_TYPEID = node.GetValue("EVENTTYPE_ID").ToString();
            }
            else if(node.GetValue("NodeType").ToString() == "EventInfo")
            {
                card.eventInfo.EVENTINFO_TYPEID = node.GetValue("EVENTTYPE_PARENTID").ToString();
            }
            card.eventInfo.EVENTINFO_CREATETIME = DateTime.Now.ToString();
            card.eventInfo.EVENTINFO_ID = Guid.NewGuid().ToString();
            card.eventInfo.EVENTINFO_IFINVALID = "F";
            card.eventInfo.EVENTINFO_LASTMODIFIEDTIME = card.eventInfo.EVENTINFO_CREATETIME;
            card.eventInfo.EVENTINFO_MODIFICATIONTIMES = "0";
            if (card.ShowDialog() == DialogResult.OK)
            {
                //重新加载表单，事件卡片只写数
                this.Frm_EventList_Load(null, null);
            }
        }
        #endregion

        #region 编辑事件
        private void barButtonItem_EditInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeList_Event.FocusedNode == null) return;
            TreeListNode node = this.TreeList_Event.FocusedNode;
            Frm_EventCard card = new Frm_EventCard();
            if (node.GetValue("NodeType").ToString() == "EventType")
            {
                MessageBox.Show("选择的是事件");
            }
            else if (node.GetValue("NodeType").ToString() == "EventInfo")
            {
                card.eventInfo.EVENTINFO_TYPEID = node.GetValue("EVENTTYPE_PARENTID").ToString();
            }
            card.eventInfo.EVENTINFO_CREATETIME = node.GetValue("EVENTTYPE_CREATETIME").ToString();
            card.eventInfo.EVENTINFO_ID = node.GetValue("EVENTTYPE_ID").ToString();
            card.eventInfo.EVENTINFO_IFINVALID = node.GetValue("EVENTTYPE_IFINVALID").ToString();
            card.eventInfo.EVENTINFO_LASTMODIFIEDTIME = node.GetValue("EVENTTYPE_LASTMODIFIEDTIME").ToString();
            card.eventInfo.EVENTINFO_MODIFICATIONTIMES = node.GetValue("EVENTTYPE_MODIFICATIONTIMES").ToString();
            if (card.ShowDialog() == DialogResult.OK)
            {
                //重新加载表单，事件卡片只写数
                this.Frm_EventList_Load(null, null);
            }
        }
        #endregion

        #region 被其他引用
        private void barButtonItem_OK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TreeList_Event.FocusedNode == null) return;
            TreeListNode node = this.TreeList_Event.FocusedNode;
            objectid = node.GetValue("EVENTTYPE_ID").ToString();
        }
        #endregion
    }
}
