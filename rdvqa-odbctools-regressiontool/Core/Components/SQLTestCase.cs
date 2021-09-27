using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.Components
{
    class SQLTestCase
    {
        public SQLTestCase(string id, SQLTestCaseType type, string hash, string query, string verificationQuery)
        {
            ID = id;
            Hash = hash;
            Query = query;
            VerificationQuery = verificationQuery;
            TestCaseType = type;
            IsEnabled = true;
        }
        public SQLTestCase(string id, string query)
        {
            ID = id;
            Query = query;
            VerificationQuery = "";
            TestCaseType = SQLTestCase.GetType(query.Trim('(').Split(' ')[0]);
        }
        public string ID { get; set; }
        public string Hash { get; set; }
        public string Query { get; }
        public string VerificationQuery { get; }
        public SQLTestCaseType TestCaseType { get; }
        public bool IsEnabled { get; set; }

        public static SQLTestCaseType GetType(string keyword)
        {
            return keyword.ToLower() switch
            {
                "select" => SQLTestCaseType.SELECT,
                "insert" => SQLTestCaseType.INSERT,
                "delete" => SQLTestCaseType.DELETE,
                "update" => SQLTestCaseType.UPDATE,
                "set" => SQLTestCaseType.CONFIG,
                _ => SQLTestCaseType.OTHER
            };
        }
        override public string ToString()
        { return ID + ";" + TestCaseType.ToString() + ";" + Hash + ";" + Query.Trim(';') + ";" + VerificationQuery.Trim(';') + ";"; }
    }
}
