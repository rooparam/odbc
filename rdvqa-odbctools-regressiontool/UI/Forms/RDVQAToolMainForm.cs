using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rocket.RDVQA.Tools.ODBC.UI.Controls;

namespace Rocket.RDVQA.Tools.ODBC.UI.Forms
{
    public partial class RDVQAToolMainForm : Form
    {
        private SuiteSelectionControl suiteSelectionControl;

        private int regressionFormCounter = 0;

        //private bool 
        public RDVQAToolMainForm()
        {
            InitializeComponent();
            suiteSelectionControl = null;
        }

        private void menuRegressionRunner_Click(object sender, EventArgs e)
        {
            // check if already a regression running or not
            if(suiteSelectionControl is null)
            {
                regressionFormCounter++;
                suiteSelectionControl = new SuiteSelectionControl();
                suiteSelectionControl.Dock = DockStyle.Fill;
                int pageCount = this.MainContainer.TabPages.Count;
                this.MainContainer.TabPages.Add("Regression - "+regressionFormCounter);
                this.MainContainer.TabPages[pageCount].Controls.Add(suiteSelectionControl);                
            }
        }
    }
}
