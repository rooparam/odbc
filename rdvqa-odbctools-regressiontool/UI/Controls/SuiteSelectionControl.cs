using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rocket.RDVQA.Tools.ODBC;
using Rocket.RDVQA.Tools.Core;

namespace Rocket.RDVQA.Tools.UI.Controls
{
    
    public partial class SuiteSelectionControl : UserControl
    {
       

        private int rsIdx, tsIdx, tcIdx;
        RegressionManager regressionManager;

        private Thread regressionThread;

        private LogWriter logWriter;
        public SuiteSelectionControl()
        {
            // Define the cancellation token.
            //TODO
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            regressionThread = new Thread(new ThreadStart(this.ThreadTask));
            //source.Cancel()

            InitializeComponent();
            logWriter = new LogWriter(this.txtLog);


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
            btnViewLog.Enabled = true;

            regressionThread.IsBackground = true;
            regressionThread.Start();
           
        }
        private void ThreadTask()
        {
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

        private void btnStopRegression_Click(object sender, EventArgs e)
        {
            regressionThread.Suspend();
            pnlListControl.Enabled = true;
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
