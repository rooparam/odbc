using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using Rocket.RDVQA.Tools.Properties;

namespace Rocket.RDVQA.Tools.Core.Data
{
    class DBManager
    {
        private String ConnectionString;
        private DBOperationsManager dbOperationsManager;
        private ODBCConnectionManager odbcConnectionManager;
        private OdbcConnection odbcConnection;

        public DataTable DTConnections { get; private set;}
        public DataTable DTDsTypes { get; private set;}

        public static readonly DBManager DataTables = new DBManager();
        DBManager()
        {
            PopulateDataTables();
        }

        public void PopulateDataTables()
        {
            if (Application.Default.UseUserDSN)
            {

            }
            else
            {
                dbOperationsManager = new DBOperationsManager(new LogWriter(null));
                DTConnections = dbOperationsManager.GetDataConnections();
                DTDsTypes = dbOperationsManager.GetDataDsTypes();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void buildOdbcConnectionString()
        {
            // check if userdsn to be used
            if (Application.Default.UseUserDSN)
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
            else
            {
                            
            }
        }
     
        public DataTable ReadTableConnections()
        {
            DataTable dt = null;
            using (odbcConnection = new OdbcConnection(ConnectionString))
            {
                using(OdbcCommand cmd = new OdbcCommand("Select ID,NAME,CONNECTION_STRING from RDVQADB.CONNECTIONS",odbcConnection))
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
        public void InsertRecordsToDeSelect(string[] queries, string tags, int dstypeId )
        {
              
        }

        public static void RefreshTables()
        {
            DataTables.PopulateDataTables();
        }
    }
}
