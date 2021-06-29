using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.RDVQA.Tools.Properties;
using System.Data.Odbc;
using System.Data;
namespace Rocket.RDVQA.Tools.Core.Data
{
    class ApplicationDBManager
    {
        private string ConnectionString => "Driver={" + DBConnectionProperties.Default.DVMDriver + "};" +
                "HOST=" + DBConnectionProperties.Default.DVMHost + ";PORT=" + DBConnectionProperties.Default.DVMPort + ";" +
                "UID=" + DBConnectionProperties.Default.User + ";" +
                "PWD=" + DBConnectionProperties.Default.Pwd + ";" +
                "SUBSYS=" + DBConnectionProperties.Default.DVMSubsystem + ";DBTY=DB2orDRDA;";

        private OdbcConnection DBConnection;

        public DataTable DTConnections { get; private set; }
        public DataTable DTDsTypes { get; private set; }

        public static readonly ApplicationDBManager RDVQADB = new ApplicationDBManager();
       
        public ApplicationDBManager()
        {
            DBConnection = new OdbcConnection(ConnectionString);
            DBConnection.Open();
            PopulateDataTables();
            DBConnection.Close();
        }
        private void PopulateDataTables()
        {
            // populate DTConnections
            DTConnections = PopulateDataTable("SELECT ID, NAME, CONNECTION_STRING, \"DESC\", SSL, TSID, KSID FROM RDVQADB.CONNECTIONS;");
            DTDsTypes = PopulateDataTable("SELECT * FROM RDVQADB.DSTYPES");
        }

        private DataTable PopulateDataTable(string SelectSQL)
        {            
            DataTable _ = new();
            if (DBConnection.State == ConnectionState.Closed)
            {
                DBConnection.Open();
            }
            // execute SQL and fill data adapter
            new OdbcDataAdapter(SelectSQL, DBConnection).Fill(_);
            return _;
            
        }
        public static void RefreshDataTables()
        {
            RDVQADB.PopulateDataTables();
        }
    }
}
