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
    public partial class frmPersonEdit : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbl;
        private DataTable tblc;
        private DataTable tblt;

        private string id = "";

        public frmPersonEdit(OleDbConnection cn, string id)
        {
            InitializeComponent();
            this.cn = cn;
            this.id = id;
        }

        private void loadData()
        {
            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "SELECT [country_id], [country_name] FROM [country] ORDER BY [country_name]",
                        cn
                        );
                    dba = new OleDbDataAdapter(dbc);
                    tblc = new DataTable();
                    dba.Fill(tblc);
                    txtCountry.DataSource = tblc;
                    txtCountry.DisplayMember = "country_name";
                    txtCountry.ValueMember = "country_id";

                    dbc = new OleDbCommand(
                        "SELECT [type_id], [type_name] FROM [type] ORDER BY [type_name]",
                        cn
                        );
                    dba = new OleDbDataAdapter(dbc);
                    tblt = new DataTable();
                    dba.Fill(tblt);
                    txtType.DataSource = tblt;
                    txtType.DisplayMember = "type_name";
                    txtType.ValueMember = "type_id";

                    dbc = new OleDbCommand(
                        "SELECT [type_id], [country_id], [person_name], [person_born], [person_died], [person_biography] FROM [person] WHERE [person_id] = " + this.id,
                        cn
                        );
                    dba = new OleDbDataAdapter(dbc);
                    tbl = new DataTable();
                    dba.Fill(tbl);
                    txtType.SelectedValue = int.Parse(tbl.Rows[0][0].ToString());
                    txtCountry.SelectedValue = int.Parse(tbl.Rows[0][1].ToString());
                    txtName.Text = tbl.Rows[0][2].ToString();
                    txtBorn.Text = (tbl.Rows[0][3].ToString()!=""?DateTime.Parse(tbl.Rows[0][3].ToString()).Day.ToString("D2") + "/" + DateTime.Parse(tbl.Rows[0][3].ToString()).Month.ToString("D2") + "/" + DateTime.Parse(tbl.Rows[0][3].ToString()).Year.ToString("D4") : "");
                    txtDied.Text = (tbl.Rows[0][4].ToString() != "" ? DateTime.Parse(tbl.Rows[0][4].ToString()).Day.ToString("D2") + "/" + DateTime.Parse(tbl.Rows[0][4].ToString()).Month.ToString("D2") + "/" + DateTime.Parse(tbl.Rows[0][4].ToString()).Year.ToString("D4") : "");
                    txtBio.Text = tbl.Rows[0][5].ToString();
                }
            }
            else
            {
                dbc = new OleDbCommand(
                    "SELECT [country_id], [country_name] FROM [country] ORDER BY [country_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tblc = new DataTable();
                dba.Fill(tblc);
                txtCountry.DataSource = tblc;
                txtCountry.DisplayMember = "country_name";
                txtCountry.ValueMember = "country_id";

                dbc = new OleDbCommand(
                    "SELECT [type_id], [type_name] FROM [type] ORDER BY [type_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tblt = new DataTable();
                dba.Fill(tblt);
                txtType.DataSource = tblt;
                txtType.DisplayMember = "type_name";
                txtType.ValueMember = "type_id";
            }
        }

        private void frmPersonEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "UPDATE [person] SET [type_id] = " + txtType.SelectedValue.ToString() + ", " +
                                            "[country_id] = " + txtCountry.SelectedValue.ToString() + ", " +
                                            "[person_name] = '" + txtName.Text + "', " +
                                            (txtBorn.Text == "  /  /" ? "[person_born] = Null, " : "[person_born] = #" + txtBorn.Text + "#, ") +
                                            (txtDied.Text == "  /  /" ? "[person_died] = Null, " : "[person_died] = #" + txtDied.Text + "#, ") +
                                            "[person_biography] = '" + txtBio.Text.Replace("\n\r", "") + "', " +
                                            "[last_update] = now() " +
                                            "WHERE [person_id] = " + this.id,
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
                        "INSERT INTO [person] ([type_id], [country_id], [person_name], [person_born], [person_died], [person_biography], [last_update], [admin_id]) " +
                        "VALUES (" + txtType.SelectedValue.ToString() + ", " + txtCountry.SelectedValue.ToString() + ", '" +
                                 txtName.Text + "', " + (txtBorn.Text == "  /  /" ? "Null, " : "#" + txtBorn.Text + "#, ") +
                                 (txtDied.Text == "  /  /" ? "Null, " : "#" + txtDied.Text + "#, ") + "'" + txtBio.Text.Replace("\n\r", "") + "', " +
                                 "now(), " + Program.user_id + ")",
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
