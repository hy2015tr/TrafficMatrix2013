using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace TrafficMatrix2013
{
    public partial class FrmPageReport : XtraForm
    {

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        // Fields
        private List<SAM_DATA_C> m_List_CC = null;
        private List<SAM_DATA_D> m_List_DD = null;
        private List<SAM_DATA_S> m_List_SS = null;

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageReport()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Reset
            this.btnClearList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClearList_Click(object sender, EventArgs e)
        {
            // DateTime
            DateTime dtNow = DateTime.Now;

            // Set DateTime
            dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

            // Reset DateTime
            ListDT01.DateTime = dtNow.AddDays(-0);
            ListDT02.DateTime = dtNow.AddDays(+1);
                
            // Reset DataSource
            grd_DataCC.DataSource = null;
            grd_DataDD.DataSource = null;
            grd_DataSS.DataSource = null;

            // Reset Columns
            grdView_DataCC.Columns.Clear();
            grdView_DataDD.Columns.Clear();
            grdView_DataSS.Columns.Clear();

            // Reset Fields
            this.m_List_CC = null;
            this.m_List_DD = null;
            this.m_List_SS = null;

            // SetPage
            TabMain.SelectedTabPage = page01;

            // Focus
            grpSelection.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                // Cursor
                alfaMsg.CursorWait();

                // GetList
                this.m_List_CC = alfaEntity.SAM_GetList_CC(ListDT01.DateTime, ListDT02.DateTime);
                this.m_List_DD = alfaEntity.SAM_GetList_DD(ListDT01.DateTime, ListDT02.DateTime);
                this.m_List_SS = alfaEntity.SAM_GetList_SS(ListDT01.DateTime, ListDT02.DateTime);

                // SetView Data
                alfaGrid.SetView(grdView_DataCC, this.m_List_CC);
                alfaGrid.SetView(grdView_DataDD, this.m_List_DD);
                alfaGrid.SetView(grdView_DataSS, this.m_List_SS);

                using (alfaDS DS = new alfaDS())
                {
                    // Set List
                    alfaEntity.m_SamConfigList = DS.Context.SAM_CONFIG.ToList();
                }

                // SetView Matrix
                alfaGrid.SetView(grdView_MatrixCC, alfaEntity.SAM_Matrix_CC(this.m_List_CC));
                alfaGrid.SetView(grdView_MatrixDD, alfaEntity.SAM_Matrix_DD(this.m_List_DD));
                alfaGrid.SetView(grdView_MatrixSS, alfaEntity.SAM_Matrix_SS(this.m_List_SS));

                // Cursor
                alfaMsg.CursorDefult();
            }

            catch (Exception ex)
            {
                // Message
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdViewALL_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            // Check
            if (e.RowHandle < 0) return;

            // Get Grid
            var p_GridView = (GridView)sender;

            // Check Selected
            if (p_GridView.IsRowSelected(e.RowHandle)) return;

            // Check Focused Row
            if (e.RowHandle == p_GridView.FocusedRowHandle) return;

            if ("DT_WIN-ADR_SOURCE".Contains(e.Column.FieldName))
            {
                // Custom View
                e.Appearance.BackColor = Color.Lavender;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}