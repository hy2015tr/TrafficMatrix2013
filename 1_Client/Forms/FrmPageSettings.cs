using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace TrafficMatrix2013
{
    public partial class FrmPageSettings : XtraForm
    {

        //-----------------------------------------------------------------------------------------------------------------------------------------//
        
        public FrmPageSettings()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Tables
            this.Admin_Tables_Items();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Items()
        {
            // Clear List
            listAdminTables.Items.Clear();

            // Add Items
            listAdminTables.Items.Add(new alfaItem(" ( 1 )  -  USERS     ", "TableUser"));
            listAdminTables.Items.Add(new alfaItem(" ( 2 )  -  GROUPS    ", "TableGroup"));
            listAdminTables.Items.Add(new alfaItem(" ( 3 )  -  PARAMS    ", "TableParams"));
            listAdminTables.Items.Add(new alfaItem(" ( 4 )  -  CONFIGS   ", "TableConfig"));

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Refresh()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Get Item
                var p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Clear
                grdAdminView.Columns.Clear();

                // Set Datasource
                switch (p_Item.Name)
                {
                    case "TableUser": grdAdmin.DataSource = alfaEntity.TableUser_GetList(null, null); break;
                    case "TableGroup": grdAdmin.DataSource = alfaEntity.TableGroup_GetList(null, null); break;
                    case "TableParams": grdAdmin.DataSource = alfaEntity.TablePrms_GetList(); break;
                    case "TableConfig": grdAdmin.DataSource = alfaEntity.TableConfig_GetList(); break;
                }

                // Set GridView
                alfaGrid.SetView(grdAdminView, grdAdmin.DataSource);

                // Set Buttons
                alfaCtrl.SetButton(btnAdminUpdate, (grdAdminView.RowCount > 0));
                alfaCtrl.SetButton(btnAdminDelete, (grdAdminView.RowCount > 0));
                alfaCtrl.EnableControl(btnAdminInsert);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Update()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Object
                Object objEntity = null;

                // Check
                if (grdAdminView.FocusedRowHandle < 0) return;

                // Get ID
                var p_ID = (decimal)grdAdminView.GetRowCellValue(grdAdminView.FocusedRowHandle, "ID");

                // Get Item
                alfaItem p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Assign Object
                switch (p_Item.Name)
                {
                    case "TableUser": objEntity = DS.Context.SAM_USER.First(tt => tt.ID == p_ID); break;
                    case "TableGroup": objEntity = DS.Context.SAM_GROUP.First(tt => tt.ID == p_ID); break;
                    case "TableParams": objEntity = DS.Context.SAM_PRMS.First(tt => tt.ID == p_ID); break;
                    case "TableConfig": objEntity = DS.Context.SAM_CONFIG.First(tt => tt.ID == p_ID); break;
                }

                // Create Form
                FrmRecord frm = new FrmRecord(p_Item.ToString(), objEntity);

                // Confirmation
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // SaveChanges
                    DS.Context.SaveChanges();

                    // Refresh
                    this.Admin_Tables_Refresh();

                    // Get Row
                    int p_RowHandle = grdAdminView.LocateByValue("ID", p_ID, null);

                    // Select Row
                    alfaGrid.SelectRow(grdAdminView, p_RowHandle);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Insert()
        {
            using (alfaDS ent = new alfaDS())
            {
                // Create Object
                Object objEntity = null;

                // Get Item
                alfaItem p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Assign Object
                switch (p_Item.Name)
                {
                    case "TableUser": objEntity = new SAM_USER(); break;
                    case "TableGroup": objEntity = new SAM_GROUP(); break;
                    case "TableParams": objEntity = new SAM_PRMS(); break; 
                    case "TableConfig": objEntity = new SAM_CONFIG(); break; 
                }

                // Create Form
                FrmRecord frm = new FrmRecord(p_Item.ToString(), objEntity);

                // Confirmation
                if (frm.ShowDialog() != DialogResult.OK) return;

                // Add Record
                switch (p_Item.Name)
                {
                    case "TableUser": ent.Context.SAM_USER.Add(objEntity as SAM_USER); break;
                    case "TableGroup": ent.Context.SAM_GROUP.Add(objEntity as SAM_GROUP); break;
                    case "TableParams": ent.Context.SAM_PRMS.Add(objEntity as SAM_PRMS); break; 
                    case "TableConfig": ent.Context.SAM_CONFIG.Add(objEntity as SAM_CONFIG); break; 
                }

                // SaveChanges
                ent.Context.SaveChanges();
            }

            // DataSource
            this.Admin_Tables_Refresh();

            // Select Row
            alfaGrid.SelectRow(grdAdminView, grdAdminView.RowCount - 1);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Delete()
        {
            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Delete the Selected Record ?") == DialogResult.No) return;

            using (alfaDS ent = new alfaDS())
            {
                // Get Item
                alfaItem p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Get ID
                int p_ID =  Convert.ToInt32(grdAdminView.GetRowCellValue(grdAdminView.FocusedRowHandle, "ID"));

                // Delete Object
                switch (p_Item.Name)
                {
                    case "TableUser": ent.Context.SAM_USER.Remove(ent.Context.SAM_USER.First(tt => tt.ID == p_ID)); break;
                    case "TableGroup": ent.Context.SAM_GROUP.Remove(ent.Context.SAM_GROUP.First(tt => tt.ID == p_ID)); break;
                    case "TableParams": ent.Context.SAM_PRMS.Remove(ent.Context.SAM_PRMS.First(tt => tt.ID == p_ID)); break; 
                    case "TableConfig": ent.Context.SAM_CONFIG.Remove(ent.Context.SAM_CONFIG.First(tt => tt.ID == p_ID)); break; 
                }

                // SaveChanges
                ent.Context.SaveChanges();
            }

            // DataSource
            this.Admin_Tables_Refresh();

            //Focus
            grdAdminView.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnAdminUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Update Record
                this.Admin_Tables_Update();
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnAdminInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Add Record
                this.Admin_Tables_Insert();
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnAdminDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete Record
                this.Admin_Tables_Delete();
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void listAdminTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get Tables
            this.Admin_Tables_Refresh();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdAdminView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                // Update 
                if (e.KeyCode == Keys.Enter && btnAdminUpdate.Enabled) this.btnAdminUpdate_Click(null, null);

                // Delete
                if (e.KeyCode == Keys.Delete && btnAdminDelete.Enabled) this.btnAdminDelete_Click(null, null);

                // Insert
                if (e.KeyCode == Keys.Insert && btnAdminInsert.Enabled) this.btnAdminInsert_Click(null, null);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdAdminView_DoubleClick(object sender, EventArgs e)
        {
            // Update
            this.btnAdminUpdate_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//
    }
}
