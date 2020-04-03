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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraCharts;

namespace TrafficMatrix2013
{
    public partial class FrmPageChart : XtraForm
    {

        // Fields
        private List<SAM_DATA_C> m_List_CC = null;
        private List<SAM_DATA_D> m_List_DD = null;
        private List<SAM_DATA_S> m_List_SS = null;

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageChart()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Reset
            this.btnClear_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private Series CreateSeries( string p_Name, ViewType p_ChartType, Object p_DataSource, string p_Argument, string p_Scale, Color p_Color )
        {
            // Create Series
            Series seriesSatis = new Series(p_Name, p_ChartType);

            // Assign Datasource
            seriesSatis.DataSource = p_DataSource;

            // Set Series Color
            seriesSatis.View.Color = p_Color;

            // Argument ScaleType
            seriesSatis.ArgumentScaleType = ScaleType.Auto;
            seriesSatis.ArgumentDataMember = p_Argument;

            // Value ScaleType
            seriesSatis.ValueScaleType = ScaleType.Numerical;
            seriesSatis.ValueDataMembers.AddRange(new string[] { p_Scale });

            // Return
            return seriesSatis;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClear_Click(object sender, EventArgs e)
        {
            // DateTime
            DateTime dtNow = DateTime.Now;

            // Set DateTime
            dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

            // Reset DateTime
            ListDT01.DateTime = dtNow.AddDays(-0);
            ListDT02.DateTime = dtNow.AddDays(+1);

            // Reset Fields
            this.m_List_CC = null;
            this.m_List_DD = null;
            this.m_List_SS = null;

            // Clear Chart
            chartCC.Series.Clear();
            chartDD.Series.Clear();
            chartSS.Series.Clear();

            // Set Page
            TabMain.SelectedTabPage = page01;

            // Reset Source
            txtSourceName.Text = null;
            txtSourceName.Enabled = false;
            txtSourceName.Properties.Items.Clear();

            // Focus
            grpSelection.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Cursor
            alfaMsg.CursorWait();

            // GetList
            this.m_List_CC = alfaEntity.SAM_GetList_CC(ListDT01.DateTime, ListDT02.DateTime);
            this.m_List_DD = alfaEntity.SAM_GetList_DD(ListDT01.DateTime, ListDT02.DateTime);
            this.m_List_SS = alfaEntity.SAM_GetList_SS(ListDT01.DateTime, ListDT02.DateTime);

            // Set LSPName
            txtSourceName.Properties.Items.Clear();

            // Get Items
            var qryList = this.m_List_CC.Select(tt => new { tt.ADR_SOURCE }).Distinct().OrderBy(tt => tt.ADR_SOURCE);

            // Add List
            qryList.ToList().ForEach(tt => txtSourceName.Properties.Items.Add(tt.ADR_SOURCE.Replace("-c","").ToUpper()));

            // Set Status
            txtSourceName.Enabled = (txtSourceName.Properties.Items.Count > 0);

            // Check
            if (txtSourceName.Enabled)
            {
                // Set Item
                txtSourceName.SelectedIndex = 0;

                // Message
                alfaSAM.Status_OK();


                // Charts
                //this.Build_Charts();
            }

            // Message
            else alfaSAM.Status_ERROR("(WARNING) No Data Found ... !");

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Build_Charts()
        {
            // Check
            if (txtSourceName.Text == string.Empty) return;

            // Get Filtred List
            var p_List_CC = alfaEntity.SAM_Chart_CC(this.m_List_CC, txtSourceName.Text);
            var p_List_DD = alfaEntity.SAM_Chart_DD(this.m_List_DD, txtSourceName.Text);
            var p_List_SS = alfaEntity.SAM_Chart_SS(this.m_List_SS, txtSourceName.Text);

            // Create Series
            Series series_CC = this.CreateSeries("DATA (C)", ViewType.Bar, p_List_CC, "ADR_TARGET", "TOPLAM", Color.Blue);
            Series series_DD = this.CreateSeries("DATA (D)", ViewType.Bar, p_List_DD, "ADR_TARGET", "TOPLAM", Color.Red);
            Series series_SS = this.CreateSeries("DATA (S)", ViewType.Bar, p_List_SS, "ADR_TARGET", "TOPLAM", Color.Green);

            // Clear Series
            chartCC.Series.Clear();
            chartDD.Series.Clear();
            chartSS.Series.Clear();
            
            // Add Series
            chartCC.Series.Add(series_CC);
            chartDD.Series.Add(series_DD);
            chartSS.Series.Add(series_SS);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtSourceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Charts
            this.Build_Charts();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}