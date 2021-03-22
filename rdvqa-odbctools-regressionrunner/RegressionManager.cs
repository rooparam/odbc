using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Rocket.RDVQA.Utils;

namespace Rocket.RDVQA.Tools.ODBC
{
    enum SQLTestCaseType
    {
        SELECT,
        INSERT,
        DELETE
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
            TestSuites = null;
        }

        public string Name { get; private set; }
        public string InputPath { get; private set; }
        public string OutputPath { get; private set; }
        private List<TestSuite> TestSuites;

        public List<TestSuite> GetTestSuites()
        {
            string[] testSuitePaths = Directory.GetFiles(InputPath);
            string connectionString = null;
            if (TestSuites is null)
            {
                TestSuites = new List<TestSuite>();
                List<SQLTestCase> sqlTestCases = new List<SQLTestCase>();
                foreach (string path in testSuitePaths)
                {
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
                        else
                        {
                            Console.Error.WriteLine("Invalide testcase type identified for TC-ID:" + testcaseFields[0]);
                        }
                    }
                    TestSuites.Add(new TestSuite(Path.GetFileNameWithoutExtension(path), connectionString, sqlTestCases));
                }
            }
            return TestSuites;
        }
        public List<String> GetPassedTestCaseIDs()
        {
            return null;
        }
    }
    internal class RegressionManager
    {
        private List<RegressionSuite> RegressionSuites;

        public RegressionManager()
        {
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
    

        private void RunRegression()
        {
            string ExecutionMessage = "";
            foreach (RegressionSuite regressionSuite in RegressionSuites)
            {
                Console.WriteLine("[ Info    ] Excution begins for Regression Suite: {0}.", regressionSuite.Name);
                foreach (TestSuite testSuite in regressionSuite.GetTestSuites())
                {
                    Console.WriteLine("[ Info    ] Excution begins for Test Suite: {0}.", testSuite.Name);
                    try
                    {
                        // build connection
                        using OdbcConnection odbcCONN = new OdbcConnection(testSuite.ConnectionString);
                        // open connection
                        odbcCONN.Open();
                        foreach (SQLTestCase testCase in testSuite.TestCases)
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
                                }
                                tempDataStream.Position = 0;
                                String hash = HashGenerator.GenerateSha256(tempDataStream);
                                if (testCase.Hash.Equals(hash))
                                {
                                    //TestExecutionResult.Add(new SQLTestResults(testCase.ID, true, ExecutionMessage));
                                    Console.WriteLine(testCase.ID + " PASS");
                                    //CountPass++;
                                }
                                else
                                {
                                    //TestExecutionResult.Add(new SQLTestResults(testCase.ID, false, "Hash mismatch"));
                                    Console.Error.WriteLine(testCase.ID + " FAIL '" + testCase.Hash + "' != '" + hash + "'");
                                    //CountFail++;
                                }
                                odbcCMD.Dispose();
                                resultSet.Clear();
                                tempDataStream.Close();
                            }
                            catch (Exception e)
                            {
                                //TestExecutionResult.Add(new SQLTestResults(testCase.ID, false, e.Message));
                                Console.WriteLine("[ ERROR ] Exception caught. Test execution will continue.");
                                Console.WriteLine("[ INFO  ] " + e.Message);
                            }
                        }

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("[ Error   ] {0}", ex.Message);
                    }
                } 
            }
        }
    }
}