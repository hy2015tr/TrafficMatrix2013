using System;
using DevExpress.XtraBars;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;


namespace TrafficMatrix2013
{
    public partial class FrmMain : XtraForm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        #region //---Member Fields---//

        // Splash Form
        private static FrmSplash m_frmSplash = new FrmSplash();

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmMain()
        {
            // Show Splash
            m_frmSplash.Show();
            m_frmSplash.Update();

            // Initializing
            this.InitializeComponent();

            // alfaSession
            alfaSession.Initialize();

            // Add Pages
            this.AddPages();

            // Hide Panels
            pnMain.Hide();

            // Set LookAndFeel
            this.SetDefaultLook(menuSkinCaramel);

            // Maximized
            this.WindowState = FormWindowState.Maximized;

            // Set Version
            this.lbVersion.Text = alfaStr.GetAppVersion(true);

            // Select Test-Prod
            radioSystem.SelectedIndex = 0;
            radioSystem.Properties.Items[0].Enabled = true;
            radioSystem.Properties.Items[1].Enabled = false;

            // Selected Page
            this.tabMain_SelectedPageChanged(null, null);  
          
            // Set Main
            alfaSAM.FrmMain = this;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                // Update
                this.Update();

                // Close Splash
                m_frmSplash.Close();

                // Clear 
                this.btnLoginClear_Click(null, null);

                // Load UserName
                this.LoadUserNameFromAppSettings();
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void SetDefaultLook(DevExpress.XtraBars.BarButtonItem p_MenuItem)
        {
            // Add Check to ViewMenuItems
            foreach (Object Item in barMenu.Manager.Items)
            {
                // Check Item
                if (Item.GetType().ToString() != "DevExpress.XtraBars.BarButtonItem") continue;

                // Get Item
                BarButtonItem obj = (BarButtonItem)Item;

                if (obj.Name.Contains("Skin"))
                {
                    // Set Properties
                    obj.ButtonStyle = BarButtonStyle.Check;
                    obj.AllowAllUp = true;
                    obj.GroupIndex = 1;
                }
            }

            // Set Default LookAndFeel
            defaultLookAndFeel.LookAndFeel.SkinName = p_MenuItem.Caption;
            p_MenuItem.Down = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menuAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Show Splash
            m_frmSplash = new FrmSplash();
            m_frmSplash.ShowDialog();

            //Hide Splash
            m_frmSplash.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void ViewItemALL_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Set LookAndFeel
            defaultLookAndFeel.LookAndFeel.SkinName = e.Item.Caption;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLoginClear_Click(object sender, EventArgs e)
        {
            // Disable Login
            alfaCtrl.DisableControl(btnLogin);

            // Clear Inputs
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;

            // Focus
            txtUser.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if ((txtUser.Text != string.Empty) && (txtPass.Text != string.Empty))
            {
                // Enable Login
                alfaCtrl.EnableControl(btnLogin);
            }
            else
            {
                // Disable Login
                alfaCtrl.DisableControl(btnLogin);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && btnLogin.Enabled == true)
            {
                // Enter
                this.btnLogin_Click(null, null);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // alfaSession
                alfaSession.Initialize();

                if (alfaEntity.CheckUserLogin(txtUser.Text, txtPass.Text))
                {
                    // Refresh ClientInfo
                    alfaSession.UserName = txtUser.Text;
                    alfaSession.RefreshLoginDateTime();

                    // Save UserName
                    TrafficMatrix2013.Properties.Settings.Default.UserName = txtUser.Text;
                    TrafficMatrix2013.Properties.Settings.Default.Save();

                    // Set Admin Page
                    pageSettings.PageVisible = (alfaSession.Admin);

                    // Set Status
                    this.Set_Status_Fields();

                    // Panels
                    pnLogin.Hide();
                    pnMain.Show();
                }
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void LoadUserNameFromAppSettings()
        {
            // Load UserName
            string p_Username = TrafficMatrix2013.Properties.Settings.Default.UserName;

            if (p_Username != string.Empty)
            {
                // Set UserName
                txtUser.Text = p_Username;

                // Focus Password
                txtPass.Focus();
            }
            // Focus UserName
            else txtUser.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Set_Status_Fields()
        {
            try
            {
                // Satus Left Items
                statusName.Caption = String.Format("PC : {0}", alfaSession.PC);
                statusIP.Caption = String.Format("IP : {0}", alfaSession.LocIP);
                statusNet.Caption = String.Format("NET : {0}", alfaSession.NetVer);
                statusSQL.Caption = String.Format("ORA : {0}", alfaSession.DBName);

                // Set User
                statusUser.Caption = alfaSession.UserGroup();

                // Set Version
                this.lbVersion.Text = alfaSession.AppVer;
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void statusSQL_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            // Create Form
            FrmServer frm = new FrmServer();

            // Call Form
            if (frm.ShowDialog() == DialogResult.OK)
            {
                statusSQL.Caption = String.Format("ORA : {0}", alfaSession.DBName);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Restart
            Application.Restart();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menuExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Close
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void statusUser_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            // Check UserName
            if (string.IsNullOrEmpty(txtUser.Text)) return;

            // Set UserName
            alfaSession.UserName = txtUser.Text;

            // Create Form
            FrmUser frm = new FrmUser();

            // Call Form
            if (frm.ShowDialog() == DialogResult.OK)
            {
                statusUser.Caption = String.Format("{0}", alfaSession.UserName);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //if (tabMain.SelectedTabPage == page03)
            //{
            //    if (page03.Controls.Count == 0) 
            //    {
            //        // Suspend
            //        this.SuspendLayout();
                    
            //        // Create Admin Page
            //        page03.Controls.Add(new FrmPage03());

            //        // Resume
            //        this.ResumeLayout();
            //    }
            //}

            //else if (tabMain.SelectedTabPage == page01)
            //{
            //    if (page01.Controls.Count == 0)
            //    {
            //        // Suspend
            //        this.SuspendLayout();

            //        // Create Admin Page
            //        page01.Controls.Add(new FrmPage01());

            //        // Resume
            //        this.ResumeLayout();
            //    }
            //}
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void AddPages()
        {
            try
            {
                // Add Pages
                this.AddPage(pageAuto, new FrmPageAuto());
                this.AddPage(pageCharts, new FrmPageChart());
                this.AddPage(pageManual, new FrmPageManual());
                this.AddPage(pageReports, new FrmPageReport());
                this.AddPage(pageSettings, new FrmPageSettings());
            }

            catch (Exception ex)
            {
                // Close
                m_frmSplash.Close();

                // Error
                alfaMsg.Error(ex);

                // Exit
                Environment.Exit(0);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void AddPage(XtraTabPage p_Page, Control p_Object)
        {
            // Suspend
            this.SuspendLayout();

            // Create Admin Page
            p_Page.Controls.Add(p_Object);

            // Resume
            this.ResumeLayout();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//
    }
}