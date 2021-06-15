using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rocket.RDVQA.Tools.Core;
using Rocket.RDVQA.Tools.Core.Data;
using Rocket.RDVQA.Tools.Core.Data.Extensions;
using Rocket.RDVQA.Tools.ODBC;
using Rocket.RDVQA.Tools.UI.Forms;

namespace Rocket.RDVQA.Tools.UI.Controls
{
    public partial class NewSQLSelectTestCase : UserControl
    {
        private RDVQAQueryManager queryManager;
        private delegate void SafeCallDelegate(string text);
        private List<SQLDeSelectTestCase> candTestCases = null;
        private LogWriter executionLog;
        private LogWriter executionResult;
        public NewSQLSelectTestCase()
        {
            InitializeComponent();
            executionLog = new LogWriter(this.txtLog);
            executionResult = new LogWriter(this.txtResults);
            queryManager = new RDVQAQueryManager(executionLog,executionResult);

            //
            // initialize cmbConnections
            //
            cmbConnections.DataSource = DBManager.DataTables.DTConnections;
            cmbConnections.DisplayMember = "name";
            cmbConnections.ValueMember = "ID";
            //
            // initalize cmbDatasources
            //
            cmbDatasources.DataSource = DBManager.DataTables.DTDsTypes;
            cmbDatasources.DisplayMember = "name";
            cmbDatasources.ValueMember = "ID";
        }


        private void btnTestQueries_Click(object sender, EventArgs e)
        {
            btnTestQueries.Enabled = false;
            btnTestQueries.Text = "Execution in Progress";
            int connId = Convert.ToInt32(cmbConnections.SelectedValue.ToString());
            string connectionString = DBManager.DataTables.DTConnections.Select("ID="+ connId)[0][2].ToString();
            string[] queries = txtQueries.Lines;
            candTestCases = new List<SQLDeSelectTestCase>();
            foreach(string query in txtQueries.Lines)
            {
                if (!string.IsNullOrWhiteSpace(query))
                {
                    SQLDeSelectTestCase tc = new SQLDeSelectTestCase(query, Convert.ToInt32(cmbDatasources.SelectedValue.ToString()), txtTags.Text, connId, connectionString);
                    candTestCases.Add(tc);
                }
            }
            DataSet ds = new DataSet();
            txtLog.Clear();
            txtResults.Clear();
            Task task = Task.Factory.StartNew(() => {
                ds = queryManager.ExecuteBatchSelect(candTestCases);
                ToggleExecutionStatus("Test Queries");
            });         
        }
        private void ToggleExecutionStatus(String text)
        {
            if (btnTestQueries.InvokeRequired)
            {
                var d = new SafeCallDelegate(ToggleExecutionStatus);
                btnTestQueries.Invoke(d, new object[] {text });
            }
            else
            {
                btnTestQueries.Enabled = true;
                btnTestQueries.Text = text;
            }
        }
        private void btnAddTCs_Click(object sender, EventArgs e)
        {
            int dstypeId = Convert.ToInt32(cmbDatasources.SelectedValue);
            string tags = txtTags.Text;
            string[] queries = txtQueries.Lines;
            txtLog.Clear();
            if (candTestCases is null)
            {
                MessageBox.Show("Please Test Queries before adding.");
            }
            else
            {
                Task task = Task.Factory.StartNew(() => {
                    new DBOperationsManager(executionLog).AddTestCasesDeSelect(candTestCases); 
                    candTestCases.Clear();
                });
            }

        }

        private void txtLog_SelectionChanged(object sender, EventArgs e)
        {
            MessageBox.Show(txtLog.SelectionStart.ToString());
        }

        private void btnNewDataSource_Click(object sender, EventArgs e)
        {
            NewDataSourcecs newDsForm = new NewDataSourcecs();
            newDsForm.ShowDialog();
        }

        private void btnNewConnection_Click(object sender, EventArgs e)
        {
            NewConnection newConnection = new NewConnection();
            newConnection.ShowDialog();
        }

        private void btnAddTestSuites_Click(object sender, EventArgs e)
        {
            NewTestSuite newTestSuite = new NewTestSuite();
            newTestSuite.ShowDialog();
        }
    }
}
