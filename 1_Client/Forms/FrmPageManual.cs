using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;


namespace TrafficMatrix2013
{
    public partial class FrmPageManual : XtraForm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageManual()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Reset
            this.btnClearRun_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private async void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                // Log
                alfaLog.Clear();

                // Start Process
                alfaSAM.Start(MainTimer, alfaSAM.PageManual);

                // Log
                alfaLog.Add("[ START ]");

                // Disable Controls
                grpSelection.Enabled = false;

                // Call Service
                await alfaSAM.Step01_CallService_TrafficData(DateTime01.DateTime, DateTime02.DateTime);

                // Get FileNames
                this.btnListFiles_Click(null, null);

                // Log
                alfaLog.Add("[ FINISH ]");
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }

            finally
            {
                // Stop Process
                alfaSAM.Stop();

                // Enable Controls
                grpSelection.Enabled = true;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void lbOutputFiles_DoubleClick(object sender, EventArgs e)
        {
            // Oracle Load
            this.btnLoadData_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private async void btnLoadData_Click(object sender, EventArgs e)
        {
            // Check
            if (lbOutputFiles.SelectedIndex < 0) return;

            try
            {
                // Start Process
                alfaSAM.Start(MainTimer, alfaSAM.PageManual);

                // Log
                alfaLog.Add("[ START ]");

                // Disable Controls
                grpSelection.Enabled = false;

                // Reset Grids
                grdResult01.DataSource = null;
                grdResult02.DataSource = null;

                // Clear Columns
                grdResult01View.Columns.Clear();
                grdResult02View.Columns.Clear();

                // Get FileName
                var p_Item = (alfaItem)lbOutputFiles.SelectedItem;

                // Download File
                var p_LocalFile = await alfaSAM.Step03_FTP_DownloadFile(p_Item.Name);

                // Process File
                var p_ResultTable = await alfaSAM.Step04_ProcessFile(p_LocalFile, true);

                // Process Data
                var p_ResultData = await alfaSAM.Step05_ProcessData(p_ResultTable);

                // Create Tasks
                var p_Task_Transfer_C = alfaSAM.Step06_Transfer_Data_C(p_ResultData);
                var p_Task_Transfer_D = alfaSAM.Step06_Transfer_Data_D(p_ResultData);
                var p_Task_Transfer_S = alfaSAM.Step06_Transfer_Data_S(p_ResultData);

                // Wait for All
                await Task.WhenAll(p_Task_Transfer_C, p_Task_Transfer_D, p_Task_Transfer_S);

                // Create Tasks
                var p_Task_Delta_C = alfaSAM.Step07_Calculate_Delta_C();
                var p_Task_Delta_D = alfaSAM.Step07_Calculate_Delta_D();
                var p_Task_Delta_S = alfaSAM.Step07_Calculate_Delta_S();

                // Wait for All
                await Task.WhenAll(p_Task_Delta_C, p_Task_Delta_D, p_Task_Delta_S);

                // SetView
                alfaGrid.SetView(grdResult01View, p_ResultTable);
                alfaGrid.SetView(grdResult02View, p_ResultData);

                // Log
                alfaLog.Add("[ FINISH ]");

            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }

            finally
            {
                // Stop Process
                alfaSAM.Stop();

                // Enable Controls
                grpSelection.Enabled = true;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnListFiles_Click(object sender, EventArgs e)
        {
            try
            {
                // Cursor
                alfaMsg.CursorWait();

                // Start Process
                alfaSAM.Start(MainTimer, alfaSAM.PageManual);

                // Clear Items
                lbOutputFiles.Items.Clear();

                // Get FileNames
                List<alfaItem> p_ItemList = alfaSAM.Step02_FTP_GetFileNames();

                // Add to List
                lbOutputFiles.Items.AddRange(p_ItemList.ToArray());

                // Set Last Item
                if (lbOutputFiles.Items.Count > 0) lbOutputFiles.SelectedIndex = lbOutputFiles.Items.Count - 1;

                // Set Buttons
                alfaCtrl.SetButton(btnLoadData, lbOutputFiles.Items.Count > 0);
                alfaCtrl.SetButton(btnClearData, lbOutputFiles.Items.Count > 0);

                // Status
                alfaSAM.Status_OK();
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }

            finally
            {
                // Stop
                alfaSAM.Stop();

                // Cursor
                alfaMsg.CursorDefult();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnDeleteFiles_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear Items
                lbOutputFiles.Items.Clear();

                // Delete Files
                alfaSAM.FTP_DeleteFiles();

                // Set Buttons
                alfaCtrl.SetButton(btnLoadData, lbOutputFiles.Items.Count > 0);
                alfaCtrl.SetButton(btnClearData, lbOutputFiles.Items.Count > 0);

                // Status
                alfaSAM.Status_OK();
            }

            catch (Exception ex)
            {
                // Status
                alfaSAM.Status_ERROR(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClearRun_Click(object sender, EventArgs e)
        {
            // DateTime
            DateTime dtNow = DateTime.Now;

            // Set DateTime
            dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, 0, 0);

            // Clear DateTime
            DateTime01.DateTime = dtNow.AddHours(-1);
            DateTime02.DateTime = dtNow.AddHours(-1).AddMinutes(15);

            // Clear
            this.btnClearData_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClearData_Click(object sender, EventArgs e)
        {
            // Reset Logs
            alfaLog.Clear();
            this.txtLog.Text = string.Empty;

            // Reset Grids
            grdResult01.DataSource = null;
            grdResult02.DataSource = null;

            // Clear Columns
            grdResult01View.Columns.Clear();
            grdResult02View.Columns.Clear();

            // Clear Items
            lbOutputFiles.Items.Clear();

            // Disable Buttons
            alfaCtrl.DisableControl(btnLoadData);
            alfaCtrl.DisableControl(btnClearData);

            // Reset Status
            alfaSAM.Status_OK();

            // Focus
            grpSelection.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            // Set LogText
            this.txtLog.Text = alfaLog.LogText;
            
            // Status
            alfaCtrl.SetText(alfaSAM.FrmMain.statusResult, " RUNNING ... ! ", Color.Blue);

            // Get Values
            int p_Value = Convert.ToInt32(alfaSAM.FrmMain.statusProgress.EditValue);

            // Increase Value
            p_Value = p_Value + 10;

            // Take Mode
            p_Value = p_Value % 100;

            // Set Value
            alfaSAM.FrmMain.statusProgress.EditValue = p_Value;

            if (!alfaSAM.IsRunning)
            {
                // Stop Timer
                this.MainTimer.Stop();

                // ProgressBar
                alfaSAM.FrmMain.statusProgress.EditValue = 100;

                // Status
                alfaSAM.Status_OK();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}