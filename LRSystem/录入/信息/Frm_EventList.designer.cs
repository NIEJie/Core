﻿namespace LRSystem
{
    partial class Frm_EventList
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
            this.barButtonItem_CreateType = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_CreateSonType = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_EditType = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Invalid = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_SaveType = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_CreateInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_EditInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Cancel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_OK = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.TreeList_Event = new DevExpress.XtraTreeList.TreeList();
            this.EVENTTYPE_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_CODE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_IFDETAIL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_GRADE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_IFINVALID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_NOTE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_CREATETIME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_LASTMODIFIEDTIME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.EVENTTYPE_MODIFICATIONTIMES = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.NodeType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.memoEdit_Note = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl_modifiedtimes = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_lastmodifiedtime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_createtime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_name = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_code = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_ModificationTimes = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_LastModifiedTime = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_CreateTime = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Name = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Code = new DevExpress.XtraEditors.TextEdit();
            this.EVENTTYPE_PARNETID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_Event)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
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
            this.barButtonItem_CreateType,
            this.barButtonItem_Close,
            this.barButtonItem_EditType,
            this.barButtonItem_Invalid,
            this.barButtonItem_SaveType,
            this.barButtonItem_CreateInfo,
            this.barButtonItem_EditInfo,
            this.barButtonItem_CreateSonType,
            this.barButtonItem_Cancel,
            this.barButtonItem_OK});
            this.barManager1.MaxItemId = 14;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_CreateType),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_CreateSonType),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_EditType),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Invalid),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_SaveType),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_CreateInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_EditInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Cancel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Close),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_OK)});
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barButtonItem_CreateType
            // 
            this.barButtonItem_CreateType.Caption = "新增类型";
            this.barButtonItem_CreateType.Id = 0;
            this.barButtonItem_CreateType.Name = "barButtonItem_CreateType";
            this.barButtonItem_CreateType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_CreateType_ItemClick);
            // 
            // barButtonItem_CreateSonType
            // 
            this.barButtonItem_CreateSonType.Caption = "新增下级类型";
            this.barButtonItem_CreateSonType.Id = 11;
            this.barButtonItem_CreateSonType.Name = "barButtonItem_CreateSonType";
            this.barButtonItem_CreateSonType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_CreateSonType_ItemClick);
            // 
            // barButtonItem_EditType
            // 
            this.barButtonItem_EditType.Caption = "编辑类型";
            this.barButtonItem_EditType.Id = 6;
            this.barButtonItem_EditType.Name = "barButtonItem_EditType";
            this.barButtonItem_EditType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_EditType_ItemClick);
            // 
            // barButtonItem_Invalid
            // 
            this.barButtonItem_Invalid.Caption = "作废";
            this.barButtonItem_Invalid.Id = 7;
            this.barButtonItem_Invalid.Name = "barButtonItem_Invalid";
            this.barButtonItem_Invalid.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Invalid_ItemClick);
            // 
            // barButtonItem_SaveType
            // 
            this.barButtonItem_SaveType.Caption = "保存类型";
            this.barButtonItem_SaveType.Id = 8;
            this.barButtonItem_SaveType.Name = "barButtonItem_SaveType";
            this.barButtonItem_SaveType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_SaveType_ItemClick);
            // 
            // barButtonItem_CreateInfo
            // 
            this.barButtonItem_CreateInfo.Caption = "新增事件";
            this.barButtonItem_CreateInfo.Id = 9;
            this.barButtonItem_CreateInfo.Name = "barButtonItem_CreateInfo";
            this.barButtonItem_CreateInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_CreateInfo_ItemClick);
            // 
            // barButtonItem_EditInfo
            // 
            this.barButtonItem_EditInfo.Caption = "编辑事件";
            this.barButtonItem_EditInfo.Id = 10;
            this.barButtonItem_EditInfo.Name = "barButtonItem_EditInfo";
            this.barButtonItem_EditInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_EditInfo_ItemClick);
            // 
            // barButtonItem_Cancel
            // 
            this.barButtonItem_Cancel.Caption = "取消";
            this.barButtonItem_Cancel.Id = 12;
            this.barButtonItem_Cancel.Name = "barButtonItem_Cancel";
            this.barButtonItem_Cancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Cancel_ItemClick);
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "关闭";
            this.barButtonItem_Close.Id = 5;
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barButtonItem_OK
            // 
            this.barButtonItem_OK.Caption = "确定";
            this.barButtonItem_OK.Id = 13;
            this.barButtonItem_OK.Name = "barButtonItem_OK";
            this.barButtonItem_OK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_OK_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1184, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 688);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1184, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 657);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1184, 31);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 657);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.TreeList_Event);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(337, 657);
            this.panelControl1.TabIndex = 4;
            // 
            // TreeList_Event
            // 
            this.TreeList_Event.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.EVENTTYPE_ID,
            this.EVENTTYPE_CODE,
            this.EVENTTYPE_NAME,
            this.EVENTTYPE_PARNETID,
            this.EVENTTYPE_IFDETAIL,
            this.EVENTTYPE_GRADE,
            this.EVENTTYPE_IFINVALID,
            this.EVENTTYPE_NOTE,
            this.EVENTTYPE_CREATETIME,
            this.EVENTTYPE_LASTMODIFIEDTIME,
            this.EVENTTYPE_MODIFICATIONTIMES,
            this.NodeType});
            this.TreeList_Event.Cursor = System.Windows.Forms.Cursors.Default;
            this.TreeList_Event.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList_Event.KeyFieldName = "EVENTTYPE_ID";
            this.TreeList_Event.Location = new System.Drawing.Point(2, 2);
            this.TreeList_Event.Name = "TreeList_Event";
            this.TreeList_Event.ParentFieldName = "EVENTTYPE_PARENTID";
            this.TreeList_Event.Size = new System.Drawing.Size(333, 653);
            this.TreeList_Event.TabIndex = 0;
            this.TreeList_Event.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.eventTreeList_BeforeFocusNode);
            this.TreeList_Event.AfterFocusNode += new DevExpress.XtraTreeList.NodeEventHandler(this.eventTreeList_AfterFocusNode);
            // 
            // EVENTTYPE_ID
            // 
            this.EVENTTYPE_ID.Caption = "EVENTTYPE_ID";
            this.EVENTTYPE_ID.FieldName = "EVENTTYPE_ID";
            this.EVENTTYPE_ID.Name = "EVENTTYPE_ID";
            // 
            // EVENTTYPE_CODE
            // 
            this.EVENTTYPE_CODE.Caption = "编号";
            this.EVENTTYPE_CODE.FieldName = "EVENTTYPE_CODE";
            this.EVENTTYPE_CODE.Name = "EVENTTYPE_CODE";
            this.EVENTTYPE_CODE.Visible = true;
            this.EVENTTYPE_CODE.VisibleIndex = 0;
            // 
            // EVENTTYPE_NAME
            // 
            this.EVENTTYPE_NAME.Caption = "名称";
            this.EVENTTYPE_NAME.FieldName = "EVENTTYPE_NAME";
            this.EVENTTYPE_NAME.Name = "EVENTTYPE_NAME";
            this.EVENTTYPE_NAME.Visible = true;
            this.EVENTTYPE_NAME.VisibleIndex = 1;
            // 
            // EVENTTYPE_IFDETAIL
            // 
            this.EVENTTYPE_IFDETAIL.Caption = "是否是明细";
            this.EVENTTYPE_IFDETAIL.FieldName = "EVENTTYPE_IFDETAIL";
            this.EVENTTYPE_IFDETAIL.Name = "EVENTTYPE_IFDETAIL";
            // 
            // EVENTTYPE_GRADE
            // 
            this.EVENTTYPE_GRADE.Caption = "级数";
            this.EVENTTYPE_GRADE.FieldName = "EVENTTYPE_GRADE";
            this.EVENTTYPE_GRADE.Name = "EVENTTYPE_GRADE";
            // 
            // EVENTTYPE_IFINVALID
            // 
            this.EVENTTYPE_IFINVALID.Caption = "是否作废";
            this.EVENTTYPE_IFINVALID.FieldName = "EVENTTYPE_IFINVALID";
            this.EVENTTYPE_IFINVALID.Name = "EVENTTYPE_IFINVALID";
            // 
            // EVENTTYPE_NOTE
            // 
            this.EVENTTYPE_NOTE.Caption = "备注";
            this.EVENTTYPE_NOTE.FieldName = "EVENTTYPE_NOTE";
            this.EVENTTYPE_NOTE.Name = "EVENTTYPE_NOTE";
            // 
            // EVENTTYPE_CREATETIME
            // 
            this.EVENTTYPE_CREATETIME.Caption = "创建时间";
            this.EVENTTYPE_CREATETIME.FieldName = "EVENTTYPE_CREATETIME";
            this.EVENTTYPE_CREATETIME.Name = "EVENTTYPE_CREATETIME";
            // 
            // EVENTTYPE_LASTMODIFIEDTIME
            // 
            this.EVENTTYPE_LASTMODIFIEDTIME.Caption = "最后修改时间";
            this.EVENTTYPE_LASTMODIFIEDTIME.FieldName = "EVENTTYPE_LASTMODIFIEDTIME";
            this.EVENTTYPE_LASTMODIFIEDTIME.Name = "EVENTTYPE_LASTMODIFIEDTIME";
            // 
            // EVENTTYPE_MODIFICATIONTIMES
            // 
            this.EVENTTYPE_MODIFICATIONTIMES.Caption = "修改次数";
            this.EVENTTYPE_MODIFICATIONTIMES.FieldName = "EVENTTYPE_MODIFICATIONTIMES";
            this.EVENTTYPE_MODIFICATIONTIMES.Name = "EVENTTYPE_MODIFICATIONTIMES";
            // 
            // NodeType
            // 
            this.NodeType.Caption = "NodeType";
            this.NodeType.FieldName = "NodeType";
            this.NodeType.Name = "NodeType";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(337, 31);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(847, 657);
            this.panelControl2.TabIndex = 5;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.panelControl5);
            this.panelControl4.Controls.Add(this.panelControl3);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(843, 653);
            this.panelControl4.TabIndex = 2;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.memoEdit_Note);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(2, 88);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(839, 563);
            this.panelControl5.TabIndex = 1;
            // 
            // memoEdit_Note
            // 
            this.memoEdit_Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit_Note.Enabled = false;
            this.memoEdit_Note.Location = new System.Drawing.Point(2, 2);
            this.memoEdit_Note.MenuManager = this.barManager1;
            this.memoEdit_Note.Name = "memoEdit_Note";
            this.memoEdit_Note.Size = new System.Drawing.Size(835, 559);
            this.memoEdit_Note.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl_modifiedtimes);
            this.panelControl3.Controls.Add(this.labelControl_lastmodifiedtime);
            this.panelControl3.Controls.Add(this.labelControl_createtime);
            this.panelControl3.Controls.Add(this.labelControl_name);
            this.panelControl3.Controls.Add(this.labelControl_code);
            this.panelControl3.Controls.Add(this.textEdit_ModificationTimes);
            this.panelControl3.Controls.Add(this.textEdit_LastModifiedTime);
            this.panelControl3.Controls.Add(this.textEdit_CreateTime);
            this.panelControl3.Controls.Add(this.textEdit_Name);
            this.panelControl3.Controls.Add(this.textEdit_Code);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(839, 86);
            this.panelControl3.TabIndex = 0;
            // 
            // labelControl_modifiedtimes
            // 
            this.labelControl_modifiedtimes.Location = new System.Drawing.Point(535, 5);
            this.labelControl_modifiedtimes.Name = "labelControl_modifiedtimes";
            this.labelControl_modifiedtimes.Size = new System.Drawing.Size(48, 14);
            this.labelControl_modifiedtimes.TabIndex = 10;
            this.labelControl_modifiedtimes.Text = "修改次数";
            // 
            // labelControl_lastmodifiedtime
            // 
            this.labelControl_lastmodifiedtime.Location = new System.Drawing.Point(423, 39);
            this.labelControl_lastmodifiedtime.Name = "labelControl_lastmodifiedtime";
            this.labelControl_lastmodifiedtime.Size = new System.Drawing.Size(72, 14);
            this.labelControl_lastmodifiedtime.TabIndex = 9;
            this.labelControl_lastmodifiedtime.Text = "最后修改时间";
            // 
            // labelControl_createtime
            // 
            this.labelControl_createtime.Location = new System.Drawing.Point(76, 39);
            this.labelControl_createtime.Name = "labelControl_createtime";
            this.labelControl_createtime.Size = new System.Drawing.Size(48, 14);
            this.labelControl_createtime.TabIndex = 8;
            this.labelControl_createtime.Text = "创建时间";
            // 
            // labelControl_name
            // 
            this.labelControl_name.Location = new System.Drawing.Point(307, 5);
            this.labelControl_name.Name = "labelControl_name";
            this.labelControl_name.Size = new System.Drawing.Size(24, 14);
            this.labelControl_name.TabIndex = 7;
            this.labelControl_name.Text = "名称";
            // 
            // labelControl_code
            // 
            this.labelControl_code.Location = new System.Drawing.Point(42, 5);
            this.labelControl_code.Name = "labelControl_code";
            this.labelControl_code.Size = new System.Drawing.Size(24, 14);
            this.labelControl_code.TabIndex = 6;
            this.labelControl_code.Text = "编号";
            // 
            // textEdit_ModificationTimes
            // 
            this.textEdit_ModificationTimes.Enabled = false;
            this.textEdit_ModificationTimes.Location = new System.Drawing.Point(606, 2);
            this.textEdit_ModificationTimes.MenuManager = this.barManager1;
            this.textEdit_ModificationTimes.Name = "textEdit_ModificationTimes";
            this.textEdit_ModificationTimes.Size = new System.Drawing.Size(100, 20);
            this.textEdit_ModificationTimes.TabIndex = 4;
            // 
            // textEdit_LastModifiedTime
            // 
            this.textEdit_LastModifiedTime.Enabled = false;
            this.textEdit_LastModifiedTime.Location = new System.Drawing.Point(511, 36);
            this.textEdit_LastModifiedTime.MenuManager = this.barManager1;
            this.textEdit_LastModifiedTime.Name = "textEdit_LastModifiedTime";
            this.textEdit_LastModifiedTime.Size = new System.Drawing.Size(200, 20);
            this.textEdit_LastModifiedTime.TabIndex = 3;
            // 
            // textEdit_CreateTime
            // 
            this.textEdit_CreateTime.Enabled = false;
            this.textEdit_CreateTime.Location = new System.Drawing.Point(143, 36);
            this.textEdit_CreateTime.MenuManager = this.barManager1;
            this.textEdit_CreateTime.Name = "textEdit_CreateTime";
            this.textEdit_CreateTime.Size = new System.Drawing.Size(200, 20);
            this.textEdit_CreateTime.TabIndex = 2;
            // 
            // textEdit_Name
            // 
            this.textEdit_Name.Enabled = false;
            this.textEdit_Name.Location = new System.Drawing.Point(395, 2);
            this.textEdit_Name.MenuManager = this.barManager1;
            this.textEdit_Name.Name = "textEdit_Name";
            this.textEdit_Name.Size = new System.Drawing.Size(100, 20);
            this.textEdit_Name.TabIndex = 1;
            // 
            // textEdit_Code
            // 
            this.textEdit_Code.Enabled = false;
            this.textEdit_Code.Location = new System.Drawing.Point(109, 2);
            this.textEdit_Code.MenuManager = this.barManager1;
            this.textEdit_Code.Name = "textEdit_Code";
            this.textEdit_Code.Size = new System.Drawing.Size(100, 20);
            this.textEdit_Code.TabIndex = 0;
            // 
            // EVENTTYPE_PARNETID
            // 
            this.EVENTTYPE_PARNETID.Caption = "父节点ID";
            this.EVENTTYPE_PARNETID.FieldName = "EVENTTYPE_PARNETID";
            this.EVENTTYPE_PARNETID.Name = "EVENTTYPE_PARNETID";
            // 
            // Frm_EventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 688);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_EventList";
            this.Text = "事件列表";
            this.Load += new System.EventHandler(this.Frm_EventList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_Event)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CreateType;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList TreeList_Event;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_CODE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_IFDETAIL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_GRADE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_NOTE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_CREATETIME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_LASTMODIFIEDTIME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_MODIFICATIONTIMES;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit textEdit_Name;
        private DevExpress.XtraEditors.TextEdit textEdit_Code;
        private DevExpress.XtraTreeList.Columns.TreeListColumn NodeType;
        private DevExpress.XtraEditors.TextEdit textEdit_ModificationTimes;
        private DevExpress.XtraEditors.TextEdit textEdit_LastModifiedTime;
        private DevExpress.XtraEditors.TextEdit textEdit_CreateTime;
        private DevExpress.XtraEditors.LabelControl labelControl_modifiedtimes;
        private DevExpress.XtraEditors.LabelControl labelControl_lastmodifiedtime;
        private DevExpress.XtraEditors.LabelControl labelControl_createtime;
        private DevExpress.XtraEditors.LabelControl labelControl_name;
        private DevExpress.XtraEditors.LabelControl labelControl_code;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Note;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_EditType;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Invalid;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_SaveType;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CreateInfo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_EditInfo;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_CreateSonType;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Cancel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_IFINVALID;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_OK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn EVENTTYPE_PARNETID;
    }
}