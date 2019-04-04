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
    public partial class frmRating : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;
        private DataTable tblf;
        private DataTable tblu;

        public frmRating(OleDbConnection cn)
        {
            InitializeComponent();

            this.cn = cn;
        }

        private void frmRating_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [Rating].[rating_date], [Film].[film_name], [User].[user_login], [Rating].[rating_num] " +
                    "FROM[User] INNER JOIN([Film] INNER JOIN [Rating] ON [Film].[film_id] = [Rating].[film_id]) ON [User].[user_id] = [Rating].[user_id] " +
                    "ORDER BY [Rating].[rating_date]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                dataGrid.DataSource = tbl;
                dataGrid.Columns[0].Width = 70;
                dataGrid.Columns[0].HeaderText = "Дата";
                dataGrid.Columns[1].Width = 150;
                dataGrid.Columns[1].HeaderText = "Фильм";
                dataGrid.Columns[2].Width = 150;
                dataGrid.Columns[2].HeaderText = "Пользователь";
                dataGrid.Columns[3].Width = 70;
                dataGrid.Columns[3].HeaderText = "Оценка";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewComments_Click(object sender, EventArgs e)
        {
            dbc = new OleDbCommand(
                "SELECT [user_id] from [user]",
                cn
                );
            dba = new OleDbDataAdapter(dbc);
            tblu = new DataTable();
            dba.Fill(tblu);

            dbc = new OleDbCommand(
                "SELECT [film_id] FROM [film]",
                cn
                );
            dba = new OleDbDataAdapter(dbc);
            tblf = new DataTable();
            dba.Fill(tblf);

            foreach(DataRow rwu in tblu.Rows)
            {
                foreach (DataRow rwf in tblf.Rows)
                {
                    dbc = new OleDbCommand(
                        "SELECT [rating_num] FROM [rating] WHERE [user_id] = " + rwu[0].ToString() + " AND [film_id] = " + rwf[0].ToString(),
                        cn
                        );
                    if (dbc.ExecuteScalar() == null)
                    {
                        Random rnd = new Random(Environment.TickCount);
                        dbc = new OleDbCommand(
                            "INSERT INTO [rating] ([user_id], [film_id], [rating_date], [rating_num]) " +
                            "VALUES (" + rwu[0].ToString() + ", " + rwf[0].ToString() + ", now(), " + (rnd.Next(4) + 1).ToString() + ")",
                            cn
                            );
                        dbc.ExecuteNonQuery();
                        loadData();
                        return;
                    }
                }
            }
            MessageBox.Show("Каждый пользователь поставил оцеку всем фильмам");
        }
    }
}
