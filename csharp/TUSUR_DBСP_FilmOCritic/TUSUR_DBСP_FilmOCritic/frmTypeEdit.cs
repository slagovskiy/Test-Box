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
    public partial class frmTypeEdit : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        private string id = "";

        public frmTypeEdit(OleDbConnection cn, string id)
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
                        "SELECT [type_name] FROM [type] WHERE [type_id] = " + this.id,
                        cn
                        );
                    txtName.Text = dbc.ExecuteScalar().ToString();
                }
            }
        }

        private void frmTypeEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtName.Text == "Актер") || (txtName.Text == "Автор") || (txtName.Text == "Режиссер"))
            {

                if (this.id != "")
                {
                    if (Toolbox.checkConnection(cn))
                    {
                        dbc = new OleDbCommand(
                            "UPDATE [type] SET [type_name] = '" + txtName.Text + "' WHERE [type_id] = " + this.id,
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
                            "INSERT INTO [type] ([type_name]) VALUES ('" + txtName.Text + "')",
                            cn
                            );
                        dbc.ExecuteNonQuery();
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Не допустимое значение!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
