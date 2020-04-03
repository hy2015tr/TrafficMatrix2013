using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace TrafficMatrix2013
{
	public partial class FrmSplash : Form
	{
		//------------------------------------------------------------------------------------------------------//

		public FrmSplash()
		{
			// VS
			InitializeComponent();

			// HY
			InitializeSplashForm();
		}

		//------------------------------------------------------------------------------------------------------//

		private void InitializeSplashForm()
		{
			// Set Properties
            this.TopMost = true;
			this.ShowInTaskbar = false;
			this.Width = pictureSplash.Width;
			this.Height = pictureSplash.Height-1;
			this.FormBorderStyle = FormBorderStyle.None;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.lbVersion.Text = alfaStr.GetAppVersion(true);
		}

		//------------------------------------------------------------------------------------------------------//

		private void pictureSplash_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		//------------------------------------------------------------------------------------------------------//
	}
}