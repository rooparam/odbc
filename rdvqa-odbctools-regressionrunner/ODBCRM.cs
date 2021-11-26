using System;
using System.IO;
using System.Collections.Generic;

namespace Rocket.RDVQA.Tools.ODBC
{
    class Application
    {
        private static readonly string[] Parms = { "cfgxml", "exclude_tc","exclude_ts"};

        private static string ConfigXML;
        private static List<string> TCExcludePatterns = new List<string>();
        private static List<string> TSExcludePatterns = new List<string>();
        static void Main(string[] args)
        {
            ValidateArguments(args);
            if (new RegressionManager().StartRegression(ConfigXML, TCExcludePatterns, TSExcludePatterns)) 
            {
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(99);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void ValidateArguments(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage is: RegressionRunner cfgxml=fullpath_to_config [exclude=pattern1;[pattern2;..]]");
                Console.WriteLine("Note: Enclose the path in quotes if path contain blank character.");
                Console.WriteLine("The format for config xml is as follows:");
                Console.WriteLine("<config>\n\t<regession_suite name=\"suite_name\" description=\"\">\n\t\t" +
                    "<input> input_path </input>\n\t\t<output> output_path </output>\n\t</regession_suite>\n.\n.\n." +
                    "\n\t<regession_suite name=\"suite_name\" description=\"\">\n\t\t" +
                    "<input> input_path </input>\n\t\t<output> output_path </output>\n\t</regession_suite>\n</config>");
                Environment.Exit(1);
            }
            else
            {
                
                foreach (string arg in args)
                {
                    string[] keyValue = args[0].Split("=");
                    switch (keyValue[0].ToLower().Trim())
                    {
                        case "cfgxml":
                            ConfigXML = keyValue[1];
                            if (ConfigXML.Trim() is null)
                            {
                                Console.WriteLine("[ Error ] Configuration XML path can not be empty.");
                                Environment.Exit(3);
                            }
                            else
                            {
                                if (!File.Exists(ConfigXML))
                                {
                                    Console.WriteLine("[ ERROR  ] Configuration XML doesn't exist.");
                                    Console.WriteLine("[ INFO   ] Configuration XML:" + ConfigXML);
                                    Environment.Exit(4);
                                }
                            }
                            break;
                        case "exclude_tc":
                            foreach (string pattern in keyValue[1].Split(';'))
                            {
                                TCExcludePatterns.Add(pattern);
                            }
                            break;
                        case "exclude_ts":
                            foreach (string pattern in keyValue[1].Split(';'))
                            {
                                TSExcludePatterns.Add(pattern);
                            }
                            break;
                        default:
                            Console.WriteLine("[ Error ] Unsupported parameter found.");
                            Console.Write("[ Info  ] Supported parameter(s) are : " + String.Join(",", Parms));
                            Environment.Exit(2);
                            break;
                    }
                }
            }
        }
    }
}
