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
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.TestManagement
{
    class BaselineBuilder
    {
        private ConcurrentBag<SQLTestSuite> _sqlTestSuites;
        public string SqlSourcePath { get; set; }
        public string BaselinePath { get; set; }
        public List<string> ConnectionStrings { get; set; }
        public bool IgnoreEmbededConnectionString { get; private set; }
        public string[] TestSuiteFiles { get; private set; }
        public LogWriter UserLog { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public BaselineBuilder(LogWriter userLog)
        {
            SqlSourcePath = null;
            BaselinePath = null;
            ConnectionStrings = null;
            _sqlTestSuites = new ConcurrentBag<SQLTestSuite>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        public BaselineBuilder(String sqlSourcePath, String baselinePath)
        {
            SqlSourcePath = sqlSourcePath;
            BaselinePath = baselinePath;
            ConnectionStrings = null;
            _sqlTestSuites = new ConcurrentBag<SQLTestSuite>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStrings"></param>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        public BaselineBuilder(List<string> connectionStrings,String sqlSourcePath, String baselinePath, bool ignoreEmbededConnectionString)
        {
            SqlSourcePath = sqlSourcePath;
            BaselinePath = baselinePath;
            ConnectionStrings = connectionStrings;
            IgnoreEmbededConnectionString = ignoreEmbededConnectionString;
            _sqlTestSuites = new ConcurrentBag<SQLTestSuite>();
        }

        public void ListTestSuites()
        {
            TestSuiteFiles = System.IO.Directory.GetFiles(SqlSourcePath, "*", System.IO.SearchOption.AllDirectories);
        }
        /// <summary>
        /// 
        /// </summary>
        public void BuildBaselines()
        {
            // build test suites
            BuildTestSuites();
            // build baselines
            int connIdx = 0;
            foreach (string connectionString in ConnectionStrings)
            {    
                connIdx++;
                string baselineDirectory = BaselinePath + "\\Connection-" + connIdx.ToString("D3");
                Directory.CreateDirectory(baselineDirectory);
                foreach (SQLTestSuite ts in _sqlTestSuites)
                {
                    string TestSuiteDirectory = baselineDirectory + "\\" + ts.Name;
                    Directory.CreateDirectory(TestSuiteDirectory);
                    string tcPrefix = ts.Name + "-" + connIdx.ToString("D3") + "-";
                    string baselineFileName = ts.Name +"-"+ connIdx.ToString("D3") + ".baseline";
                    List<string> baseLineRecords = new List<string>();
                    /* open connection */
                    using OdbcConnection odbcConnection = new (connectionString);
                    try
                    {
                        odbcConnection.Open();
                        foreach (SQLTestCase tc in ts.SqlTCs)
                        {

                            MemoryStream tempDataStream = new ();
                            StreamWriter fileWriter = new (tempDataStream);
                            if (tc.Sql.Trim().StartsWith("--"))
                            { continue; }
                            OdbcCommand odbcCommand = new()
                            {
                                Connection = odbcConnection
                            };
                            odbcCommand.CommandText = tc.Sql;
                            DataSet resultSet = new ();
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
                                Console.WriteLine("[ Warning ] ODBCException caught for TC :" + (tc.Id));
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("[ Debug   ] " + ex.Message);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("[ Info    ] Verify the exception is an accepted test scenario.");

                                fileWriter.Write(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("[ Error   ] System excpetion caught while executing TC: " + (tc.Id));
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
                    WriteBaselineFileAsync(TestSuiteDirectory + "\\" + baselineFileName, connectionString, baseLineRecords);
                }
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="connectionString"></param>
        /// <param name="sqlTestcases"></param>
        private static void WriteBaselineFileAsync(string path, string connectionString, List<string> sqlTestcases)
        {
            using StreamWriter fileStream = new(path);
            fileStream.WriteLine("#" + connectionString);
            foreach (string sqlTestcase in sqlTestcases)
            {
                fileStream.WriteLine(sqlTestcase);
            }
        }

        private void BuildTestSuites()
        {

            var tasks = new List<Task<SQLTestSuite>>();
            /* Read input folder and list down SQL test suites */
            foreach (string testSuitePath in Directory.GetFiles(SqlSourcePath, "*", SearchOption.AllDirectories))
            {
                /* Task for reading each file in parallel and create TestSuites */
                tasks.Add(Task.Factory.StartNew(new Func<object, SQLTestSuite>(TestSuiteBuildTask), testSuitePath));
                Task t = Task.WhenAll(tasks);
                try { t.Wait(); }
                catch { }
            }
            foreach (Task<SQLTestSuite> task in tasks)
            {
                _sqlTestSuites.Add(task.Result);
            }
            //if (ConnectionStrings != null)
            //{
            //    foreach(SQLTestSuite ts in _sqlTestSuites)
            //    { foreach (string connstr in ConnectionStrings) { ts.ConnectionString.Add(connstr); } }
            //}
        }
        private static SQLTestSuite TestSuiteBuildTask(object testSuitePath)
        {
            int tcCount = 1;
            string tcIDPfx = Path.GetFileNameWithoutExtension((string)testSuitePath);
            SQLTestSuite testSuite = new (tcIDPfx);

            /* Read SQL File */
            foreach (string line in File.ReadAllLines((string)testSuitePath))
            {
                if (line.Length > 0)
                {
                    switch (line[0])
                    {
                        /* A connection String */
                        case '#':
                            testSuite.ConnectionString = line.Trim('#');
                            break;
                        /* A comment */
                        case '-':
                            break;
                        /* An SQL */
                        default:
                            SQLTestCase testCase = new SQLTestCase(tcIDPfx + "-" + tcCount.ToString("D4"), line);
                            testSuite.SqlTCs.Add(testCase);
                            tcCount++;
                            break;
                    }
                }
            }
            return testSuite;
        }
    }
}
