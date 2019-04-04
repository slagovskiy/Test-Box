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
    public partial class frmFilm : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        public frmFilm(OleDbConnection cn)
        {
            InitializeComponent();

            this.cn = cn;
        }

        private void frmFilm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [Film].[film_id], [Film].[film_name], [Film].[film_year], [Admin].[admin_login], [Film].[last_update] " +
                    "FROM [Admin] INNER JOIN [Film] ON [Admin].[admin_id] = [Film].[admin_id] " +
                    "ORDER BY [Film].[film_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                dataGrid.DataSource = tbl;
                dataGrid.Columns[0].Width = 70;
                dataGrid.Columns[0].HeaderText = "Код";
                dataGrid.Columns[1].Width = 300;
                dataGrid.Columns[1].HeaderText = "Наименование";
                dataGrid.Columns[2].Width = 70;
                dataGrid.Columns[2].HeaderText = "Год";
                dataGrid.Columns[3].Width = 150;
                dataGrid.Columns[3].HeaderText = "Завел";
                dataGrid.Columns[4].Width = 70;
                dataGrid.Columns[4].HeaderText = "Обновлено";
            }
        }

        private void btnNewFilm_Click(object sender, EventArgs e)
        {
            string id = "";
            frmFilmEdit frm = new frmFilmEdit(cn, id);
            frm.ShowDialog();
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
            frmFilmEdit frm = new frmFilmEdit(cn, id);
            frm.ShowDialog();
            loadData();
        }
    }
}
