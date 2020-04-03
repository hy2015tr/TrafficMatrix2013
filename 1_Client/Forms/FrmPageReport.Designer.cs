namespace TrafficMatrix2013
{
    partial class FrmPageReport
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
            this.grpSelection = new DevExpress.XtraEditors.GroupControl();
            this.btnList = new DevExpress.XtraEditors.SimpleButton();
            this.lbStartFinish = new DevExpress.XtraEditors.LabelControl();
            this.btnClearList = new DevExpress.XtraEditors.SimpleButton();
            this.ListDT02 = new DevExpress.XtraEditors.DateEdit();
            this.ListDT01 = new DevExpress.XtraEditors.DateEdit();
            this.TabMain = new DevExpress.XtraTab.XtraTabControl();
            this.page01 = new DevExpress.XtraTab.XtraTabPage();
            this.grd_DataCC = new DevExpress.XtraGrid.GridControl();
            this.grdView_DataCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.page02 = new DevExpress.XtraTab.XtraTabPage();
            this.grd_DataDD = new DevExpress.XtraGrid.GridControl();
            this.grdView_DataDD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.page03 = new DevExpress.XtraTab.XtraTabPage();
            this.grd_DataSS = new DevExpress.XtraGrid.GridControl();
            this.grdView_DataSS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.page04 = new DevExpress.XtraTab.XtraTabPage();
            this.grd_MatrixCC = new DevExpress.XtraGrid.GridControl();
            this.grdView_MatrixCC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.page05 = new DevExpress.XtraTab.XtraTabPage();
            this.grd_MatrixDD = new DevExpress.XtraGrid.GridControl();
            this.grdView_MatrixDD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.page06 = new DevExpress.XtraTab.XtraTabPage();
            this.grd_MatrixSS = new DevExpress.XtraGrid.GridControl();
            this.grdView_MatrixSS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnGap = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpSelection)).BeginInit();
            this.grpSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT02.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT02.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT01.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT01.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).BeginInit();
            this.TabMain.SuspendLayout();
            this.page01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DataCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_DataCC)).BeginInit();
            this.page02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DataDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_DataDD)).BeginInit();
            this.page03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DataSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_DataSS)).BeginInit();
            this.page04.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_MatrixCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_MatrixCC)).BeginInit();
            this.page05.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_MatrixDD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_MatrixDD)).BeginInit();
            this.page06.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_MatrixSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_MatrixSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnGap)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSelection
            // 
            this.grpSelection.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSelection.AppearanceCaption.Options.UseFont = true;
            this.grpSelection.AppearanceCaption.Options.UseTextOptions = true;
            this.grpSelection.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpSelection.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpSelection.Controls.Add(this.btnList);
            this.grpSelection.Controls.Add(this.lbStartFinish);
            this.grpSelection.Controls.Add(this.btnClearList);
            this.grpSelection.Controls.Add(this.ListDT02);
            this.grpSelection.Controls.Add(this.ListDT01);
            this.grpSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSelection.Location = new System.Drawing.Point(10, 10);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(1043, 121);
            this.grpSelection.TabIndex = 9;
            this.grpSelection.Text = "Parameters";
            // 
            // btnList
            // 
            this.btnList.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnList.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnList.Appearance.Options.UseFont = true;
            this.btnList.Appearance.Options.UseForeColor = true;
            this.btnList.Location = new System.Drawing.Point(532, 43);
            this.btnList.LookAndFeel.SkinName = "Glass Oceans";
            this.btnList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 34);
            this.btnList.TabIndex = 62;
            this.btnList.Tag = "ActionButton";
            this.btnList.Text = "List";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // lbStartFinish
            // 
            this.lbStartFinish.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbStartFinish.Location = new System.Drawing.Point(45, 52);
            this.lbStartFinish.Name = "lbStartFinish";
            this.lbStartFinish.Size = new System.Drawing.Size(89, 14);
            this.lbStartFinish.TabIndex = 61;
            this.lbStartFinish.Text = "Start / Finish :";
            // 
            // btnClearList
            // 
            this.btnClearList.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClearList.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClearList.Appearance.Options.UseFont = true;
            this.btnClearList.Appearance.Options.UseForeColor = true;
            this.btnClearList.Location = new System.Drawing.Point(638, 45);
            this.btnClearList.LookAndFeel.SkinName = "Sharp";
            this.btnClearList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(100, 30);
            this.btnClearList.TabIndex = 60;
            this.btnClearList.Tag = "";
            this.btnClearList.Text = "Clear";
            this.btnClearList.ToolTip = "Ctrl + Enter";
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // ListDT02
            // 
            this.ListDT02.EditValue = new System.DateTime(2012, 9, 28, 17, 1, 16, 88);
            this.ListDT02.Location = new System.Drawing.Point(328, 49);
            this.ListDT02.Name = "ListDT02";
            this.ListDT02.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.ListDT02.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ListDT02.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ListDT02.Properties.Appearance.Options.UseBackColor = true;
            this.ListDT02.Properties.Appearance.Options.UseFont = true;
            this.ListDT02.Properties.Appearance.Options.UseForeColor = true;
            this.ListDT02.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.ListDT02.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.ListDT02.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ListDT02.Properties.DisplayFormat.FormatString = "G";
            this.ListDT02.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ListDT02.Properties.EditFormat.FormatString = "G";
            this.ListDT02.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ListDT02.Properties.Mask.EditMask = "G";
            this.ListDT02.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ListDT02.Size = new System.Drawing.Size(170, 20);
            this.ListDT02.TabIndex = 59;
            // 
            // ListDT01
            // 
            this.ListDT01.EditValue = new System.DateTime(2012, 9, 28, 17, 1, 16, 88);
            this.ListDT01.Location = new System.Drawing.Point(152, 49);
            this.ListDT01.Name = "ListDT01";
            this.ListDT01.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.ListDT01.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ListDT01.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ListDT01.Properties.Appearance.Options.UseBackColor = true;
            this.ListDT01.Properties.Appearance.Options.UseFont = true;
            this.ListDT01.Properties.Appearance.Options.UseForeColor = true;
            this.ListDT01.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.ListDT01.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.ListDT01.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ListDT01.Properties.DisplayFormat.FormatString = "G";
            this.ListDT01.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ListDT01.Properties.EditFormat.FormatString = "G";
            this.ListDT01.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ListDT01.Properties.Mask.EditMask = "G";
            this.ListDT01.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ListDT01.Size = new System.Drawing.Size(170, 20);
            this.ListDT01.TabIndex = 58;
            // 
            // TabMain
            // 
            this.TabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TabMain.AppearancePage.Header.Options.UseFont = true;
            this.TabMain.AppearancePage.Header.Options.UseTextOptions = true;
            this.TabMain.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(10, 146);
            this.TabMain.LookAndFeel.SkinName = "McSkin";
            this.TabMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedTabPage = this.page01;
            this.TabMain.Size = new System.Drawing.Size(1043, 505);
            this.TabMain.TabIndex = 11;
            this.TabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.page01,
            this.page02,
            this.page03,
            this.page04,
            this.page05,
            this.page06});
            this.TabMain.TabPageWidth = 140;
            // 
            // page01
            // 
            this.page01.Controls.Add(this.grd_DataCC);
            this.page01.Name = "page01";
            this.page01.Size = new System.Drawing.Size(1035, 472);
            this.page01.Text = "DATA  ( C )";
            // 
            // grd_DataCC
            // 
            this.grd_DataCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_DataCC.Location = new System.Drawing.Point(0, 0);
            this.grd_DataCC.LookAndFeel.SkinName = "Office 2010 Black";
            this.grd_DataCC.MainView = this.grdView_DataCC;
            this.grd_DataCC.Name = "grd_DataCC";
            this.grd_DataCC.Size = new System.Drawing.Size(1035, 472);
            this.grd_DataCC.TabIndex = 10;
            this.grd_DataCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView_DataCC});
            // 
            // grdView_DataCC
            // 
            this.grdView_DataCC.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataCC.Appearance.FooterPanel.Options.UseFont = true;
            this.grdView_DataCC.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataCC.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdView_DataCC.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataCC.Appearance.Row.Options.UseFont = true;
            this.grdView_DataCC.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataCC.Appearance.ViewCaption.Options.UseFont = true;
            this.grdView_DataCC.GridControl = this.grd_DataCC;
            this.grdView_DataCC.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdView_DataCC.Name = "grdView_DataCC";
            this.grdView_DataCC.OptionsBehavior.Editable = false;
            this.grdView_DataCC.OptionsBehavior.ReadOnly = true;
            this.grdView_DataCC.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdView_DataCC.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdView_DataCC.OptionsLayout.Columns.StoreAppearance = true;
            this.grdView_DataCC.OptionsLayout.StoreAllOptions = true;
            this.grdView_DataCC.OptionsLayout.StoreAppearance = true;
            this.grdView_DataCC.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView_DataCC.OptionsSelection.MultiSelect = true;
            this.grdView_DataCC.OptionsView.EnableAppearanceOddRow = true;
            this.grdView_DataCC.OptionsView.ShowAutoFilterRow = true;
            this.grdView_DataCC.ViewCaption = "RAW DATA";
            this.grdView_DataCC.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdViewALL_CustomDrawCell);
            // 
            // page02
            // 
            this.page02.Controls.Add(this.grd_DataDD);
            this.page02.Name = "page02";
            this.page02.Size = new System.Drawing.Size(1035, 472);
            this.page02.Text = "DATA  ( D )";
            // 
            // grd_DataDD
            // 
            this.grd_DataDD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_DataDD.Location = new System.Drawing.Point(0, 0);
            this.grd_DataDD.LookAndFeel.SkinName = "Office 2010 Black";
            this.grd_DataDD.MainView = this.grdView_DataDD;
            this.grd_DataDD.Name = "grd_DataDD";
            this.grd_DataDD.Size = new System.Drawing.Size(1035, 472);
            this.grd_DataDD.TabIndex = 11;
            this.grd_DataDD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView_DataDD});
            // 
            // grdView_DataDD
            // 
            this.grdView_DataDD.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataDD.Appearance.FooterPanel.Options.UseFont = true;
            this.grdView_DataDD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataDD.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdView_DataDD.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataDD.Appearance.Row.Options.UseFont = true;
            this.grdView_DataDD.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataDD.Appearance.ViewCaption.Options.UseFont = true;
            this.grdView_DataDD.GridControl = this.grd_DataDD;
            this.grdView_DataDD.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdView_DataDD.Name = "grdView_DataDD";
            this.grdView_DataDD.OptionsBehavior.Editable = false;
            this.grdView_DataDD.OptionsBehavior.ReadOnly = true;
            this.grdView_DataDD.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdView_DataDD.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdView_DataDD.OptionsLayout.Columns.StoreAppearance = true;
            this.grdView_DataDD.OptionsLayout.StoreAllOptions = true;
            this.grdView_DataDD.OptionsLayout.StoreAppearance = true;
            this.grdView_DataDD.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView_DataDD.OptionsSelection.MultiSelect = true;
            this.grdView_DataDD.OptionsView.EnableAppearanceOddRow = true;
            this.grdView_DataDD.OptionsView.ShowAutoFilterRow = true;
            this.grdView_DataDD.ViewCaption = "RAW DATA";
            this.grdView_DataDD.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdViewALL_CustomDrawCell);
            // 
            // page03
            // 
            this.page03.Controls.Add(this.grd_DataSS);
            this.page03.Name = "page03";
            this.page03.Size = new System.Drawing.Size(1035, 472);
            this.page03.Text = "DATA  ( S )";
            // 
            // grd_DataSS
            // 
            this.grd_DataSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_DataSS.Location = new System.Drawing.Point(0, 0);
            this.grd_DataSS.LookAndFeel.SkinName = "Office 2010 Black";
            this.grd_DataSS.MainView = this.grdView_DataSS;
            this.grd_DataSS.Name = "grd_DataSS";
            this.grd_DataSS.Size = new System.Drawing.Size(1035, 472);
            this.grd_DataSS.TabIndex = 12;
            this.grd_DataSS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView_DataSS});
            // 
            // grdView_DataSS
            // 
            this.grdView_DataSS.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataSS.Appearance.FooterPanel.Options.UseFont = true;
            this.grdView_DataSS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataSS.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdView_DataSS.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataSS.Appearance.Row.Options.UseFont = true;
            this.grdView_DataSS.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_DataSS.Appearance.ViewCaption.Options.UseFont = true;
            this.grdView_DataSS.GridControl = this.grd_DataSS;
            this.grdView_DataSS.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdView_DataSS.Name = "grdView_DataSS";
            this.grdView_DataSS.OptionsBehavior.Editable = false;
            this.grdView_DataSS.OptionsBehavior.ReadOnly = true;
            this.grdView_DataSS.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdView_DataSS.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdView_DataSS.OptionsLayout.Columns.StoreAppearance = true;
            this.grdView_DataSS.OptionsLayout.StoreAllOptions = true;
            this.grdView_DataSS.OptionsLayout.StoreAppearance = true;
            this.grdView_DataSS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView_DataSS.OptionsSelection.MultiSelect = true;
            this.grdView_DataSS.OptionsView.EnableAppearanceOddRow = true;
            this.grdView_DataSS.OptionsView.ShowAutoFilterRow = true;
            this.grdView_DataSS.ViewCaption = "RAW DATA";
            this.grdView_DataSS.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdViewALL_CustomDrawCell);
            // 
            // page04
            // 
            this.page04.Controls.Add(this.grd_MatrixCC);
            this.page04.Name = "page04";
            this.page04.Size = new System.Drawing.Size(1035, 472);
            this.page04.Text = "MATRIX  ( C )";
            // 
            // grd_MatrixCC
            // 
            this.grd_MatrixCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_MatrixCC.Location = new System.Drawing.Point(0, 0);
            this.grd_MatrixCC.LookAndFeel.SkinName = "Office 2010 Black";
            this.grd_MatrixCC.MainView = this.grdView_MatrixCC;
            this.grd_MatrixCC.Name = "grd_MatrixCC";
            this.grd_MatrixCC.Size = new System.Drawing.Size(1035, 472);
            this.grd_MatrixCC.TabIndex = 13;
            this.grd_MatrixCC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView_MatrixCC});
            // 
            // grdView_MatrixCC
            // 
            this.grdView_MatrixCC.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixCC.Appearance.FooterPanel.Options.UseFont = true;
            this.grdView_MatrixCC.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixCC.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdView_MatrixCC.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixCC.Appearance.Row.Options.UseFont = true;
            this.grdView_MatrixCC.Appearance.Row.Options.UseTextOptions = true;
            this.grdView_MatrixCC.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdView_MatrixCC.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixCC.Appearance.ViewCaption.Options.UseFont = true;
            this.grdView_MatrixCC.GridControl = this.grd_MatrixCC;
            this.grdView_MatrixCC.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdView_MatrixCC.Name = "grdView_MatrixCC";
            this.grdView_MatrixCC.OptionsBehavior.Editable = false;
            this.grdView_MatrixCC.OptionsBehavior.ReadOnly = true;
            this.grdView_MatrixCC.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdView_MatrixCC.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdView_MatrixCC.OptionsLayout.Columns.StoreAppearance = true;
            this.grdView_MatrixCC.OptionsLayout.StoreAllOptions = true;
            this.grdView_MatrixCC.OptionsLayout.StoreAppearance = true;
            this.grdView_MatrixCC.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView_MatrixCC.OptionsSelection.MultiSelect = true;
            this.grdView_MatrixCC.OptionsView.EnableAppearanceOddRow = true;
            this.grdView_MatrixCC.OptionsView.ShowAutoFilterRow = true;
            this.grdView_MatrixCC.ViewCaption = "RAW DATA";
            // 
            // page05
            // 
            this.page05.Controls.Add(this.grd_MatrixDD);
            this.page05.Name = "page05";
            this.page05.Size = new System.Drawing.Size(1035, 472);
            this.page05.Text = "MATRIX  ( D )";
            // 
            // grd_MatrixDD
            // 
            this.grd_MatrixDD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_MatrixDD.Location = new System.Drawing.Point(0, 0);
            this.grd_MatrixDD.LookAndFeel.SkinName = "Office 2010 Black";
            this.grd_MatrixDD.MainView = this.grdView_MatrixDD;
            this.grd_MatrixDD.Name = "grd_MatrixDD";
            this.grd_MatrixDD.Size = new System.Drawing.Size(1035, 472);
            this.grd_MatrixDD.TabIndex = 14;
            this.grd_MatrixDD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView_MatrixDD});
            // 
            // grdView_MatrixDD
            // 
            this.grdView_MatrixDD.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixDD.Appearance.FooterPanel.Options.UseFont = true;
            this.grdView_MatrixDD.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixDD.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdView_MatrixDD.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixDD.Appearance.Row.Options.UseFont = true;
            this.grdView_MatrixDD.Appearance.Row.Options.UseTextOptions = true;
            this.grdView_MatrixDD.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdView_MatrixDD.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixDD.Appearance.ViewCaption.Options.UseFont = true;
            this.grdView_MatrixDD.GridControl = this.grd_MatrixDD;
            this.grdView_MatrixDD.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdView_MatrixDD.Name = "grdView_MatrixDD";
            this.grdView_MatrixDD.OptionsBehavior.Editable = false;
            this.grdView_MatrixDD.OptionsBehavior.ReadOnly = true;
            this.grdView_MatrixDD.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdView_MatrixDD.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdView_MatrixDD.OptionsLayout.Columns.StoreAppearance = true;
            this.grdView_MatrixDD.OptionsLayout.StoreAllOptions = true;
            this.grdView_MatrixDD.OptionsLayout.StoreAppearance = true;
            this.grdView_MatrixDD.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView_MatrixDD.OptionsSelection.MultiSelect = true;
            this.grdView_MatrixDD.OptionsView.EnableAppearanceOddRow = true;
            this.grdView_MatrixDD.OptionsView.ShowAutoFilterRow = true;
            this.grdView_MatrixDD.ViewCaption = "RAW DATA";
            // 
            // page06
            // 
            this.page06.Controls.Add(this.grd_MatrixSS);
            this.page06.Name = "page06";
            this.page06.Size = new System.Drawing.Size(1035, 472);
            this.page06.Text = "MATRIX  ( S )";
            // 
            // grd_MatrixSS
            // 
            this.grd_MatrixSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd_MatrixSS.Location = new System.Drawing.Point(0, 0);
            this.grd_MatrixSS.LookAndFeel.SkinName = "Office 2010 Black";
            this.grd_MatrixSS.MainView = this.grdView_MatrixSS;
            this.grd_MatrixSS.Name = "grd_MatrixSS";
            this.grd_MatrixSS.Size = new System.Drawing.Size(1035, 472);
            this.grd_MatrixSS.TabIndex = 15;
            this.grd_MatrixSS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdView_MatrixSS});
            // 
            // grdView_MatrixSS
            // 
            this.grdView_MatrixSS.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixSS.Appearance.FooterPanel.Options.UseFont = true;
            this.grdView_MatrixSS.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixSS.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdView_MatrixSS.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixSS.Appearance.Row.Options.UseFont = true;
            this.grdView_MatrixSS.Appearance.Row.Options.UseTextOptions = true;
            this.grdView_MatrixSS.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdView_MatrixSS.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdView_MatrixSS.Appearance.ViewCaption.Options.UseFont = true;
            this.grdView_MatrixSS.GridControl = this.grd_MatrixSS;
            this.grdView_MatrixSS.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdView_MatrixSS.Name = "grdView_MatrixSS";
            this.grdView_MatrixSS.OptionsBehavior.Editable = false;
            this.grdView_MatrixSS.OptionsBehavior.ReadOnly = true;
            this.grdView_MatrixSS.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdView_MatrixSS.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdView_MatrixSS.OptionsLayout.Columns.StoreAppearance = true;
            this.grdView_MatrixSS.OptionsLayout.StoreAllOptions = true;
            this.grdView_MatrixSS.OptionsLayout.StoreAppearance = true;
            this.grdView_MatrixSS.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdView_MatrixSS.OptionsSelection.MultiSelect = true;
            this.grdView_MatrixSS.OptionsView.EnableAppearanceOddRow = true;
            this.grdView_MatrixSS.OptionsView.ShowAutoFilterRow = true;
            this.grdView_MatrixSS.ViewCaption = "RAW DATA";
            // 
            // pnGap
            // 
            this.pnGap.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnGap.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnGap.Location = new System.Drawing.Point(10, 131);
            this.pnGap.Name = "pnGap";
            this.pnGap.Size = new System.Drawing.Size(1043, 15);
            this.pnGap.TabIndex = 12;
            // 
            // FrmPageReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 661);
            this.Controls.Add(this.TabMain);
            this.Controls.Add(this.pnGap);
            this.Controls.Add(this.grpSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPageReport";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmPage01";
            ((System.ComponentModel.ISupportInitialize)(this.grpSelection)).EndInit();
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT02.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT02.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT01.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListDT01.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).EndInit();
            this.TabMain.ResumeLayout(false);
            this.page01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DataCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_DataCC)).EndInit();
            this.page02.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DataDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_DataDD)).EndInit();
            this.page03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_DataSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_DataSS)).EndInit();
            this.page04.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_MatrixCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_MatrixCC)).EndInit();
            this.page05.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_MatrixDD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_MatrixDD)).EndInit();
            this.page06.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_MatrixSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView_MatrixSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnGap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpSelection;
        private DevExpress.XtraTab.XtraTabControl TabMain;
        private DevExpress.XtraTab.XtraTabPage page01;
        private DevExpress.XtraGrid.GridControl grd_DataCC;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView_DataCC;
        private DevExpress.XtraTab.XtraTabPage page02;
        private DevExpress.XtraEditors.SimpleButton btnList;
        private DevExpress.XtraEditors.LabelControl lbStartFinish;
        private DevExpress.XtraEditors.SimpleButton btnClearList;
        private DevExpress.XtraEditors.DateEdit ListDT02;
        private DevExpress.XtraEditors.DateEdit ListDT01;
        private DevExpress.XtraTab.XtraTabPage page03;
        private DevExpress.XtraGrid.GridControl grd_DataDD;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView_DataDD;
        private DevExpress.XtraGrid.GridControl grd_DataSS;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView_DataSS;
        private DevExpress.XtraEditors.PanelControl pnGap;
        private DevExpress.XtraTab.XtraTabPage page04;
        private DevExpress.XtraGrid.GridControl grd_MatrixCC;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView_MatrixCC;
        private DevExpress.XtraTab.XtraTabPage page05;
        private DevExpress.XtraGrid.GridControl grd_MatrixDD;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView_MatrixDD;
        private DevExpress.XtraTab.XtraTabPage page06;
        private DevExpress.XtraGrid.GridControl grd_MatrixSS;
        private DevExpress.XtraGrid.Views.Grid.GridView grdView_MatrixSS;

    }
}