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
    public partial class frmGenreEdit : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        private string id = "";

        public frmGenreEdit(OleDbConnection cn, string id)
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
                        "SELECT [genre_name] FROM [genre] WHERE [genre_id] = " + this.id,
                        cn
                        );
                    txtName.Text = dbc.ExecuteScalar().ToString();
                }
            }
        }


        private void frmGenreEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "UPDATE [genre] SET [genre_name] = '" + txtName.Text + "' WHERE [genre_id] = " + this.id,
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
                        "INSERT INTO [genre] ([genre_name]) VALUES ('" + txtName.Text + "')",
                        cn
                        );
                    dbc.ExecuteNonQuery();
                }
            }
            this.Close();
        }
    }
}
