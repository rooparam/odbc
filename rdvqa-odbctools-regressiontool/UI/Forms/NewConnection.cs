using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rocket.RDVQA.Tools.Core.DB;

namespace Rocket.RDVQA.Tools.UI.Forms
{
    public partial class NewConnection : Form
    {
        public NewConnection()
        {
            InitializeComponent();
        }

        private void chkTrustStore_CheckedChanged(object sender, EventArgs e)
        {
            txtTrustStore.Enabled = chkTrustStore.Checked;
            btnBrowseTS.Enabled = chkTrustStore.Checked;
        }

        private void chkKeyStore_CheckedChanged(object sender, EventArgs e)
        {
            txtKeyStore.Enabled = chkKeyStore.Checked;
            btnBrowseKS.Enabled = chkKeyStore.Checked;
        }

        private void btnAddConnection_Click(object sender, EventArgs e)
        {
            DataTable dt = TableManager.RDVQADBTables.DTConnections();
            if(chkKeyStore.Checked)
            {

            }
            if(chkTrustStore.Checked)
            {

            }

        }

    }
}
