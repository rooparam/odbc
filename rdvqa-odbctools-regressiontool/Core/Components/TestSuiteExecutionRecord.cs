using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.Components
{
    class TestSuiteExecutionRecord
    {
        private List<TestCaseExecutionRecord> TestCaseExecutionRecords;

        public TestSuiteExecutionRecord(string suiteName)
        {
            TestCaseExecutionRecords = new List<TestCaseExecutionRecord>();
            Name = suiteName;
        }

        public string Name { get; private set; }
        public string Comment { get; set; }
        public int TestCaseCount()
        {
            return TestCaseExecutionRecords.Count;
        }

        public void AddTestCaseExecutionRecord(TestCaseExecutionRecord tceRecord)
        {
            TestCaseExecutionRecords.Add(tceRecord);
        }
        public int PassTCCount()
        {
            int _ = 0;
            foreach (TestCaseExecutionRecord tceRecord in TestCaseExecutionRecords)
            {
                _ += tceRecord.Pass ? 1 : 0;
            }
            return _;
        }

        internal void BuildReportTable()
        {
            throw new NotImplementedException();
        }
    }
}
