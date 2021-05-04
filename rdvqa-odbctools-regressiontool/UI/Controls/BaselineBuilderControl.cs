using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Rocket.RDVQA.Tools.ODBC.UI.Controls
{
    public partial class BaselineBuilderControl : UserControl
    {
        private Thread baselineInputCollectionThread;
        public BaselineBuilderControl()
        {
            baselineInputCollectionThread = null;
            InitializeComponent();
        }

        private void RDVQADBConnection_InfoMessage(object sender, IBM.Data.DB2.Core.DB2InfoMessageEventArgs e)
        {
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = folderBrowserDialog.SelectedPath;
                txtSQLSource.Text = filename;
                baselineInputCollectionThread =  new Thread(new ThreadStart(this.BaseLineInputDataCollectionTask));
                baselineInputCollectionThread.IsBackground = true;
                baselineInputCollectionThread.Start();
            }
        }

        private void btnBrosweDest_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = folderBrowserDialog.SelectedPath;
                txtBaselineDest.Text = filename;
            }
        }

        private void BaseLineInputDataCollectionTask()
        {
            string filePath = txtSQLSource.Text;
            MessageBox.Show(filePath);
        }
    }
}
