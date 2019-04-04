using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace TUSUR_DBСP_FilmOCritic
{
    static class Toolbox
    {
        static public bool checkConnection(OleDbConnection cn)
        {
            bool ok = false;
            if (cn.State != ConnectionState.Open)
            {
                try
                {
                    cn.Open();
                    ok = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                ok = true;
            }
            return ok;
        }
    }
}
