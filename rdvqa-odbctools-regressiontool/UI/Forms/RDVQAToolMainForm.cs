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
        private BaselineBuilderControl baselineBuilderControl;

        private int regressionFormCounter = 0;

        //private bool 
        public RDVQAToolMainForm()
        {
            InitializeComponent();
            suiteSelectionControl = null;
            baselineBuilderControl = null;
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

        private void menuBaselineBuilderBatch_Click(object sender, EventArgs e)
        {
            if (baselineBuilderControl is null)
            {
                baselineBuilderControl = new BaselineBuilderControl();
                baselineBuilderControl.Dock = DockStyle.Left;
                int pageCount = this.MainContainer.TabPages.Count;
                this.MainContainer.TabPages.Add("Baseline Build - ");
                this.MainContainer.TabPages[pageCount].Controls.Add(baselineBuilderControl);
            }
        }

        private void menuTableViewer_Click(object sender, EventArgs e)
        {
            TableViewControl t = new TableViewControl();

            t.Dock = DockStyle.Fill;
            int pageCount = this.MainContainer.TabPages.Count;
            this.MainContainer.TabPages.Add("Table Viewer");
            this.MainContainer.TabPages[pageCount].Controls.Add(t);

        }
    }
}
