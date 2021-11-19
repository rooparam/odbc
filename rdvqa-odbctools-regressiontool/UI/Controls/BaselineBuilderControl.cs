using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rocket.RDVQA.Tools.Core;
using Rocket.RDVQA.Tools.Core.TestManagement;

namespace Rocket.RDVQA.Tools.UI.Controls
{
    public partial class BaselineBuilderControl : UserControl
    {
        private List<string> testSuites = new List<string>();
        private LogWriter executionLog;
        public BaselineBuilderControl()
        {
            InitializeComponent();
            executionLog = new LogWriter(logBaselineBuild);
        }

        private void BtnBuildBaseline_Click(object sender, EventArgs e)
        {
            string sqlSourcePath = txtBaselineDestinationPath.Text;
            string baselineDestPath = txtBaselineDestinationPath.Text;
            List<string> connectionStrings = new List<string>();
            
            string odbcParms = txtODBCParms.Text;
            // validate ODBCParms

            if (chkDVM31.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Manager Driver 3.1};" + odbcParms);
            }
            if (chkDVM32.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Manager Driver 3.2};" + odbcParms);
            }
            if (chkDVS31.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Driver 3.1};" + odbcParms);
            }
            if (chkDVS32.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Driver 3.2};" + odbcParms);
            }

           if(odbcParms != null && sqlSourcePath != null && connectionStrings.Count != 0)
            {
                // Collect Testsuites
                foreach(TreeNode node  in treeViewTestSuites.Nodes)
                {
                    if(node.Checked)
                    {
                        testSuites.Add(node.Name);
                    }
                }
                if(testSuites.Count ==0 )
                {
                    MessageBox.Show(this, "No testsuites selected", "Nothing To Build");
                }
                else
                {
                    BaselineBuilder baselineBuilder = new BaselineBuilder(connectionStrings,sqlSourcePath,baselineDestPath,chkIgnoreEmbeddedConnStr.Checked);
                    baselineBuilder.UserLog = executionLog;
                    baselineBuilder.BuildBaselines();
                }
            }
            else 
            {
                MessageBox.Show(this, "Not all required data is provided", "Validation Error");
            }
        }
        private void BtnBrowseBaselineDestination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                txtBaselineDestinationPath.Text = path;
            }
        }
        private void BtnBrowseSQLSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                txtSQLSourcePath.Text = path;
                DirectoryInfo directoryInfo = new(path);
                if (directoryInfo.Exists)
                {
                    treeViewTestSuites.Nodes.Clear();
                    BuildTree(directoryInfo, treeViewTestSuites.Nodes);
                }
            }
        }
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }
        private void TreeViewTestSuites_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.EndsWith("sql"))
            {
                this.txtTestCases.Clear();
                StreamReader reader = new(e.Node.Name);
                this.txtTestCases.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void TreeViewTestSuites_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Checked)
            {
                testSuites.Add(e.Node.Name);
                MessageBox.Show(e.Node.Name);
            }
            else
            {
                testSuites.Remove(e.Node.Name);
            }
            foreach (TreeNode tn in e.Node.Nodes)
            {
                tn.Checked = e.Node.Checked;
                if (tn.Checked)
                {
                    testSuites.Add(tn.Name);
                }
                else
                {
                    testSuites.Remove(tn.Name);
                }
            }
        }

       
    }
}
