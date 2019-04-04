using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TUSUR_DBСP_FilmOCritic
{
    public partial class frmCountryEdit : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        private string id = "";

        public frmCountryEdit(OleDbConnection cn, string id)
        {
            InitializeComponent();
            this.cn = cn;
            this.id = id;
        }

        private void loadData()
        {
            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "SELECT [country_name] FROM [country] WHERE [country_id] = " + this.id,
                        cn
                        );
                    txtName.Text = dbc.ExecuteScalar().ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "UPDATE [country] SET [country_name] = '" + txtName.Text + "' WHERE [country_id] = " + this.id,
                        cn
                        );
                    dbc.ExecuteNonQuery();
                }
            }
            else
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "INSERT INTO [country] ([country_name]) VALUES ('" + txtName.Text + "')",
                        cn
                        );
                    dbc.ExecuteNonQuery();
                }
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCountryEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
