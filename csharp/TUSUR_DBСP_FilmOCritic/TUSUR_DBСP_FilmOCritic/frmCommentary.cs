using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TUSUR_DBСP_FilmOCritic
{
    public partial class frmCommentary : Form
    {

        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;
        private DataTable tblf;
        private DataTable tblu;

        public frmCommentary(OleDbConnection cn)
        {
            InitializeComponent();

            this.cn = cn;
        }

        private void frmCommentary_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [Commentary].[comment_id], [Commentary].[comment_date], [Film].[film_name], [User].[user_login], [Commentary].[comment_published], " +
                    "[Commentary].[comment_bad], [Commentary].[comment_tested], [Admin].[admin_login]" +
                    "FROM [Admin] RIGHT JOIN ([User] INNER JOIN ([Film] INNER JOIN [Commentary] ON [Film].[film_id] = [Commentary].[film_id]) ON [User].[user_id] = [Commentary].[user_id]) ON [Admin].[admin_id] = [Commentary].[admin_id]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                dataGrid.DataSource = tbl;
                dataGrid.Columns[0].Width = 30;
                dataGrid.Columns[0].HeaderText = "Код";
                dataGrid.Columns[1].Width = 70;
                dataGrid.Columns[1].HeaderText = "Дата";
                dataGrid.Columns[2].Width = 150;
                dataGrid.Columns[2].HeaderText = "Фильм";
                dataGrid.Columns[3].Width = 100;
                dataGrid.Columns[3].HeaderText = "Пользователь";
                dataGrid.Columns[4].Width = 80;
                dataGrid.Columns[4].HeaderText = "Опубликован";
                dataGrid.Columns[5].Width = 80;
                dataGrid.Columns[5].HeaderText = "Плохой";
                dataGrid.Columns[6].Width = 80;
                dataGrid.Columns[6].HeaderText = "Проверен";
                dataGrid.Columns[7].Width = 100;
                dataGrid.Columns[7].HeaderText = "Администратор";
            }
        }

        private void btnRazbor_Click(object sender, EventArgs e)
        {
            dbc = new OleDbCommand(
                "SELECT [comment_id] FROM [commentary] WHERE [comment_tested] is Null ORDER BY [comment_date]",
                cn
                );
            dba = new OleDbDataAdapter(dbc);
            tbl = new DataTable();
            dba.Fill(tbl);
            if (tbl.Rows.Count == 0)
                MessageBox.Show("Нет не проверенных комментариев");
            foreach (DataRow rw in tbl.Rows)
            {
                frmCommentAllow frm = new frmCommentAllow(cn, rw[0].ToString());
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.No)
                    break;
            }
            loadData();
        }

        private void btnNewComments_Click(object sender, EventArgs e)
        {
            string randtext = "qazwsxedcrfvtgbyhnujmikolpйфяцычувскамепинртгоьшлбщдюзжхэъ";
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [film_id] FROM [film]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tblf = new DataTable();
                dba.Fill(tblf);

                dbc = new OleDbCommand(
                    "SELECT [user_id] FROM [user]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tblu = new DataTable();
                dba.Fill(tblu);

                for (int i = 0; i < 10; i++)
                {
                    Random rnd = new Random(Environment.TickCount);
                    int film = (int)tblf.Rows[rnd.Next(tblf.Rows.Count)][0];
                    int user = (int)tblu.Rows[rnd.Next(tblu.Rows.Count)][0];
                    string text = "";
                    int words = rnd.Next(50) + 5;
                    for (int j = 0; j < words; j++)
                    {
                        int word_len = rnd.Next(10) + 5;
                        for (int k = 0; k < word_len; k++)
                        {
                            text += randtext[rnd.Next(randtext.Length)];
                        }
                        text += " ";
                    }
                    dbc = new OleDbCommand(
                        "INSERT INTO [Commentary] ([film_id], [user_id], [comment_date], [comment_text], [admin_id], [comment_published], [comment_bad], [comment_tested]) " +
                        "VALUES(" + film.ToString() + ", " + user.ToString() + ", now(), '" + text + "', 0, False, False, Null)",
                        cn
                        );
                    dbc.ExecuteNonQuery();
                    Thread.Sleep(128);
                }
            }
            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = "";
            id = dataGrid[0, (dataGrid.SelectedCells[0]).RowIndex].Value.ToString();
            frmCommentAllow frm = new frmCommentAllow(cn, id);
            frm.ShowDialog();
            loadData();
        }
    }
}
