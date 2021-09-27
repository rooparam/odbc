using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.Components
{
    class TestSuite
    {
        public TestSuite(string name, string connectionString, List<SQLTestCase> testcases)
        {
            ConnectionString = new List<string>();
            Name = name;
            ConnectionString.Add(connectionString);
            TestCases = testcases is null ? new List<SQLTestCase>() : testcases;
            IsEnabled = true;
        }
        public TestSuite(string name)
        {
            Name = name;
            ConnectionString = new List<string>();
            TestCases = new List<SQLTestCase>();
            IsEnabled = true;
        }

        public string Name { get; private set; }
        public List<string> ConnectionString { get; private set; }
        public List<SQLTestCase> TestCases { get; private set; }
        public bool IsEnabled { get; set; }
    }
}
