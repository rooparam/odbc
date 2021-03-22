﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Reflection;
using System.Data.Odbc;
using System.Data;
using Rocket.RDVQA.Utils;

namespace Rocket.RDVQA.Tools.ODBC
{
    enum SQLTestCaseType
    {
        SELECT,
        INSERT,
        DELETE,
        OTHER
    }
    struct TestEnvironment
    {
        public TestEnvironment(string dsn, Dictionary<string,string> parms, string input, string output)
        {
            DSN = dsn;
            Parms = parms;
            InputPath = input;
            OutputPath = output;
        }

        public string DSN { get; private set; }
        public Dictionary<string, string> Parms { get; }
        public string InputPath { get; }
        public string OutputPath { get; }
    }
    struct SQLTestCase
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

        override public string ToString()
        { return ID + ";" + TestCaseType.ToString() + ";" + Hash + ";" + Query.Trim(';') + ";" + VerficationQuery.Trim(';') + ";"; }
       
    }
    class BaslineBuilder
    {
        private static readonly string[] Parms = { "cfgxml", "genout"};
        private static string configXML;
        private static List<TestEnvironment> environments;
        static void Main(string[] args)
        {
            ValidateArguments(args);
            ParseConfigXML();
            BuildBaseline();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void BuildBaseline()
        {
            static SQLTestCaseType SQLType(string keyword)
            {
                return keyword.ToLower() switch
                {
                    "select" => SQLTestCaseType.SELECT,
                    "insert" => SQLTestCaseType.INSERT,
                    "delete" => SQLTestCaseType.DELETE,
                    _ => SQLTestCaseType.OTHER,
                };
            }
            // For each test environment
            foreach (TestEnvironment env in environments)
            {
                Console.WriteLine("[ Info    ] Baseline build started for environment :" + env.DSN);
                // check if input directory exists
                if(Directory.Exists(env.InputPath))
                {     
                    // create output directory if not exists
                    if(!Directory.Exists(env.OutputPath))
                    {
                        Console.WriteLine("[ Warning ] Output directory doesn't exist.");
                        Console.WriteLine("[ Info    ] Creating Output directory.");
                        Directory.CreateDirectory(env.OutputPath);                        
                    }
                    // Create Testsuite Baseline Output directory
                    Console.WriteLine("[ Info    ] Creating Baseline Output directory.");
                    string baselineOutDirectory = env.OutputPath + "\\" + DateTime.Today.ToString("yyyymmdd")+"\\"+env.DSN;
                    Directory.CreateDirectory(baselineOutDirectory);
                    foreach (string testSuite in Directory.GetFiles(env.InputPath, "*", SearchOption.AllDirectories))
                    {                        
                        int tcCount = 0;
                        string tcIDPfx = Path.GetFileNameWithoutExtension(testSuite);
                        string connectionString = GetConnectionString(env.Parms);
                        List<SQLTestCase> sqlTestcases = new List<SQLTestCase>();
                        Console.WriteLine("[ Info    ] Creating baseline for Test Suite " + tcIDPfx);

                        foreach (string testCase in File.ReadAllLines(testSuite))
                        {
                            // Create ODBC connection
                            using OdbcConnection odbcConnection = new OdbcConnection(connectionString);
                            odbcConnection.Open();
                            MemoryStream tempDataStream = new MemoryStream();
                            StreamWriter fileWriter = new StreamWriter(tempDataStream);
                            if (testCase.Trim().StartsWith("--"))
                            { continue; }
                            tcCount++;
                            OdbcCommand odbcCommand = new OdbcCommand
                            {
                                Connection = odbcConnection                                
                            };
                            odbcCommand.CommandText = testCase;
                            DataSet resultSet = new DataSet();                            
                            try
                            {
                                Console.WriteLine("[ Info    ] Creating baseline for Test Case " + (tcIDPfx + tcCount.ToString("D4")));
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
                            catch(OdbcException ex)
                            {
                                fileWriter.Write(ex.Message);
                            }
                            fileWriter.Flush();
                            tempDataStream.Position = 0;
                            String hash = HashGenerator.GenerateSha256(tempDataStream);
                            tempDataStream.Close();
                            sqlTestcases.Add(new SQLTestCase(tcIDPfx + tcCount.ToString("D4"), SQLType(testCase.Split(" ")[0]),hash,testCase,""));
                            odbcCommand.Dispose();
                            odbcConnection.Close();
                        }
                        // build baseline file for testsuite
                       
                        string outFile = baselineOutDirectory + "\\" + tcIDPfx + ".baseline";
                        //OdbcConnection x = new OdbcConnection(env.DSN);

                        WriteBaselineFileAsync(outFile,connectionString, sqlTestcases);
                        Console.WriteLine("[ Info    ] Creating baseline for Test Suite '{0}' completed.", tcIDPfx);
                    }
                    Console.WriteLine("[ Info    ] Baseline build completed.");
                }
                else
                {
                    Console.WriteLine("[ Error   ] Input directory {0} doesn't exist.",env.InputPath);
                }
            }
        }

        private static string GetConnectionString(Dictionary<string, string> parms)
        {
            OdbcConnectionStringBuilder builder = new OdbcConnectionStringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in parms)
            {
                builder.Add(keyValuePair.Key, keyValuePair.Value);
            }
            return builder.ConnectionString;
        }

        private static void WriteBaselineFileAsync(string path, string connectionString, List<SQLTestCase> sqlTestcases)
        {            
            using StreamWriter fileStream = new StreamWriter (path);
            fileStream.WriteLine(connectionString);
            foreach (SQLTestCase sqlTestcase in sqlTestcases)
            {
                fileStream.WriteLine(sqlTestcase.ToString());
            }
        }

        private static void ParseConfigXML()
        {
            string dsn = null, input = null, output = null;
            environments = new List<TestEnvironment>();
            Dictionary<string, string> parms = null;
            using XmlReader reader = XmlReader.Create(configXML);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name.ToLower().Equals("environment"))
                        {
                            input = null;
                            output = null;
                        }
                        else if (reader.Name.ToLower().Equals("env_dsn"))
                        {
                            dsn = reader.GetAttribute("name");
                        }
                        else if (reader.Name.ToLower().Equals("env_inputpath"))
                        {
                            reader.Read();
                            input = reader.Value;
                        }
                        else if (reader.Name.ToLower().Equals("env_outputpath"))
                        {
                            reader.Read();
                            output = reader.Value;
                        }  
                        else if (reader.Name.ToLower().Equals("env_parm"))
                        {
                            if(parms is null)
                            {
                                parms = new Dictionary<string, string>();
                            }
                            string key = reader.GetAttribute("key");
                            string value = reader.GetAttribute("value");
                            parms.Add(key, value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name.ToLower().Equals("environment"))
                        {
                           
                            if (parms is null || input is null || output is null)
                            {
                                Console.WriteLine("[ Error    ] Atleast one subnode of <environment> is empty.");
                                Console.WriteLine("[ Info     ] None of the <environment> subnodes are nullable. ");
                                return;
                            }
                            else
                            {
                                environments.Add(new TestEnvironment(dsn,parms, input, output));
                                parms = new Dictionary<string, string>();
                            }
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        private static void ValidateArguments(string [] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("Usage is: BaselineBuilder cfgxml=fullpath_to_config");
                Console.WriteLine("Note: Enclose the path in quotes if path contain blank character.");
                Console.WriteLine("The format for config xml is as follows:");
                string[] lines = File.ReadAllLines(new Uri(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).LocalPath+"\\baselineconfig.xml");
                foreach(string line in lines)
                {
                    Console.WriteLine(line);
                }
                Environment.Exit(1);
            }
            else
            {
                string[] keyValue = args[0].Split("=");
                if(keyValue[0].ToLower().Trim().Equals("cfgxml"))
                {
                    configXML = keyValue[1];
                    if(configXML.Trim() is null)
                    {
                        Console.WriteLine("[ Error ] Configuration XML path can not be empty.");
                        Environment.Exit(3);
                    }
                    else
                    {
                        if(File.Exists(configXML))
                        {
                            ValidateConfigXML();
                        }
                        else
                        {
                            Console.WriteLine("[ Error ] Configuration XML doesn't exist.");
                            Environment.Exit(4);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("[ Error ] Unsupported parameter found.");
                    Console.Write("[ Info  ] Supported parameter(s) are : " + String.Join(",",Parms));
                    Environment.Exit(2);
                }
            }
        }

        private static void ValidateConfigXML()
        {
            string executionPath = new Uri(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).LocalPath;
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("",executionPath+"\\baselineconfig.xsd");
            XmlReader xmlReader = XmlReader.Create(configXML);
            XDocument xmlDocument = XDocument.Load(xmlReader);
            xmlDocument.Validate(schema, XMLValidationEventHandler);
        }
        private static void XMLValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (Enum.TryParse<XmlSeverityType>("Error", out XmlSeverityType type))
            {
                if (type == XmlSeverityType.Error)
                {
                    Console.WriteLine("[ Error    ] Invalid XML format.");
                    Console.WriteLine("[ Info     ] " + e.Message);
                    Environment.Exit(5);
                }
            }
        }
    }
}