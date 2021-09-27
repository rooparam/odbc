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

namespace Rocket.RDVQA.Tools.UI.Controls
{
    public partial class BaselineBuilder : UserControl
    {
        public BaselineBuilder()
        {
            InitializeComponent();
        }

        private void btnBuildBaseline_Click(object sender, EventArgs e)
        {
            string sqlSourcePath = txtBaselineDestinationPath.Text;
            string baselineDestPath = txtBaselineDestinationPath.Text;
            List<string> connectionStrings = new List<string>();
            string odbcParms = txtODBCParms.Text;

            if (chkDVM31.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Manager Driver 3.1};"+odbcParms);
            }
            if(chkDVM32.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Manager Driver 3.2};" + odbcParms);
            } 
            if(chkDVS31.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Driver 3.1};" + odbcParms);
            } if(chkDVS32.Checked)
            {
                connectionStrings.Add("Driver={Data Virtualization Driver 3.2};" + odbcParms);
            }
           
        }

        private void btnBrowseSQLSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = folderBrowserDialog.SelectedPath;
                txtSQLSourcePath.Text = filename;
                DirectoryInfo directoryInfo = new DirectoryInfo(filename);
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
                StreamReader reader = new StreamReader(e.Node.Name);
                this.txtTestCases.Text = reader.ReadToEnd();
                reader.Close();
            }
        }
    }
}
