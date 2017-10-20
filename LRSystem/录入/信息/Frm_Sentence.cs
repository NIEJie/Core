using LRSystem.录入.信息;
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
    public partial class Frm_Sentence : Form
    {

        #region 变量
        private SentenceClient sentenceClient = new SentenceClient();
        public MySentenceInfo g_sentenceInfo = new MySentenceInfo();
        private List<MyVocabularyInfo> VocabularyInfoList = new List<MyVocabularyInfo>();
        private MyVocabularyInfo g_vocabularyInfo = new MyVocabularyInfo();

        public string objectid = string.Empty;
        #endregion

        public Frm_Sentence()
        {
            InitializeComponent();
        }

        private void Frm_Sentence_Load(object sender, EventArgs e)
        {
            VocabularyInfoList = sentenceClient.GetVocabularyInfoCard(g_sentenceInfo.SENTENCEINFO_CODE);
            //句子
            this.textEdit_Name.EditValue = g_sentenceInfo.SENTENCEINFO_NAME;
            this.textEdit_Code.EditValue = g_sentenceInfo.SENTENCEINFO_CODE;
            this.textEdit_CreateTime.EditValue = g_sentenceInfo.SENTENCEINFO_CREATETIME;
            this.textEdit_LastModifiedTime.EditValue = g_sentenceInfo.SENTENCEINFO_LASTMODIFIEDTIME;
            this.textEdit_ModificationTimes.EditValue = g_sentenceInfo.SENTENCEINFO_MODIFICATIONTIMES;
            this.memoEdit_SentenceNote.EditValue = g_sentenceInfo.SENTENCEINFO_NOTE;
            //词汇
            this.gridControl_Vocabulary.DataSource = VocabularyInfoList;
        }

        private void barButtonItem_EditSentence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(true);
        }

        //修改卡片状态
        private void changeState(bool state)
        {
            this.textEdit_Name.Enabled = state;
            this.textEdit_Code.Enabled = state;
            this.memoEdit_SentenceNote.Enabled = state;
        }

        private void barButtonItem_CreateVocabulary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Vocabulary card = new Frm_Vocabulary();
            card.vocabularyInfo.VOCABULARYINFO_SENTENCEINFOID = g_vocabularyInfo.VOCABULARYINFO_SENTENCEINFOID;
            card.vocabularyInfo.VOCABULARYINFO_CREATETIME = DateTime.Now.ToString();
            card.vocabularyInfo.VOCABULARYINFO_ID = Guid.NewGuid().ToString();
            card.vocabularyInfo.VOCABULARYINFO_IFINVALID = "F";
            card.vocabularyInfo.VOCABULARYINFO_LASTMODIFIEDTIME = card.vocabularyInfo.VOCABULARYINFO_CREATETIME;
            card.vocabularyInfo.VOCABULARYINFO_MODIFICATIONTIMES = "0";

            if (card.ShowDialog() == DialogResult.OK)
            {
                this.Frm_Sentence_Load(null, null);
            }
        }

        private void barButtonItem_SaveSentence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(false);
            g_sentenceInfo.SENTENCEINFO_CODE = this.textEdit_Code.EditValue.ToString();
            g_sentenceInfo.SENTENCEINFO_NAME = this.textEdit_Name.EditValue.ToString();
            g_sentenceInfo.SENTENCEINFO_NOTE = this.memoEdit_SentenceNote.EditValue.ToString();
            g_sentenceInfo.SENTENCEINFO_LASTMODIFIEDTIME = DateTime.Now.ToString();
            g_sentenceInfo.SENTENCEINFO_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);

            if (sentenceClient.SaveSentenceInfoCard(g_sentenceInfo))
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

        private void gridControl_Vocabulary_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            g_vocabularyInfo = this.gridView_Vocabulary.GetFocusedRow() as MyVocabularyInfo;
            this.memoEdit_VocabularyNote.EditValue = g_vocabularyInfo.VOCABULARYINFO_NOTE;
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem_EditVocabulary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Vocabulary card = new Frm_Vocabulary();
            card.vocabularyInfo.VOCABULARYINFO_SENTENCEINFOID = g_vocabularyInfo.VOCABULARYINFO_SENTENCEINFOID;
            card.vocabularyInfo.VOCABULARYINFO_CREATETIME = g_vocabularyInfo.VOCABULARYINFO_CREATETIME;
            card.vocabularyInfo.VOCABULARYINFO_ID = g_vocabularyInfo.VOCABULARYINFO_ID;
            card.vocabularyInfo.VOCABULARYINFO_IFINVALID = g_vocabularyInfo.VOCABULARYINFO_IFINVALID;
            card.vocabularyInfo.VOCABULARYINFO_LASTMODIFIEDTIME = g_vocabularyInfo.VOCABULARYINFO_LASTMODIFIEDTIME;
            card.vocabularyInfo.VOCABULARYINFO_MODIFICATIONTIMES = g_vocabularyInfo.VOCABULARYINFO_MODIFICATIONTIMES;
            if(card.ShowDialog()==DialogResult.OK)
            {
                this.Frm_Sentence_Load(null, null);
            }
        }

        private void barButtonItem_OK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView_Vocabulary.GetFocusedRow() == null) return;
            g_vocabularyInfo = this.gridView_Vocabulary.GetFocusedRow() as MyVocabularyInfo;
            objectid = g_vocabularyInfo.VOCABULARYINFO_ID;
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
