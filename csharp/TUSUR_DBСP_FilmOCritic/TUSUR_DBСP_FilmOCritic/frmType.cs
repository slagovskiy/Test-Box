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
    public partial class frmType : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;

        public frmType(OleDbConnection cn)
        {
            InitializeComponent();

            this.cn = cn;
        }

        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void loadData()
        {
            if (Toolbox.checkConnection(cn))
            {
                dbc = new OleDbCommand(
                    "SELECT [type_id], [type_name] FROM [type] ORDER BY [type_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbl = new DataTable();
                dba.Fill(tbl);
                dataGrid.DataSource = tbl;
                dataGrid.Columns[0].Width = 100;
                dataGrid.Columns[0].HeaderText = "Код";
                dataGrid.Columns[1].Width = 300;
                dataGrid.Columns[1].HeaderText = "Наименование";
            }
        }

        private void frmType_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnNewType_Click(object sender, EventArgs e)
        {
            string id = "";
            frmTypeEdit frm = new frmTypeEdit(cn, id);
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
            frmTypeEdit frm = new frmTypeEdit(cn, id);
            frm.ShowDialog();
            loadData();
        }
    }
}
