using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Rocket.RDVQA.Tools.ODBC;
using Rocket.RDVQA.Tools.ODBC.Utils;

namespace Rocket.RDVQA.Tools.Core.Data
{
    class SQLDeSelectTestCase
    {
        public string SQL { get; private set; }
        public int SqlID { get; set; }
        public int DataSourceID { get; private set; }
        public string Tags { get; private set; } 
        public int ConnectionID { get; private set; }
        public string ConnectionString { get; private set; }
        public string Hash { get; set; }

        public SQLDeSelectTestCase(string sql, int dstypeId, string tags, int connectionId, string connectionString)
        {
            SQL = sql;
            DataSourceID = dstypeId;
            Tags = tags;
            ConnectionID = connectionId;
            ConnectionString = connectionString;
        }
    }
}
