namespace Core.UI
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_Relation = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Property = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_FX = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_CX = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_LR = new DevExpress.XtraEditors.SimpleButton();
            this.simpleBtn_QA = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleBtn_QA);
            this.panelControl1.Controls.Add(this.simpleButton_Relation);
            this.panelControl1.Controls.Add(this.simpleButton_Property);
            this.panelControl1.Controls.Add(this.simpleButton_FX);
            this.panelControl1.Controls.Add(this.simpleButton_CX);
            this.panelControl1.Controls.Add(this.simpleButton_LR);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1099, 633);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton_Relation
            // 
            this.simpleButton_Relation.Location = new System.Drawing.Point(129, 113);
            this.simpleButton_Relation.Name = "simpleButton_Relation";
            this.simpleButton_Relation.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Relation.TabIndex = 4;
            this.simpleButton_Relation.Text = "关系定义";
            this.simpleButton_Relation.Click += new System.EventHandler(this.simpleButton_Relation_Click);
            // 
            // simpleButton_Property
            // 
            this.simpleButton_Property.Location = new System.Drawing.Point(129, 57);
            this.simpleButton_Property.Name = "simpleButton_Property";
            this.simpleButton_Property.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Property.TabIndex = 3;
            this.simpleButton_Property.Text = "属性定义";
            this.simpleButton_Property.Click += new System.EventHandler(this.simpleButton_Property_Click);
            // 
            // simpleButton_FX
            // 
            this.simpleButton_FX.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.simpleButton_FX.Appearance.Options.UseFont = true;
            this.simpleButton_FX.Location = new System.Drawing.Point(796, 241);
            this.simpleButton_FX.Name = "simpleButton_FX";
            this.simpleButton_FX.Size = new System.Drawing.Size(120, 120);
            this.simpleButton_FX.TabIndex = 2;
            this.simpleButton_FX.Text = "分析";
            // 
            // simpleButton_CX
            // 
            this.simpleButton_CX.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.simpleButton_CX.Appearance.Options.UseFont = true;
            this.simpleButton_CX.Location = new System.Drawing.Point(456, 241);
            this.simpleButton_CX.Name = "simpleButton_CX";
            this.simpleButton_CX.Size = new System.Drawing.Size(120, 120);
            this.simpleButton_CX.TabIndex = 1;
            this.simpleButton_CX.Text = "查询";
            // 
            // simpleButton_LR
            // 
            this.simpleButton_LR.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.simpleButton_LR.Appearance.Options.UseFont = true;
            this.simpleButton_LR.Location = new System.Drawing.Point(129, 241);
            this.simpleButton_LR.Name = "simpleButton_LR";
            this.simpleButton_LR.Size = new System.Drawing.Size(120, 120);
            this.simpleButton_LR.TabIndex = 0;
            this.simpleButton_LR.Text = "录入";
            this.simpleButton_LR.Click += new System.EventHandler(this.simpleButton_LR_Click);
            // 
            // simpleBtn_QA
            // 
            this.simpleBtn_QA.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.simpleBtn_QA.Appearance.Options.UseFont = true;
            this.simpleBtn_QA.Location = new System.Drawing.Point(456, 82);
            this.simpleBtn_QA.Name = "simpleBtn_QA";
            this.simpleBtn_QA.Size = new System.Drawing.Size(120, 107);
            this.simpleBtn_QA.TabIndex = 5;
            this.simpleBtn_QA.Text = "问题集";
            this.simpleBtn_QA.Click += new System.EventHandler(this.simpleBtn_QA_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 633);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_Main";
            this.Text = "主界面";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_FX;
        private DevExpress.XtraEditors.SimpleButton simpleButton_CX;
        private DevExpress.XtraEditors.SimpleButton simpleButton_LR;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Relation;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Property;
        private DevExpress.XtraEditors.SimpleButton simpleBtn_QA;
    }
}