
namespace Rocket.RDVQA.Tools.ODBC.UI.Controls
{
    partial class SuiteSelectionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listTestCases = new System.Windows.Forms.CheckedListBox();
            this.splitTestSuite = new System.Windows.Forms.Splitter();
            this.listTestSuites = new System.Windows.Forms.CheckedListBox();
            this.splitRegressionSuiteList = new System.Windows.Forms.Splitter();
            this.listRegressionSuites = new System.Windows.Forms.CheckedListBox();
            this.pnlListControl = new System.Windows.Forms.Panel();
            this.pnlLogControl = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.logSplitter = new System.Windows.Forms.Splitter();
            this.controlButtonSplitter = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartRegression = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnLoadConfigFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.pnlListControl.SuspendLayout();
            this.pnlLogControl.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listTestCases
            // 
            this.listTestCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTestCases.FormattingEnabled = true;
            this.listTestCases.Location = new System.Drawing.Point(499, 4);
            this.listTestCases.Margin = new System.Windows.Forms.Padding(2);
            this.listTestCases.Name = "listTestCases";
            this.listTestCases.Size = new System.Drawing.Size(425, 452);
            this.listTestCases.TabIndex = 10;
            // 
            // splitTestSuite
            // 
            this.splitTestSuite.Location = new System.Drawing.Point(495, 4);
            this.splitTestSuite.Margin = new System.Windows.Forms.Padding(2);
            this.splitTestSuite.Name = "splitTestSuite";
            this.splitTestSuite.Size = new System.Drawing.Size(4, 452);
            this.splitTestSuite.TabIndex = 9;
            this.splitTestSuite.TabStop = false;
            // 
            // listTestSuites
            // 
            this.listTestSuites.Dock = System.Windows.Forms.DockStyle.Left;
            this.listTestSuites.FormattingEnabled = true;
            this.listTestSuites.Location = new System.Drawing.Point(195, 4);
            this.listTestSuites.Margin = new System.Windows.Forms.Padding(2);
            this.listTestSuites.Name = "listTestSuites";
            this.listTestSuites.Size = new System.Drawing.Size(300, 452);
            this.listTestSuites.TabIndex = 8;
            this.listTestSuites.SelectedIndexChanged += new System.EventHandler(this.listTestSuites_SelectedIndexChanged);
            // 
            // splitRegressionSuiteList
            // 
            this.splitRegressionSuiteList.Location = new System.Drawing.Point(191, 4);
            this.splitRegressionSuiteList.Margin = new System.Windows.Forms.Padding(2);
            this.splitRegressionSuiteList.Name = "splitRegressionSuiteList";
            this.splitRegressionSuiteList.Size = new System.Drawing.Size(4, 452);
            this.splitRegressionSuiteList.TabIndex = 6;
            this.splitRegressionSuiteList.TabStop = false;
            // 
            // listRegressionSuites
            // 
            this.listRegressionSuites.Dock = System.Windows.Forms.DockStyle.Left;
            this.listRegressionSuites.FormattingEnabled = true;
            this.listRegressionSuites.Location = new System.Drawing.Point(4, 4);
            this.listRegressionSuites.Margin = new System.Windows.Forms.Padding(2);
            this.listRegressionSuites.Name = "listRegressionSuites";
            this.listRegressionSuites.Size = new System.Drawing.Size(187, 452);
            this.listRegressionSuites.TabIndex = 5;
            this.listRegressionSuites.SelectedIndexChanged += new System.EventHandler(this.listRegressionSuites_SelectedIndexChanged);
            // 
            // pnlListControl
            // 
            this.pnlListControl.Controls.Add(this.listTestCases);
            this.pnlListControl.Controls.Add(this.splitTestSuite);
            this.pnlListControl.Controls.Add(this.listTestSuites);
            this.pnlListControl.Controls.Add(this.splitRegressionSuiteList);
            this.pnlListControl.Controls.Add(this.listRegressionSuites);
            this.pnlListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListControl.Location = new System.Drawing.Point(0, 43);
            this.pnlListControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlListControl.Name = "pnlListControl";
            this.pnlListControl.Padding = new System.Windows.Forms.Padding(4);
            this.pnlListControl.Size = new System.Drawing.Size(928, 460);
            this.pnlListControl.TabIndex = 17;
            // 
            // pnlLogControl
            // 
            this.pnlLogControl.Controls.Add(this.txtLog);
            this.pnlLogControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogControl.Location = new System.Drawing.Point(0, 43);
            this.pnlLogControl.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLogControl.Name = "pnlLogControl";
            this.pnlLogControl.Padding = new System.Windows.Forms.Padding(4);
            this.pnlLogControl.Size = new System.Drawing.Size(928, 460);
            this.pnlLogControl.TabIndex = 17;
            this.pnlLogControl.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtLog.Location = new System.Drawing.Point(4, 4);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(920, 452);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // logSplitter
            // 
            this.logSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logSplitter.Location = new System.Drawing.Point(0, 503);
            this.logSplitter.Margin = new System.Windows.Forms.Padding(2);
            this.logSplitter.Name = "logSplitter";
            this.logSplitter.Size = new System.Drawing.Size(928, 10);
            this.logSplitter.TabIndex = 16;
            this.logSplitter.TabStop = false;
            // 
            // controlButtonSplitter
            // 
            this.controlButtonSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlButtonSplitter.Location = new System.Drawing.Point(0, 331);
            this.controlButtonSplitter.Margin = new System.Windows.Forms.Padding(2);
            this.controlButtonSplitter.Name = "controlButtonSplitter";
            this.controlButtonSplitter.Size = new System.Drawing.Size(928, 194);
            this.controlButtonSplitter.TabIndex = 16;
            this.controlButtonSplitter.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.54342F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.91315F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.54343F));
            this.tableLayoutPanel2.Controls.Add(this.btnStartRegression, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnViewLog, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 513);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(928, 45);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // btnStartRegression
            // 
            this.btnStartRegression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartRegression.Location = new System.Drawing.Point(609, 3);
            this.btnStartRegression.Name = "btnStartRegression";
            this.btnStartRegression.Size = new System.Drawing.Size(316, 39);
            this.btnStartRegression.TabIndex = 0;
            this.btnStartRegression.Text = "Start";
            this.btnStartRegression.UseVisualStyleBackColor = true;
            this.btnStartRegression.Click += new System.EventHandler(this.btnStartRegression_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(323, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnViewLog
            // 
            this.btnViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnViewLog.Enabled = false;
            this.btnViewLog.Location = new System.Drawing.Point(3, 3);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(314, 39);
            this.btnViewLog.TabIndex = 2;
            this.btnViewLog.Text = "Show Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 32);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(928, 11);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // btnLoadConfigFile
            // 
            this.btnLoadConfigFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadConfigFile.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLoadConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoadConfigFile.Location = new System.Drawing.Point(3, 3);
            this.btnLoadConfigFile.Name = "btnLoadConfigFile";
            this.btnLoadConfigFile.Size = new System.Drawing.Size(133, 26);
            this.btnLoadConfigFile.TabIndex = 0;
            this.btnLoadConfigFile.Text = "Load Config XML";
            this.btnLoadConfigFile.UseVisualStyleBackColor = true;
            this.btnLoadConfigFile.Click += new System.EventHandler(this.btnLoadConfigFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.03638F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.96362F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoadConfigFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtConfigFile, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 32);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfigFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfigFile.Enabled = false;
            this.txtConfigFile.Location = new System.Drawing.Point(144, 5);
            this.txtConfigFile.Margin = new System.Windows.Forms.Padding(5);
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.Size = new System.Drawing.Size(779, 23);
            this.txtConfigFile.TabIndex = 1;
            // 
            // SuiteSelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListControl);
            this.Controls.Add(this.pnlLogControl);
            this.Controls.Add(this.logSplitter);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SuiteSelectionControl";
            this.Size = new System.Drawing.Size(928, 558);
            this.pnlListControl.ResumeLayout(false);
            this.pnlLogControl.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox listTestCases;
        private System.Windows.Forms.Splitter splitTestSuite;
        private System.Windows.Forms.CheckedListBox listTestSuites;
        private System.Windows.Forms.Splitter splitRegressionSuiteList;
        private System.Windows.Forms.CheckedListBox listRegressionSuites;
        private System.Windows.Forms.Panel pnlListControl;
        private System.Windows.Forms.Panel pnlLogControl;
        private System.Windows.Forms.Splitter logSplitter;
        private System.Windows.Forms.Splitter controlButtonSplitter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnStartRegression;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnLoadConfigFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtConfigFile;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}
