using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rocket.RDVQA.Tools.ODBC.UI.Controls
{
    
    public partial class SuiteSelectionControl : UserControl
    {
        private class LogWriter : System.IO.TextWriter
        {
            public override Encoding Encoding
            {
                get { return Encoding.Unicode; }
            }
            private Control MyControl;
            public LogWriter(Control control)
            {
                MyControl = control;
            }

            public override void Write(char value)
            {
                MyControl.Text += value;
            }

            public override void Write(string value)
            {
                MyControl.Text += value;
            }

        }

        private int rsIdx, tsIdx, tcIdx;
        RegressionManager regressionManager;



        private LogWriter logWriter;
        public SuiteSelectionControl()
        {
            InitializeComponent();
        }

        private void listTestSuites_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEnabled;
            tsIdx = listTestSuites.SelectedIndex;
            listTestCases.Items.Clear();
            isEnabled = listTestSuites.GetItemChecked(tsIdx);
            foreach (SQLTestCase tc in regressionManager.RegressionSuites[rsIdx].GetTestSuites()[tsIdx].TestCases)
            {
                listTestCases.Items.Add(tc.ID, isEnabled);
                tc.IsEnabled = isEnabled;
            }
        }

        private void btnStartRegression_Click(object sender, EventArgs e)
        {
            pnlListControl.Enabled = false;
            logWriter = new LogWriter(this.txtLog);
            btnViewLog.Enabled = true;
            regressionManager.StartRegression(logWriter);
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            pnlListControl.Visible = !pnlListControl.Visible;
            pnlLogControl.Visible = !pnlLogControl.Visible;
            if(pnlLogControl.Visible)
            {
                btnViewLog.Text = "Hide Log";
            }
            else
            {
                btnViewLog.Text = "Show Log";
            }
        }

        private void btnLoadConfigFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                txtConfigFile.Text = filename;
                regressionManager = new RegressionManager(filename);
                listRegressionSuites.Items.Clear();
                foreach (RegressionSuite rs in regressionManager.RegressionSuites)
                {
                    listRegressionSuites.Items.Add(rs.Name, true);
                }
            }
        }

        private void listRegressionSuites_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEnabled;
            listTestSuites.Items.Clear();
            listTestCases.Items.Clear();
            rsIdx = listRegressionSuites.SelectedIndex;
            isEnabled = listRegressionSuites.GetItemChecked(rsIdx);

            foreach (TestSuite ts in regressionManager.RegressionSuites[rsIdx].GetTestSuites())
            {
                listTestSuites.Items.Add(ts.Name, isEnabled);
                ts.IsEnabled = isEnabled;
            }
        }

    }
}
