using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TUSUR_DBСP_FilmOCritic
{
    public partial class frmFilmEdit : Form
    {
        public OleDbConnection cn;
        private OleDbDataAdapter dba;
        private OleDbCommand dbc;
        private DataTable tbla;
        private DataTable tblt;
        private DataTable tblaf;
        private DataTable tblp;
        private DataTable tblg;
        private DataTable tblc;
        private DataTable tbl;

        private string filePath = "";

        private string id = "";


        public frmFilmEdit(OleDbConnection cn, string id)
        {
            InitializeComponent();
            this.cn = cn;
            this.id = id;
        }

        private void loadData()
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
                    "SELECT [genre_id], [genre_name] FROM [genre] ORDER BY [genre_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tblg = new DataTable();
                dba.Fill(tblg);
                txtGenre.DataSource = tblg;
                txtGenre.DisplayMember = "genre_name";
                txtGenre.ValueMember = "genre_id";

                dbc = new OleDbCommand(
                    "SELECT [Person].[person_id], [Person].[person_name] FROM " +
                    "[Type] INNER JOIN [Person] ON [Type].[type_id] = [Person].[type_id] WHERE([Type].[type_name]) = 'Режиссер' " +
                    "ORDER BY [Person].[person_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tblp = new DataTable();
                dba.Fill(tblp);
                txtProducer.DataSource = tblp;
                txtProducer.DisplayMember = "person_name";
                txtProducer.ValueMember = "person_id";

                dbc = new OleDbCommand(
                    "SELECT [Person].[person_id], [Person].[person_name] FROM " +
                    "[Type] INNER JOIN [Person] ON [Type].[type_id] = [Person].[type_id] WHERE([Type].[type_name]) = 'Автор' " +
                    "ORDER BY [Person].[person_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tbla = new DataTable();
                dba.Fill(tbla);
                txtAuthor.DataSource = tbla;
                txtAuthor.DisplayMember = "person_name";
                txtAuthor.ValueMember = "person_id";

                dbc = new OleDbCommand(
                    "SELECT [Person].[person_id], [Person].[person_name] FROM " +
                    "[Type] INNER JOIN [Person] ON [Type].[type_id] = [Person].[type_id] WHERE([Type].[type_name]) = 'Актер' " +
                    "ORDER BY [Person].[person_name]",
                    cn
                    );
                dba = new OleDbDataAdapter(dbc);
                tblt = new DataTable();
                dba.Fill(tblt);
                listActor.DataSource = tblt;
                listActor.DisplayMember = "person_name";
                listActor.ValueMember = "person_id";
            }

            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "SELECT [film_id], [genre_id], [country_id], [film_name], [film_author], [film_producer], [film_year], [film_poster], [film_description], [film_limit] " +
                        "FROM [film] WHERE [film_id] = " + this.id,
                        cn
                        );
                    dba = new OleDbDataAdapter(dbc);
                    tbl = new DataTable();
                    dba.Fill(tbl);
                    txtGenre.SelectedValue = int.Parse(tbl.Rows[0]["genre_id"].ToString());
                    txtCountry.SelectedValue = int.Parse(tbl.Rows[0]["country_id"].ToString());
                    txtName.Text = tbl.Rows[0]["film_name"].ToString();
                    txtAuthor.SelectedValue = int.Parse(tbl.Rows[0]["film_author"].ToString());
                    txtProducer.SelectedValue = int.Parse(tbl.Rows[0]["film_producer"].ToString());
                    txtYear.Text = tbl.Rows[0]["film_year"].ToString();
                    txtDescription.Text = tbl.Rows[0]["film_description"].ToString();
                    txtLimit.Text = tbl.Rows[0]["film_limit"].ToString();

                    dbc = new OleDbCommand(
                        "SELECT [person_id], [film_id] FROM [Actor] WHERE [film_id] = " + this.id,
                        cn
                        );
                    dba = new OleDbDataAdapter(dbc);
                    tblaf = new DataTable();
                    dba.Fill(tblaf);
                    listActor.ClearSelected();
                    foreach (DataRow rw in tblaf.Rows)
                    {
                        listActor.SelectedValue = rw["person_id"];
                    }

                    if (tbl.Rows[0]["film_poster"]!=DBNull.Value)
                    {
                        byte[] _img = (byte[])tbl.Rows[0]["film_poster"];
                        if (_img == null)
                            picPoster.Image = null;
                        else
                        {
                            MemoryStream ms = new MemoryStream(_img);
                            picPoster.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }
            }
            else
            {
                listActor.ClearSelected();
            }
        }


        private void frmFilmEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            if (this.filePath != "")
            {
                FileStream fs = new FileStream(this.filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
            }

            if (this.id != "")
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "UPDATE [film] SET [genre_id] = " + txtGenre.SelectedValue.ToString() + 
                        ", [country_id] = " + txtCountry.SelectedValue.ToString() +
                        ", [film_name] = '" + txtName.Text + "'" +
                        ", [film_author] = " + txtAuthor.SelectedValue.ToString() +
                        ", [film_producer] = " + txtProducer.SelectedValue.ToString() +
                        ", [film_year] = " + txtYear.Text +
                        (img!=null?", [film_poster] = @IMG":"") + 
                        ", [film_description] = '" + txtDescription.Text.Replace("\n\r", "") + "'" +
                        ", [film_limit] = " + txtLimit.Text +
                        ", [last_update] = Now() " +
                        "WHERE [film_id] = " + this.id,
                        cn
                        );
                    if (img != null)
                        dbc.Parameters.Add(new OleDbParameter("@IMG", img));
                    dbc.ExecuteNonQuery();

                    dbc = new OleDbCommand(
                        "DELETE FROM [Actor] WHERE [film_id] = " + this.id,
                        cn
                        );
                    dbc.ExecuteNonQuery();
                    foreach (DataRowView item in listActor.SelectedItems)
                    {
                        dbc = new OleDbCommand(
                            "INSERT INTO [actor] ([film_id], [person_id]) VALUES (" + this.id + ", " + item.Row[0].ToString() + ")",
                            cn
                            );
                        dbc.ExecuteNonQuery();
                    }

                }
            }
            else
            {
                if (Toolbox.checkConnection(cn))
                {
                    dbc = new OleDbCommand(
                        "INSERT INTO [film] ([admin_id], [genre_id], [country_id], [film_name], [film_author], [film_producer], [film_year], [film_poster], [film_description], [film_limit], [last_update]) " +
                        "VALUES (" + Program.user_id + ", " + txtGenre.SelectedValue.ToString() + ", " + txtCountry.SelectedValue.ToString() + ", '" +
                        txtName.Text + "', " + txtAuthor.SelectedValue.ToString() + ", " + txtProducer.SelectedValue.ToString() + ", " + txtYear.Text + "," +
                        "" + (img==null?"Null":"@IMG") + ", '" + txtDescription.Text.Replace("\n\r", "") + "', " + txtLimit.Text + ", now())",
                        cn
                        );
                    if (img != null)
                        dbc.Parameters.Add(new OleDbParameter("@IMG", img));
                    dbc.ExecuteNonQuery();
                    dbc = new OleDbCommand(
                        "SELECT @@Identity;",
                        cn
                        );
                    string id = dbc.ExecuteScalar().ToString();

                    foreach (DataRowView item in listActor.SelectedItems)
                    {
                        dbc = new OleDbCommand(
                            "INSERT INTO [actor] ([film_id], [person_id]) VALUES (" + id + ", " + item.Row[0].ToString() + ")",
                            cn
                            );
                        dbc.ExecuteNonQuery();
                    }
                }
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPoster_Click(object sender, EventArgs e)
        {
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                this.filePath = openFile.FileName;
                picPoster.ImageLocation = this.filePath;
            }


        }
    }
}
