
namespace Rocket.RDVQA.Tools.ODBC.UI.Forms
{
    partial class RDVQAToolMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mstrpMain = new System.Windows.Forms.MenuStrip();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewTestCase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewBatchTestCase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewTestSuite = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewRegressionSuite = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRegressionRunner = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBaselineBuilderBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.MainContainer = new System.Windows.Forms.TabControl();
            this.menuTableViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.mstrpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstrpMain
            // 
            this.mstrpMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuTools});
            this.mstrpMain.Location = new System.Drawing.Point(0, 0);
            this.mstrpMain.Name = "mstrpMain";
            this.mstrpMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mstrpMain.Size = new System.Drawing.Size(1237, 24);
            this.mstrpMain.TabIndex = 1;
            this.mstrpMain.Text = "New";
            // 
            // menuNew
            // 
            this.menuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewTestCase,
            this.menuNewBatchTestCase,
            this.menuNewTestSuite,
            this.menuNewRegressionSuite});
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(43, 20);
            this.menuNew.Text = "New";
            // 
            // menuNewTestCase
            // 
            this.menuNewTestCase.Name = "menuNewTestCase";
            this.menuNewTestCase.Size = new System.Drawing.Size(157, 22);
            this.menuNewTestCase.Text = "Test Case";
            // 
            // menuNewBatchTestCase
            // 
            this.menuNewBatchTestCase.Name = "menuNewBatchTestCase";
            this.menuNewBatchTestCase.Size = new System.Drawing.Size(157, 22);
            this.menuNewBatchTestCase.Text = "Batch Test Case";
            // 
            // menuNewTestSuite
            // 
            this.menuNewTestSuite.Name = "menuNewTestSuite";
            this.menuNewTestSuite.Size = new System.Drawing.Size(157, 22);
            this.menuNewTestSuite.Text = "Test Suite";
            this.menuNewTestSuite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuNewRegressionSuite
            // 
            this.menuNewRegressionSuite.Name = "menuNewRegressionSuite";
            this.menuNewRegressionSuite.Size = new System.Drawing.Size(157, 22);
            this.menuNewRegressionSuite.Text = "RegressionSuite";
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRegressionRunner,
            this.menuBaselineBuilderBatch,
            this.menuTableViewer});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(47, 20);
            this.menuTools.Text = "Tools";
            // 
            // menuRegressionRunner
            // 
            this.menuRegressionRunner.Name = "menuRegressionRunner";
            this.menuRegressionRunner.Size = new System.Drawing.Size(198, 22);
            this.menuRegressionRunner.Text = "Regression Runner";
            this.menuRegressionRunner.Click += new System.EventHandler(this.menuRegressionRunner_Click);
            // 
            // menuBaselineBuilderBatch
            // 
            this.menuBaselineBuilderBatch.Name = "menuBaselineBuilderBatch";
            this.menuBaselineBuilderBatch.Size = new System.Drawing.Size(198, 22);
            this.menuBaselineBuilderBatch.Text = "Baseline Builder (Batch)";
            this.menuBaselineBuilderBatch.Click += new System.EventHandler(this.menuBaselineBuilderBatch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1237, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.77778F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.77778F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // MainContainer
            // 
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 24);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.SelectedIndex = 0;
            this.MainContainer.Size = new System.Drawing.Size(1237, 521);
            this.MainContainer.TabIndex = 3;
            // 
            // menuTableViewer
            // 
            this.menuTableViewer.Name = "menuTableViewer";
            this.menuTableViewer.Size = new System.Drawing.Size(198, 22);
            this.menuTableViewer.Text = "Table Viewer";
            this.menuTableViewer.Click += new System.EventHandler(this.menuTableViewer_Click);
            // 
            // RDVQAToolMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1237, 567);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mstrpMain);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.mstrpMain;
            this.Name = "RDVQAToolMainForm";
            this.Text = "RDV QA Suite";
            this.mstrpMain.ResumeLayout(false);
            this.mstrpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstrpMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuNewTestCase;
        private System.Windows.Forms.ToolStripMenuItem menuNewBatchTestCase;
        private System.Windows.Forms.ToolStripMenuItem menuNewTestSuite;
        private System.Windows.Forms.ToolStripMenuItem menuNewRegressionSuite;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStripMenuItem menuRegressionRunner;
        private System.Windows.Forms.TabControl MainContainer;
        private System.Windows.Forms.ToolStripMenuItem menuBaselineBuilderBatch;
        private System.Windows.Forms.ToolStripMenuItem menuTableViewer;
    }
}