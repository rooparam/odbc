using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.Components
{
    class TestCaseExecutionRecord
    {
        public TestCaseExecutionRecord(string tcid, string comment, bool pass)
        {
            ID = tcid;
            Comment = comment;
            Pass = pass;
        }
        public string ID { get; private set; }
        public string Comment { get; set; }
        public bool Pass { get; set; }
    }
}
