using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rocket.RDVQA.Tools.UI.Forms;
using Rocket.RDVQA.Tools.Core.Data;

namespace Rocket.RDVQA.Tools.ODBC
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DBManager.DataTables.PopulateDataTables();
            Application.Run(new RDVQAToolMainForm());
            //_ = new ConnectionTester();
        }
    }
}
