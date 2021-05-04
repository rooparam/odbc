using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace Rocket.RDVQA.Tools.ODBC.Core.DB
{
    class DBManager
    {
        private String ConnectionString;
        private OdbcConnection odbcConnection;
        public DBManager()
        {
            buildOdbcConnectionString();
        }
        private void buildOdbcConnectionString()
        {
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
            builder.Add("DRIVER", Resource.RDVQADB_Driver);
            builder.Add("DBTY", Resource.RDVQADB_DBType);
            builder.Add("CPFX", Resource.RDVQADB_DBPfx);
            builder.Add("HOST", Resource.RDVQADB_Server);
            builder.Add("PORT", Resource.RDVQADB_Port);
            builder.Add("UID", Resource.RDVQADB_User);
            builder.Add("PWD", Resource.RDVQADB_Pwd);
            builder.Add("SUBSYS", Resource.RDVQADB_Subsys);
            ConnectionString = builder.ConnectionString;
        }
        public DataTable ReadTableConnections()
        {
            DataTable dt = null;
            using (odbcConnection = new OdbcConnection(ConnectionString))
            {
                using(OdbcCommand cmd = new OdbcCommand("Select * from RDVQADB.CONNECTIONS",odbcConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    using (OdbcDataAdapter odbcDataAdapter = new OdbcDataAdapter(cmd))
                    {
                        using( dt = new DataTable())
                        {
                            odbcDataAdapter.Fill(dt);                            
                        }
                    }
                }
            }
            return dt;
        }

    }
}
