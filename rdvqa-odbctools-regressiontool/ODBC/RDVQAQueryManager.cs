using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using Rocket.RDVQA.Tools.Core;
using Rocket.RDVQA.Tools.Core.Data;
using Rocket.RDVQA.Tools.ODBC.Utils;

namespace Rocket.RDVQA.Tools.ODBC
{
    class RDVQAQueryManager
    {
        private LogWriter logger;
        private LogWriter tableWriter;
        public RDVQAQueryManager(LogWriter logger, LogWriter resultView)
        {
            this.logger = logger;
            this.tableWriter = resultView;
        }
        public DataTable ExecuteQuery(string query, string connectionString)
        {
            String [] queries = { query};
            return ExecuteBatchSelect(queries, connectionString).Tables[0];
        }
        public DataSet ExecuteBatchSelect(string[] queries, string connectionString )
        {
            DataSet resultSet = null;
            try
            {
                OdbcConnection odbcConnection = new(connectionString);
                odbcConnection.Open();
                OdbcCommand odbcCommand;
                resultSet = new();
                int tIdx = 0;
                foreach (String query in queries)
                {
                    odbcCommand = new(query, odbcConnection);
                    int rowsAffected = odbcCommand.ExecuteNonQuery();
                    resultSet.Tables.Add(new DataTable());
                    new OdbcDataAdapter(odbcCommand).Fill(resultSet.Tables[tIdx++]);
                    odbcCommand.Dispose();
                }
                odbcConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return resultSet;
        }

        public DataSet ExecuteBatchSelect(List<SQLDeSelectTestCase> testCases)
        {
            DataSet resultSet = new();
            int tIdx = 0;
            OdbcConnection odbcConnection;
            OdbcCommand odbcCommand;

                   
            foreach (SQLDeSelectTestCase tc in testCases)
            {
                try
                {
                    logger.WriteInfo("Exeuting " + tc.SQL);
                    odbcConnection = new(tc.ConnectionString);
                    odbcConnection.Open();
                    odbcCommand = new(tc.SQL, odbcConnection);
                    int rowsAffected = odbcCommand.ExecuteNonQuery();
                    resultSet.Tables.Add(new DataTable());
                    new OdbcDataAdapter(odbcCommand).Fill(resultSet.Tables[tIdx++]);

                    tc.Hash = HashGenerator.GenerateSha256(resultSet.Tables[tIdx - 1]);

                    logger.WriteInfo(resultSet.Tables[tIdx - 1].Rows.Count+" records fetched." );
                    logger.WriteInfo("Hash : "+tc.Hash);
                    logger.WriteInfo("Execution complete.");
                    Task task = Task.Factory.StartNew(() => {
                        PrintTable(tc.SQL, resultSet.Tables[tIdx - 1]);
                        tableWriter.WriteLine("Hash : " + tc.Hash);
                    }); 

                    odbcCommand.Dispose();
                    odbcConnection.Close();
                }
                catch (Exception ex)
                {
                    logger.WriteInfo("[SQL] "+tc.SQL);
                    logger.WriteError(ex.Message);
                }
            }
           
            return resultSet;
        }

        private void PrintTable(string query, DataTable dt)
        {
            int[] columnWidth = new int[dt.Columns.Count];
            int idx = 0;
            StringBuilder horizontalSplitter = new StringBuilder("+");
            StringBuilder colHeader = new StringBuilder("|");
            StringBuilder rowData = new StringBuilder();
            DataTableReader dr = dt.CreateDataReader();

            foreach (DataColumn c in dt.Columns)
            {

                if (dt.Rows.Count > 0)
                {
                    columnWidth[idx] = Math.Max(c.ColumnName.Length, dt.AsEnumerable()
                         .Select(row => row[c.ColumnName].ToString())
                         .OrderByDescending(st => st.Length).FirstOrDefault().Length);
                }
                else
                {
                    columnWidth[idx] = c.ColumnName.Length;
                }
                horizontalSplitter.Append(new String('-', columnWidth[idx] + 2));
                horizontalSplitter.Append("+");
                idx++;
            }
            // print table name 
            tableWriter.WriteLine("Table : " + dt.TableName);
            tableWriter.WriteLine("Query : " + query);
            //tableWriter.WriteLine("           ");
            tableWriter.WriteLine(horizontalSplitter.ToString());
            // write column names
            idx = 0;
            foreach (DataColumn c in dt.Columns)
            {
                colHeader.Append(" " + c.ColumnName.PadRight(columnWidth[idx++]) + " |");
            }
            tableWriter.WriteLine(colHeader.ToString());
            tableWriter.WriteLine(horizontalSplitter.ToString());
            string tempStr;
            //while (dr.Read())
            //{
            //    rowData.Append(dr.GetValue("CHAR_4") + " " + dr.GetValue("BIT_40") + " ");
            //}

            foreach (DataRow r in dt.Rows)
            {
                rowData.Append("|");
                idx = 0;

                foreach (DataColumn c in dt.Columns)
                {
                    tempStr = string.Format("{0}", (r[c] == DBNull.Value || r[c] == null ? "null" : r[c]));
                    if (c.DataType == Type.GetType("System.String"))
                    {
                        tempStr = tempStr.Replace((char)0x00, ' ');
                        //byte[] ba = Encoding.Default.GetBytes(tempStr);
                        //System.Windows.Forms.MessageBox.Show(BitConverter.ToString(ba));
                        rowData.Append(" " + tempStr.PadRight(columnWidth[idx++]) + " |");
                    }
                    else if (c.DataType == Type.GetType("System.Byte[]"))
                    {
                        rowData.Append(" " + BitConverter.ToString((byte[])r[c]).Replace("-", "").PadLeft(columnWidth[idx++]) + " |");
                    }
                    else
                    {
                        rowData.Append(" " + tempStr.PadLeft(columnWidth[idx++]) + " |");

                    }
                }
                rowData.Append("\n");
            }
            tableWriter.Write(rowData.ToString());
            tableWriter.WriteLine(horizontalSplitter.ToString());
            rowData.Clear();
        }
    }
}
