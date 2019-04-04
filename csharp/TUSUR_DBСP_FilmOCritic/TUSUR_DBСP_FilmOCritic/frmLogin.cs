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
    public partial class frmLogin : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;
        public string user_id;
        public frmLogin(OleDbConnection cn)
        {
            InitializeComponent();

            this.cn = cn;

            loadLogins();
        }

        private void loadLogins()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [admin_login] FROM [admin] ORDER BY [admin_login]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                txtLogin.DataSource = tbl;
                txtLogin.DisplayMember = "admin_login";
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [admin_password], [admin_id] FROM [admin] WHERE [admin_login] = '" + txtLogin.Text + "'",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                if (tbl.Rows.Count > 1)
                {
                    MessageBox.Show("Обнаружены дублирующиеся учетные записи, обратитесь к системному администратору!");
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
                else
                {
                    if (tbl.Rows[0][0].ToString().Trim() == txtPassword.Text)
                    {
                        this.user_id = tbl.Rows[0][1].ToString();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не правильный пароль!");
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                }
            }
        }
    }
}
