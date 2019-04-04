using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TUSUR_DBСP_FilmOCritic
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnDatabaseFile_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                txtDatabaseFile.Text = openFileDialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["database"] = txtDatabaseFile.Text;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtDatabaseFile.Text = Properties.Settings.Default["database"].ToString();
        }
    }
}
