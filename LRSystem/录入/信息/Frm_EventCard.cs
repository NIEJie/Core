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
    public partial class Frm_EventCard : Form
    {
        #region 变量
        private EventClient eventClient = new EventClient();
        public MyEventInfo eventInfo = new MyEventInfo();//当前的事件
        private List<MySentenceInfo> sentenceInfoList = new List<MySentenceInfo>();//绑定的句子列表
        private MySentenceInfo sentenceInfo = new MySentenceInfo();//当前选中的句子

        public string objectid = string.Empty;
        #endregion
        public Frm_EventCard()
        {
            InitializeComponent();
        }

        private void Frm_EventCard_Load(object sender, EventArgs e)
        {
            changeState(false);
            sentenceInfoList = eventClient.GetSentenceInfoCard(eventInfo.EVENTINFO_CODE);
            //事件
            this.textEdit_Name.EditValue = eventInfo.EVENTINFO_NAME;
            this.textEdit_Code.EditValue = eventInfo.EVENTINFO_CODE;
            this.textEdit_CreateTime.EditValue = eventInfo.EVENTINFO_CREATETIME;
            this.textEdit_LastModifiedTime.EditValue = eventInfo.EVENTINFO_LASTMODIFIEDTIME;
            this.textEdit_ModificationTimes.EditValue = eventInfo.EVENTINFO_MODIFICATIONTIMES;
            this.memoEdit_EventNote.EditValue = eventInfo.EVENTINFO_NOTE;
            //句子
            this.gridControl_Sentence.DataSource = sentenceInfoList;
            //直接通过gridControl_Event_FocusedViewChanged设置
            //this.memoEdit_SentenceNote.EditValue = sentenceInfoList[0].SENTENCEINFO_NOTE;
        }

        private void barButtonItem_EditEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(true);

        }

        //修改卡片状态
        private void changeState(bool state)
        {
            this.textEdit_Name.Enabled = state;
            this.textEdit_Code.Enabled = state;
            this.memoEdit_EventNote.Enabled = state;
        }

        private void barButtonItem_SaveEvent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(false);
            eventInfo.EVENTINFO_CODE = this.textEdit_Code.EditValue.ToString();
            eventInfo.EVENTINFO_NAME = this.textEdit_Name.EditValue.ToString();
            eventInfo.EVENTINFO_NOTE = this.memoEdit_EventNote.EditValue.ToString();
            eventInfo.EVENTINFO_LASTMODIFIEDTIME= DateTime.Now.ToString();
            eventInfo.EVENTINFO_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);
            if (eventClient.SaveEventInfoCard(eventInfo))
            {
                this.textEdit_LastModifiedTime.EditValue = DateTime.Now.ToString();
                this.textEdit_ModificationTimes.EditValue = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void barButtonItem_CreateSentence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Sentence card = new Frm_Sentence();
            card.g_sentenceInfo.SENTENCEINFO_EVENTINFOID = sentenceInfo.SENTENCEINFO_EVENTINFOID;
            card.g_sentenceInfo.SENTENCEINFO_CREATETIME = DateTime.Now.ToString();
            card.g_sentenceInfo.SENTENCEINFO_ID = Guid.NewGuid().ToString();
            card.g_sentenceInfo.SENTENCEINFO_IFINVALID = "F";
            card.g_sentenceInfo.SENTENCEINFO_LASTMODIFIEDTIME = card.g_sentenceInfo.SENTENCEINFO_CREATETIME;
            card.g_sentenceInfo.SENTENCEINFO_MODIFICATIONTIMES = "0";

            if(card.ShowDialog() ==DialogResult.OK)
            {
                //列表刷新
            }
        }

        private void barButtonItem_EditSentence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Sentence card = new Frm_Sentence();
            card.g_sentenceInfo.SENTENCEINFO_EVENTINFOID = sentenceInfo.SENTENCEINFO_EVENTINFOID;
            card.g_sentenceInfo.SENTENCEINFO_CREATETIME = sentenceInfo.SENTENCEINFO_CREATETIME;
            card.g_sentenceInfo.SENTENCEINFO_ID = sentenceInfo.SENTENCEINFO_ID;
            card.g_sentenceInfo.SENTENCEINFO_IFINVALID = sentenceInfo.SENTENCEINFO_IFINVALID;
            card.g_sentenceInfo.SENTENCEINFO_LASTMODIFIEDTIME = sentenceInfo.SENTENCEINFO_LASTMODIFIEDTIME;
            card.g_sentenceInfo.SENTENCEINFO_MODIFICATIONTIMES = sentenceInfo.SENTENCEINFO_MODIFICATIONTIMES;

            if (card.ShowDialog() == DialogResult.OK)
            {
                //列表刷新
            }
        }

        private void gridControl_Event_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            sentenceInfo = this.gridView_Sentence.GetFocusedRow() as MySentenceInfo;
            this.memoEdit_SentenceNote.EditValue = sentenceInfo.SENTENCEINFO_NOTE;
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem_OK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_Sentence.GetFocusedRow() == null) return;
            sentenceInfo = this.gridView_Sentence.GetFocusedRow() as MySentenceInfo;
            objectid = sentenceInfo.SENTENCEINFO_ID;
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //删除句子，做判断是否有对应词汇
        }

        private void barButtonItem_EventProperty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem_EventRelation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
