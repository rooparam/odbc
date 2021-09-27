using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Drawing;
using System.Threading;
//using Rocket.RDVQA.Tools.Report;
using Rocket.RDVQA.Tools.ODBC.Utils;
using Rocket.RDVQA.Tools.Core;
using Rocket.RDVQA.Tools.Core.Components;

namespace Rocket.RDVQA.Tools.ODBC
{
   
    internal class RegressionSuite
    {
        public RegressionSuite(string name, string inputPath, string outputPath)
        {
            Name = name is null ? "Unnamed Suite" : name;
            InputPath = inputPath;
            OutputPath = outputPath;
            IsEnabled = true;
            BuildTestSuites();
        }

        public string Name { get; private set; }
        public string InputPath { get; private set; }
        public string OutputPath { get; private set; }
        private List<TestSuite> TestSuites;
        public bool IsEnabled { get; set; }
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
                TestSuites.Add(new TestSuite(new DirectoryInfo(path).Parent.Name + "/" + Path.GetFileNameWithoutExtension(path), connectionString, sqlTestCases));
            }
        }
        public List<String> GetPassedTestCaseIDs()
        {
            return null;
        }
    }

    internal class RegressionManager
    {
        private List<RegressionSuiteExecutionRecord> RegressionSuiteExecutionRecords;
        private LogWriter logger;

        public List<RegressionSuite> RegressionSuites { get; private set; }
        public RegressionManager(string configXML)
        {

            RegressionSuiteExecutionRecords = new List<RegressionSuiteExecutionRecord>();
            ValidateConfigXML(configXML);
            BuildRegressionSuites(configXML);
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
        public void StartRegression(LogWriter logWriter)
        {
            logger = logWriter;
            RunRegression();
            BuildRegressionReport();

        }
   
        private void BuildRegressionReport()
        {
            //loggerTableOptions loggerTableOptions = new loggerTableOptions();
            //loggerTableOptions.Columns = new List<String>() { "Test Suite Name", "Total TCs", "Pass TCs", "Fail TCs"};
            //loggerTableOptions.EnableCount = false;
            //loggerTableOptions.OutputTo=new TextWriter(new File)
            //loggerTableOptions.NumberAlignment = Alignment.Right;
            logger.WriteInfo(new String('#', 80));
            logger.WriteInfo("#" + "Regression Report".PadLeft(45) + "#".PadLeft(33));
            logger.WriteInfo(new String('#', 80));
            logger.WriteInfo("Regression Suite Execution Summary");
            logger.WriteInfo("----------------------------------");
            logger.WriteInfo("Total Regression Suites          : " + RegressionSuites.Count);
            logger.WriteInfo("Total Executed Regression Suites : " + RegressionSuiteExecutionRecords.Count);
            foreach (RegressionSuiteExecutionRecord rseRecord in RegressionSuiteExecutionRecords)
            {
                logger.WriteInfo(new String('-', 80));
                logger.WriteInfo("Execution Summary for Regression Suite - " + rseRecord.Name);
                logger.WriteInfo(new String('-', 80));
                logger.WriteInfo("Number of Test Suites : " + rseRecord.TestSuiteCount());
                logger.WriteInfo(new String('-', 60));
                //var table = new loggerTable("Test Suite Name", "Total TCs", "Pass TCs", "Fail TCs");
                //var table = new loggerTable(loggerTableOptions);
                foreach (TestSuiteExecutionRecord tseRecord in rseRecord.TestSuiteExecutionRecords)
                {
                    int tcCount = tseRecord.TestCaseCount();
                    int passCount = tseRecord.PassTCCount();
                    //table.AddRow(tseRecord.Name, tcCount.ToString("D4"), passCount.ToString("D4"), (tcCount - passCount).ToString("D4"));
                }
                //table.Write();

                logger.WriteInfo(new String('-', 60));


            }
        }

        private void BuildRegressionSuites(string configXML)
        {
            string name = null, input = null, output = null;
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
                                logger.WriteInfo("[ Error ] Atleast one subnode of <environment> is empty.");
                                logger.WriteInfo("[ Info  ] None of the <environment> subnodes are nullable. ");
                                return;
                            }
                            else
                            {
                                if (Directory.Exists(input))
                                {
                                    RegressionSuites.Add(new RegressionSuite(name, input, output));
                                }
                                else
                                {
                                    logger.WriteLine("[ Error   ] Input path '{0}' not found.", input);
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
                    logger.WriteInfo("[ Error ] Invalid XML format.");
                    logger.WriteInfo("[ Info  ] " + e.Message);
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
                if (regressionSuite.IsEnabled)
                {
                    logger.WriteLine("[ Info    ] Execution begins for Regression Suite: {0}.", regressionSuite.Name);
                    foreach (TestSuite testSuite in regressionSuite.GetTestSuites())
                    {
                        // create test suite execution record
                        TestSuiteExecutionRecord tseRecord = new TestSuiteExecutionRecord(testSuite.Name);
                        rseRecord.AddTestSuiteExecutionRecord(tseRecord);
                        if (testSuite.IsEnabled)
                        {
                            logger.WriteLine("[ Info    ] Execution begins for Test Suite: {0}.", testSuite.Name);
                            try
                            {
                                // build connection
                                using OdbcConnection odbcCONN = new OdbcConnection(testSuite.ConnectionString[0]);
                                // open connection
                                odbcCONN.Open();
                                foreach (SQLTestCase testCase in testSuite.TestCases)
                                {
                                    //
                                    TestCaseExecutionRecord tceRecord = new TestCaseExecutionRecord(testCase.ID, "Testing Commenced", false);
                                    tseRecord.AddTestCaseExecutionRecord(tceRecord);
                                    if (testCase.IsEnabled)
                                    {
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
                                                    odbcCMD = new OdbcCommand(testCase.VerificationQuery, odbcCONN);
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
                                                tceRecord.Comment = "Execution ended with accepted exception: " + ex.Message;
                                            }
                                            tempDataStream.Position = 0;
                                            String hash = HashGenerator.GenerateSha256(tempDataStream);
                                            if (testCase.Hash.Equals(hash))
                                            {
                                                //TestExecutionResult.Add(new SQLTestResults(testCase.ID, true, ExecutionMessage));
                                                logger.WriteInfo("[ INFO  ]"+testCase.ID + " PASS",Color.Green);
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
                                            logger.WriteError("[ ERROR ] Exception caught. Test execution will continue.");
                                            logger.WriteInfo("[ INFO  ] " + ex.Message,Color.Orange);
                                            tceRecord.Comment = "Execution ended with exception: " + ex.Message;
                                        }

                                    }
                                    else
                                    {

                                    }
                                }
                                tseRecord.Comment = "Test Suite execution completed successfully";
                            }
                            catch (Exception ex)
                            {
                                logger.WriteError("[ Error   ] "+ ex.Message);
                                tseRecord.Comment = "Test Suite execution interrupted by exception: " + ex.Message;
                            }
                        }
                        else
                        {
                            logger.WriteInfo("[ Info    ] Skip requested for Test Suite: "+ testSuite.Name,Color.PaleTurquoise);
                            tseRecord.Comment = "Test Suite Skipped By User";
                        }
                    }
                    rseRecord.Comment = "Execution completed successfully";
                }
                else
                {
                    rseRecord.Comment = "Regression Suite Skipped By User";
                }
                RegressionSuiteExecutionRecords.Add(rseRecord);

            }
        }
    }
}
