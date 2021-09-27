using Rocket.RDVQA.Tools.Core.Components;
using Rocket.RDVQA.Tools.ODBC.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core
{
    class NewBaselineBuilder
    {
        private string[] connectionStrings;
        private string inputPath;
        private string outputPath;
        private ConcurrentBag<TestSuite> testSuites;

        public NewBaselineBuilder(string[] connectionStrings, string inputPath, string outputPath)
        {
            this.connectionStrings = connectionStrings;
            this.inputPath = inputPath;
            this.outputPath = outputPath;
            testSuites = new ConcurrentBag<TestSuite>();
        }
        public void BuildBaseline()
        {
            BuildTestSuites();
            foreach(TestSuite ts in testSuites)
            {
                int connIdx = 0;
                foreach(string connectionString in ts.ConnectionString)
                {
                    connIdx++;
                    Directory.CreateDirectory(this.outputPath + "\\Connection-" + connIdx.ToString("D3"));
                    string tsFileName = ts.Name + connIdx.ToString("D3")+".baseline";
                    List<string> baseLineRecords = new List<string>();
                    /* open connection */
                    using OdbcConnection odbcConnection = new OdbcConnection(connectionString);
                    try
                    {
                        odbcConnection.Open();
                        foreach (SQLTestCase tc in ts.TestCases)
                        {

                            MemoryStream tempDataStream = new MemoryStream();
                            StreamWriter fileWriter = new StreamWriter(tempDataStream);
                            if (tc.Query.Trim().StartsWith("--"))
                            { continue; }
                            OdbcCommand odbcCommand = new OdbcCommand
                            {
                                Connection = odbcConnection
                            };
                            odbcCommand.CommandText = tc.Query;
                            DataSet resultSet = new DataSet();
                            try
                            {                               
                                odbcCommand.ExecuteNonQuery();
                                new OdbcDataAdapter(odbcCommand).Fill(resultSet);
                                // write dataset to file                                
                                foreach (DataRow row in resultSet.Tables[0].Rows)
                                {
                                    foreach (Object columnVal in row.ItemArray)
                                    {
                                        fileWriter.Write(columnVal);
                                    }
                                }
                            }
                            catch (OdbcException ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("[ Warning ] ODBCException caught for TC :" + (tc.ID));
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("[ Debug   ] " + ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("[ Info    ] Verify the exception is an accepted test scenario.");

                                fileWriter.Write(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("[ Error   ] System excpetion caught while executing TC: " + (tc.ID));
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("[ Debug   ] " + ex.Message);
                                // try recreating connection
                                odbcConnection.Close();
                                odbcConnection.Open();
                            }
                            Console.ForegroundColor = ConsoleColor.White;

                            fileWriter.Flush();
                            tempDataStream.Position = 0;
                            tc.Hash = HashGenerator.GenerateSha256(tempDataStream);
                            //tc.ID = ts.Name + "-" + connIdx.ToString("D3") + "-" + tc.ID;
                            tempDataStream.Close();
                            odbcCommand.Dispose();
                            baseLineRecords.Add(tc.ToString());
                        }
                    }
                    catch (OdbcException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("[ Error   ] ODBC excpetion caught while creating a connection");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("[ Debug   ] " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("[ Error   ] System excpetion caught while creating a connection");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("[ Debug   ] " + ex.Message);
                    }
                    odbcConnection.Close();
                    string outFile = this.outputPath + "\\Connection-" +connIdx.ToString("D3")+"\\"+tsFileName;
                    WriteBaselineFileAsync(outFile, connectionString, baseLineRecords);

                }
            }
        }
        private static void WriteBaselineFileAsync(string path, string connectionString, List<string> sqlTestcases)
        {
            using StreamWriter fileStream = new StreamWriter(path);
            fileStream.WriteLine("#" + connectionString);
            foreach (string sqlTestcase in sqlTestcases)
            {
                fileStream.WriteLine(sqlTestcase);
            }
        }

        private void BuildTestSuites()
        {
            var tasks = new List<Task<TestSuite>>();
            /* Read input folder and list down SQL test suites */
            foreach (string testSuitePath in Directory.GetFiles(inputPath, "*", SearchOption.AllDirectories))
            {
                /* Task for reading each file in parallel and create TestSuites */
                tasks.Add(Task.Factory.StartNew(new Func<object, TestSuite>(TestSuiteBuildTask), testSuitePath));
                Task t = Task.WhenAll(tasks);
                try { t.Wait(); }
                catch { }                
            }
            foreach (Task<TestSuite> task in tasks)
            {
                testSuites.Add(task.Result);
            }
            if (connectionStrings != null)
            {
                foreach (TestSuite ts in testSuites)
                { foreach (string connstr in connectionStrings) { ts.ConnectionString.Add(connstr); } }
            }
        }
        private static TestSuite TestSuiteBuildTask(object testSuitePath)
        {
            int tcCount = 1;
            string tcIDPfx = Path.GetFileNameWithoutExtension((string)testSuitePath);
            TestSuite testSuite = new TestSuite(tcIDPfx);

            /* Read SQL File */
            foreach (string line in File.ReadAllLines((string)testSuitePath))
            {
                if (line.Length > 0)
                {
                    switch (line[0])
                    {
                        /* A connection String */
                        case '#':
                            testSuite.ConnectionString.Add(line.Trim('#'));
                            break;
                        /* A comment */
                        case '-':
                            break;
                        /* An SQL */
                        default:
                            SQLTestCase testCase = new SQLTestCase(tcIDPfx+"-"+tcCount.ToString("D4"), line);
                            testSuite.TestCases.Add(testCase);
                            tcCount++;
                            break;
                    }
                }
            }
            return testSuite;
        }
    }
}
