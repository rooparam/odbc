using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Data.DB2.Core;

namespace Rocket.RDVQA.Tools.Core.Data
{
    class ConnectionTester
    {
        public ConnectionTester()
        {
            IBM.Data.DB2.Core.DB2Connection conn = new DB2Connection("Database=RS28DDS9;Server=rs28.rocketsoftware.com:3725;Uid=Ts8832;Pwd=J0hnwick");
            try { conn.Open();
                DB2Command cmd = new DB2Command("SELECT * FROm RDVQADB.CONNECTIONS", conn);
                cmd.ExecuteNonQuery();
                DB2DataAdapter da = new DB2DataAdapter("SELECT * FROm RDVQADB.CONNECTIONS", conn);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                System.Windows.Forms.MessageBox.Show(ds.Tables[0].Columns[0].ColumnName);

            }
            
            catch(DB2Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
