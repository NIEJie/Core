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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRSystem
{
    public partial class MakHack : XtraForm
    {
        /*规定：
         * 全局对象变量要以g_开头
         * 局部变量要以l_开头 
         * 参数变量去除前缀
         * 特殊变量、标志变量无需遵守之上的规则
         * 
         * 信息源：：构建框架的信息
         * 数据源：：框架运作产生的数据
         * 
         * 
         * */

         //1. 当tab页切换或鼠标焦点切换页面时，判断当前页面状态，如果为U||I，就不允许切换，必须点S，才允许切换
         //2. 当前页面切换焦点时，也需要判断状态，同时不同状态行颜色不同。
         //3. 点击属性，再点击事件、句子、词汇，也要变属性data
         //4. !!!!保存需要刷新，但是也要固定焦点

        #region 构造函数
        public MakHack()
        {
            InitializeComponent();
        }

        #endregion

        #region 全局变量

        private List<MyPropertyInfo> g_LpropertyInfoList = new List<MyPropertyInfo>();//左属性信息源
        private MyPropertyInfo g_LpropertyInfo = new MyPropertyInfo();
        private List<MyPropertyInfo> g_RpropertyInfoList = new List<MyPropertyInfo>();//右属性信息源
        private MyPropertyInfo g_RpropertyInfo = new MyPropertyInfo();

        private List<MyPropertyData> g_LpropertyDataList = new List<MyPropertyData>();//左属性数据源
        private List<MyPropertyData> g_RpropertyDataList = new List<MyPropertyData>();//右属性数据源
        private MyPropertyData g_LpropertyData = new MyPropertyData();
        private MyPropertyData g_RpropertyData = new MyPropertyData();

        private List<MyRelationInfo> g_relationInfoList = new List<MyRelationInfo>();//关系信息源
        private MyRelationInfo g_relationInfo = new MyRelationInfo();

        private List<MyRelationData> g_relationDataList = new List<MyRelationData>();//关系数据源
        private MyRelationData g_relationData = new MyRelationData();

        private List<MyEventInfo> g_LeventInfoList = new List<MyEventInfo>();//左事件数据源（信息源）
        private MyEventInfo g_LeventInfo = new MyEventInfo();
        private List<MyEventInfo> g_ReventInfoList = new List<MyEventInfo>();//右事件数据源（信息源）
        private MyEventInfo g_ReventInfo = new MyEventInfo();

        private List<MySentenceInfo> g_LsenetenceInfoList = new List<MySentenceInfo>();//左句子数据源（信息源）
        private MySentenceInfo g_LsentenceInfo = new MySentenceInfo();
        private List<MySentenceInfo> g_RsenetenceInfoList = new List<MySentenceInfo>();//右句子数据源（信息源）
        private MySentenceInfo g_RsentenceInfo = new MySentenceInfo();

        private List<MyVocabularyInfo> g_LvocabularyInfoList = new List<MyVocabularyInfo>();//左词汇数据源（信息源）
        private MyVocabularyInfo g_LvocabularyInfo = new MyVocabularyInfo();
        private List<MyVocabularyInfo> g_RvocabularyInfoList = new List<MyVocabularyInfo>();//右词汇数据源（信息源）
        private MyVocabularyInfo g_RvocabularyInfo = new MyVocabularyInfo();

        #region 特殊变量

        private PropertyClient propertyClient = new PropertyClient();
        private RelationClient relationClient = new RelationClient();
        private EventClient eventClient = new EventClient();
        private SentenceClient sentenceClient = new SentenceClient();
        private VocabularyClient vocabularyClient = new VocabularyClient();

        #endregion

        #region 标志变量
        private string DBOperType = string.Empty; //I : insert ; U : update ; S : save
        private string addflage = string.Empty; // 0 : 同级增加类型 ; 1 :下级增加类型
        private string LObject = string.Empty; // 左属性对象 Levent Lsentence Lvocabulary
        private string RObject = string.Empty;  //右属性对象
        #endregion

        #endregion

        #region 表单加载

        #region load函数
        private void NIEJIE_Load(object sender, EventArgs e)
        {
            this.BindRelation();
            this.BindProperty();
            this.BindEvent();
        }

        #endregion

        #region 绑定

        //绑定关系树
        private void BindRelation()
        {
            g_relationInfoList = relationClient.GetRelationInfoList();
            if (g_relationInfoList.Count > 0)
            {
                this.BindRelationTree(treeList_RelationList, g_relationInfoList);
            }
        }

        //绑定左右属性树
        private void BindProperty()
        {
            g_LpropertyInfoList = propertyClient.GetPropertyInfoList();
            g_RpropertyInfoList = propertyClient.GetPropertyInfoList();
            if (g_LpropertyInfoList.Count > 0)
            {
                this.BindLPropertyInfoTree(treeList_LPropertyList, g_LpropertyInfoList);
                this.BindRPropertyTree(treeList_RPropertyList, g_RpropertyInfoList);
            }
        }

        //绑定事件树
        private void BindEvent()
        {
            g_LeventInfoList = eventClient.GetEventInfo();
            g_ReventInfoList = eventClient.GetEventInfo();
            if (g_LeventInfoList.Count > 0)
            {
                this.BindTreeList_Event(treeList_LEvent, g_LeventInfoList);
                this.BindTreeList_Event(treeList_REvent, g_ReventInfoList);
            }
        }

        //绑定句子
        private void BindSentence()
        {
            g_LsenetenceInfoList = eventClient.GetSentenceInfoCard(g_LeventInfo.EVENTINFO_CODE);
            this.gridControl_LSentence.DataSource = g_LsenetenceInfoList;
            g_RsenetenceInfoList = eventClient.GetSentenceInfoCard(g_ReventInfo.EVENTINFO_CODE);
            this.gridControl_RSentence.DataSource = g_RsenetenceInfoList;
        }

        //绑定词汇
        private void BindVocabulary()
        {
            g_LvocabularyInfoList = sentenceClient.GetVocabularyInfoCard(g_LsentenceInfo.SENTENCEINFO_CODE);
            this.gridControl_LVocabulary.DataSource = g_LvocabularyInfoList;
            g_RvocabularyInfoList = sentenceClient.GetVocabularyInfoCard(g_RsentenceInfo.SENTENCEINFO_CODE);
            this.gridControl_RVocabulary.DataSource = g_RvocabularyInfoList;
        }

        #endregion

        #region 绑定树细节


        #region 绑定左属性树

        /// <summary>
        /// 绑定treelist
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="propertyInfoList"></param>
        private void BindLPropertyInfoTree(DevExpress.XtraTreeList.TreeList treeList, List<MyPropertyInfo> propertyInfoList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            
            foreach (MyPropertyInfo item in propertyInfoList)
            {
                //树的第一级节点，进入递归
                if (item.PROPERTYINFO_GRADE == 1)
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.PROPERTYINFO_ID, item.PROPERTYINFO_CODE, item.PROPERTYINFO_NAME, item.PROPERTYINFO_PARENTID, item.PROPERTYINFO_IFDETAIL, item.PROPERTYINFO_GRADE, item.PROPERTYINFO_IFINVALID, item.PROPERTYINFO_NOTE, item.PROPERTYINFO_CREATETIME, item.PROPERTYINFO_LASTMODIFIEDTIME, item.PROPERTYINFO_MODIFICATIONTIMES }, null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子属性
                    LoadLPropertyInfoTreeNode(treeList, node, item, propertyInfoList);
                }
            }
            treeList.EndUpdate();
        }

        /// <summary>
        /// 循环绑定子属性
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="propertyInfo"></param>
        /// <param name="propertyInfoList"></param>
        private void LoadLPropertyInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, MyPropertyInfo propertyInfo, List<MyPropertyInfo> propertyInfoList)
        {
            int grade = propertyInfo.PROPERTYINFO_GRADE;
            string parentid = propertyInfo.PROPERTYINFO_PARENTID;
            foreach (MyPropertyInfo item in propertyInfoList)
            {
                if (item.PROPERTYINFO_PARENTID == parentid && item.PROPERTYINFO_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.PROPERTYINFO_ID, item.PROPERTYINFO_CODE, item.PROPERTYINFO_NAME, item.PROPERTYINFO_PARENTID, item.PROPERTYINFO_IFDETAIL, item.PROPERTYINFO_GRADE, item.PROPERTYINFO_IFINVALID, item.PROPERTYINFO_NOTE, item.PROPERTYINFO_CREATETIME, item.PROPERTYINFO_LASTMODIFIEDTIME, item.PROPERTYINFO_MODIFICATIONTIMES }, treeNode);
                    typeNode.StateImageIndex = 0;
                    //递归绑定子属性
                    LoadLPropertyInfoTreeNode(treeList, typeNode, item, propertyInfoList);
                }
            }
        }

        #endregion

        #region 绑定关系树

        /// <summary>
        /// 绑定关系树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="relationTypeList"></param>
        private void BindRelationTree(DevExpress.XtraTreeList.TreeList treeList, List<MyRelationInfo> relationInfoList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            foreach (MyRelationInfo item in relationInfoList)
            {
                //树的第一级节点，进入递归
                if (item.RELATIONINFO_GRADE == 1)
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.RELATIONINFO_ID, item.RELATIONINFO_CODE, item.RELATIONINFO_NAME, item.RELATIONINFO_PARENTID, item.RELATIONINFO_IFDETAIL, item.RELATIONINFO_GRADE, item.RELATIONINFO_IFINVALID, item.RELATIONINFO_NOTE, item.RELATIONINFO_CREATETIME, item.RELATIONINFO_LASTMODIFIEDTIME, item.RELATIONINFO_MODIFICATIONTIMES }, null);
                    node.StateImageIndex = 0;//关系的图片
                    //绑定子关系
                    LoadRelationTreeNode(treeList, node, item, relationInfoList);
                }
            }
            treeList.EndUpdate();
        }

        /// <summary>
        /// 递归绑定关系树
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="relationType"></param>
        /// <param name="relationTypeList"></param>
        private void LoadRelationTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, MyRelationInfo relationInfo, List<MyRelationInfo> relationInfoList)
        {
            int grade = relationInfo.RELATIONINFO_GRADE;
            string parentid = relationInfo.RELATIONINFO_PARENTID;
            foreach (MyRelationInfo item in relationInfoList)
            {
                if (item.RELATIONINFO_PARENTID == parentid && item.RELATIONINFO_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.RELATIONINFO_ID, item.RELATIONINFO_CODE, item.RELATIONINFO_NAME, item.RELATIONINFO_PARENTID, item.RELATIONINFO_IFDETAIL, item.RELATIONINFO_GRADE, item.RELATIONINFO_IFINVALID, item.RELATIONINFO_NOTE, item.RELATIONINFO_CREATETIME, item.RELATIONINFO_LASTMODIFIEDTIME, item.RELATIONINFO_MODIFICATIONTIMES }, treeNode);
                    typeNode.StateImageIndex = 0;
                    // 递归绑定关系树
                    LoadRelationTreeNode(treeList, typeNode, item, relationInfoList);
                }
            }
        }

        #endregion

        #region 绑定右属性树

        /// <summary>
        /// 绑定treelist
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="propertyInfoList"></param>
        private void BindRPropertyTree(DevExpress.XtraTreeList.TreeList treeList, List<MyPropertyInfo> propertyInfoList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();

            foreach (MyPropertyInfo item in propertyInfoList)
            {
                //树的第一级节点，进入递归
                if (item.PROPERTYINFO_GRADE == 1)
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.PROPERTYINFO_ID, item.PROPERTYINFO_CODE, item.PROPERTYINFO_NAME, item.PROPERTYINFO_PARENTID, item.PROPERTYINFO_IFDETAIL, item.PROPERTYINFO_GRADE, item.PROPERTYINFO_IFINVALID, item.PROPERTYINFO_NOTE, item.PROPERTYINFO_CREATETIME, item.PROPERTYINFO_LASTMODIFIEDTIME, item.PROPERTYINFO_MODIFICATIONTIMES }, null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子属性
                    LoadRPropertyInfoTreeNode(treeList, node, item, propertyInfoList);
                }
            }
            treeList.EndUpdate();
        }

        /// <summary>
        /// 循环绑定子属性
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="propertyInfo"></param>
        /// <param name="propertyInfoList"></param>
        private void LoadRPropertyInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, MyPropertyInfo propertyInfo, List<MyPropertyInfo> propertyInfoList)
        {
            int grade = propertyInfo.PROPERTYINFO_GRADE;
            string parentid = propertyInfo.PROPERTYINFO_PARENTID;
            foreach (MyPropertyInfo item in propertyInfoList)
            {
                if (item.PROPERTYINFO_PARENTID == parentid && item.PROPERTYINFO_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.PROPERTYINFO_ID, item.PROPERTYINFO_CODE, item.PROPERTYINFO_NAME, item.PROPERTYINFO_PARENTID, item.PROPERTYINFO_IFDETAIL, item.PROPERTYINFO_GRADE, item.PROPERTYINFO_IFINVALID, item.PROPERTYINFO_NOTE, item.PROPERTYINFO_CREATETIME, item.PROPERTYINFO_LASTMODIFIEDTIME, item.PROPERTYINFO_MODIFICATIONTIMES }, treeNode);
                    typeNode.StateImageIndex = 0;
                    //递归绑定子属性
                    LoadRPropertyInfoTreeNode(treeList, typeNode, item, propertyInfoList);
                }
            }
        }

        #endregion

        #region 绑定事件tab页

        /// <summary>
        /// 绑定事件
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="eventInfoList"></param>
        private void BindTreeList_Event(DevExpress.XtraTreeList.TreeList treeList, List<MyEventInfo> eventInfoList)
        {
            treeList.OptionsBehavior.Editable = false;
            treeList.BeginUpdate();
            treeList.Nodes.Clear();
            foreach (MyEventInfo item in eventInfoList)
            {
                //树的第一级节点，进入递归
                if (item.EVENTINFO_GRADE == 1)
                {
                    TreeListNode node = treeList.AppendNode(new object[] { item.EVENTINFO_ID, item.EVENTINFO_CODE, item.EVENTINFO_NAME, item.EVENTINFO_PARENTID, item.EVENTINFO_IFDETAIL, item.EVENTINFO_GRADE, item.EVENTINFO_IFINVALID, item.EVENTINFO_NOTE, item.EVENTINFO_CREATETIME, item.EVENTINFO_LASTMODIFIEDTIME, item.EVENTINFO_MODIFICATIONTIMES }, null);
                    node.StateImageIndex = 0;//类型的图片
                    //绑定子事件
                    LoadEventInfoTreeNode(treeList, node, item, eventInfoList);
                }
            }
            treeList.EndUpdate();
        }

        /// <summary>
        /// 递归绑定事件
        /// </summary>
        /// <param name="treeList"></param>
        /// <param name="treeNode"></param>
        /// <param name="eventInfo"></param>
        /// <param name="eventInfoList"></param>
        private void LoadEventInfoTreeNode(DevExpress.XtraTreeList.TreeList treeList, TreeListNode treeNode, MyEventInfo eventInfo, List<MyEventInfo> eventInfoList)
        {
            int grade = eventInfo.EVENTINFO_GRADE;
            string parentid = eventInfo.EVENTINFO_ID;
            foreach (MyEventInfo item in eventInfoList)
            {
                if (item.EVENTINFO_PARENTID == parentid && item.EVENTINFO_GRADE - grade == 1)
                {
                    TreeListNode typeNode = treeList.AppendNode(new Object[] { item.EVENTINFO_ID, item.EVENTINFO_CODE, item.EVENTINFO_NAME, item.EVENTINFO_PARENTID, item.EVENTINFO_IFDETAIL, item.EVENTINFO_GRADE, item.EVENTINFO_IFINVALID, item.EVENTINFO_NOTE, item.EVENTINFO_CREATETIME, item.EVENTINFO_LASTMODIFIEDTIME, item.EVENTINFO_MODIFICATIONTIMES }, treeNode);
                    typeNode.StateImageIndex = 0;
                    //递归绑定子事件
                    LoadEventInfoTreeNode(treeList, typeNode, item, eventInfoList);
                }
            }
        }

        #endregion

        #endregion

        #endregion



        #region 导出
        private void btn_Export_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "导出Excel";
            fileDialog.Filter = "Excel文件(*.xls)|*.xls";
            fileDialog.FileName = "多项目策划管理" + System.DateTime.Now.ToString("yyyyMMddhhmmss");
            DialogResult dialogResult = fileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                //gridControl.ExportToXls(fileDialog.FileName);
                XtraMessageBox.Show("多项目策划管理导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 写日志
        public static void WriteLogs(string LogMsg)
        {
            System.IO.StreamWriter writer = null;
            string sCurDate = System.DateTime.Now.ToString("yyyy-MM-dd");
            string sFile = sCurDate + "Logs.txt";
            string sFileDir = "C:\\JGHYB_YSKZ\\Server";
            sFile = sFileDir + "\\" + sFile;
            try
            {
                if (!System.IO.Directory.Exists(sFileDir))
                    System.IO.Directory.CreateDirectory(sFileDir);

                if (System.IO.File.Exists(sFile))
                    writer = new System.IO.StreamWriter(sFile, true, System.Text.Encoding.GetEncoding("gb2312"));
                else
                    writer = new System.IO.StreamWriter(sFile, false, System.Text.Encoding.GetEncoding("gb2312"));
                string sDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                writer.WriteLine(sDateTime + " " + LogMsg);
                writer.WriteLine("");
            }
            catch (System.IO.IOException e)
            {
                throw e;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        #endregion

        #region 焦点事件

        //左属性树
        private void treeList_LPropertyList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //左属性节点获取
            g_LpropertyInfo.PROPERTYINFO_CODE = e.Node.GetValue("PROPERTYINFO_CODE").ToString();
            g_LpropertyInfo.PROPERTYINFO_CREATETIME = e.Node.GetValue("PROPERTYINFO_CREATETIME").ToString();
            g_LpropertyInfo.PROPERTYINFO_GRADE = Convert.ToInt32(e.Node.GetValue("PROPERTYINFO_GRADE"));
            g_LpropertyInfo.PROPERTYINFO_ID = e.Node.GetValue("PROPERTYINFO_ID").ToString();
            g_LpropertyInfo.PROPERTYINFO_IFDETAIL = e.Node.GetValue("PROPERTYINFO_IFDETAIL").ToString();
            g_LpropertyInfo.PROPERTYINFO_IFINVALID = e.Node.GetValue("PROPERTYINFO_IFINVALID").ToString();
            g_LpropertyInfo.PROPERTYINFO_LASTMODIFIEDTIME = e.Node.GetValue("PROPERTYINFO_LASTMODIFIEDTIME").ToString();
            g_LpropertyInfo.PROPERTYINFO_MODIFICATIONTIMES = e.Node.GetValue("PROPERTYINFO_MODIFICATIONTIMES").ToString();
            g_LpropertyInfo.PROPERTYINFO_NAME = e.Node.GetValue("PROPERTYINFO_NAME").ToString();
            g_LpropertyInfo.PROPERTYINFO_NOTE = e.Node.GetValue("PROPERTYINFO_NOTE").ToString();
            g_LpropertyInfo.PROPERTYINFO_PARENTID = e.Node.GetValue("PROPERTYINFO_PARENTID").ToString();

            this.memoEdit_Info.Text = g_LpropertyInfo.PROPERTYINFO_NOTE;
            this.memoEdit_InfoName.Text = g_LpropertyInfo.PROPERTYINFO_NAME;

            if (LObject == "Levent")
            {
                //获取左事件属性信息 通过object过滤list
                //this.g_LpropertyData = this.g_LpropertyDataList
                this.memoEdit_Data.Text = this.g_LpropertyData.PROPERTYDATA_NOTE;
                this.memoEdit_Data.Text = this.g_LpropertyData.PROPERTYDATA_NAME;
            }
            else if(LObject == "Lsentence")
            {
                //获取左句子属性信息 通过object过滤list
                //this.g_LpropertyData = this.g_LpropertyDataList
                this.memoEdit_Data.Text = this.g_LpropertyData.PROPERTYDATA_NOTE;
                this.memoEdit_Data.Text = this.g_LpropertyData.PROPERTYDATA_NAME;
            }
            else if(LObject == "Lvocabulary")
            {
                //获取左词汇属性信息 通过object过滤list
                //this.g_LpropertyData = this.g_LpropertyDataList
                this.memoEdit_Data.Text = this.g_LpropertyData.PROPERTYDATA_NOTE;
                this.memoEdit_Data.Text = this.g_LpropertyData.PROPERTYDATA_NAME;
            }
            else
            {
                MessageBox.Show("请选择对象");
                return;
            }
        }

        //右属性树
        private void treeList_RPropertyList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //右属性节点获取
            g_RpropertyInfo.PROPERTYINFO_CODE = e.Node.GetValue("PROPERTYINFO_CODE").ToString();
            g_RpropertyInfo.PROPERTYINFO_CREATETIME = e.Node.GetValue("PROPERTYINFO_CREATETIME").ToString();
            g_RpropertyInfo.PROPERTYINFO_GRADE = Convert.ToInt32(e.Node.GetValue("PROPERTYINFO_GRADE"));
            g_RpropertyInfo.PROPERTYINFO_ID = e.Node.GetValue("PROPERTYINFO_ID").ToString();
            g_RpropertyInfo.PROPERTYINFO_IFDETAIL = e.Node.GetValue("PROPERTYINFO_IFDETAIL").ToString();
            g_RpropertyInfo.PROPERTYINFO_IFINVALID = e.Node.GetValue("PROPERTYINFO_IFINVALID").ToString();
            g_RpropertyInfo.PROPERTYINFO_LASTMODIFIEDTIME = e.Node.GetValue("PROPERTYINFO_LASTMODIFIEDTIME").ToString();
            g_RpropertyInfo.PROPERTYINFO_MODIFICATIONTIMES = e.Node.GetValue("PROPERTYINFO_MODIFICATIONTIMES").ToString();
            g_RpropertyInfo.PROPERTYINFO_NAME = e.Node.GetValue("PROPERTYINFO_NAME").ToString();
            g_RpropertyInfo.PROPERTYINFO_NOTE = e.Node.GetValue("PROPERTYINFO_NOTE").ToString();
            g_RpropertyInfo.PROPERTYINFO_PARENTID = e.Node.GetValue("PROPERTYINFO_PARENTID").ToString();

            this.memoEdit_Info.Text = g_RpropertyInfo.PROPERTYINFO_NOTE;
            this.memoEdit_InfoName.Text = g_RpropertyInfo.PROPERTYINFO_NAME;

            if (RObject == "Revent")
            {
                //获取左事件属性信息 通过object过滤list
                //this.g_RpropertyData = this.g_RpropertyDataList
                this.memoEdit_Data.Text = this.g_RpropertyData.PROPERTYDATA_NOTE;
                this.memoEdit_Data.Text = this.g_RpropertyData.PROPERTYDATA_NAME;
            }
            else if (RObject == "Rsentence")
            {
                //获取左句子属性信息 通过object过滤list
                //this.g_RpropertyData = this.g_RpropertyDataList
                this.memoEdit_Data.Text = this.g_RpropertyData.PROPERTYDATA_NOTE;
                this.memoEdit_Data.Text = this.g_RpropertyData.PROPERTYDATA_NAME;
            }
            else if (RObject == "Rvocabulary")
            {
                //获取左词汇属性信息 通过object过滤list
                //this.g_RpropertyData = this.g_RpropertyDataList
                this.memoEdit_Data.Text = this.g_RpropertyData.PROPERTYDATA_NOTE;
                this.memoEdit_Data.Text = this.g_RpropertyData.PROPERTYDATA_NAME;
            }
            else
            {
                MessageBox.Show("请选择对象");
                return;
            }
        }


        //关系树
        private void treeList_RelationList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //关系属性节点获取
            g_relationInfo.RELATIONINFO_CODE = e.Node.GetValue("RELATIONINFO_CODE").ToString();
            g_relationInfo.RELATIONINFO_CREATETIME = e.Node.GetValue("RELATIONINFO_CREATETIME").ToString();
            g_relationInfo.RELATIONINFO_GRADE = Convert.ToInt32(e.Node.GetValue("RELATIONINFO_GRADE"));
            g_relationInfo.RELATIONINFO_ID = e.Node.GetValue("RELATIONINFO_ID").ToString();
            g_relationInfo.RELATIONINFO_IFDETAIL = e.Node.GetValue("RELATIONINFO_IFDETAIL").ToString();
            g_relationInfo.RELATIONINFO_IFINVALID = e.Node.GetValue("RELATIONINFO_IFINVALID").ToString();
            g_relationInfo.RELATIONINFO_LASTMODIFIEDTIME = e.Node.GetValue("RELATIONINFO_LASTMODIFIEDTIME").ToString();
            g_relationInfo.RELATIONINFO_MODIFICATIONTIMES = e.Node.GetValue("RELATIONINFO_MODIFICATIONTIMES").ToString();
            g_relationInfo.RELATIONINFO_NAME = e.Node.GetValue("RELATIONINFO_NAME").ToString();
            g_relationInfo.RELATIONINFO_NOTE = e.Node.GetValue("RELATIONINFO_NOTE").ToString();
            g_relationInfo.RELATIONINFO_PARENTID = e.Node.GetValue("RELATIONINFO_PARENTID").ToString();

            this.memoEdit_Info.Text = g_relationInfo.RELATIONINFO_NOTE;
            this.memoEdit_InfoName.Text = g_relationInfo.RELATIONINFO_NAME;

            //注意：：：当没有属性或者对像时，可以直接显示全部！
            //if(g_LpropertyData != null && g_RpropertyData != null)
            //{
            //    //获取关系树信息
            //    //this.g_relationDataList = 
            //    this.gridControl_RelationDataList.DataSource = this.g_relationDataList;

            //}
        }


        //左事件树
        private void treeList_LEvent_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //左事件节点获取
            g_LeventInfo.EVENTINFO_CODE = e.Node.GetValue("EVENTTYPE_ID").ToString();
            g_LeventInfo.EVENTINFO_CREATETIME = e.Node.GetValue("EVENTINFO_CREATETIME").ToString();
            g_LeventInfo.EVENTINFO_GRADE = Convert.ToInt32(e.Node.GetValue("EVENTINFO_GRADE"));
            g_LeventInfo.EVENTINFO_ID = e.Node.GetValue("EVENTINFO_ID").ToString();
            g_LeventInfo.EVENTINFO_IFDETAIL = e.Node.GetValue("EVENTINFO_IFDETAIL").ToString();
            g_LeventInfo.EVENTINFO_IFINVALID = e.Node.GetValue("EVENTINFO_IFINVALID").ToString();
            g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME = e.Node.GetValue("EVENTINFO_LASTMODIFIEDTIME").ToString();
            g_LeventInfo.EVENTINFO_MODIFICATIONTIMES = e.Node.GetValue("EVENTINFO_MODIFICATIONTIMES").ToString();
            g_LeventInfo.EVENTINFO_NAME = e.Node.GetValue("EVENTINFO_NAME").ToString();
            g_LeventInfo.EVENTINFO_NOTE = e.Node.GetValue("EVENTINFO_NOTE").ToString();
            g_LeventInfo.EVENTINFO_PARENTID = e.Node.GetValue("EVENTINFO_PARENTID").ToString();

            this.memoEdit_Info.Text = g_LeventInfo.EVENTINFO_NOTE;
            this.memoEdit_InfoName.Text = g_LeventInfo.EVENTINFO_NAME;

            this.LObject = "Levent";
        }

        //右事件节点获取
        private void treeList_REvent_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //右事件节点获取
            g_ReventInfo.EVENTINFO_CODE = e.Node.GetValue("EVENTTYPE_ID").ToString();
            g_ReventInfo.EVENTINFO_CREATETIME = e.Node.GetValue("EVENTINFO_CREATETIME").ToString();
            g_ReventInfo.EVENTINFO_GRADE = Convert.ToInt32(e.Node.GetValue("EVENTINFO_GRADE"));
            g_ReventInfo.EVENTINFO_ID = e.Node.GetValue("EVENTINFO_ID").ToString();
            g_ReventInfo.EVENTINFO_IFDETAIL = e.Node.GetValue("EVENTINFO_IFDETAIL").ToString();
            g_ReventInfo.EVENTINFO_IFINVALID = e.Node.GetValue("EVENTINFO_IFINVALID").ToString();
            g_ReventInfo.EVENTINFO_LASTMODIFIEDTIME = e.Node.GetValue("EVENTINFO_LASTMODIFIEDTIME").ToString();
            g_ReventInfo.EVENTINFO_MODIFICATIONTIMES = e.Node.GetValue("EVENTINFO_MODIFICATIONTIMES").ToString();
            g_ReventInfo.EVENTINFO_NAME = e.Node.GetValue("EVENTINFO_NAME").ToString();
            g_ReventInfo.EVENTINFO_NOTE = e.Node.GetValue("EVENTINFO_NOTE").ToString();
            g_ReventInfo.EVENTINFO_PARENTID = e.Node.GetValue("EVENTINFO_PARENTID").ToString();

            this.memoEdit_Info.Text = g_ReventInfo.EVENTINFO_NOTE;
            this.memoEdit_InfoName.Text = g_ReventInfo.EVENTINFO_NAME;

            this.RObject = "Revent";
        }

        //左句子节点获取
        private void gridControl_LSentence_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            //左句子节点获取
            g_LsentenceInfo = this.gridView_LSentence.GetRow(this.gridView_LSentence.FocusedRowHandle) as MySentenceInfo;

            this.memoEdit_Info.Text = g_LsentenceInfo.SENTENCEINFO_NOTE;
            this.memoEdit_InfoName.Text = g_LsentenceInfo.SENTENCEINFO_NAME;

            this.LObject = "Lsentence";
        }

        //右句子节点获取
        private void gridControl_RSentence_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            //右句子节点获取
            g_RsentenceInfo = this.gridView_RSentence.GetRow(this.gridView_RSentence.FocusedRowHandle) as MySentenceInfo;

            this.memoEdit_Info.Text = g_RsentenceInfo.SENTENCEINFO_NOTE;
            this.memoEdit_InfoName.Text = g_RsentenceInfo.SENTENCEINFO_NAME;

            this.RObject = "Rsentence";
        }

        //左词汇节点获取
        private void gridControl_LVocabulary_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            //左词汇节点获取
            g_LvocabularyInfo = this.gridView_LVocabulary.GetRow(this.gridView_LVocabulary.FocusedRowHandle) as MyVocabularyInfo;

            this.memoEdit_Info.Text = g_LvocabularyInfo.VOCABULARYINFO_NOTE;
            this.memoEdit_InfoName.Text = g_LvocabularyInfo.VOCABULARYINFO_NAME;

            this.LObject = "Lvocabulary";
        }

        //右词汇节点获取
        private void gridControl_RVocabulary_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            //左词汇节点获取
            g_RvocabularyInfo = this.gridView_RVocabulary.GetRow(this.gridView_RVocabulary.FocusedRowHandle) as MyVocabularyInfo;

            this.memoEdit_Info.Text = g_RvocabularyInfo.VOCABULARYINFO_NOTE;
            this.memoEdit_InfoName.Text = g_RvocabularyInfo.VOCABULARYINFO_NAME;

            this.RObject = "Rvocabulary";
        }

        //关系数据获取
        private void gridControl_RelationDataList_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            //关系数据获取
            g_relationData = this.gridView_RelationDataList.GetRow(this.gridView_LVocabulary.FocusedRowHandle) as MyRelationData;


            this.memoEdit_Data.Text = g_relationData.RELATIONDATA_NOTE;
            this.memoEdit_DataName.Text = g_relationData.RELATIONDATA_NAME;

            //获取对应关系树节点，并赋值给info
            this.memoEdit_Info.Text = g_relationInfo.RELATIONINFO_NOTE;
            this.memoEdit_InfoName.Text = g_relationInfo.RELATIONINFO_NAME;
        }




        #endregion

        #region 按钮事件

        #endregion

        #region 左事件新增按钮
        private void barButtonItem_CreateLEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList_LEvent.OptionsBehavior.Editable = false;
            treeList_LEvent.BeginUpdate();
            if (this.treeList_LEvent.FocusedNode == null)
            {
                if (treeList_LEvent.Nodes.Count > 0)
                {
                    MessageBox.Show("请选择父节点");
                    return;
                }

                //左事件节点获取
                g_LeventInfo.EVENTINFO_CODE = DateTime.Now.ToString("yyyyMMdd") + "0001";
                g_LeventInfo.EVENTINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
                g_LeventInfo.EVENTINFO_GRADE = 1;
                g_LeventInfo.EVENTINFO_ID = System.Guid.NewGuid().ToString();
                g_LeventInfo.EVENTINFO_IFDETAIL = "1";
                g_LeventInfo.EVENTINFO_IFINVALID = "F";
                g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME = "";
                g_LeventInfo.EVENTINFO_MODIFICATIONTIMES = "0";
                g_LeventInfo.EVENTINFO_NAME = "新增" + g_LeventInfo.EVENTINFO_CODE;
                g_LeventInfo.EVENTINFO_NOTE = "新增" + g_LeventInfo.EVENTINFO_CODE;
                g_LeventInfo.EVENTINFO_PARENTID = "";

                TreeListNode node = treeList_LEvent.AppendNode(new object[] { g_LeventInfo.EVENTINFO_ID, g_LeventInfo.EVENTINFO_CODE, g_LeventInfo.EVENTINFO_NAME, g_LeventInfo.EVENTINFO_PARENTID, g_LeventInfo.EVENTINFO_IFDETAIL, g_LeventInfo.EVENTINFO_GRADE, g_LeventInfo.EVENTINFO_IFINVALID, g_LeventInfo.EVENTINFO_NOTE, g_LeventInfo.EVENTINFO_CREATETIME, g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME, g_LeventInfo.EVENTINFO_MODIFICATIONTIMES }, null);

                g_LeventInfoList.Add(g_LeventInfo);
            }
            else
            {
                TreeListNode L_LeventInfo = this.treeList_LEvent.FocusedNode;

                List<string> strlist = new List<string>();
                foreach (TreeListNode item in treeList_LEvent.Nodes)
                {
                    if (item.GetValue("EVENTINFO_CODE").ToString().Contains(DateTime.Now.ToString("yyyyMMdd"))) strlist.Add(item.GetValue("EVENTINFO_CODE").ToString());
                }

                if (strlist.Count > 0)
                {
                    g_LeventInfo.EVENTINFO_CODE = (Convert.ToInt32(strlist.Max()) + 1).ToString();
                }
                else
                {
                    g_LeventInfo.EVENTINFO_CODE = DateTime.Now.ToString("yyyyMMdd") + "0001";
                }
                
                g_LeventInfo.EVENTINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
                g_LeventInfo.EVENTINFO_GRADE = Convert.ToInt32(L_LeventInfo.GetValue("EVENTINFO_GRADE"));
                g_LeventInfo.EVENTINFO_ID = System.Guid.NewGuid().ToString();
                g_LeventInfo.EVENTINFO_IFDETAIL = "1";
                g_LeventInfo.EVENTINFO_IFINVALID = "F";
                g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME = "";
                g_LeventInfo.EVENTINFO_MODIFICATIONTIMES = "0";
                g_LeventInfo.EVENTINFO_NAME = "新增" + g_LeventInfo.EVENTINFO_CODE;
                g_LeventInfo.EVENTINFO_NOTE = "新增" + g_LeventInfo.EVENTINFO_CODE;
                g_LeventInfo.EVENTINFO_PARENTID = L_LeventInfo.GetValue("EVENTINFO_PARENTID").ToString();

                this.memoEdit_Info.Text = g_LeventInfo.EVENTINFO_NOTE;
                this.memoEdit_InfoName.Text = g_LeventInfo.EVENTINFO_NAME;

                TreeListNode parnode = L_LeventInfo.ParentNode;
                TreeListNode node = treeList_LEvent.AppendNode(new object[] { g_LeventInfo.EVENTINFO_ID, g_LeventInfo.EVENTINFO_CODE, g_LeventInfo.EVENTINFO_NAME, g_LeventInfo.EVENTINFO_PARENTID, g_LeventInfo.EVENTINFO_IFDETAIL, g_LeventInfo.EVENTINFO_GRADE, g_LeventInfo.EVENTINFO_IFINVALID, g_LeventInfo.EVENTINFO_NOTE, g_LeventInfo.EVENTINFO_CREATETIME, g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME, g_LeventInfo.EVENTINFO_MODIFICATIONTIMES }, parnode);

                g_LeventInfoList.Add(g_LeventInfo);
            }
            
            treeList_LEvent.EndUpdate();

            this.LObject = "Levent";
            this.DBOperType = "I";

        }


        #endregion

        #region 左事件新增下级按钮
        private void barButtonItem_CreateSonLEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList_LEvent.OptionsBehavior.Editable = false;
            treeList_LEvent.BeginUpdate();
            if (this.treeList_LEvent.FocusedNode == null)
            {
                MessageBox.Show("请选择父节点");
                return;
            }
            else
            {
                TreeListNode L_LeventInfo = this.treeList_LEvent.FocusedNode;

                List<string> strlist = new List<string>();
                foreach (TreeListNode item in treeList_LEvent.Nodes)
                {
                    if (item.GetValue("EVENTINFO_CODE").ToString().Contains(DateTime.Now.ToString("yyyyMMdd"))) strlist.Add(item.GetValue("EVENTINFO_CODE").ToString());
                }

                if (strlist.Count > 0)
                {
                    g_LeventInfo.EVENTINFO_CODE = (Convert.ToInt32(strlist.Max()) + 1).ToString();
                }
                else
                {
                    g_LeventInfo.EVENTINFO_CODE = DateTime.Now.ToString("yyyyMMdd") + "0001";
                }

                g_LeventInfo.EVENTINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
                g_LeventInfo.EVENTINFO_GRADE = Convert.ToInt32(L_LeventInfo.GetValue("EVENTINFO_GRADE")) + 1;
                g_LeventInfo.EVENTINFO_ID = System.Guid.NewGuid().ToString();
                g_LeventInfo.EVENTINFO_IFDETAIL = "1";
                g_LeventInfo.EVENTINFO_IFINVALID = "F";
                g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME = "";
                g_LeventInfo.EVENTINFO_MODIFICATIONTIMES = "0";
                g_LeventInfo.EVENTINFO_NAME = "新增" + g_LeventInfo.EVENTINFO_CODE;
                g_LeventInfo.EVENTINFO_NOTE = "新增" + g_LeventInfo.EVENTINFO_CODE;
                g_LeventInfo.EVENTINFO_PARENTID = L_LeventInfo.GetValue("EVENTINFO_ID").ToString();

                this.memoEdit_Info.Text = g_LeventInfo.EVENTINFO_NOTE;
                this.memoEdit_InfoName.Text = g_LeventInfo.EVENTINFO_NAME;

                TreeListNode parnode = L_LeventInfo.ParentNode;
                TreeListNode node = treeList_LEvent.AppendNode(new object[] { g_LeventInfo.EVENTINFO_ID, g_LeventInfo.EVENTINFO_CODE, g_LeventInfo.EVENTINFO_NAME, g_LeventInfo.EVENTINFO_PARENTID, g_LeventInfo.EVENTINFO_IFDETAIL, g_LeventInfo.EVENTINFO_GRADE, g_LeventInfo.EVENTINFO_IFINVALID, g_LeventInfo.EVENTINFO_NOTE, g_LeventInfo.EVENTINFO_CREATETIME, g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME, g_LeventInfo.EVENTINFO_MODIFICATIONTIMES }, parnode);

                g_LeventInfoList.Add(g_LeventInfo);
            }

            treeList_LEvent.EndUpdate();

            this.LObject = "Levent";
            this.DBOperType = "I";
        }
        #endregion

        #region 左事件编辑按钮
        private void barButtonItem_EditLEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList_LEvent.FocusedNode == null) return;
            TreeListNode node = this.treeList_LEvent.FocusedNode;

            this.memoEdit_Info.Text = g_LpropertyInfo.PROPERTYINFO_NOTE;
            this.memoEdit_InfoName.Text = g_LpropertyInfo.PROPERTYINFO_NAME;

            g_LeventInfo.EVENTINFO_LASTMODIFIEDTIME = DateTime.Now.ToString("yyyyMMdd");
            g_LeventInfo.EVENTINFO_MODIFICATIONTIMES = (Convert.ToInt32(node.GetValue("EVENTTYPE_MODIFICATIONTIMES")) + 1).ToString();

            this.LObject = "Levent";
            this.DBOperType = "U";
        }
        #endregion

        #region 左事件保存按钮
        private void barButtonItem_SaveLEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList_LEvent.FocusedNode == null) return;

            if (this.DBOperType == "I")
            {
                //新增
            }
            else if (this.DBOperType == "U")
            {
                //编辑
            }
            else if(this.DBOperType == "S") { MessageBox.Show("没有需要保存的数据");return; }
            

            this.LObject = "Levent";

        }
        #endregion

        #region 左事件作废按钮
        private void barButtonItem_InvalidLEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(DBOperType != "S") { MessageBox.Show("请先保存！");return; }

            if (treeList_LEvent.FocusedNode == null) {MessageBox.Show("请选择作废行！"); return; }

            TreeListNode node = this.treeList_LEvent.FocusedNode;
            node.SetValue("EVENTINFO_IFINVALID", "T");

            g_LeventInfo.EVENTINFO_IFINVALID = "T";

            this.LObject = "Levent";
            this.DBOperType = "U";
        }
        #endregion

        #region 左句子新增按钮
        private void barButtonItem_CreateLSentence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

    }
}
