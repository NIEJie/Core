using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.UI
{
    public partial class Frm_Main : XtraForm
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton_LR_Click(object sender, EventArgs e)
        {
            //Frm_EventList eventList = new Frm_EventList();
            //eventList.ShowDialog();
        }

        private void simpleButton_Property_Click(object sender, EventArgs e)
        {
            //Frm_PropertyList propertyList = new Frm_PropertyList();
            //propertyList.ShowDialog();
        }

        private void simpleButton_Relation_Click(object sender, EventArgs e)
        {
            //Frm_RelationList relationList = new Frm_RelationList();
            //relationList.ShowDialog();
        }

        private void simpleBtn_QA_Click(object sender, EventArgs e)
        {
            Core_Enter core = new Core_Enter();
            core.ShowDialog();
        }
    }
}
