using System;
using System.IO;

namespace Rocket.RDVQA.Tools.ODBC
{
    class Application
    {
        private static readonly string[] Parms = { "cfgxml" };

        private static string ConfigXML;

        static void Main(string[] args)
        {
            ValidateArguments(args);
            new RegressionManager().StartRegression(ConfigXML);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void ValidateArguments(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage is: BaselineBuilder cfgxml=fullpath_to_config");
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
                string[] keyValue = args[0].Split("=");
                if (keyValue[0].ToLower().Trim().Equals("cfgxml"))
                {
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
                            Console.WriteLine("[ Error ] Configuration XML doesn't exist.");
                            Environment.Exit(4);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("[ Error ] Unsupported parameter found.");
                    Console.Write("[ Info  ] Supported parameter(s) are : " + String.Join(",", Parms));
                    Environment.Exit(2);
                }
            }
        }
    }
}
