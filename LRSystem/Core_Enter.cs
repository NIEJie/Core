using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
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
using Core.Client.EnterClient;

namespace Core.UI
{
    public partial class Core_Enter : XtraForm
    {

        /*规定：
        * 全局对象变量要以g_开头
        * 局部变量、参数变量无要求
        * 标志变量要以flag_开头
        * 
        * 
        * 信息源：：构建框架的信息
        * 数据源：：框架运作产生的数据
        * 
        * 
        * */

        /*整体构建的思想
        * 1. 数据与后台的交换只有：界面打开时获取数据库中的数据 && 保存按钮写入数据库
        * 2. 全局变量和标志变量是中间数据源，页面效果要和全局变量、标志变量实时同步
        * 3. 如果数据量很大，那么可以采用分页的技术
        * 
        * 现在有两种处理数据的方式：第一种使用BindingList，最后保存时转换成list，第二种是直接使用list，目前采用第一种
        * 数据行之后可以加上状态列，根据不同的状态有不同的显示，但是现在可以先不做，状态的变化可以通过事件将state列和显示结合起来（具体地说应该是节点或行值变化事件）
        * 可以将各种编辑按钮用编辑框、复选框的事件集代替，这样可以做到实时编辑
        * 
        * 
        * 
        * 
        * */

        /*细节规定
        * 1. 由于需要实时同步，所以各种状态的数据会混合在一起展现，所以需要给数据加上状态列
        * 2. 为了前台展示方便，对于不同的状态添加颜色标识，而且实时同步状态
        * 3. 为了操作逻辑的简洁可靠，只保留一个保存按钮，一次性根据数据保存全部的数据
        * 4. 保存时刷新所有界面绑定，但是也要固定焦点
        * 5. 保存时，根据状态列，判断更新还是插入
        * 6. 获取数据是一次性全部获取，保存是循环单个保存
        * 7. 所有的gridview的绑定都要改为bindinglist，便于操作，每次修改数据都要同步刷新一次list
        * */

        #region 构造函数
        public Core_Enter()
        {
            InitializeComponent();
        }
        #endregion

        #region 全局变量

        private List<MyQAInfo> g_QAInfoList = new List<MyQAInfo>();//问题集
        private BindingList<MyQAInfo> g_QAInfoBindingList = new BindingList<MyQAInfo>();//问题集
        private MyQAInfo g_QAInfo = new MyQAInfo();//问题对象


        private List<MyPropertyInfo> g_propertyInfoList = new List<MyPropertyInfo>();//属性
        private MyPropertyInfo g_propertyInfo = new MyPropertyInfo();//属性对象

        private List<MyPropertyData> g_propertyDataList = new List<MyPropertyData>();//对象的属性
        private MyPropertyData g_propertyData = new MyPropertyData();//对象的属性对象

        private List<MyRelationInfo> g_relationInfoList = new List<MyRelationInfo>();//关系
        private MyRelationInfo g_relationInfo = new MyRelationInfo();//关系对象

        private List<MyRelationData> g_OrelationDataList = new List<MyRelationData>();//对象的关系
        private MyRelationData g_OrelationData = new MyRelationData();//对象的关系对象

        private List<MySentenceInfo> g_senetenceInfoList = new List<MySentenceInfo>();//句子
        private MySentenceInfo g_sentenceInfo = new MySentenceInfo();//句子对象

        private List<MyVocabularyInfo> g_vocabularyInfoList = new List<MyVocabularyInfo>();//词汇
        private MyVocabularyInfo g_vocabularyInfo = new MyVocabularyInfo();//词汇对象

        //private List<MyEventInfo> g_OeventInfoList = new List<MyEventInfo>();//对应事件
        //private MyEventInfo g_OeventInfo = new MyEventInfo();//对应事件对象

        private List<MySentenceInfo> g_OsenetenceInfoList = new List<MySentenceInfo>();//对应句子
        private MySentenceInfo g_OsentenceInfo = new MySentenceInfo();//对应句子对象

        private List<MyVocabularyInfo> g_OvocabularyInfoList = new List<MyVocabularyInfo>();//对应词汇
        private MyVocabularyInfo g_OvocabularyInfo = new MyVocabularyInfo();//对应词汇对象

        private List<MyPropertyData> g_OpropertyDataList = new List<MyPropertyData>();//对应对象的属性
        private MyPropertyData g_OpropertyData = new MyPropertyData();//对应对象的属性对象

        #endregion

        #region 特殊变量
        private EnterClient enterClient = new EnterClient();
        #endregion
         
        #region 标志变量 使用行状态，无需标记变量了
        //private string flag_operType = string.Empty; //I : insert ; U : update ; S : save
        #endregion



        #region 表单加载
        private void Core_Enter_Load(object sender, EventArgs e)
        {
            //需要分页，每次获取一页的所有数据

            //获取事件
            g_QAInfoList = enterClient.GetQAInfoList();
            if (g_QAInfoList != null && g_QAInfoList.Count > 0) g_QAInfo = g_QAInfoList[0];
            ////获取句子
            //g_senetenceInfoList = enterClient.GetSentenceInfoList(g_QAInfo.EVENTINFO_CODE);
            //if (g_senetenceInfoList != null && g_senetenceInfoList.Count > 0) g_sentenceInfo = g_senetenceInfoList[0];
            ////获取词汇
            //g_vocabularyInfoList = enterClient.GetVocabularyInfoList(g_sentenceInfo.SENTENCEINFO_CODE);
            ////获取属性、关系
            //g_propertyInfoList = enterClient.GetPropertyInfoList();
            //g_relationInfoList = enterClient.GetRelationInfoList();
            ////获取对象属性、对象关系(第一个词汇或句子或事件的属性、关系)
            //if(g_vocabularyInfo != null)
            //{
                

            //}
            

        }
        #endregion

        #region 绑定表单

        #region 绑定关系树
        private void BindRelation()
        {
            g_relationInfoList = enterClient.GetRelationInfoList();
            if (g_relationInfoList.Count > 0)
            {
                this.BindRelationTree(treeList_RelationList, g_relationInfoList);
            }
        }

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

        #region 绑定属性树和对应属性树

        //绑定属性树
        private void BindProperty()
        {
            g_propertyInfoList = enterClient.GetPropertyInfoList();
            if (g_propertyInfoList.Count > 0)
            {
                this.BindLPropertyInfoTree(treeList_PropertyList, g_propertyInfoList);
                this.BindRPropertyTree(treeList_OPropertyList, g_propertyInfoList);
            }
        }

        #region 绑定对应属性树

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

        #region 绑定属性树

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

        #endregion

        #region 绑定事件,绑定句子和词汇

        //绑定问题
        private void BindQA()
        {
            g_QAInfoList = enterClient.GetQAInfoList();
            g_QAInfoBindingList = new BindingList<MyQAInfo>(g_QAInfoList);
            treeList_QA.KeyFieldName = "QA_ID";
            treeList_QA.ParentFieldName = "QA_ParentID";
            this.treeList_QA.DataSource = g_QAInfoBindingList;
        }


        //绑定句子和对应句子
        private void BindSentence()
        {
            g_senetenceInfoList = g_OsenetenceInfoList = enterClient.GetSentenceInfoList(g_QAInfo.QAINFO_CODE);
            this.gridControl_Sentence.DataSource = g_senetenceInfoList;
            this.gridControl_OSentence.DataSource = g_OsenetenceInfoList;
        }

        //绑定词汇
        private void BindVocabulary()
        {
            g_vocabularyInfoList = g_OvocabularyInfoList = enterClient.GetVocabularyInfoList(g_sentenceInfo.SENTENCEINFO_CODE);
            this.gridControl_Vocabulary.DataSource = g_vocabularyInfoList;
            this.gridControl_OVocabulary.DataSource = g_OvocabularyInfoList;
        }
        #endregion

        #endregion

        #region 焦点事件

        //属性树
        private void treeList_PropertyList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //属性节点获取
            g_propertyInfo.PROPERTYINFO_CODE = e.Node.GetValue("PROPERTYINFO_CODE").ToString();
            g_propertyInfo.PROPERTYINFO_CREATETIME = e.Node.GetValue("PROPERTYINFO_CREATETIME").ToString();
            g_propertyInfo.PROPERTYINFO_GRADE = Convert.ToInt32(e.Node.GetValue("PROPERTYINFO_GRADE"));
            g_propertyInfo.PROPERTYINFO_ID = e.Node.GetValue("PROPERTYINFO_ID").ToString();
            g_propertyInfo.PROPERTYINFO_IFDETAIL = e.Node.GetValue("PROPERTYINFO_IFDETAIL").ToString();
            g_propertyInfo.PROPERTYINFO_IFINVALID = e.Node.GetValue("PROPERTYINFO_IFINVALID").ToString();
            g_propertyInfo.PROPERTYINFO_LASTMODIFIEDTIME = e.Node.GetValue("PROPERTYINFO_LASTMODIFIEDTIME").ToString();
            g_propertyInfo.PROPERTYINFO_MODIFICATIONTIMES = e.Node.GetValue("PROPERTYINFO_MODIFICATIONTIMES").ToString();
            g_propertyInfo.PROPERTYINFO_NAME = e.Node.GetValue("PROPERTYINFO_NAME").ToString();
            g_propertyInfo.PROPERTYINFO_NOTE = e.Node.GetValue("PROPERTYINFO_NOTE").ToString();
            g_propertyInfo.PROPERTYINFO_PARENTID = e.Node.GetValue("PROPERTYINFO_PARENTID").ToString();

            this.memoEdit_Note.Text = g_propertyInfo.PROPERTYINFO_NOTE;
            this.memoEdit_Name.Text = g_propertyInfo.PROPERTYINFO_NAME;

        }

        //对应属性树
        private void treeList_OPropertyList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //属性节点获取
            g_propertyInfo.PROPERTYINFO_CODE = e.Node.GetValue("PROPERTYINFO_CODE").ToString();
            g_propertyInfo.PROPERTYINFO_CREATETIME = e.Node.GetValue("PROPERTYINFO_CREATETIME").ToString();
            g_propertyInfo.PROPERTYINFO_GRADE = Convert.ToInt32(e.Node.GetValue("PROPERTYINFO_GRADE"));
            g_propertyInfo.PROPERTYINFO_ID = e.Node.GetValue("PROPERTYINFO_ID").ToString();
            g_propertyInfo.PROPERTYINFO_IFDETAIL = e.Node.GetValue("PROPERTYINFO_IFDETAIL").ToString();
            g_propertyInfo.PROPERTYINFO_IFINVALID = e.Node.GetValue("PROPERTYINFO_IFINVALID").ToString();
            g_propertyInfo.PROPERTYINFO_LASTMODIFIEDTIME = e.Node.GetValue("PROPERTYINFO_LASTMODIFIEDTIME").ToString();
            g_propertyInfo.PROPERTYINFO_MODIFICATIONTIMES = e.Node.GetValue("PROPERTYINFO_MODIFICATIONTIMES").ToString();
            g_propertyInfo.PROPERTYINFO_NAME = e.Node.GetValue("PROPERTYINFO_NAME").ToString();
            g_propertyInfo.PROPERTYINFO_NOTE = e.Node.GetValue("PROPERTYINFO_NOTE").ToString();
            g_propertyInfo.PROPERTYINFO_PARENTID = e.Node.GetValue("PROPERTYINFO_PARENTID").ToString();

            this.memoEdit_Note.Text = g_propertyInfo.PROPERTYINFO_NOTE;
            this.memoEdit_Name.Text = g_propertyInfo.PROPERTYINFO_NAME;
        }

        //关系树
        private void treeList_RelationList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //关系节点获取
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

            this.memoEdit_Note.Text = g_relationInfo.RELATIONINFO_NOTE;
            this.memoEdit_Name.Text = g_relationInfo.RELATIONINFO_NAME;

        }

        //问题树
        private void treeList_QA_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            //属性节点获取
            g_QAInfo.QAINFO_CODE = e.Node.GetValue("QAINFO_CODE").ToString();
            g_QAInfo.QAINFO_CREATETIME = e.Node.GetValue("QAINFO_CREATETIME").ToString();
            g_QAInfo.QAINFO_ID = e.Node.GetValue("QAINFO_ID").ToString();
            g_QAInfo.QAINFO_IFINVALID = e.Node.GetValue("QAINFO_IFINVALID").ToString();
            g_QAInfo.QAINFO_LASTMODIFIEDTIME = e.Node.GetValue("QAINFO_LASTMODIFIEDTIME").ToString();
            g_QAInfo.QAINFO_MODIFICATIONTIMES = Convert.ToInt32(e.Node.GetValue("QAINFO_MODIFICATIONTIMES"));
            g_QAInfo.QAINFO_QUESTION = e.Node.GetValue("QAINFO_QUESTION").ToString();
            g_QAInfo.QAINFO_ANSWER = e.Node.GetValue("QAINFO_ANSWER").ToString();
            g_QAInfo.QAINFO_PARENTID = e.Node.GetValue("QAINFO_PARENTID").ToString();
            g_QAInfo.QAINFO_STATE = e.Node.GetValue("QAINFO_STATE").ToString();

            this.memoEdit_Note.Text = g_QAInfo.QAINFO_ANSWER;
            this.memoEdit_Name.Text = g_QAInfo.QAINFO_QUESTION;

        }

        //对应事件
        //private void gridControl_OEvent_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        //{
        //    if (e.View == null) return;

        //    g_OeventInfo = this.gridView_OEvent.GetRow(this.gridView_OEvent.FocusedRowHandle) as MyEventInfo;

        //    this.memoEdit_Note.Text = g_OeventInfo.EVENTINFO_NOTE;
        //    this.memoEdit_Name.Text = g_OeventInfo.EVENTINFO_NAME;

        //}

        //句子
        private void gridControl_Sentence_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            g_sentenceInfo = this.gridView_Sentence.GetRow(this.gridView_Sentence.FocusedRowHandle) as MySentenceInfo;

            this.memoEdit_Note.Text = g_sentenceInfo.SENTENCEINFO_NOTE;
            this.memoEdit_Name.Text = g_sentenceInfo.SENTENCEINFO_NAME;

        }
        //对应句子
        private void gridControl_OSentence_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            g_OsentenceInfo = this.gridView_OSentence.GetRow(this.gridView_OSentence.FocusedRowHandle) as MySentenceInfo;

            this.memoEdit_Note.Text = g_OsentenceInfo.SENTENCEINFO_NOTE;
            this.memoEdit_Name.Text = g_OsentenceInfo.SENTENCEINFO_NAME;

        }

        //词汇
        private void gridControl_Vocabulary_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            g_vocabularyInfo = this.gridView_Vocabulary.GetRow(this.gridView_Vocabulary.FocusedRowHandle) as MyVocabularyInfo;

            this.memoEdit_Note.Text = g_vocabularyInfo.VOCABULARYINFO_NOTE;
            this.memoEdit_Name.Text = g_vocabularyInfo.VOCABULARYINFO_NAME;

        }

        //对应词汇
        private void gridControl_OVocabulary_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            if (e.View == null) return;

            g_OvocabularyInfo = this.gridView_OVocabulary.GetRow(this.gridView_OVocabulary.FocusedRowHandle) as MyVocabularyInfo;

            this.memoEdit_Note.Text = g_OvocabularyInfo.VOCABULARYINFO_NOTE;
            this.memoEdit_Name.Text = g_OvocabularyInfo.VOCABULARYINFO_NAME;

        }

        #endregion

        #region 问题集

        #region 问题新增按钮 
        private void barButtonItem_QACreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.treeList_QA.CloseEditor();

            //有数据，无选中
            if (this.treeList_QA.FocusedNode == null && this.treeList_QA.AllNodesCount != 0) { MessageBox.Show("请选择节点");return; }
            //无数据无选中
            if (this.treeList_QA.FocusedNode == null && this.treeList_QA.AllNodesCount == 0)
            {
                this.treeList_QA.BeginUpdate();

                g_QAInfo.QAINFO_ID = System.Guid.NewGuid().ToString();
                g_QAInfo.QAINFO_CODE = GetMaxBH("QA");
                g_QAInfo.QAINFO_PARENTID = string.Empty;
                g_QAInfo.QAINFO_QUESTION = "新增" + g_QAInfo.QAINFO_CODE;
                g_QAInfo.QAINFO_ANSWER = "新增" + g_QAInfo.QAINFO_CODE;
                g_QAInfo.QAINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
                g_QAInfo.QAINFO_LASTMODIFIEDTIME = DateTime.Now.ToString("yyyyMMdd");
                g_QAInfo.QAINFO_MODIFICATIONTIMES = 0;
                g_QAInfo.QAINFO_IFINVALID = "N";
                g_QAInfo.QAINFO_STATE = "N";

                treeList_QA.AppendNode(new object[] { g_QAInfo.QAINFO_IFINVALID, g_QAInfo.QAINFO_CODE, g_QAInfo.QAINFO_PARENTID, g_QAInfo.QAINFO_QUESTION, g_QAInfo.QAINFO_ANSWER, g_QAInfo.QAINFO_CREATETIME, g_QAInfo.QAINFO_LASTMODIFIEDTIME, g_QAInfo.QAINFO_MODIFICATIONTIMES, g_QAInfo.QAINFO_IFINVALID,g_QAInfo.QAINFO_STATE }, null);

                this.treeList_QA.EndUpdate();

                //g_QAInfoList.Add(g_QAInfo);

                this.memoEdit_Note.Text = g_QAInfo.QAINFO_ANSWER;
                this.memoEdit_Name.Text = g_QAInfo.QAINFO_QUESTION;

                return;
            }

            //有数据有选中节点
            this.treeList_QA.BeginUpdate();

            TreeListNode newNode = this.treeList_QA.FocusedNode;

            g_QAInfo.QAINFO_ID = System.Guid.NewGuid().ToString();
            g_QAInfo.QAINFO_CODE = GetMaxBH("QA");
            g_QAInfo.QAINFO_PARENTID = newNode.GetValue("QAINFO_PARENTID").ToString();
            g_QAInfo.QAINFO_QUESTION = "新增" + g_QAInfo.QAINFO_CODE;
            g_QAInfo.QAINFO_ANSWER = "新增" + g_QAInfo.QAINFO_CODE;
            g_QAInfo.QAINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
            g_QAInfo.QAINFO_LASTMODIFIEDTIME = DateTime.Now.ToString("yyyyMMdd");
            g_QAInfo.QAINFO_MODIFICATIONTIMES = 0;
            g_QAInfo.QAINFO_IFINVALID = "N";
            g_QAInfo.QAINFO_STATE = "N";

            treeList_QA.AppendNode(new object[] { g_QAInfo.QAINFO_IFINVALID, g_QAInfo.QAINFO_CODE, g_QAInfo.QAINFO_PARENTID, g_QAInfo.QAINFO_QUESTION, g_QAInfo.QAINFO_ANSWER, g_QAInfo.QAINFO_CREATETIME, g_QAInfo.QAINFO_LASTMODIFIEDTIME, g_QAInfo.QAINFO_MODIFICATIONTIMES, g_QAInfo.QAINFO_IFINVALID,g_QAInfo.QAINFO_STATE }, newNode.ParentNode);

            this.treeList_QA.EndUpdate();

            //g_QAInfoList.Add(g_QAInfo);

            this.memoEdit_Note.Text = g_QAInfo.QAINFO_ANSWER;
            this.memoEdit_Name.Text = g_QAInfo.QAINFO_QUESTION;
        }


        #endregion

        #region 问题新增下级按钮

        private void barButtonItem_QASonCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.treeList_QA.CloseEditor();
            if (this.treeList_QA.FocusedNode == null)
            {
                MessageBox.Show("请选择父节点");
                return;
            }
            else
            {
                //有数据有选中节点
                this.treeList_QA.BeginUpdate();

                TreeListNode newNode = this.treeList_QA.FocusedNode;

                g_QAInfo.QAINFO_ID = System.Guid.NewGuid().ToString();
                g_QAInfo.QAINFO_CODE = GetMaxBH("QA");
                g_QAInfo.QAINFO_PARENTID = newNode.GetValue("QAINFO_ID").ToString();
                g_QAInfo.QAINFO_QUESTION = "新增" + g_QAInfo.QAINFO_CODE;
                g_QAInfo.QAINFO_ANSWER = "新增" + g_QAInfo.QAINFO_CODE;
                g_QAInfo.QAINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
                g_QAInfo.QAINFO_LASTMODIFIEDTIME = DateTime.Now.ToString("yyyyMMdd");
                g_QAInfo.QAINFO_MODIFICATIONTIMES = 0;
                g_QAInfo.QAINFO_IFINVALID = "N";
                g_QAInfo.QAINFO_STATE = "N";

                treeList_QA.AppendNode(new object[] { g_QAInfo.QAINFO_IFINVALID, g_QAInfo.QAINFO_CODE, g_QAInfo.QAINFO_PARENTID, g_QAInfo.QAINFO_QUESTION, g_QAInfo.QAINFO_ANSWER, g_QAInfo.QAINFO_CREATETIME, g_QAInfo.QAINFO_LASTMODIFIEDTIME, g_QAInfo.QAINFO_MODIFICATIONTIMES, g_QAInfo.QAINFO_IFINVALID,g_QAInfo.QAINFO_STATE }, newNode);

                this.treeList_QA.EndUpdate();

                //g_QAInfoList.Add(g_QAInfo);

                this.memoEdit_Note.Text = g_QAInfo.QAINFO_ANSWER;
                this.memoEdit_Name.Text = g_QAInfo.QAINFO_QUESTION;

                treeList_QA.EndUpdate();
            }
        }

        #endregion

        #region 问题编辑按钮
        private void barButtonItem_QAEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (treeList_QA.FocusedNode == null) return;

            this.treeList_QA.CloseEditor();
            this.treeList_QA.BeginUpdate();
            TreeListNode node = this.treeList_QA.FocusedNode;

            node.SetValue("QAINFO_LASTMODIFYTIME", DateTime.Now.ToString("yyyyMMdd"));
            node.SetValue("EVENTINFO_MODIFICATIONTIMES",Convert.ToInt32(node.GetValue("EVENTTYPE_MODIFICATIONTIMES")) + 1);
            g_QAInfo.QAINFO_STATE = "E";

            this.treeList_QA.EndUpdate();

        }
        #endregion

        #region 事件作废按钮
        private void barButtonItem_QAInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (treeList_QA.FocusedNode == null) { MessageBox.Show("请选择作废行！"); return; }

            this.treeList_QA.CloseEditor();
            this.treeList_QA.BeginUpdate();
            TreeListNode node = this.treeList_QA.FocusedNode;
            node.SetValue("QAINFO_IFINVALID", "T");
            this.treeList_QA.EndUpdate();
        }
        #endregion

        #endregion

        #region 句子
        #region 句子新增按钮
        private void barButtonItem_SentenceCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            g_sentenceInfo.SENTENCEINFO_EVENTINFOID = g_sentenceInfo.SENTENCEINFO_EVENTINFOID;
            g_sentenceInfo.SENTENCEINFO_CREATETIME = DateTime.Now.ToString();
            g_sentenceInfo.SENTENCEINFO_ID = Guid.NewGuid().ToString();
            g_sentenceInfo.SENTENCEINFO_IFINVALID = "F";
            g_sentenceInfo.SENTENCEINFO_LASTMODIFIEDTIME = g_sentenceInfo.SENTENCEINFO_CREATETIME;
            g_sentenceInfo.SENTENCEINFO_MODIFICATIONTIMES = "0";

        }
        #endregion
        #region 句子插入按钮
        private void barButtonItem_SentenceInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 句子编辑按钮
        private void barButtonItem_SentenceEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 句子作废按钮
        private void barButtonItem_SentenceInvaild_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        #endregion

        #region 词汇
        #region 新增词汇
        private void barButtonItem_VocabularyCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 插入词汇
        private void barButtonItem_VocabularyInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 编辑词汇
        private void barButtonItem_VocabularyEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 作废词汇
        private void barButtonItem_VocabularyInvaild_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        #endregion

        #region 保存全部
        private void barButtonItem_SaveALL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region 保存问题集
            this.treeList_QA.CloseEditor();
            g_QAInfoList = g_QAInfoBindingList.ToList();
            enterClient.SaveQAInfoList(g_QAInfoList);
            #endregion
        }

        #endregion

        #region 属性
        #region 新增
        private void barButtonItem_PropertyCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //treeList_Event.OptionsBehavior.Editable = false;
            //treeList_Event.BeginUpdate();
            //if (this.treeList_Event.FocusedNode == null)
            //{
            //    if (treeList_Event.Nodes.Count > 0)
            //    {
            //        MessageBox.Show("请选择父节点");
            //        return;
            //    }

            //    //事件节点获取
            //    g_QAInfo.EVENTINFO_CODE = DateTime.Now.ToString("yyyyMMdd") + "0001";
            //    g_QAInfo.EVENTINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
            //    g_QAInfo.EVENTINFO_GRADE = 1;
            //    g_QAInfo.EVENTINFO_ID = System.Guid.NewGuid().ToString();
            //    g_QAInfo.EVENTINFO_IFDETAIL = "1";
            //    g_QAInfo.EVENTINFO_IFINVALID = "F";
            //    g_QAInfo.EVENTINFO_LASTMODIFIEDTIME = "";
            //    g_QAInfo.EVENTINFO_MODIFICATIONTIMES = "0";
            //    g_QAInfo.EVENTINFO_NAME = "新增" + g_QAInfo.EVENTINFO_CODE;
            //    g_QAInfo.EVENTINFO_NOTE = "新增" + g_QAInfo.EVENTINFO_CODE;
            //    g_QAInfo.EVENTINFO_PARENTID = "";

            //    TreeListNode node = treeList_Event.AppendNode(new object[] { g_QAInfo.EVENTINFO_ID, g_QAInfo.EVENTINFO_CODE, g_QAInfo.EVENTINFO_NAME, g_QAInfo.EVENTINFO_PARENTID, g_QAInfo.EVENTINFO_IFDETAIL, g_QAInfo.EVENTINFO_GRADE, g_QAInfo.EVENTINFO_IFINVALID, g_QAInfo.EVENTINFO_NOTE, g_QAInfo.EVENTINFO_CREATETIME, g_QAInfo.EVENTINFO_LASTMODIFIEDTIME, g_QAInfo.EVENTINFO_MODIFICATIONTIMES }, null);

            //    g_QAInfoList.Add(g_QAInfo);
            //}
            //else
            //{
            //    TreeListNode eventInfo = this.treeList_Event.FocusedNode;

            //    List<string> strlist = new List<string>();
            //    foreach (TreeListNode item in treeList_Event.Nodes)
            //    {
            //        if (item.GetValue("EVENTINFO_CODE").ToString().Contains(DateTime.Now.ToString("yyyyMMdd"))) strlist.Add(item.GetValue("EVENTINFO_CODE").ToString());
            //    }

            //    if (strlist.Count > 0)
            //    {
            //        g_QAInfo.EVENTINFO_CODE = (Convert.ToInt32(strlist.Max()) + 1).ToString();
            //    }
            //    else
            //    {
            //        g_QAInfo.EVENTINFO_CODE = DateTime.Now.ToString("yyyyMMdd") + "0001";
            //    }

            //    g_QAInfo.EVENTINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
            //    g_QAInfo.EVENTINFO_GRADE = Convert.ToInt32(eventInfo.GetValue("EVENTINFO_GRADE"));
            //    g_QAInfo.EVENTINFO_ID = System.Guid.NewGuid().ToString();
            //    g_QAInfo.EVENTINFO_IFDETAIL = "1";
            //    g_QAInfo.EVENTINFO_IFINVALID = "F";
            //    g_QAInfo.EVENTINFO_LASTMODIFIEDTIME = "";
            //    g_QAInfo.EVENTINFO_MODIFICATIONTIMES = "0";
            //    g_QAInfo.EVENTINFO_NAME = "新增" + g_QAInfo.EVENTINFO_CODE;
            //    g_QAInfo.EVENTINFO_NOTE = "新增" + g_QAInfo.EVENTINFO_CODE;
            //    g_QAInfo.EVENTINFO_PARENTID = eventInfo.GetValue("EVENTINFO_PARENTID").ToString();

            //    this.memoEdit_Note.Text = g_QAInfo.EVENTINFO_NOTE;
            //    this.memoEdit_Name.Text = g_QAInfo.EVENTINFO_NAME;

            //    TreeListNode parnode = eventInfo.ParentNode;
            //    TreeListNode node = treeList_Event.AppendNode(new object[] { g_QAInfo.EVENTINFO_ID, g_QAInfo.EVENTINFO_CODE, g_QAInfo.EVENTINFO_NAME, g_QAInfo.EVENTINFO_PARENTID, g_QAInfo.EVENTINFO_IFDETAIL, g_QAInfo.EVENTINFO_GRADE, g_QAInfo.EVENTINFO_IFINVALID, g_QAInfo.EVENTINFO_NOTE, g_QAInfo.EVENTINFO_CREATETIME, g_QAInfo.EVENTINFO_LASTMODIFIEDTIME, g_QAInfo.EVENTINFO_MODIFICATIONTIMES }, parnode);

            //    g_QAInfoList.Add(g_QAInfo);
            //}

            //treeList_Event.EndUpdate();
        }


        #endregion

        #region 新增下级
        private void barButtonItem_PropertyCreateSon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //treeList_Event.OptionsBehavior.Editable = false;
            //treeList_Event.BeginUpdate();
            //if (this.treeList_Event.FocusedNode == null)
            //{
            //    MessageBox.Show("请选择父节点");
            //    return;
            //}
            //else
            //{
            //    TreeListNode L_LeventInfo = this.treeList_Event.FocusedNode;

            //    List<string> strlist = new List<string>();
            //    foreach (TreeListNode item in treeList_Event.Nodes)
            //    {
            //        if (item.GetValue("EVENTINFO_CODE").ToString().Contains(DateTime.Now.ToString("yyyyMMdd"))) strlist.Add(item.GetValue("EVENTINFO_CODE").ToString());
            //    }

            //    if (strlist.Count > 0)
            //    {
            //        g_QAInfo.EVENTINFO_CODE = (Convert.ToInt32(strlist.Max()) + 1).ToString();
            //    }
            //    else
            //    {
            //        g_QAInfo.EVENTINFO_CODE = DateTime.Now.ToString("yyyyMMdd") + "0001";
            //    }

            //    g_QAInfo.EVENTINFO_CREATETIME = DateTime.Now.ToString("yyyyMMdd");
            //    g_QAInfo.EVENTINFO_GRADE = Convert.ToInt32(L_LeventInfo.GetValue("EVENTINFO_GRADE")) + 1;
            //    g_QAInfo.EVENTINFO_ID = System.Guid.NewGuid().ToString();
            //    g_QAInfo.EVENTINFO_IFDETAIL = "1";
            //    g_QAInfo.EVENTINFO_IFINVALID = "F";
            //    g_QAInfo.EVENTINFO_LASTMODIFIEDTIME = "";
            //    g_QAInfo.EVENTINFO_MODIFICATIONTIMES = "0";
            //    g_QAInfo.EVENTINFO_NAME = "新增" + g_QAInfo.EVENTINFO_CODE;
            //    g_QAInfo.EVENTINFO_NOTE = "新增" + g_QAInfo.EVENTINFO_CODE;
            //    g_QAInfo.EVENTINFO_PARENTID = L_LeventInfo.GetValue("EVENTINFO_ID").ToString();

            //    this.memoEdit_Note.Text = g_QAInfo.EVENTINFO_NOTE;
            //    this.memoEdit_Name.Text = g_QAInfo.EVENTINFO_NAME;

            //    TreeListNode parnode = L_LeventInfo.ParentNode;
            //    TreeListNode node = treeList_Event.AppendNode(new object[] { g_QAInfo.EVENTINFO_ID, g_QAInfo.EVENTINFO_CODE, g_QAInfo.EVENTINFO_NAME, g_QAInfo.EVENTINFO_PARENTID, g_QAInfo.EVENTINFO_IFDETAIL, g_QAInfo.EVENTINFO_GRADE, g_QAInfo.EVENTINFO_IFINVALID, g_QAInfo.EVENTINFO_NOTE, g_QAInfo.EVENTINFO_CREATETIME, g_QAInfo.EVENTINFO_LASTMODIFIEDTIME, g_QAInfo.EVENTINFO_MODIFICATIONTIMES }, parnode);

            //    g_QAInfoList.Add(g_QAInfo);
            //}

            //treeList_Event.EndUpdate();
        }
        #endregion
        #region 编辑
        private void barButtonItem_PropertyEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (treeList_Event.FocusedNode == null) return;
            //TreeListNode node = this.treeList_Event.FocusedNode;

            //this.memoEdit_Note.Text = g_propertyInfo.PROPERTYINFO_NOTE;
            //this.memoEdit_Name.Text = g_propertyInfo.PROPERTYINFO_NAME;

            //g_QAInfo.EVENTINFO_LASTMODIFIEDTIME = DateTime.Now.ToString("yyyyMMdd");
            //g_QAInfo.EVENTINFO_MODIFICATIONTIMES = (Convert.ToInt32(node.GetValue("EVENTTYPE_MODIFICATIONTIMES")) + 1).ToString();

        }
        #endregion
        #region 作废
        private void barButtonItem_PropertyInvaild_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (treeList_Event.FocusedNode == null) { MessageBox.Show("请选择作废行！"); return; }

            //TreeListNode node = this.treeList_Event.FocusedNode;
            //node.SetValue("EVENTINFO_IFINVALID", "T");

            //g_QAInfo.EVENTINFO_IFINVALID = "T";
        }
        #endregion

        #endregion

        #region 关系
        #region 新增
        private void barButtonItem_RealtionCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 新增下级
        private void barButtonItem_RelationCreateSon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 编辑
        private void barButtonItem_RelationEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion
        #region 作废
        private void barButtonItem_RelationInvaild_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }





        #endregion

        #endregion

        #region 事件新增行数据初始化操作
        //private void gridView_Event_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        //{
        //    ColumnView View = sender as ColumnView;

        //    foreach (DevExpress.XtraGrid.Columns.GridColumn groupColumn in View.GroupedColumns)
        //    {
        //        View.SetRowCellValue(e.RowHandle, groupColumn, gridView_Event.GetRowCellValue(gridView_Event.GetRowHandle(gridView_Event.RowCount - 2), groupColumn)); //复制最后一行的数据到新行 
        //    }
        //    //修改部分数据：

        //}
        #endregion

        #region 方法

        #region 获取最大编号
        private string GetMaxBH(string flag)
        {
            string maxbh = string.Empty;

            return maxbh;
        }
        #endregion

        #endregion


    }
}
