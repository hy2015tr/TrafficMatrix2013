using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;

namespace TrafficMatrix2013
{
    public partial class FrmPageAuto : XtraForm
    {
        private DateTime m_DateTime1;
        private DateTime m_DateTime2;
        private DateTime m_DateTime_Running;
        private Stopwatch m_Stopwatch = new Stopwatch();
        private bool m_TimerSchedule_Running = false;
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageAuto()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Reset
            this.btnClearStart_Click(null, null);
            this.btnClearList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void chkFinish_EditValueChanged(object sender, EventArgs e)
        {
            // Set Status
            this.SetDateTimeStatus(ScheduleDT02, chkFinish.Checked); 

            // Focus
            ScheduleDT02.Focus();
            ScheduleDT02.SelectionStart = 0;
            ScheduleDT02.SelectionLength = 0;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClearStart_Click(object sender, EventArgs e)
        {
            // Reset Watch
            this.m_Stopwatch.Reset();

            // DateTime
            DateTime dtNow = DateTime.Now;

            // Set DateTime
            dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, 0, 0);

            // Reset DateTime
            ScheduleDT01.DateTime = dtNow.AddHours(-1);
            ScheduleDT02.DateTime = ScheduleDT01.DateTime.AddHours(1);

            // Set Gauges
            gaugePeriod.Value = 0;
            gaugePeriod.MaxValue = Convert.ToInt64(txtPeriod.Value);
            gaugeStart.Text = alfaDate.GetDate_V7(ScheduleDT01.DateTime);
            gaugeFinish.Text = alfaDate.GetDate_V7(ScheduleDT01.DateTime.AddMinutes((double)txtPeriod.Value));

            // Set ChkFinish
            this.chkFinish.Checked = false;
            this.chkFinish_EditValueChanged(null, null);

            // Clear Log
            txtLog.Text = string.Empty;

            // Set Period
            txtPeriod.Value = 20;

            // Reset Status
            alfaSAM.Status_OK();

            // Focus
            this.grpSchedule.Focus();

            // STOP ...
            this.SetScheduleControls(1);

            // Focus
            grpSchedule.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClearList_Click(object sender, EventArgs e)
        {
            // DateTime
            DateTime dtNow = DateTime.Now;

            // Set DateTime
            dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

            // Reset DateTime
            ListDT01.DateTime = dtNow.AddDays(-2);
            ListDT02.DateTime = dtNow.AddDays(+1);
                
            // Reset Grids
            grdLog.DataSource = null;
            grdLogView.Columns.Clear();

            // Focus
            this.grpList.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnList_Click(object sender, EventArgs e)
        {
            // GetList
            var p_List = alfaEntity.TableLog_GetList(ListDT01.DateTime, ListDT02.DateTime);

            // SetView
            alfaGrid.SetView(grdLogView, p_List);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                // START 
                if (this.btnStartStop.Text == "START") this.Start_Process();

                //########################################### (1) STOP by USER #############################################//
                
                else if (this.btnStartStop.Text == "STOP")
                {
                    // Log
                    alfaLog.Add("STOP Button was Clicked by User... !");

                    // Stop
                    this.Stop_Process("USER");
                }
            
                //##########################################################################################################//
            
            }

            catch (Exception ex)
            {
                // Log
                alfaLog.Add("[ ERROR ] " + ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Start_Process()
        {
            // STOP ...
            this.SetScheduleControls(2);

            // Select Page
            TabMain.SelectedTabPage = page01;

            // Focus
            this.txtLog.Focus();

            // Set Period
            this.TimerSchedule.Interval = Convert.ToInt16(this.txtPeriod.Value) * 60 * 1000;

            // Set Period
            this.gaugePeriod.Value = 0;

            // Reset Watch
            this.m_Stopwatch.Restart();

            // Start Timers
            this.TimerMain.Start();
            this.TimerSchedule.Start();

            // Start SAM
            alfaSAM.Start(alfaSAM.PageAuto);

            // Init DateTime
            this.m_DateTime2 = ScheduleDT01.DateTime;

            // Refresh
            Application.DoEvents();

            // Call TimerEvent
            this.TimerSchedule_Tick(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Stop_Process(string p_BreakUser)
        {
            // Set BreakUser
            alfaSAM.BreakUser = p_BreakUser;

            // BREAKING ...
            this.SetScheduleControls(3);

            // Stop Watch
            this.m_Stopwatch.Stop();

            // Stop SAM
            alfaSAM.Stop();

            // Stop Timer
            this.TimerSchedule.Stop();

            // Status
            alfaSAM.Status_STOPPED();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void SetScheduleControls(int p_Status)
        {
            if (p_Status == 1) // START
            {
                // Set Buton
                this.btnStartStop.Enabled = true;
                this.btnStartStop.Text = "START";
                this.btnStartStop.BackColor = Color.Green;

                // Enable Controls
                alfaCtrl.EnableControl(this.btnClearStart);
                this.SetDateTimeStatus(ScheduleDT01, true);
                this.SetDateTimeStatus(ScheduleDT02, this.chkFinish.Checked);
                this.txtPeriod.Enabled = true;
                this.chkFinish.Enabled = true;
                this.lbPeriod.Enabled = true;
                this.lbStartRun.Enabled = true;
            }

            else if (p_Status == 2) // STOP
            {
                // Set Buton
                this.btnStartStop.Enabled = true;
                this.btnStartStop.Text = "STOP";
                this.btnStartStop.BackColor = Color.Red;

                // Disable Controls
                alfaCtrl.DisableControl(this.btnClearStart);
                this.SetDateTimeStatus(ScheduleDT01, false);
                this.SetDateTimeStatus(ScheduleDT02, false);
                this.txtPeriod.Enabled = false;
                this.chkFinish.Enabled = false;
                this.lbPeriod.Enabled = false;
                this.lbStartRun.Enabled = false;
            }

            else if (p_Status == 3) // BREAKING
            {
                // Set Buton
                this.btnStartStop.Enabled = false;
                this.btnStartStop.Text = "BREAKING";
                this.btnStartStop.BackColor = Color.Gray;
            }

            else if (p_Status == 4) // FINISHED
            {
                // Set Buton
                this.btnStartStop.Enabled = false;
                this.btnStartStop.Text = "FINISHED";
                this.btnStartStop.BackColor = Color.Gray;
                alfaCtrl.EnableControl(this.btnClearStart);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void SetDateTimeStatus(DateEdit p_Control, bool p_Status)
        {
            // Set Status
            p_Control.Enabled = p_Status;

            // Set Color
            if (p_Status) p_Control.ForeColor = Color.Black; else p_Control.ForeColor = Color.LightGray;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            // Increase Period
            if (this.m_Stopwatch.Elapsed.Seconds % 60 == 0) this.gaugePeriod.Value += 1;

            // Reset Period
            if (this.m_Stopwatch.Elapsed.Minutes == (int)txtPeriod.Value) 
            {
                // Reset Watch
                this.m_Stopwatch.Restart();

                // Set Period
                this.gaugePeriod.Value = 0;
            }

            // Set Current
            this.m_DateTime_Running = this.m_DateTime1.AddSeconds(this.m_Stopwatch.Elapsed.TotalSeconds);

            //Set Start
            gaugeStart.Text = alfaDate.GetDate_V7(this.m_DateTime_Running);

            //Set Finish
            gaugeFinish.Text = alfaDate.GetDate_V7(this.m_DateTime2);

            //########################################### (2) STOP by SCHEDULE ########################################//

            if (chkFinish.Checked && this.m_DateTime_Running > ScheduleDT02.DateTime)
            {
                // Stop
                this.Stop_Process("SCHEDULE");
            }

            //#########################################################################################################//

            // Set LogText
            this.txtLog.Text = alfaLog.LogText;

            // Focus
            this.txtLog.Focus();
            this.txtLog.SelectionStart = this.txtLog.Text.Length;
            this.txtLog.ScrollToCaret();
            
            // Get Values
            int p_Value = Convert.ToInt32(alfaSAM.FrmMain.statusProgress.EditValue);

            // Increase Value
            p_Value = p_Value + 10;

            // Take Mode
            p_Value = p_Value % 100;

            // Set Value
            alfaSAM.FrmMain.statusProgress.EditValue = p_Value;

            if (TimerMain.Enabled && TimerSchedule.Enabled)
            {
                // Status
                alfaSAM.Status_RUNNING();
            }

            else
            {
                // ProgressBar
                alfaSAM.FrmMain.statusProgress.EditValue = 100;

                // FINISHED
                if (!this.m_TimerSchedule_Running) this.SetScheduleControls(4);

                // Stop TimerMain
                this.TimerMain.Stop();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private async void TimerSchedule_Tick(object sender, EventArgs e)
        {
            // Create Log (DB)
            SAM_LOG p_Log = alfaEntity.TableLog_Add();

            try
            {
                // Flag
                this.m_TimerSchedule_Running = true;

                // Set DateTimes
                this.m_DateTime1 = this.m_DateTime2;
                this.m_DateTime2 = this.m_DateTime2.AddMinutes((int)txtPeriod.Value);

                // Log
                alfaLog.Clear();

                // Log
                alfaLog.Add("[ START ]");

                // Period
                var p_Period = string.Format("(SAM) Period = {0} -- {1}", alfaDate.GetDate_V6(this.m_DateTime1), alfaDate.GetDate_V6(this.m_DateTime2));

                // Log
                alfaLog.Add(p_Period);

                // Set Log (DB)
                p_Log.STATUS = "RUNNING ...";
                p_Log.DT_PERIOD1 = alfaDate.GetDate_V6(this.m_DateTime1);
                p_Log.DT_PERIOD2 = alfaDate.GetDate_V6(this.m_DateTime2);

                // Update Log (DB)
                alfaEntity.TableLog_Update(p_Log);

                // Call Service
                await alfaSAM.Step01_CallService_TrafficData(this.m_DateTime1, this.m_DateTime2);

                // Get FileNames
                var p_FileNames = alfaSAM.Step02_FTP_GetFileNames();

                // Get FileName
                var p_Item = p_FileNames.Where(tt => tt.Name.StartsWith(alfaSAM.FileName)).Single();

                // Download File
                var p_LocalFile = await alfaSAM.Step03_FTP_DownloadFile(p_Item.Name);

                // Process File
                var p_ResultTable = await alfaSAM.Step04_ProcessFile(p_LocalFile, true);

                // Set Log (DB)
                p_Log.SAM_FILENAME = p_Item.Name;

                // Update Log (DB)
                alfaEntity.TableLog_Update(p_Log);

                if (p_ResultTable != null)
                {
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

                    // Set Log (DB)
                    p_Log.COUNT_C = p_Task_Transfer_C.Result;
                    p_Log.COUNT_D = p_Task_Transfer_D.Result;
                    p_Log.COUNT_S = p_Task_Transfer_S.Result;
                    p_Log.COUNT_PRC = p_ResultData.Count;
                    p_Log.COUNT_RAW = p_ResultTable.Rows.Count;
                }

                else
                {
                    // Set Values
                    p_Log.COUNT_C = 0;
                    p_Log.COUNT_D = 0;
                    p_Log.COUNT_S = 0;
                    p_Log.COUNT_RAW = 0;
                    p_Log.COUNT_PRC = 0;
                }

                // Delete Local File
                alfaSAM.Step08_Delete_LocalFile();

                // Log
                alfaLog.Add("[ FINISH ]");

                // Set Log (DB)
                p_Log.STATUS = "DONE";
                p_Log.DT_ELAPSED = Convert.ToInt32(this.m_Stopwatch.Elapsed.TotalSeconds);

                // Update Log (DB)
                alfaEntity.TableLog_Update(p_Log);

            }

            catch (Exception ex)
            {

                //########################################### (3) STOP by ERROR #########################################//

                if (ex.Message != alfaSAM.BreakMessage) this.Stop_Process("ERROR");

                //#######################################################################################################//

                // Message
                string p_Message = string.Format("[ WARNING ] {0} {1}", ex.Message, alfaSAM.BreakUser);

                // Log
                alfaLog.Add(p_Message);

                // Status
                alfaSAM.Status_ERROR(p_Message);

                // Set LogText
                this.txtLog.Text = alfaLog.LogText;

                // Stop Timer
                this.TimerSchedule.Stop();

                // FINISHED ...
                this.SetScheduleControls(4);

                // Set Log (DB)
                p_Log.STATUS = "ERROR";
                p_Log.DT_ELAPSED = Convert.ToInt32(this.m_Stopwatch.Elapsed.TotalSeconds);

                // Update Log (DB)
                alfaEntity.TableLog_Update(p_Log);
            }

            finally
            {
                // Flag
                this.m_TimerSchedule_Running = false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtALL_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Set Period
                gaugePeriod.MaxValue = Convert.ToInt64(txtPeriod.Value);

                // Set Start
                gaugeStart.Text = alfaDate.GetDate_V7(ScheduleDT01.DateTime);

                // Set Finish
                gaugeFinish.Text = alfaDate.GetDate_V7(ScheduleDT01.DateTime.AddMinutes((double)txtPeriod.Value));
            }

            catch
            {
                //null
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdLogView_DoubleClick(object sender, EventArgs e)
        {
            // Check
            if (grdLogView.DataSource == null || grdLogView.RowCount == 0) return;

            // Get Row
            var row = (SAM_LOG)grdLogView.GetFocusedRow();

            // Set Text
            txtLog.Text = row.LOG_FULLTEXT;

            // Select Page
            TabMain.SelectedTabPage = page01;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdLogView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // GridView
            GridView p_GridView = sender as GridView;

            // Check
            if (e.RowHandle < 0) return;

            if (e.Column.FieldName=="STATUS")
            {
                // Get Text
                string p_CellValue = p_GridView.GetRowCellDisplayText(e.RowHandle, p_GridView.Columns[e.Column.FieldName]);

                // Set Fonts
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);

                // Set Color
                if (p_CellValue == alfaStr.DONE)    e.Appearance.BackColor = Color.Green ; else
                if (p_CellValue == alfaStr.ERROR)   e.Appearance.BackColor = Color.Red   ; else 
                if (p_CellValue == alfaStr.RUNNING) e.Appearance.BackColor = Color.Blue  ;
            }

            else if (e.Column.FieldName == "ID")
            {
                // Check Focused Row
                if (e.RowHandle == p_GridView.FocusedRowHandle) return;

                // Set Color
                e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.LightGray; 
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}