using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace rdvqa_odbctools_regressiontool
{
    public partial class UCTestExecutionRecord : UserControl
    {
        public UCTestExecutionRecord(string tcID, string comments, bool pass)
        {
            InitializeComponent();
            lblTestCaseID.Text = tcID;
            lblComments.Text = comments;
            if (!pass)
            {
                lblTestCaseID.BackColor = Color.Red;
                btnMoreInfo.Text = "Fail";
            }
            else
            {
                lblTestCaseID.BackColor = Color.Green;
                btnMoreInfo.Text = "Pass";
            }

        }
    }
}
