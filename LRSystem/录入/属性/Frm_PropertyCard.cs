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

namespace LRSystem.录入.属性
{
    public partial class Frm_PropertyCard : XtraForm
    {
        #region 变量
        private PropertyClient propertyClient = new PropertyClient();
        public MyPropertyInfo propertyInfo = new MyPropertyInfo();
        #endregion

        public Frm_PropertyCard()
        {
            InitializeComponent();
        }

        private void barButtonItem_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(false);
            propertyInfo.PROPERTYINFO_CODE = this.textEdit_Code.EditValue.ToString();
            propertyInfo.PROPERTYINFO_NAME = this.textEdit_Name.EditValue.ToString();
            propertyInfo.PROPERTYINFO_NOTE = this.memoEdit_Note.EditValue.ToString();
            propertyInfo.PROPERTYINFO_LASTMODIFIEDTIME = DateTime.Now.ToString();
            propertyInfo.PROPERTYINFO_MODIFICATIONTIMES = Convert.ToString(Convert.ToInt32(this.textEdit_ModificationTimes.EditValue) + 1);
            if (propertyClient.SavePropertyInfoCard(propertyInfo))
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

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Frm_PropertyCard_Load(object sender, EventArgs e)
        {
            this.textEdit_Name.EditValue = propertyInfo.PROPERTYINFO_NAME;
            this.textEdit_Code.EditValue = propertyInfo.PROPERTYINFO_CODE;
            this.textEdit_CreateTime.EditValue = propertyInfo.PROPERTYINFO_CREATETIME;
            this.textEdit_LastModifiedTime.EditValue = propertyInfo.PROPERTYINFO_LASTMODIFIEDTIME;
            this.textEdit_ModificationTimes.EditValue = propertyInfo.PROPERTYINFO_MODIFICATIONTIMES;
            this.memoEdit_Note.EditValue = propertyInfo.PROPERTYINFO_NOTE;
        }

        private void barButtonItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            changeState(true);
            
        }

        //修改卡片状态
        private void changeState(bool state)
        {
            this.textEdit_Name.Enabled = state;
            this.textEdit_Code.Enabled = state;
            this.memoEdit_Note.Enabled = state;
        }
    }
}
