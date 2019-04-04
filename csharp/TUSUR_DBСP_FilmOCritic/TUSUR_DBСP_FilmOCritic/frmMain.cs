using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace TUSUR_DBСP_FilmOCritic
{
    public partial class frmMain : Form
    {
        OleDbConnection cn = new OleDbConnection();

        public frmMain()
        {
            InitializeComponent();

            initConnection();
        }

        private void initConnection()
        {
            OleDbConnectionStringBuilder cnString = new OleDbConnectionStringBuilder();
            cnString["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            cnString["Data Source"] = Properties.Settings.Default["database"].ToString();
            if (cn.State == ConnectionState.Open)
                cn.Close();
            cn.ConnectionString = cnString.ToString();
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                openSettings();
            }

        }

        private void openSettings()
        {
            frmSettings frm = new frmSettings();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                initConnection();
            }
        }

        private bool login()
        {
            bool ok = false;

            frmLogin frm = new frmLogin(cn);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ok = true;
                Program.user_id = frm.user_id;
            }

            return ok;
        }

        private bool reopenForm(string formName)
        {
            bool ok = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == formName)
                {
                    f.MdiParent = this;
                    f.Show();
                    f.WindowState = FormWindowState.Maximized;
                    ok = true;
                }
            }
            return ok;
        }

        private void openGenre()
        {
            if (!reopenForm("frmGenre"))
            {
                frmGenre frm = new frmGenre(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void openCountry()
        {
            if (!reopenForm("frmCountry"))
            {
                frmCountry frm = new frmCountry(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void openTypePerson()
        {
            if (!reopenForm("frmType"))
            {
                frmType frm = new frmType(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void openPerson()
        {
            if (!reopenForm("frmPerson"))
            {
                frmPerson frm = new frmPerson(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void openFilm()
        {
            if (!reopenForm("frmFilm"))
            {
                frmFilm frm = new frmFilm(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void openUser()
        {
            if (!reopenForm("frmUser"))
            {
                frmUser frm = new frmUser(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void openComment()
        {
            if (!reopenForm("frmCommentary"))
            {
                frmCommentary frm = new frmCommentary(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void openRating()
        {
            if (!reopenForm("frmRating"))
            {
                frmRating frm = new frmRating(cn);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void settingsMenu_Click(object sender, EventArgs e)
        {
            openSettings();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!login())
            {
                this.Close();
            }
        }

        private void genreMenu_Click(object sender, EventArgs e)
        {
            openGenre();
        }

        private void countryMenu_Click(object sender, EventArgs e)
        {
            openCountry();
        }

        private void typePersonMenu_Click(object sender, EventArgs e)
        {
            openTypePerson();
        }

        private void personMenu_Click(object sender, EventArgs e)
        {
            openPerson();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filmMenu_Click(object sender, EventArgs e)
        {
            openFilm();
        }

        private void userMenu_Click(object sender, EventArgs e)
        {
            openUser();
        }

        private void commentMenu_Click(object sender, EventArgs e)
        {
            openComment();
        }

        private void ratingMenu_Click(object sender, EventArgs e)
        {
            openRating();
        }

        private void reportPersonMenu_Click(object sender, EventArgs e)
        {
            using(frmPersonReport frm = new frmPersonReport())
            {
                frm.ShowDialog();
            }
        }

        private void reportFilmMenu_Click(object sender, EventArgs e)
        {
            using (frmFilmReport frm = new frmFilmReport())
            {
                frm.ShowDialog();
            }
        }

        private void reportCommentMenu_Click(object sender, EventArgs e)
        {
            using (frmCommentReport frm = new frmCommentReport())
            {
                frm.ShowDialog();
            }
        }
    }
}
