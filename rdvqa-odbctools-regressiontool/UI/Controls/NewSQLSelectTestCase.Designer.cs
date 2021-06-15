
namespace Rocket.RDVQA.Tools.UI.Controls
{
    partial class NewSQLSelectTestCase
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
            this.pnlControlPanel = new System.Windows.Forms.Panel();
            this.btnAddTCs = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbxQueries = new System.Windows.Forms.GroupBox();
            this.txtQueries = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddTestSuites = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTestSuites = new System.Windows.Forms.ComboBox();
            this.btnNewDataSource = new System.Windows.Forms.Button();
            this.btnNewConnection = new System.Windows.Forms.Button();
            this.btnTestQueries = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbConnections = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDatasources = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabStats = new System.Windows.Forms.TabControl();
            this.tpageLog = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.tpageResult = new System.Windows.Forms.TabPage();
            this.txtResults = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxQueries.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.tpageLog.SuspendLayout();
            this.tpageResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControlPanel
            // 
            this.pnlControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControlPanel.Location = new System.Drawing.Point(0, 626);
            this.pnlControlPanel.Name = "pnlControlPanel";
            this.pnlControlPanel.Size = new System.Drawing.Size(883, 47);
            this.pnlControlPanel.TabIndex = 15;
            // 
            // btnAddTCs
            // 
            this.btnAddTCs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddTCs.Location = new System.Drawing.Point(183, 288);
            this.btnAddTCs.Name = "btnAddTCs";
            this.btnAddTCs.Size = new System.Drawing.Size(150, 33);
            this.btnAddTCs.TabIndex = 14;
            this.btnAddTCs.Text = "Add Test Cases";
            this.btnAddTCs.UseVisualStyleBackColor = true;
            this.btnAddTCs.Click += new System.EventHandler(this.btnAddTCs_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 623);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(883, 3);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbxQueries);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabStats);
            this.splitContainer1.Size = new System.Drawing.Size(883, 623);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 17;
            // 
            // gbxQueries
            // 
            this.gbxQueries.Controls.Add(this.txtQueries);
            this.gbxQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxQueries.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbxQueries.Location = new System.Drawing.Point(0, 0);
            this.gbxQueries.Margin = new System.Windows.Forms.Padding(5);
            this.gbxQueries.Name = "gbxQueries";
            this.gbxQueries.Size = new System.Drawing.Size(540, 331);
            this.gbxQueries.TabIndex = 31;
            this.gbxQueries.TabStop = false;
            this.gbxQueries.Text = "SQL";
            // 
            // txtQueries
            // 
            this.txtQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQueries.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtQueries.Location = new System.Drawing.Point(3, 19);
            this.txtQueries.Multiline = true;
            this.txtQueries.Name = "txtQueries";
            this.txtQueries.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQueries.Size = new System.Drawing.Size(534, 309);
            this.txtQueries.TabIndex = 29;
            this.txtQueries.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddTestSuites);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbTestSuites);
            this.groupBox1.Controls.Add(this.btnNewDataSource);
            this.groupBox1.Controls.Add(this.btnNewConnection);
            this.groupBox1.Controls.Add(this.btnAddTCs);
            this.groupBox1.Controls.Add(this.btnTestQueries);
            this.groupBox1.Controls.Add(this.txtTags);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbConnections);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbDatasources);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(540, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.groupBox1.Size = new System.Drawing.Size(343, 331);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection/TC Attributes";
            // 
            // btnAddTestSuites
            // 
            this.btnAddTestSuites.Font = new System.Drawing.Font("Wingdings 2", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddTestSuites.Location = new System.Drawing.Point(307, 151);
            this.btnAddTestSuites.Name = "btnAddTestSuites";
            this.btnAddTestSuites.Size = new System.Drawing.Size(23, 23);
            this.btnAddTestSuites.TabIndex = 34;
            this.btnAddTestSuites.Text = "Ë";
            this.btnAddTestSuites.UseVisualStyleBackColor = true;
            this.btnAddTestSuites.Click += new System.EventHandler(this.btnAddTestSuites_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "Test Suite";
            // 
            // cmbTestSuites
            // 
            this.cmbTestSuites.FormattingEnabled = true;
            this.cmbTestSuites.Location = new System.Drawing.Point(13, 151);
            this.cmbTestSuites.Name = "cmbTestSuites";
            this.cmbTestSuites.Size = new System.Drawing.Size(288, 23);
            this.cmbTestSuites.TabIndex = 33;
            // 
            // btnNewDataSource
            // 
            this.btnNewDataSource.Font = new System.Drawing.Font("Wingdings 2", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewDataSource.Location = new System.Drawing.Point(307, 102);
            this.btnNewDataSource.Name = "btnNewDataSource";
            this.btnNewDataSource.Size = new System.Drawing.Size(23, 23);
            this.btnNewDataSource.TabIndex = 31;
            this.btnNewDataSource.Text = "Ë";
            this.btnNewDataSource.UseVisualStyleBackColor = true;
            this.btnNewDataSource.Click += new System.EventHandler(this.btnNewDataSource_Click);
            // 
            // btnNewConnection
            // 
            this.btnNewConnection.Font = new System.Drawing.Font("Wingdings 2", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNewConnection.Location = new System.Drawing.Point(307, 51);
            this.btnNewConnection.Name = "btnNewConnection";
            this.btnNewConnection.Size = new System.Drawing.Size(23, 23);
            this.btnNewConnection.TabIndex = 31;
            this.btnNewConnection.Text = "Ë";
            this.btnNewConnection.UseVisualStyleBackColor = true;
            this.btnNewConnection.Click += new System.EventHandler(this.btnNewConnection_Click);
            // 
            // btnTestQueries
            // 
            this.btnTestQueries.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTestQueries.Location = new System.Drawing.Point(10, 288);
            this.btnTestQueries.Name = "btnTestQueries";
            this.btnTestQueries.Size = new System.Drawing.Size(148, 33);
            this.btnTestQueries.TabIndex = 30;
            this.btnTestQueries.Text = "Test Query(s)";
            this.btnTestQueries.UseVisualStyleBackColor = true;
            this.btnTestQueries.Click += new System.EventHandler(this.btnTestQueries_Click);
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(13, 202);
            this.txtTags.Multiline = true;
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(320, 44);
            this.txtTags.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Connection";
            // 
            // cmbConnections
            // 
            this.cmbConnections.FormattingEnabled = true;
            this.cmbConnections.Location = new System.Drawing.Point(13, 52);
            this.cmbConnections.Name = "cmbConnections";
            this.cmbConnections.Size = new System.Drawing.Size(288, 23);
            this.cmbConnections.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Datasource";
            // 
            // cmbDatasources
            // 
            this.cmbDatasources.FormattingEnabled = true;
            this.cmbDatasources.Location = new System.Drawing.Point(13, 102);
            this.cmbDatasources.Name = "cmbDatasources";
            this.cmbDatasources.Size = new System.Drawing.Size(288, 23);
            this.cmbDatasources.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tags";
            // 
            // tabStats
            // 
            this.tabStats.Controls.Add(this.tpageLog);
            this.tabStats.Controls.Add(this.tpageResult);
            this.tabStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStats.Location = new System.Drawing.Point(0, 0);
            this.tabStats.Name = "tabStats";
            this.tabStats.SelectedIndex = 0;
            this.tabStats.Size = new System.Drawing.Size(883, 282);
            this.tabStats.TabIndex = 7;
            // 
            // tpageLog
            // 
            this.tpageLog.Controls.Add(this.txtLog);
            this.tpageLog.Location = new System.Drawing.Point(4, 24);
            this.tpageLog.Name = "tpageLog";
            this.tpageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpageLog.Size = new System.Drawing.Size(875, 254);
            this.tpageLog.TabIndex = 0;
            this.tpageLog.Text = "Execution Log";
            this.tpageLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtLog.Size = new System.Drawing.Size(869, 248);
            this.txtLog.TabIndex = 4;
            this.txtLog.Text = "";
            this.txtLog.WordWrap = false;
            // 
            // tpageResult
            // 
            this.tpageResult.Controls.Add(this.txtResults);
            this.tpageResult.Location = new System.Drawing.Point(4, 24);
            this.tpageResult.Name = "tpageResult";
            this.tpageResult.Padding = new System.Windows.Forms.Padding(3);
            this.tpageResult.Size = new System.Drawing.Size(875, 254);
            this.tpageResult.TabIndex = 1;
            this.tpageResult.Text = "Results";
            this.tpageResult.UseVisualStyleBackColor = true;
            // 
            // txtResults
            // 
            this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResults.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtResults.Location = new System.Drawing.Point(3, 3);
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(869, 248);
            this.txtResults.TabIndex = 0;
            this.txtResults.Text = "";
            // 
            // NewSQLSelectTestCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlControlPanel);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "NewSQLSelectTestCase";
            this.Size = new System.Drawing.Size(883, 673);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxQueries.ResumeLayout(false);
            this.gbxQueries.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabStats.ResumeLayout(false);
            this.tpageLog.ResumeLayout(false);
            this.tpageResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlControlPanel;
        private System.Windows.Forms.Button btnAddTCs;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDatasources;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbConnections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabStats;
        private System.Windows.Forms.TabPage tpageLog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TabPage tpageResult;
        private System.Windows.Forms.RichTextBox txtResults;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbxQueries;
        private System.Windows.Forms.TextBox txtQueries;
        private System.Windows.Forms.Button btnTestQueries;
        private System.Windows.Forms.Button btnNewDataSource;
        private System.Windows.Forms.Button btnNewConnection;
        private System.Windows.Forms.Button btnAddTestSuites;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTestSuites;
    }
}
