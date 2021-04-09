using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rdvqa_odbctools_regressiontool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] idx= new int[3];
            idx[0] = ucTestExecutionTable.AddRegressionSuite("Suite 1");
            idx[1] = ucTestExecutionTable.AddRegressionSuite("Suite 2");
            idx[2] = ucTestExecutionTable.AddRegressionSuite("Suite 3");
            ucTestExecutionTable.AddTCExecutionRecord(idx[0], "TS1TC1", "nothing", true);
            ucTestExecutionTable.AddTCExecutionRecord(idx[0], "TS1TC1", "nothing", true);
            ucTestExecutionTable.AddTCExecutionRecord(idx[0], "TS1TC1", "nothing", true);
            ucTestExecutionTable.AddTCExecutionRecord(idx[0], "TS1TC1", "nothing", true);
            ucTestExecutionTable.AddTCExecutionRecord(idx[0], "TS1TC1", "nothing", true);
            ucTestExecutionTable.AddTCExecutionRecord(idx[1], "TS1TC2", "nothing", true);
        }
    }
}
