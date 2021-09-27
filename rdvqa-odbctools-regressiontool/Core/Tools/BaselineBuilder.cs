using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.Tools
{
    class BaselineBuilder
    {
        private string _sqlSourcePath;
        private string _baselinePath;
        public string SqlSourcePath { get => _sqlSourcePath ; set { ListTestSuites(); } }
        public string BaselinePath { get => _baselinePath; set => _baselinePath = value; }
        public string[] ConnectionStrings { get; set; }
        public string[] TestSuiteFiles { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public BaselineBuilder()
        {
            SqlSourcePath = null;
            BaselinePath = null;
            ConnectionStrings = null;
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStrings"></param>
        /// <param name="inputPath"></param>
        /// <param name="outputPath"></param>
        public BaselineBuilder(String[] connectionStrings,String sqlSourcePath, String baselinePath)
        {
            SqlSourcePath = sqlSourcePath;
            BaselinePath = baselinePath;
            ConnectionStrings = connectionStrings;
        }

        public void ListTestSuites()
        {
            TestSuiteFiles = System.IO.Directory.GetFiles(SqlSourcePath, "*", System.IO.SearchOption.AllDirectories);
        }
        /// <summary>
        /// 
        /// </summary>
        private void BuildBaselines()
        {
            //

        }

    }
}
