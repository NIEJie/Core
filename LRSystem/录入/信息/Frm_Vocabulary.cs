using DevExpress.XtraEditors;
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

namespace LRSystem.录入.信息
{
    public partial class Frm_Vocabulary : XtraForm
    {
        #region 变量
        private VocabularyClient vocabularyClient = new VocabularyClient();
        public MyVocabularyInfo vocabularyInfo = new MyVocabularyInfo();
        #endregion
        public Frm_Vocabulary()
        {
            InitializeComponent();
        }

        private void Frm_Vocabulary_Load(object sender, EventArgs e)
        {
            this.textEdit_Name.EditValue = vocabularyInfo.VOCABULARYINFO_NAME;
            this.textEdit_Code.EditValue = vocabularyInfo.VOCABULARYINFO_CODE;
            this.textEdit_CreateTime.EditValue = vocabularyInfo.VOCABULARYINFO_CREATETIME;
            this.textEdit_LastModifiedTime.EditValue = vocabularyInfo.VOCABULARYINFO_LASTMODIFIEDTIME;
            this.textEdit_ModificationTimes.EditValue = vocabularyInfo.VOCABULARYINFO_MODIFICATIONTIMES;
            this.memoEdit_VocabularyNote.EditValue = vocabularyInfo.VOCABULARYINFO_NOTE;
        }

        private void barButtonItem_SaveVocabulary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(false);
            vocabularyInfo.VOCABULARYINFO_CODE = this.textEdit_Code.EditValue.ToString();
            vocabularyInfo.VOCABULARYINFO_NAME = this.textEdit_Name.EditValue.ToString();
            vocabularyInfo.VOCABULARYINFO_NOTE = this.memoEdit_VocabularyNote.EditValue.ToString();
            this.textEdit_LastModifiedTime.EditValue = DateTime.Now.ToString();
            this.textEdit_ModificationTimes.EditValue = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);

            if (vocabularyClient.SaveVocabularyInfoCard(vocabularyInfo))
            {
                vocabularyInfo.VOCABULARYINFO_LASTMODIFIEDTIME = DateTime.Now.ToString();
                vocabularyInfo.VOCABULARYINFO_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);

                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void barButtonItem_EditVocabulary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(true);
        }

        //修改卡片状态
        private void changeState(bool state)
        {
            this.textEdit_Name.Enabled = state;
            this.textEdit_Code.Enabled = state;
            this.memoEdit_VocabularyNote.Enabled = state;
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
