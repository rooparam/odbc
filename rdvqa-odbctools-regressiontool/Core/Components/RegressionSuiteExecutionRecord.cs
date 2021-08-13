using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.Components
{
    class RegressionSuiteExecutionRecord
    {
        public RegressionSuiteExecutionRecord(string suiteName)
        {
            TestSuiteExecutionRecords = new List<TestSuiteExecutionRecord>();
            Name = suiteName;
        }

        public string Name { get; private set; }
        public string Comment { get; set; }
        public List<TestSuiteExecutionRecord> TestSuiteExecutionRecords { get; private set; }
        public void AddTestSuiteExecutionRecord(TestSuiteExecutionRecord tseRecord)
        {
            TestSuiteExecutionRecords.Add(tseRecord);
        }
        public int TestSuiteCount()
        {
            return TestSuiteExecutionRecords.Count;
        }

        public int TestCaseCount()
        {
            int _ = 0;
            foreach (TestSuiteExecutionRecord tseRecord in TestSuiteExecutionRecords)
            {
                _ += tseRecord.TestCaseCount();
            }
            return _;
        }

        public void BuildReportTables()
        {
            foreach (TestSuiteExecutionRecord tseRecord in TestSuiteExecutionRecords)
            {
                tseRecord.BuildReportTable();
            }
        }
    }
}
