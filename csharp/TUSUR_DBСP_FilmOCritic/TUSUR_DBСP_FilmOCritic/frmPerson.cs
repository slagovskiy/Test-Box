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
    public partial class frmPerson : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        public frmPerson(OleDbConnection cn)
        {
            InitializeComponent();

            this.cn = cn;
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [Person].[person_id] as [person_id], [Person].[person_name] as [person_name], [Country].[country_name] as [country_name], " +
                    "[Type].[type_name] as [type_name], [Person].[person_born] as [persond_born], [Person].[person_died] as [person_died], " +
                    "[Admin].[admin_login] as [admin_login], [Person].[last_update] as [last_update] " +
                    "FROM [Type] INNER JOIN([Admin] INNER JOIN([Country] INNER JOIN [Person] ON [Country].[country_id] = [Person].[country_id]) " +
                    "ON [Admin].[admin_id] = [Person].[admin_id]) ON [Type].[type_id] = [Person].[type_id]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                dataGrid.DataSource = tbl;
                dataGrid.Columns[0].Width = 30;
                dataGrid.Columns[0].HeaderText = "Код";
                dataGrid.Columns[1].Width = 150;
                dataGrid.Columns[1].HeaderText = "ФИО";
                dataGrid.Columns[2].Width = 100;
                dataGrid.Columns[2].HeaderText = "Страна";
                dataGrid.Columns[3].Width = 100;
                dataGrid.Columns[3].HeaderText = "Тип";
                dataGrid.Columns[4].Width = 70;
                dataGrid.Columns[4].HeaderText = "Родился";
                dataGrid.Columns[5].Width = 70;
                dataGrid.Columns[5].HeaderText = "Умер";
                dataGrid.Columns[6].Width = 70;
                dataGrid.Columns[6].HeaderText = "Добавил";
                dataGrid.Columns[7].Width = 70;
                dataGrid.Columns[7].HeaderText = "Обновлено";
            }
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            string id = "";
            frmPersonEdit frm = new frmPersonEdit(cn, id);
            frm.ShowDialog();
            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = "";
            id = dataGrid[0, (dataGrid.SelectedCells[0]).RowIndex].Value.ToString();
            frmPersonEdit frm = new frmPersonEdit(cn, id);
            frm.ShowDialog();
            loadData();
        }
    }
}
