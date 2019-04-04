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
    public partial class frmUser : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        public frmUser(OleDbConnection cn)
        {
            InitializeComponent();

            this.cn = cn;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [user_id], [user_login], [user_email], [user_locked] FROM [User] ORDER BY [user_login]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                dataGrid.DataSource = tbl;
                dataGrid.Columns[0].Width = 30;
                dataGrid.Columns[0].HeaderText = "Код";
                dataGrid.Columns[1].Width = 150;
                dataGrid.Columns[1].HeaderText = "Логин";
                dataGrid.Columns[2].Width = 150;
                dataGrid.Columns[2].HeaderText = "Почта";
                dataGrid.Columns[3].Width = 100;
                dataGrid.Columns[3].HeaderText = "Заблокирован";
            }
        }

        private void btnNewPerson_Click(object sender, EventArgs e)
        {
            string id = "";
            frmUserEdit frm = new frmUserEdit(cn, id);
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
            frmUserEdit frm = new frmUserEdit(cn, id);
            frm.ShowDialog();
            loadData();
        }
    }
}
