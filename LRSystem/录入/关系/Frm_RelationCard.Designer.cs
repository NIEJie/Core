namespace LRSystem.录入.关系
{
    partial class Frm_RelationCard
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Save = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.memoEdit_Note = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl_ModificationTimes = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_ModificationTimes = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_LastModifiedTime = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_LastModifiedTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_CreateTime = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_CreateTime = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_Name = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_Code = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Code = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ModificationTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_LastModifiedTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Code.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Save,
            this.barButtonItem_Close,
            this.barButtonItem_Edit});
            this.barManager1.MaxItemId = 3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Edit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Save),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Close)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barButtonItem_Edit
            // 
            this.barButtonItem_Edit.Caption = "编辑";
            this.barButtonItem_Edit.Id = 2;
            this.barButtonItem_Edit.Name = "barButtonItem_Edit";
            this.barButtonItem_Edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Edit_ItemClick);
            // 
            // barButtonItem_Save
            // 
            this.barButtonItem_Save.Caption = "保存";
            this.barButtonItem_Save.Id = 0;
            this.barButtonItem_Save.Name = "barButtonItem_Save";
            this.barButtonItem_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Save_ItemClick);
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "关闭";
            this.barButtonItem_Close.Id = 1;
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1131, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 597);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1131, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 566);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1131, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 566);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.memoEdit_Note);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1131, 120);
            this.panelControl1.TabIndex = 4;
            // 
            // memoEdit_Note
            // 
            this.memoEdit_Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit_Note.Location = new System.Drawing.Point(2, 2);
            this.memoEdit_Note.MenuManager = this.barManager1;
            this.memoEdit_Note.Name = "memoEdit_Note";
            this.memoEdit_Note.Size = new System.Drawing.Size(1127, 116);
            this.memoEdit_Note.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl_ModificationTimes);
            this.panelControl2.Controls.Add(this.textEdit_ModificationTimes);
            this.panelControl2.Controls.Add(this.labelControl_LastModifiedTime);
            this.panelControl2.Controls.Add(this.textEdit_LastModifiedTime);
            this.panelControl2.Controls.Add(this.labelControl_CreateTime);
            this.panelControl2.Controls.Add(this.textEdit_CreateTime);
            this.panelControl2.Controls.Add(this.labelControl_Name);
            this.panelControl2.Controls.Add(this.textEdit_Name);
            this.panelControl2.Controls.Add(this.labelControl_Code);
            this.panelControl2.Controls.Add(this.textEdit_Code);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 151);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1131, 446);
            this.panelControl2.TabIndex = 5;
            // 
            // labelControl_ModificationTimes
            // 
            this.labelControl_ModificationTimes.Location = new System.Drawing.Point(739, 34);
            this.labelControl_ModificationTimes.Name = "labelControl_ModificationTimes";
            this.labelControl_ModificationTimes.Size = new System.Drawing.Size(48, 14);
            this.labelControl_ModificationTimes.TabIndex = 9;
            this.labelControl_ModificationTimes.Text = "修改次数";
            // 
            // textEdit_ModificationTimes
            // 
            this.textEdit_ModificationTimes.Enabled = false;
            this.textEdit_ModificationTimes.Location = new System.Drawing.Point(802, 31);
            this.textEdit_ModificationTimes.MenuManager = this.barManager1;
            this.textEdit_ModificationTimes.Name = "textEdit_ModificationTimes";
            this.textEdit_ModificationTimes.Size = new System.Drawing.Size(100, 20);
            this.textEdit_ModificationTimes.TabIndex = 8;
            // 
            // labelControl_LastModifiedTime
            // 
            this.labelControl_LastModifiedTime.Location = new System.Drawing.Point(530, 34);
            this.labelControl_LastModifiedTime.Name = "labelControl_LastModifiedTime";
            this.labelControl_LastModifiedTime.Size = new System.Drawing.Size(72, 14);
            this.labelControl_LastModifiedTime.TabIndex = 7;
            this.labelControl_LastModifiedTime.Text = "最后修改时间";
            // 
            // textEdit_LastModifiedTime
            // 
            this.textEdit_LastModifiedTime.Enabled = false;
            this.textEdit_LastModifiedTime.Location = new System.Drawing.Point(619, 31);
            this.textEdit_LastModifiedTime.MenuManager = this.barManager1;
            this.textEdit_LastModifiedTime.Name = "textEdit_LastModifiedTime";
            this.textEdit_LastModifiedTime.Size = new System.Drawing.Size(100, 20);
            this.textEdit_LastModifiedTime.TabIndex = 6;
            // 
            // labelControl_CreateTime
            // 
            this.labelControl_CreateTime.Location = new System.Drawing.Point(354, 34);
            this.labelControl_CreateTime.Name = "labelControl_CreateTime";
            this.labelControl_CreateTime.Size = new System.Drawing.Size(48, 14);
            this.labelControl_CreateTime.TabIndex = 5;
            this.labelControl_CreateTime.Text = "创建时间";
            // 
            // textEdit_CreateTime
            // 
            this.textEdit_CreateTime.Enabled = false;
            this.textEdit_CreateTime.Location = new System.Drawing.Point(408, 31);
            this.textEdit_CreateTime.MenuManager = this.barManager1;
            this.textEdit_CreateTime.Name = "textEdit_CreateTime";
            this.textEdit_CreateTime.Size = new System.Drawing.Size(100, 20);
            this.textEdit_CreateTime.TabIndex = 4;
            // 
            // labelControl_Name
            // 
            this.labelControl_Name.Location = new System.Drawing.Point(206, 34);
            this.labelControl_Name.Name = "labelControl_Name";
            this.labelControl_Name.Size = new System.Drawing.Size(24, 14);
            this.labelControl_Name.TabIndex = 3;
            this.labelControl_Name.Text = "名称";
            // 
            // textEdit_Name
            // 
            this.textEdit_Name.Enabled = false;
            this.textEdit_Name.Location = new System.Drawing.Point(236, 31);
            this.textEdit_Name.MenuManager = this.barManager1;
            this.textEdit_Name.Name = "textEdit_Name";
            this.textEdit_Name.Size = new System.Drawing.Size(100, 20);
            this.textEdit_Name.TabIndex = 2;
            // 
            // labelControl_Code
            // 
            this.labelControl_Code.Location = new System.Drawing.Point(42, 34);
            this.labelControl_Code.Name = "labelControl_Code";
            this.labelControl_Code.Size = new System.Drawing.Size(24, 14);
            this.labelControl_Code.TabIndex = 1;
            this.labelControl_Code.Text = "编号";
            // 
            // textEdit_Code
            // 
            this.textEdit_Code.Enabled = false;
            this.textEdit_Code.Location = new System.Drawing.Point(72, 31);
            this.textEdit_Code.MenuManager = this.barManager1;
            this.textEdit_Code.Name = "textEdit_Code";
            this.textEdit_Code.Size = new System.Drawing.Size(100, 20);
            this.textEdit_Code.TabIndex = 0;
            // 
            // Frm_RelationCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 597);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_RelationCard";
            this.Text = "Frm_RelationCard";
            this.Load += new System.EventHandler(this.Frm_RelationCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ModificationTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_LastModifiedTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Code.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl_ModificationTimes;
        private DevExpress.XtraEditors.TextEdit textEdit_ModificationTimes;
        private DevExpress.XtraEditors.LabelControl labelControl_LastModifiedTime;
        private DevExpress.XtraEditors.TextEdit textEdit_LastModifiedTime;
        private DevExpress.XtraEditors.LabelControl labelControl_CreateTime;
        private DevExpress.XtraEditors.TextEdit textEdit_CreateTime;
        private DevExpress.XtraEditors.LabelControl labelControl_Name;
        private DevExpress.XtraEditors.TextEdit textEdit_Name;
        private DevExpress.XtraEditors.LabelControl labelControl_Code;
        private DevExpress.XtraEditors.TextEdit textEdit_Code;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Note;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Save;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Edit;
    }
}