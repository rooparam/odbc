using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;


namespace Rocket.RDVQA.Tools.ODBC
{
    class RDVQAQueryManager
    {
        public RDVQAQueryManager()
        {

        }
        public void ExecuteQuery(string query, string connectionString)
        {

        }
        public static DataSet ExecuteBatchSelect(string[] queries, string connectionString )
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
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultSet;
        }
    }
}
