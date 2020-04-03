﻿namespace TrafficMatrix2013
{
    partial class FrmRecord
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
            this.propGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtTabloAdi = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.propGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTabloAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // propGrid
            // 
            this.propGrid.Appearance.FocusedCell.BackColor = System.Drawing.Color.Yellow;
            this.propGrid.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.propGrid.Appearance.FocusedCell.Options.UseBackColor = true;
            this.propGrid.Appearance.FocusedCell.Options.UseForeColor = true;
            this.propGrid.Location = new System.Drawing.Point(21, 75);
            this.propGrid.Name = "propGrid";
            this.propGrid.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            this.propGrid.OptionsBehavior.ResizeHeaderPanel = false;
            this.propGrid.OptionsBehavior.ResizeRowHeaders = false;
            this.propGrid.OptionsBehavior.ResizeRowValues = false;
            this.propGrid.OptionsBehavior.UseEnterAsTab = true;
            this.propGrid.OptionsView.ShowRootCategories = false;
            this.propGrid.RecordWidth = 150;
            this.propGrid.RowHeaderWidth = 50;
            this.propGrid.Size = new System.Drawing.Size(500, 280);
            this.propGrid.TabIndex = 0;
            this.propGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.propGrid_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(320, 372);
            this.btnSave.LookAndFeel.SkinName = "Glass Oceans";
            this.btnSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(441, 372);
            this.btnCancel.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTabloAdi
            // 
            this.txtTabloAdi.EditValue = "TEST";
            this.txtTabloAdi.Location = new System.Drawing.Point(21, 30);
            this.txtTabloAdi.Name = "txtTabloAdi";
            this.txtTabloAdi.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.txtTabloAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTabloAdi.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua;
            this.txtTabloAdi.Properties.Appearance.Options.UseBackColor = true;
            this.txtTabloAdi.Properties.Appearance.Options.UseFont = true;
            this.txtTabloAdi.Properties.Appearance.Options.UseForeColor = true;
            this.txtTabloAdi.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTabloAdi.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTabloAdi.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTabloAdi.Properties.MaxLength = 10;
            this.txtTabloAdi.Properties.ReadOnly = true;
            this.txtTabloAdi.Size = new System.Drawing.Size(500, 26);
            this.txtTabloAdi.TabIndex = 3;
            // 
            // FrmRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 422);
            this.Controls.Add(this.txtTabloAdi);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.propGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRecord";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Record Form";
            this.Shown += new System.EventHandler(this.FrmRecord_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRecord_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.propGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTabloAdi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propGrid;
        private DevExpress.XtraEditors.TextEdit txtTabloAdi;
    }
}