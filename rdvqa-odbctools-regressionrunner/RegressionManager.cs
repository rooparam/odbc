using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Rocket.RDVQA.Tools.Report;
using Rocket.RDVQA.Utils;

namespace Rocket.RDVQA.Tools.ODBC
{
    enum SQLTestCaseType
    {
        SELECT,
        INSERT,
        DELETE,
        UPDATE,
        CONFIG
    }
    internal class SQLTestCase
    {
        public SQLTestCase(string id, SQLTestCaseType type, string hash, string query, string verificationQuery)
        {
            ID = id;
            Hash = hash;
            Query = query;
            VerficationQuery = verificationQuery;
            TestCaseType = type;
        }
        public string ID { get; }
        public string Hash { get; }
        public string Query { get; }
        public string VerficationQuery { get; }
        public SQLTestCaseType TestCaseType { get; }
    }
    internal class TestSuite
    {
        public TestSuite(string name,string connectionString, List<SQLTestCase> testcases)
        {
            Name = name;
            ConnectionString = connectionString;
            TestCases = testcases is null?new List<SQLTestCase>():testcases;
        }

        public string Name { get; private set; }
        public string ConnectionString { get; private set; }
        public List<SQLTestCase> TestCases { get; private set; }
    }
    internal class RegressionSuite
    {
        public RegressionSuite(string name, string inputPath, string outputPath)
        {
            Name = name is null ? "Unnamed Suite" : name;
            InputPath = inputPath;
            OutputPath = outputPath;
            BuildTestSuites();
        }

        public string Name { get; private set; }
        public string InputPath { get; private set; }
        public string OutputPath { get; private set; }
        private List<TestSuite> TestSuites;

        public List<TestSuite> GetTestSuites()
        {
            return TestSuites;
        }
        private void BuildTestSuites()
        {
            string[] testSuitePaths = Directory.GetFiles(InputPath, "*", SearchOption.AllDirectories);
            string connectionString = null;
            TestSuites = new List<TestSuite>();
            foreach (string path in testSuitePaths)
            {
                List<SQLTestCase> sqlTestCases = new List<SQLTestCase>();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    // Ignore comments
                    if (line.Trim().StartsWith("--"))
                    { continue; }
                    if (line.Trim().StartsWith('#'))
                    {
                        connectionString = line.Trim('#');
                        continue;
                    }
                    string[] testcaseFields = line.Split(";");
                    if (testcaseFields[1].ToLower().Equals("select"))
                    {
                        sqlTestCases.Add(new SQLTestCase(testcaseFields[0], SQLTestCaseType.SELECT, testcaseFields[2], testcaseFields[3], null));
                    }
                    else if (testcaseFields[1].ToLower().Equals("delete"))
                    {
                        sqlTestCases.Add(new SQLTestCase(testcaseFields[0], SQLTestCaseType.DELETE, testcaseFields[2], testcaseFields[3], testcaseFields[4]));
                    }
                    else if (testcaseFields[1].ToLower().Equals("insert"))
                    {
                        sqlTestCases.Add(new SQLTestCase(testcaseFields[0], SQLTestCaseType.INSERT, testcaseFields[2], testcaseFields[3], testcaseFields[4]));
                    }
                    else if (testcaseFields[1].ToLower().Equals("update"))
                    {
                        sqlTestCases.Add(new SQLTestCase(testcaseFields[0], SQLTestCaseType.UPDATE, testcaseFields[2], testcaseFields[3], testcaseFields[4]));
                    }
                    else if (testcaseFields[1].ToLower().Equals("config"))
                    {
                        sqlTestCases.Add(new SQLTestCase(testcaseFields[0], SQLTestCaseType.CONFIG, testcaseFields[2], testcaseFields[3], testcaseFields[4]));
                    }
                    else
                    {
                        Console.Error.WriteLine("Invalide testcase type identified for TC-ID:" + testcaseFields[0]);
                    }
                }
                TestSuites.Add(new TestSuite(new DirectoryInfo(path).Parent.Name + "/"+Path.GetFileNameWithoutExtension(path), connectionString, sqlTestCases));
            }
        }
        public List<String> GetPassedTestCaseIDs()
        {
            return null;
        }
    }
    
    internal class TestCaseExecutionRecord
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
    internal class TestSuiteExecutionRecord
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
            foreach(TestCaseExecutionRecord tceRecord in TestCaseExecutionRecords)
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
    internal class RegressionSuiteExecutionRecord
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
            foreach(TestSuiteExecutionRecord tseRecord in TestSuiteExecutionRecords)
            {
                _ += tseRecord.TestCaseCount();
            }
            return _;
        }

        public void BuildReportTables()
        {
            foreach(TestSuiteExecutionRecord tseRecord  in TestSuiteExecutionRecords)
            {
                tseRecord.BuildReportTable();
            }
        }
    }
    internal class RegressionManager
    {
        private List<RegressionSuite> RegressionSuites;
        private List<RegressionSuiteExecutionRecord> RegressionSuiteExecutionRecords;
        public RegressionManager()
        {
            RegressionSuiteExecutionRecords = new List<RegressionSuiteExecutionRecord>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configXML"></param>
        public void StartRegression(string configXML)
        {
            ValidateConfigXML(configXML);
            BuildRegressionSuites(configXML);
            RunRegression();
            BuildRegressionReport();
        }

        private void BuildRegressionReport()
        {
            ConsoleTableOptions consoleTableOptions = new ConsoleTableOptions();
            consoleTableOptions.Columns = new List<String>() { "Test Suite Name", "Total TCs", "Pass TCs", "Fail TCs"};
            consoleTableOptions.EnableCount = false;
            //consoleTableOptions.OutputTo=new TextWriter(new File)
            consoleTableOptions.NumberAlignment = Alignment.Right;
            Console.WriteLine(new String('#', 80));
            Console.WriteLine("#" + "Regression Report".PadLeft(45)+"#".PadLeft(33));
            Console.WriteLine(new String('#', 80));
            Console.WriteLine("Regression Suite Execution Summary");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Total Regression Suites          : " + RegressionSuites.Count);
            Console.WriteLine("Total Executed Regression Suites : " + RegressionSuiteExecutionRecords.Count);
            foreach (RegressionSuiteExecutionRecord rseRecord in RegressionSuiteExecutionRecords)
            {
                Console.WriteLine(new String('-', 80));
                Console.WriteLine("Execution Summary for Regression Suite - " + rseRecord.Name);
                Console.WriteLine(new String('-', 80));
                Console.WriteLine("Number of Test Suites : " + rseRecord.TestSuiteCount());
                Console.WriteLine(new String('-', 60));
                //var table = new ConsoleTable("Test Suite Name", "Total TCs", "Pass TCs", "Fail TCs");
                var table = new ConsoleTable(consoleTableOptions);
                foreach(TestSuiteExecutionRecord tseRecord in rseRecord.TestSuiteExecutionRecords)
                {
                    int tcCount = tseRecord.TestCaseCount();
                    int passCount = tseRecord.PassTCCount();
                    table.AddRow(tseRecord.Name, tcCount.ToString("D4"), passCount.ToString("D4"), (tcCount - passCount).ToString("D4"));
                }
                table.Write();

                Console.WriteLine(new String('-', 60));


            }
        }

        private void BuildRegressionSuites(string configXML)
        {
            string name=null, input = null, output = null;
            RegressionSuites = new List<RegressionSuite>();
            using XmlReader reader = XmlReader.Create(configXML);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name.ToLower().Equals("regession_suite"))
                        {
                            input = null;
                            output = null;
                            name = reader.GetAttribute("name");
                        }

                        else if (reader.Name.ToLower().Equals("input"))
                        {
                            reader.Read();
                            input = reader.Value;
                        }
                        else if (reader.Name.ToLower().Equals("output"))
                        {
                            reader.Read();
                            output = reader.Value;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name.ToLower().Equals("regession_suite"))
                        {
                            if (input is null || output is null)
                            {
                                Console.WriteLine("[ Error ] Atleast one subnode of <environment> is empty.");
                                Console.WriteLine("[ Info  ] None of the <environment> subnodes are nullable. ");
                                return;
                            }
                            else
                            {
                                input = Environment.ExpandEnvironmentVariables(input);
                                if (Directory.Exists(input))
                                {
                                    RegressionSuites.Add(new RegressionSuite(name, input, output));
                                }
                                else
                                {
                                    Console.WriteLine("[ Error   ] Input path '{0}' not found.", input);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configXML"></param>
        private void ValidateConfigXML(string configXML)
        {
            string executionPath = new Uri(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).LocalPath;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", executionPath + "\\testconfig.xsd");
            XmlReader rd = XmlReader.Create(configXML);
            XDocument doc = XDocument.Load(rd);
            doc.Validate(schema, XMLValidationEventHandler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XMLValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType type = XmlSeverityType.Warning;
            if (Enum.TryParse<XmlSeverityType>("Error", out type))
            {
                if (type == XmlSeverityType.Error)
                {
                    Console.WriteLine("[ Error ] Invalid XML format.");
                    Console.WriteLine("[ Info  ] " + e.Message);
                    Environment.Exit(5);
                }
            }
        }
    

        /// <summary>
        /// 
        /// </summary>
        private void RunRegression()
        {
            string ExecutionMessage = "";
            foreach (RegressionSuite regressionSuite in RegressionSuites)
            {
                RegressionSuiteExecutionRecord rseRecord = new RegressionSuiteExecutionRecord(regressionSuite.Name);
                Console.WriteLine("[ Info    ] Execution begins for Regression Suite: {0}.", regressionSuite.Name);
                foreach (TestSuite testSuite in regressionSuite.GetTestSuites())
                {
                    // create test suite execution record
                    TestSuiteExecutionRecord tseRecord = new TestSuiteExecutionRecord(testSuite.Name);
                    rseRecord.AddTestSuiteExecutionRecord(tseRecord);
                    Console.WriteLine("[ Info    ] Execution begins for Test Suite: {0}.", testSuite.Name);
                    try
                    {
                        // build connection
                        using OdbcConnection odbcCONN = new OdbcConnection(testSuite.ConnectionString);
                        // open connection
                        odbcCONN.Open();
                        foreach (SQLTestCase testCase in testSuite.TestCases)
                        {
                            //
                            TestCaseExecutionRecord tceRecord = new TestCaseExecutionRecord(testCase.ID, "Testing Commenced", false);
                            tseRecord.AddTestCaseExecutionRecord(tceRecord);
                            ExecutionMessage = "";
                            try
                            {
                                OdbcCommand odbcCMD = new OdbcCommand(testCase.Query, odbcCONN);
                                DataSet resultSet = new DataSet();
                                MemoryStream tempDataStream = new MemoryStream();
                                StreamWriter fileWriter = new StreamWriter(tempDataStream);
                                try
                                {
                                    _ = odbcCMD.ExecuteNonQuery();
                                    if (testCase.TestCaseType == SQLTestCaseType.INSERT ||
                                        testCase.TestCaseType == SQLTestCaseType.DELETE)
                                    {
                                        odbcCMD = new OdbcCommand(testCase.VerficationQuery, odbcCONN);
                                        _ = odbcCMD.ExecuteNonQuery();
                                    }
                                    new OdbcDataAdapter(odbcCMD).Fill(resultSet);
                                    // write dataset to file

                                    foreach (DataRow row in resultSet.Tables[0].Rows)
                                    {
                                        foreach (Object columnVal in row.ItemArray)
                                        {
                                            fileWriter.Write(columnVal);
                                        }
                                    }
                                    fileWriter.Flush();
                                }
                                catch (OdbcException ex)
                                {
                                    fileWriter.Write(ex.Message);
                                    ExecutionMessage = ex.Message;
                                    tceRecord.Comment = "Execution ended with accepted exception: "+ex.Message;
                                }
                                tempDataStream.Position = 0;
                                String hash = HashGenerator.GenerateSha256(tempDataStream);
                                if (testCase.Hash.Equals(hash))
                                {
                                    //TestExecutionResult.Add(new SQLTestResults(testCase.ID, true, ExecutionMessage));
                                    Console.WriteLine(testCase.ID + " PASS");
                                    tceRecord.Pass = true;
                                    tceRecord.Comment = "Execution Successful";
                                    //CountPass++;
                                }
                                else
                                {
                                    //TestExecutionResult.Add(new SQLTestResults(testCase.ID, false, "Hash mismatch"));
                                    Console.Error.WriteLine(testCase.ID + " FAIL '" + testCase.Hash + "' != '" + hash + "'");
                                    //CountFail++;
                                    tceRecord.Comment = "Execution Fail. Hash mismatch";
                                }
                                
                                odbcCMD.Dispose();
                                resultSet.Clear();
                                tempDataStream.Close();
                            }
                            catch (Exception ex)
                            {
                                //TestExecutionResult.Add(new SQLTestResults(testCase.ID, false, e.Message));
                                Console.WriteLine("[ ERROR ] Exception caught. Test execution will continue.");
                                Console.WriteLine("[ INFO  ] " + ex.Message);
                                tceRecord.Comment = "Execution ended with exception: " + ex.Message;
                            }
                        }
                        tseRecord.Comment = "Testcase execution completed successfully";
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[ Error   ] {0}", ex.Message);
                        tseRecord.Comment = "Testcase execution interrupted by exception: " + ex.Message;
                    }
                }
                rseRecord.Comment = "Execution completed successfully";
                RegressionSuiteExecutionRecords.Add(rseRecord);

            }
        }
    }
}