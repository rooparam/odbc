using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.TestManagement
{
    class SQLTestSuite
    {
        private SQLTestSuite _parent;
        private string _group;
        private string _name;
        private string _connectionString;
        private List<SQLTestCase> _sqlTCs;
        public SQLTestSuite()
        {
            Name = "Default-TestSuite";
            ConnectionString = null;
            SqlTCs = new List<SQLTestCase>();
            Parent = null;
        }
        public SQLTestSuite(string name)
        {
            Name = name;
            ConnectionString = null;
            SqlTCs = new List<SQLTestCase>();
            Parent = null;
        }

        public SQLTestSuite(string name, string connectionString)
        {
            Name = name;
            ConnectionString = connectionString;
            SqlTCs = new List<SQLTestCase>();
            Parent = null;
        }

        public SQLTestSuite(string name, string connectionString, List<SQLTestCase> testCases)
        {
            Name = name;
            ConnectionString = connectionString;
            SqlTCs = testCases;
            Parent = null;
        }
        public SQLTestSuite(string name, string connectionString, List<SQLTestCase> testCases, SQLTestSuite parent)
        {
            Name = name;
            ConnectionString = connectionString;
            SqlTCs = testCases;
            Parent = parent;
        }

        public string Name { get => _name; set => _name = value; }
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }
        internal SQLTestSuite Parent { get => _parent; set => _parent = value; }
        internal List<SQLTestCase> SqlTCs { get => _sqlTCs; set => _sqlTCs = value; }
    }
}
