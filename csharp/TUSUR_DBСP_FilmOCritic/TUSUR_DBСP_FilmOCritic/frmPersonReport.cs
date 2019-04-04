using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using objAccApp = Microsoft.Office.Interop.Access;


namespace TUSUR_DBСP_FilmOCritic
{
    public partial class frmPersonReport : Form
    {
        public frmPersonReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string file = "";
            if (Properties.Settings.Default["database"].ToString() == "db.mdb")
                file = Application.StartupPath + "\\" + Properties.Settings.Default["database"].ToString();
            else
                file = Properties.Settings.Default["database"].ToString();
            objAccApp.Application app = new objAccApp.Application();
            app.OpenCurrentDatabase(file, false, "");
            app.Visible = false;
            app.DoCmd.OpenReport("repPerson", Microsoft.Office.Interop.Access.AcView.acViewPreview, System.Reflection.Missing.Value, "(([Person].[last_update] Between #" + date.Value.ToShortDateString() + "# And #" + date.Value.ToShortDateString() + " 23:59:00#) AND ([Admin].[admin_id] = " + Program.user_id + "))"); //Type.Missing, objAccApp.AcWindowMode.acWindowNormal, Type.Missing);
            app.DoCmd.PrintOut(objAccApp.AcPrintRange.acPrintAll, Type.Missing, Type.Missing, objAccApp.AcPrintQuality.acHigh, Type.Missing, Type.Missing);
            app.DoCmd.CloseDatabase();
            app.DoCmd.Close();
            app = null;

            this.Close();
        }
    }
}
