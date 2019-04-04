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
    public partial class frmUserEdit : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        private string id = "";

        public frmUserEdit(OleDbConnection cn, string id)
        {
            InitializeComponent();
            this.cn = cn;
            this.id = id;
        }

        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "SELECT [user_login], [user_password], [user_email], [user_locked], [user_write_from] FROM [user] WHERE [user_id] = " + this.id,
                        cn
                        );
                    dba = new OleDbDataAdapter(dbc);
                    tbl = new DataTable();
                    dba.Fill(tbl);
                    txtLogin.Text = tbl.Rows[0]["user_login"].ToString();
                    txtPassword.Text = tbl.Rows[0]["user_password"].ToString();
                    txtEmail.Text = tbl.Rows[0]["user_email"].ToString();
                    checkLock.Checked = (bool)tbl.Rows[0]["user_locked"];
                    dateWrite.Value = (DateTime)tbl.Rows[0]["user_write_from"];
                }
            }
            else
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "UPDATE [user] SET [user_login] = '" + txtLogin.Text + "', " +
                                            "[user_password] = '" + txtPassword.Text + "', " +
                                            "[user_email] = '" + txtEmail.Text + "', " +
                                            "[user_locked] = " + checkLock.Checked.ToString() + ", " +
                                            "[user_write_from] = #" + dateWrite.Value.ToShortDateString() + "#" +
                                            "WHERE [user_id] = " + this.id,
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
                        "INSERT INTO [user] ([user_login], [user_password], [user_email], [user_locked], [user_write_from]) " +
                        "VALUES ('" + txtLogin.Text + "', '" + txtPassword.Text + "', '" + txtEmail.Text + "', " + checkLock.Checked.ToString() + ", #" + dateWrite.Value.ToShortDateString() + "#)",
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
    }
}
