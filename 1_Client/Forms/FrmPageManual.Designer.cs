namespace TrafficMatrix2013
{
    partial class FrmPageManual
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
            this.grpSelection = new DevExpress.XtraEditors.GroupControl();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadData = new DevExpress.XtraEditors.SimpleButton();
            this.grpOutput = new DevExpress.XtraEditors.GroupControl();
            this.btnDeleteFiles = new DevExpress.XtraEditors.SimpleButton();
            this.btnListFiles = new DevExpress.XtraEditors.SimpleButton();
            this.lbOutputFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.btnClearRun = new DevExpress.XtraEditors.SimpleButton();
            this.btnRunQuery = new DevExpress.XtraEditors.SimpleButton();
            this.DateTime02 = new DevExpress.XtraEditors.DateEdit();
            this.DateTime01 = new DevExpress.XtraEditors.DateEdit();
            this.lbFinish = new DevExpress.XtraEditors.LabelControl();
            this.lbStart = new DevExpress.XtraEditors.LabelControl();
            this.grdResult01 = new DevExpress.XtraGrid.GridControl();
            this.grdResult01View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TabMain = new DevExpress.XtraTab.XtraTabControl();
            this.page01 = new DevExpress.XtraTab.XtraTabPage();
            this.txtLog = new DevExpress.XtraEditors.MemoEdit();
            this.page02 = new DevExpress.XtraTab.XtraTabPage();
            this.page03 = new DevExpress.XtraTab.XtraTabPage();
            this.grdResult02 = new DevExpress.XtraGrid.GridControl();
            this.grdResult02View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpSelection)).BeginInit();
            this.grpSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOutput)).BeginInit();
            this.grpOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbOutputFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime02.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime02.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime01.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime01.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult01View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).BeginInit();
            this.TabMain.SuspendLayout();
            this.page01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).BeginInit();
            this.page02.SuspendLayout();
            this.page03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult02View)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSelection
            // 
            this.grpSelection.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSelection.AppearanceCaption.Options.UseFont = true;
            this.grpSelection.AppearanceCaption.Options.UseTextOptions = true;
            this.grpSelection.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpSelection.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpSelection.Controls.Add(this.btnClearData);
            this.grpSelection.Controls.Add(this.btnLoadData);
            this.grpSelection.Controls.Add(this.grpOutput);
            this.grpSelection.Controls.Add(this.btnClearRun);
            this.grpSelection.Controls.Add(this.btnRunQuery);
            this.grpSelection.Controls.Add(this.DateTime02);
            this.grpSelection.Controls.Add(this.DateTime01);
            this.grpSelection.Controls.Add(this.lbFinish);
            this.grpSelection.Controls.Add(this.lbStart);
            this.grpSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSelection.Location = new System.Drawing.Point(0, 0);
            this.grpSelection.Name = "grpSelection";
            this.grpSelection.Size = new System.Drawing.Size(1058, 229);
            this.grpSelection.TabIndex = 8;
            this.grpSelection.Text = "Manual  Parameters";
            // 
            // btnClearData
            // 
            this.btnClearData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearData.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClearData.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClearData.Appearance.Options.UseFont = true;
            this.btnClearData.Appearance.Options.UseForeColor = true;
            this.btnClearData.Location = new System.Drawing.Point(915, 152);
            this.btnClearData.LookAndFeel.SkinName = "Sharp";
            this.btnClearData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(100, 30);
            this.btnClearData.TabIndex = 57;
            this.btnClearData.Tag = "";
            this.btnClearData.Text = "Clear";
            this.btnClearData.ToolTip = "Ctrl + Enter";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadData.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadData.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLoadData.Appearance.Options.UseFont = true;
            this.btnLoadData.Appearance.Options.UseForeColor = true;
            this.btnLoadData.Location = new System.Drawing.Point(915, 55);
            this.btnLoadData.LookAndFeel.SkinName = "Glass Oceans";
            this.btnLoadData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(100, 82);
            this.btnLoadData.TabIndex = 56;
            this.btnLoadData.Tag = "ActionButton";
            this.btnLoadData.Text = "Load Data\r\n\r\n(ORACLE)";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // grpOutput
            // 
            this.grpOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOutput.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpOutput.Appearance.Options.UseBackColor = true;
            this.grpOutput.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpOutput.AppearanceCaption.Options.UseFont = true;
            this.grpOutput.Controls.Add(this.btnDeleteFiles);
            this.grpOutput.Controls.Add(this.btnListFiles);
            this.grpOutput.Controls.Add(this.lbOutputFiles);
            this.grpOutput.Location = new System.Drawing.Point(427, 40);
            this.grpOutput.LookAndFeel.SkinName = "Office 2010 Black";
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(462, 156);
            this.grpOutput.TabIndex = 55;
            this.grpOutput.Text = "  SAM Output Files (XML)";
            // 
            // btnDeleteFiles
            // 
            this.btnDeleteFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFiles.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteFiles.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteFiles.Appearance.Options.UseFont = true;
            this.btnDeleteFiles.Appearance.Options.UseForeColor = true;
            this.btnDeleteFiles.Location = new System.Drawing.Point(374, 0);
            this.btnDeleteFiles.LookAndFeel.SkinName = "Glass Oceans";
            this.btnDeleteFiles.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDeleteFiles.Name = "btnDeleteFiles";
            this.btnDeleteFiles.Size = new System.Drawing.Size(88, 22);
            this.btnDeleteFiles.TabIndex = 59;
            this.btnDeleteFiles.Tag = "ActionButton";
            this.btnDeleteFiles.Text = "Delete Files";
            this.btnDeleteFiles.Click += new System.EventHandler(this.btnDeleteFiles_Click);
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListFiles.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListFiles.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnListFiles.Appearance.Options.UseFont = true;
            this.btnListFiles.Appearance.Options.UseForeColor = true;
            this.btnListFiles.Location = new System.Drawing.Point(280, 0);
            this.btnListFiles.LookAndFeel.SkinName = "Glass Oceans";
            this.btnListFiles.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(88, 22);
            this.btnListFiles.TabIndex = 58;
            this.btnListFiles.Tag = "ActionButton";
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // lbOutputFiles
            // 
            this.lbOutputFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOutputFiles.Location = new System.Drawing.Point(2, 22);
            this.lbOutputFiles.LookAndFeel.SkinName = "Office 2010 Black";
            this.lbOutputFiles.Name = "lbOutputFiles";
            this.lbOutputFiles.Size = new System.Drawing.Size(458, 132);
            this.lbOutputFiles.TabIndex = 50;
            this.lbOutputFiles.DoubleClick += new System.EventHandler(this.lbOutputFiles_DoubleClick);
            // 
            // btnClearRun
            // 
            this.btnClearRun.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClearRun.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClearRun.Appearance.Options.UseFont = true;
            this.btnClearRun.Appearance.Options.UseForeColor = true;
            this.btnClearRun.Location = new System.Drawing.Point(297, 152);
            this.btnClearRun.LookAndFeel.SkinName = "Sharp";
            this.btnClearRun.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClearRun.Name = "btnClearRun";
            this.btnClearRun.Size = new System.Drawing.Size(100, 30);
            this.btnClearRun.TabIndex = 50;
            this.btnClearRun.Tag = "";
            this.btnClearRun.Text = "Clear";
            this.btnClearRun.ToolTip = "Ctrl + Enter";
            this.btnClearRun.Click += new System.EventHandler(this.btnClearRun_Click);
            // 
            // btnRunQuery
            // 
            this.btnRunQuery.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRunQuery.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRunQuery.Appearance.Options.UseFont = true;
            this.btnRunQuery.Appearance.Options.UseForeColor = true;
            this.btnRunQuery.Location = new System.Drawing.Point(297, 55);
            this.btnRunQuery.LookAndFeel.SkinName = "Glass Oceans";
            this.btnRunQuery.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(100, 82);
            this.btnRunQuery.TabIndex = 49;
            this.btnRunQuery.Tag = "ActionButton";
            this.btnRunQuery.Text = "Run Query\r\n\r\n(SAM)";
            this.btnRunQuery.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // DateTime02
            // 
            this.DateTime02.EditValue = new System.DateTime(2012, 9, 28, 17, 1, 16, 88);
            this.DateTime02.Location = new System.Drawing.Point(102, 143);
            this.DateTime02.Name = "DateTime02";
            this.DateTime02.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.DateTime02.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DateTime02.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.DateTime02.Properties.Appearance.Options.UseBackColor = true;
            this.DateTime02.Properties.Appearance.Options.UseFont = true;
            this.DateTime02.Properties.Appearance.Options.UseForeColor = true;
            this.DateTime02.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.DateTime02.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DateTime02.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateTime02.Properties.DisplayFormat.FormatString = "G";
            this.DateTime02.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateTime02.Properties.EditFormat.FormatString = "G";
            this.DateTime02.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateTime02.Properties.Mask.EditMask = "G";
            this.DateTime02.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateTime02.Size = new System.Drawing.Size(170, 20);
            this.DateTime02.TabIndex = 1;
            // 
            // DateTime01
            // 
            this.DateTime01.EditValue = new System.DateTime(2012, 9, 28, 17, 1, 16, 88);
            this.DateTime01.Location = new System.Drawing.Point(102, 68);
            this.DateTime01.Name = "DateTime01";
            this.DateTime01.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.DateTime01.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DateTime01.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.DateTime01.Properties.Appearance.Options.UseBackColor = true;
            this.DateTime01.Properties.Appearance.Options.UseFont = true;
            this.DateTime01.Properties.Appearance.Options.UseForeColor = true;
            this.DateTime01.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.DateTime01.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.DateTime01.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateTime01.Properties.DisplayFormat.FormatString = "G";
            this.DateTime01.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateTime01.Properties.EditFormat.FormatString = "G";
            this.DateTime01.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DateTime01.Properties.Mask.EditMask = "G";
            this.DateTime01.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateTime01.Size = new System.Drawing.Size(170, 20);
            this.DateTime01.TabIndex = 0;
            // 
            // lbFinish
            // 
            this.lbFinish.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbFinish.Location = new System.Drawing.Point(54, 146);
            this.lbFinish.Name = "lbFinish";
            this.lbFinish.Size = new System.Drawing.Size(42, 14);
            this.lbFinish.TabIndex = 28;
            this.lbFinish.Text = "Finish :";
            // 
            // lbStart
            // 
            this.lbStart.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbStart.Location = new System.Drawing.Point(56, 71);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(40, 14);
            this.lbStart.TabIndex = 26;
            this.lbStart.Text = "Start :";
            // 
            // grdResult01
            // 
            this.grdResult01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult01.Location = new System.Drawing.Point(0, 0);
            this.grdResult01.LookAndFeel.SkinName = "Office 2010 Black";
            this.grdResult01.MainView = this.grdResult01View;
            this.grdResult01.Name = "grdResult01";
            this.grdResult01.Size = new System.Drawing.Size(1058, 592);
            this.grdResult01.TabIndex = 10;
            this.grdResult01.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdResult01View});
            // 
            // grdResult01View
            // 
            this.grdResult01View.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult01View.Appearance.FooterPanel.Options.UseFont = true;
            this.grdResult01View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult01View.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdResult01View.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult01View.Appearance.Row.Options.UseFont = true;
            this.grdResult01View.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult01View.Appearance.ViewCaption.Options.UseFont = true;
            this.grdResult01View.GridControl = this.grdResult01;
            this.grdResult01View.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdResult01View.Name = "grdResult01View";
            this.grdResult01View.OptionsBehavior.Editable = false;
            this.grdResult01View.OptionsBehavior.ReadOnly = true;
            this.grdResult01View.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdResult01View.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdResult01View.OptionsLayout.Columns.StoreAppearance = true;
            this.grdResult01View.OptionsLayout.StoreAllOptions = true;
            this.grdResult01View.OptionsLayout.StoreAppearance = true;
            this.grdResult01View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdResult01View.OptionsSelection.MultiSelect = true;
            this.grdResult01View.OptionsView.EnableAppearanceOddRow = true;
            this.grdResult01View.OptionsView.ShowAutoFilterRow = true;
            this.grdResult01View.ViewCaption = "RAW DATA";
            // 
            // TabMain
            // 
            this.TabMain.Appearance.Options.UseTextOptions = true;
            this.TabMain.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TabMain.AppearancePage.Header.Options.UseFont = true;
            this.TabMain.AppearancePage.Header.Options.UseTextOptions = true;
            this.TabMain.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(10, 10);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedTabPage = this.page01;
            this.TabMain.Size = new System.Drawing.Size(1065, 623);
            this.TabMain.TabIndex = 11;
            this.TabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.page01,
            this.page02,
            this.page03});
            this.TabMain.TabPageWidth = 160;
            // 
            // page01
            // 
            this.page01.Controls.Add(this.txtLog);
            this.page01.Controls.Add(this.grpSelection);
            this.page01.Name = "page01";
            this.page01.Size = new System.Drawing.Size(1058, 592);
            this.page01.Text = "       Run       ";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 229);
            this.txtLog.Name = "txtLog";
            this.txtLog.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtLog.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLog.Properties.Appearance.Options.UseBackColor = true;
            this.txtLog.Properties.Appearance.Options.UseFont = true;
            this.txtLog.Properties.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(1058, 363);
            this.txtLog.TabIndex = 11;
            // 
            // page02
            // 
            this.page02.Controls.Add(this.grdResult01);
            this.page02.Name = "page02";
            this.page02.Size = new System.Drawing.Size(1058, 592);
            this.page02.Text = "Raw Data";
            // 
            // page03
            // 
            this.page03.Controls.Add(this.grdResult02);
            this.page03.Name = "page03";
            this.page03.Size = new System.Drawing.Size(1058, 592);
            this.page03.Text = "Processed Data";
            // 
            // grdResult02
            // 
            this.grdResult02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult02.Location = new System.Drawing.Point(0, 0);
            this.grdResult02.LookAndFeel.SkinName = "Office 2010 Black";
            this.grdResult02.MainView = this.grdResult02View;
            this.grdResult02.Name = "grdResult02";
            this.grdResult02.Size = new System.Drawing.Size(1058, 592);
            this.grdResult02.TabIndex = 11;
            this.grdResult02.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdResult02View});
            // 
            // grdResult02View
            // 
            this.grdResult02View.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult02View.Appearance.FooterPanel.Options.UseFont = true;
            this.grdResult02View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult02View.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdResult02View.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult02View.Appearance.Row.Options.UseFont = true;
            this.grdResult02View.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdResult02View.Appearance.ViewCaption.Options.UseFont = true;
            this.grdResult02View.GridControl = this.grdResult02;
            this.grdResult02View.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdResult02View.Name = "grdResult02View";
            this.grdResult02View.OptionsBehavior.Editable = false;
            this.grdResult02View.OptionsBehavior.ReadOnly = true;
            this.grdResult02View.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdResult02View.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdResult02View.OptionsLayout.Columns.StoreAppearance = true;
            this.grdResult02View.OptionsLayout.StoreAllOptions = true;
            this.grdResult02View.OptionsLayout.StoreAppearance = true;
            this.grdResult02View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdResult02View.OptionsSelection.MultiSelect = true;
            this.grdResult02View.OptionsView.EnableAppearanceOddRow = true;
            this.grdResult02View.OptionsView.ShowAutoFilterRow = true;
            this.grdResult02View.ViewCaption = "PROCESSED DATA";
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // FrmPageManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 643);
            this.Controls.Add(this.TabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPageManual";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmPage01";
            ((System.ComponentModel.ISupportInitialize)(this.grpSelection)).EndInit();
            this.grpSelection.ResumeLayout(false);
            this.grpSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpOutput)).EndInit();
            this.grpOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbOutputFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime02.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime02.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime01.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTime01.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult01View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).EndInit();
            this.TabMain.ResumeLayout(false);
            this.page01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).EndInit();
            this.page02.ResumeLayout(false);
            this.page03.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult02View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpSelection;
        private DevExpress.XtraEditors.SimpleButton btnClearRun;
        private DevExpress.XtraEditors.SimpleButton btnRunQuery;
        private DevExpress.XtraEditors.DateEdit DateTime02;
        private DevExpress.XtraEditors.DateEdit DateTime01;
        private DevExpress.XtraEditors.LabelControl lbFinish;
        private DevExpress.XtraEditors.LabelControl lbStart;
        private DevExpress.XtraGrid.GridControl grdResult01;
        private DevExpress.XtraGrid.Views.Grid.GridView grdResult01View;
        private DevExpress.XtraEditors.GroupControl grpOutput;
        private DevExpress.XtraEditors.ListBoxControl lbOutputFiles;
        private DevExpress.XtraEditors.SimpleButton btnClearData;
        private DevExpress.XtraEditors.SimpleButton btnLoadData;
        private DevExpress.XtraGrid.GridControl grdResult02;
        private DevExpress.XtraGrid.Views.Grid.GridView grdResult02View;
        private DevExpress.XtraEditors.SimpleButton btnListFiles;
        private System.Windows.Forms.Timer MainTimer;
        private DevExpress.XtraEditors.SimpleButton btnDeleteFiles;
        private DevExpress.XtraTab.XtraTabControl TabMain;
        private DevExpress.XtraTab.XtraTabPage page02;
        private DevExpress.XtraTab.XtraTabPage page03;
        private DevExpress.XtraEditors.MemoEdit txtLog;
        private DevExpress.XtraTab.XtraTabPage page01;

    }
}