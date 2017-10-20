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

namespace LRSystem.录入.关系
{
    public partial class Frm_RelationCard : XtraForm
    {
        #region 变量
        private RelationClient relationClient = new RelationClient();
        public MyRelationInfo relationInfo = new MyRelationInfo();
        #endregion

        public Frm_RelationCard()
        {
            InitializeComponent();
        }

        private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.textEdit_Code.Enabled = false;
            this.textEdit_Name.Enabled = false;
            this.memoEdit_Note.Enabled = false;
            relationInfo.RELATIONINFO_CODE = this.textEdit_Code.EditValue.ToString();
            relationInfo.RELATIONINFO_NAME = this.textEdit_Name.EditValue.ToString();
            relationInfo.RELATIONINFO_NOTE = this.memoEdit_Note.EditValue.ToString();
            if (relationClient.SaveRelationInfoCard(relationInfo))
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Frm_RelationCard_Load(object sender, EventArgs e)
        {
            this.textEdit_Name.EditValue = relationInfo.RELATIONINFO_NAME;
            this.textEdit_Code.EditValue = relationInfo.RELATIONINFO_CODE;
            this.textEdit_CreateTime.EditValue = relationInfo.RELATIONINFO_CREATETIME;
            this.textEdit_LastModifiedTime.EditValue = relationInfo.RELATIONINFO_LASTMODIFIEDTIME;
            this.textEdit_ModificationTimes.EditValue = relationInfo.RELATIONINFO_MODIFICATIONTIMES;
            this.memoEdit_Note.EditValue = relationInfo.RELATIONINFO_NOTE;
        }

        private void barButtonItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.textEdit_Name.Enabled = true;
            this.textEdit_Code.Enabled = true;
            this.memoEdit_Note.Enabled = true;
            this.textEdit_LastModifiedTime.EditValue = DateTime.Now.ToString();
            this.textEdit_ModificationTimes.EditValue = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);
        }
    }
}
