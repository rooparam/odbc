using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Data.DB2.Core;
using Rocket.RDVQA.Tools.Properties;
using Rocket.RDVQA.Tools.Core.DB;

namespace Rocket.RDVQA.Tools.Core.Data
{
    class DBOperationsManager
    {
        private string ConnectionString;
        private DB2Connection db2Connection;
        private LogWriter logger;
        public DBOperationsManager(LogWriter logger)
        {
            this.logger = logger;
            buildConnectionString();

        }
        private void buildConnectionString()
        {
            ConnectionString = "Database=" + DBConnectionProperties.Default.Database + ";";
            ConnectionString += "Server=" + DBConnectionProperties.Default.Server + ":" + DBConnectionProperties.Default.Port + ";";
            ConnectionString += "Uid=" + DBConnectionProperties.Default.User + ";";
            ConnectionString += "Pwd=" + DBConnectionProperties.Default.Pwd + ";";
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
        public void AddTestCasesDeSelect(List<SQLDeSelectTestCase> testCases )
        {
            try
            {
              
                DataTable dtDeSelect, dtHash = new DataTable();
                // 
                dtDeSelect = TableManager.RDVQADBTables.DTDeSelect();
                dtHash = TableManager.RDVQADBTables.DTDeSelectHash();

                int sqlId = GetMaxID(dtDeSelect.TableName) + 1;
                int hashId = GetMaxID(dtHash.TableName) + 1 ;
               
                foreach (SQLDeSelectTestCase tc in testCases)
                {
                    dtDeSelect.Rows.Add(new Object []{sqlId,tc.DataSourceID,tc.SQL,tc.Tags});
                    dtHash.Rows.Add(new Object[]{hashId,tc.ConnectionID,sqlId,tc.Hash});
                    sqlId++;
                    hashId++;
                }
                BulkInsert(dtDeSelect, "INSERT INTO RDVQADB.DE_SELECT(ID,DSTYPE_ID,QUERY,TAGS) VALUES(?,?,?,?)");
                BulkInsert(dtHash, "INSERT INTO RDVQADB.DESELECT_HASH(ID,CONN_ID,QUERY_ID,RESULT_HASH) VALUES(?,?,?,?)");
            }
            catch (Exception ex)
            {
                logger.WriteError(ex.Message);
            }
        }
        private void BulkInsert(DataTable dt, string sqlInsert)
        {
            logger.WriteInfo("Bulk insert initiated for table " + dt.TableName);

            DB2Connection conn = new(ConnectionString);
            conn.Open();
            // Initiate SQLBulkCopy operation
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
            logger.WriteInfo("Bulk insert completed for " + dt.TableName);
            logger.WriteInfo(dt.Rows.Count+" records added to table "+dt.TableName);
        }
        private int GetMaxID(string table)
        {
            int max = 0;
            try
            {
                DB2Connection conn = new(ConnectionString);
                conn.Open();
                DB2Command cmd = new DB2Command("SELECT max(ID) FROM " + table, conn);
                max = (int)cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
            }
            catch (InvalidCastException ex)
            {
                max = 0;
            }
            catch(Exception)
            {
                throw;
            }

            return max;
        }

        public void AddRecordsDESelect(string [] queries,  string tags, int dstypeId)
        {
            try
            {
                DB2Connection conn = new(ConnectionString);
                conn.Open();
                String sqlInsert = "INSERT INTO RDVQADB.DE_SELECT(DSTYPE_ID,QUERY,TAGS) VALUES(?,?,?)";
                DB2Command insertCmd = new DB2Command(sqlInsert, conn);
                DB2Parameter dstypeIdParam = new DB2Parameter("DSTYPE_ID", DB2Type.Integer);
                DB2Parameter queryParam = new DB2Parameter("QUERY", DB2Type.VarChar);
                DB2Parameter tagsParam = new DB2Parameter("TAGS", DB2Type.VarChar);
                dstypeIdParam.Value = dstypeId;
                tagsParam.Value = tags;
                foreach(string query in queries)
                {
                    queryParam.Value = query;
                    insertCmd.Parameters.Add(dstypeIdParam);
                    insertCmd.Parameters.Add(queryParam);
                    insertCmd.Parameters.Add(tagsParam);
                    insertCmd.ExecuteNonQuery();
                    insertCmd.Parameters.Clear();
                }
                insertCmd.Dispose();
                conn.Close();
                System.Windows.Forms.MessageBox.Show("Test cases added to database");

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
