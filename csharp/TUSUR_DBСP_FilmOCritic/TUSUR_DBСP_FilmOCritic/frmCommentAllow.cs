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
    public partial class frmCommentAllow : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        private string id = "0";

        public frmCommentAllow(OleDbConnection cn, string id)
        {
            InitializeComponent();

            this.cn = cn;
            this.id = id;
        }

        private void frmCommentAllow_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [Commentary].[comment_id], [Film].[film_name], [User].[user_login], [Commentary].[comment_date], [Commentary].[comment_tested], [Commentary].[comment_text] " +
                    "FROM [Film] INNER JOIN([User] INNER JOIN [Commentary] ON [User].[user_id] = [Commentary].[user_id]) ON [Film].[film_id] = [Commentary].[film_id] " +
                    "WHERE [Commentary].[comment_id] = " + this.id,
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                txtUser.Text = tbl.Rows[0]["user_login"].ToString();
                txtFilm.Text = tbl.Rows[0]["film_name"].ToString();
                txtComment.Text = tbl.Rows[0]["comment_text"].ToString();
                if (tbl.Rows[0]["comment_tested"].ToString() != "")
                {
                    btnBad.Enabled = false;
                    btnNext.Enabled = false;
                    btnPub.Enabled = false;
                }
            }
        }

        private void btnPub_Click(object sender, EventArgs e)
        {
            dbc = new OleDbCommand(
                "UPDATE [commentary] SET [admin_id] = " + Program.user_id + ", comment_published = True, comment_bad = False, comment_tested = Now() WHERE [comment_id] = " + this.id,
                cn
                );
            dbc.ExecuteNonQuery();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBad_Click(object sender, EventArgs e)
        {
            dbc = new OleDbCommand(
                "UPDATE [commentary] SET [admin_id] = " + Program.user_id + ", comment_published = False, comment_bad = True, comment_tested = Now() WHERE [comment_id] = " + this.id, 
                cn
                );
            dbc.ExecuteNonQuery();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dbc = new OleDbCommand(
                "UPDATE [commentary] SET [admin_id] = " + Program.user_id + ", comment_published = False, comment_bad = False, comment_tested = Now() WHERE [comment_id] = " + this.id,
                cn
                );
            dbc.ExecuteNonQuery();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ftnFinish_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
