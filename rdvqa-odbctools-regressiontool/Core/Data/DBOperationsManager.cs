using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Data.DB2.Core;
using Rocket.RDVQA.Tools.Properties;


namespace Rocket.RDVQA.Tools.Core.Data
{
    class DBOperationsManager
    {
        private string ConnectionString;
        private DB2Connection db2Connection;
        public DBOperationsManager( )
        {
            buildConnectionString();
        }

        private void buildConnectionString()
        {
            ConnectionString = "Database=" + DBConnection.Default.Database + ";";
            ConnectionString += "Server=" + DBConnection.Default.Server + ":" + DBConnection.Default.Port + ";";
            ConnectionString += "Uid=" + DBConnection.Default.User + ";";
            ConnectionString += "Pwd=" + DBConnection.Default.Pwd + ";";
        }

        public DataTable GetDataConnections()
        {
            try
            {
                DB2Connection conn = new(ConnectionString);
                DB2DataAdapter da = new("SELECT * FROM RDVQADB.CONNECTIONS", conn);
                DataTable dt = new();
                da.Fill(dt);
                conn.Close();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
         public DataTable GetDataDsTypes()
        {
            try
            {
                DB2Connection conn = new(ConnectionString);
                DB2DataAdapter da = new("SELECT * FROM RDVQADB.DSTYPES", conn);
                DataTable dt = new();
                da.Fill(dt);
                conn.Close();

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddRecordsConnections(DataTable dt)
        {

        }
        public void AddRecordsDESelect(DataTable dt)
        {
            try
            {
                DB2Connection conn = new(ConnectionString);
                String sqlInsert = "INSERT INTO DE_SELECT(DSTYPE_ID,QUERY,TAGS) VALUES(?,?,?)";
                DB2Command insertCmd = new DB2Command(sqlInsert, conn);
                using DB2BulkCopy db2BulkCopy = new(conn);
                db2BulkCopy.DestinationTableName = dt.TableName;
                // column mappings
                foreach (DataColumn column in dt.Columns)
                {
                    if (!column.ReadOnly)
                    {
                        db2BulkCopy.ColumnMappings.Add(column.ToString(), column.ToString());
                    }
                }
                db2BulkCopy.WriteToServer(dt);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddRecordsHashDESelect(DataTable dt)
        {

        }
    }
}
