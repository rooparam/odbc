using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace rdvqa_odbctools_regressiontool
{
    public partial class UCTestExecutionTable : UserControl
    {
        List<List<UCTestExecutionRecord>> records;
        public UCTestExecutionTable()
        {
            InitializeComponent();
            records = new List<List<UCTestExecutionRecord>>();
        }

        public int AddRegressionSuite(string rsName)
        {
            int idx = tvTCGroup.Nodes.Add(new TreeNode(rsName));
            records.Add(new List<UCTestExecutionRecord>());
            tvTCGroup.SelectedNode = tvTCGroup.Nodes[idx];
            return idx;
        }

        public int AddTestSuite(int rsIdx, string tsName)
        {
            int idx = tvTCGroup.Nodes.Add(new TreeNode(tsName));
            records.Add(new List<UCTestExecutionRecord>());
            tvTCGroup.SelectedNode = tvTCGroup.Nodes[idx];
            return idx;
        }
        public void AddTCExecutionRecord(int nodeID, string tcid, string comments, bool pass)
        {
            records[nodeID].Add(new UCTestExecutionRecord(tcid, comments, pass));
        }

        private void tvTCGroup_Click(object sender, EventArgs e)
        {
            
        }

        private void tvTCGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int idx = ((TreeView)sender).SelectedNode.Index;
            pnlRecords.Controls.Clear();
            pnlRecords.Refresh();
            foreach (UCTestExecutionRecord ucTCrecord in records[idx])
            {
                ucTCrecord.Dock = DockStyle.Top;
                pnlRecords.Controls.Add(ucTCrecord);
            }
            pnlRecords.Refresh();

        }
    }
}
