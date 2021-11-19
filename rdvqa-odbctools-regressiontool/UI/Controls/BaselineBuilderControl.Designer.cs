
namespace Rocket.RDVQA.Tools.UI.Controls
{
    partial class BaselineBuilderControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpageBaselineBuildLog = new System.Windows.Forms.TabPage();
            this.logBaselineBuild = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewTestSuites = new System.Windows.Forms.TreeView();
            this.lblTestSuites = new System.Windows.Forms.Label();
            this.txtTestCases = new System.Windows.Forms.RichTextBox();
            this.lblSQLs = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtODBCParms = new System.Windows.Forms.TextBox();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.btnBuildBaseline = new System.Windows.Forms.Button();
            this.lblConenctionParms = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkDVS32 = new System.Windows.Forms.CheckBox();
            this.chkDVM32 = new System.Windows.Forms.CheckBox();
            this.chkDVS31 = new System.Windows.Forms.CheckBox();
            this.chkDVM31 = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chkIgnoreEmbeddedConnStr = new System.Windows.Forms.CheckBox();
            this.btnBrowseBaselineDestination = new System.Windows.Forms.Button();
            this.txtBaselineDestinationPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseSQLSource = new System.Windows.Forms.Button();
            this.txtSQLSourcePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpageBaselineBuildLog.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 655);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 100);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageBaselineBuildLog);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1300, 76);
            this.tabControl1.TabIndex = 2;
            // 
            // tpageBaselineBuildLog
            // 
            this.tpageBaselineBuildLog.Controls.Add(this.logBaselineBuild);
            this.tpageBaselineBuildLog.Location = new System.Drawing.Point(4, 24);
            this.tpageBaselineBuildLog.Name = "tpageBaselineBuildLog";
            this.tpageBaselineBuildLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpageBaselineBuildLog.Size = new System.Drawing.Size(1292, 48);
            this.tpageBaselineBuildLog.TabIndex = 0;
            this.tpageBaselineBuildLog.Text = "Baseline Build Log";
            this.tpageBaselineBuildLog.UseVisualStyleBackColor = true;
            // 
            // logBaselineBuild
            // 
            this.logBaselineBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBaselineBuild.Location = new System.Drawing.Point(3, 3);
            this.logBaselineBuild.Name = "logBaselineBuild";
            this.logBaselineBuild.Size = new System.Drawing.Size(1286, 42);
            this.logBaselineBuild.TabIndex = 0;
            this.logBaselineBuild.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1292, 48);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 76);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1300, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 651);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1302, 4);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1302, 651);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(344, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(958, 651);
            this.panel4.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewTestSuites);
            this.splitContainer1.Panel1.Controls.Add(this.lblTestSuites);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTestCases);
            this.splitContainer1.Panel2.Controls.Add(this.lblSQLs);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(956, 649);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 28;
            // 
            // treeViewTestSuites
            // 
            this.treeViewTestSuites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewTestSuites.CheckBoxes = true;
            this.treeViewTestSuites.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.treeViewTestSuites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTestSuites.Location = new System.Drawing.Point(3, 18);
            this.treeViewTestSuites.Name = "treeViewTestSuites";
            this.treeViewTestSuites.Size = new System.Drawing.Size(311, 628);
            this.treeViewTestSuites.TabIndex = 1;
            this.treeViewTestSuites.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewTestSuites_AfterCheck);
            this.treeViewTestSuites.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewTestSuites_AfterSelect);
            // 
            // lblTestSuites
            // 
            this.lblTestSuites.AutoSize = true;
            this.lblTestSuites.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTestSuites.Location = new System.Drawing.Point(3, 3);
            this.lblTestSuites.Name = "lblTestSuites";
            this.lblTestSuites.Size = new System.Drawing.Size(67, 15);
            this.lblTestSuites.TabIndex = 0;
            this.lblTestSuites.Text = "Test Suites";
            // 
            // txtTestCases
            // 
            this.txtTestCases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTestCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTestCases.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTestCases.Location = new System.Drawing.Point(3, 18);
            this.txtTestCases.Name = "txtTestCases";
            this.txtTestCases.Size = new System.Drawing.Size(629, 628);
            this.txtTestCases.TabIndex = 1;
            this.txtTestCases.Text = "";
            // 
            // lblSQLs
            // 
            this.lblSQLs.AutoSize = true;
            this.lblSQLs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSQLs.Location = new System.Drawing.Point(3, 3);
            this.lblSQLs.Name = "lblSQLs";
            this.lblSQLs.Size = new System.Drawing.Size(34, 15);
            this.lblSQLs.TabIndex = 0;
            this.lblSQLs.Text = "SQLs";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(341, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 651);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(341, 651);
            this.panel3.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtODBCParms);
            this.panel7.Controls.Add(this.splitter5);
            this.panel7.Controls.Add(this.btnBuildBaseline);
            this.panel7.Controls.Add(this.lblConenctionParms);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 282);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(3);
            this.panel7.Size = new System.Drawing.Size(339, 367);
            this.panel7.TabIndex = 28;
            // 
            // txtODBCParms
            // 
            this.txtODBCParms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtODBCParms.Location = new System.Drawing.Point(3, 18);
            this.txtODBCParms.Multiline = true;
            this.txtODBCParms.Name = "txtODBCParms";
            this.txtODBCParms.Size = new System.Drawing.Size(333, 284);
            this.txtODBCParms.TabIndex = 4;
            // 
            // splitter5
            // 
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter5.Location = new System.Drawing.Point(3, 302);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(333, 24);
            this.splitter5.TabIndex = 3;
            this.splitter5.TabStop = false;
            // 
            // btnBuildBaseline
            // 
            this.btnBuildBaseline.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBuildBaseline.Location = new System.Drawing.Point(3, 326);
            this.btnBuildBaseline.Name = "btnBuildBaseline";
            this.btnBuildBaseline.Size = new System.Drawing.Size(333, 38);
            this.btnBuildBaseline.TabIndex = 2;
            this.btnBuildBaseline.Text = "Build Baselines";
            this.btnBuildBaseline.UseVisualStyleBackColor = true;
            this.btnBuildBaseline.Click += new System.EventHandler(this.BtnBuildBaseline_Click);
            // 
            // lblConenctionParms
            // 
            this.lblConenctionParms.AutoSize = true;
            this.lblConenctionParms.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConenctionParms.Location = new System.Drawing.Point(3, 3);
            this.lblConenctionParms.Margin = new System.Windows.Forms.Padding(5);
            this.lblConenctionParms.Name = "lblConenctionParms";
            this.lblConenctionParms.Size = new System.Drawing.Size(137, 15);
            this.lblConenctionParms.TabIndex = 0;
            this.lblConenctionParms.Text = "Connection Parameters";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 182);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(339, 100);
            this.panel5.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkDVS32);
            this.groupBox3.Controls.Add(this.chkDVM32);
            this.groupBox3.Controls.Add(this.chkDVS31);
            this.groupBox3.Controls.Add(this.chkDVM31);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 94);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Drivers";
            // 
            // chkDVS32
            // 
            this.chkDVS32.AutoSize = true;
            this.chkDVS32.Location = new System.Drawing.Point(143, 53);
            this.chkDVS32.Name = "chkDVS32";
            this.chkDVS32.Size = new System.Drawing.Size(109, 19);
            this.chkDVS32.TabIndex = 11;
            this.chkDVS32.Text = "DVS 3.2 Driver";
            this.chkDVS32.UseVisualStyleBackColor = true;
            // 
            // chkDVM32
            // 
            this.chkDVM32.AutoSize = true;
            this.chkDVM32.Location = new System.Drawing.Point(6, 53);
            this.chkDVM32.Name = "chkDVM32";
            this.chkDVM32.Size = new System.Drawing.Size(113, 19);
            this.chkDVM32.TabIndex = 10;
            this.chkDVM32.Text = "DVM 3.2 Driver";
            this.chkDVM32.UseVisualStyleBackColor = true;
            // 
            // chkDVS31
            // 
            this.chkDVS31.AutoSize = true;
            this.chkDVS31.Location = new System.Drawing.Point(143, 28);
            this.chkDVS31.Name = "chkDVS31";
            this.chkDVS31.Size = new System.Drawing.Size(109, 19);
            this.chkDVS31.TabIndex = 9;
            this.chkDVS31.Text = "DVS 3.1 Driver";
            this.chkDVS31.UseVisualStyleBackColor = true;
            // 
            // chkDVM31
            // 
            this.chkDVM31.AutoSize = true;
            this.chkDVM31.Location = new System.Drawing.Point(6, 28);
            this.chkDVM31.Name = "chkDVM31";
            this.chkDVM31.Size = new System.Drawing.Size(113, 19);
            this.chkDVM31.TabIndex = 8;
            this.chkDVM31.Text = "DVM 3.1 Driver";
            this.chkDVM31.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.chkIgnoreEmbeddedConnStr);
            this.panel6.Controls.Add(this.btnBrowseBaselineDestination);
            this.panel6.Controls.Add(this.txtBaselineDestinationPath);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.btnBrowseSQLSource);
            this.panel6.Controls.Add(this.txtSQLSourcePath);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(339, 182);
            this.panel6.TabIndex = 26;
            // 
            // chkIgnoreEmbeddedConnStr
            // 
            this.chkIgnoreEmbeddedConnStr.AutoSize = true;
            this.chkIgnoreEmbeddedConnStr.Checked = true;
            this.chkIgnoreEmbeddedConnStr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreEmbeddedConnStr.Location = new System.Drawing.Point(9, 139);
            this.chkIgnoreEmbeddedConnStr.Name = "chkIgnoreEmbeddedConnStr";
            this.chkIgnoreEmbeddedConnStr.Size = new System.Drawing.Size(241, 19);
            this.chkIgnoreEmbeddedConnStr.TabIndex = 21;
            this.chkIgnoreEmbeddedConnStr.Text = "Ignore Embedded Connection String(s)";
            this.chkIgnoreEmbeddedConnStr.UseVisualStyleBackColor = true;
            // 
            // btnBrowseBaselineDestination
            // 
            this.btnBrowseBaselineDestination.Location = new System.Drawing.Point(303, 87);
            this.btnBrowseBaselineDestination.Name = "btnBrowseBaselineDestination";
            this.btnBrowseBaselineDestination.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseBaselineDestination.TabIndex = 20;
            this.btnBrowseBaselineDestination.Text = "...";
            this.btnBrowseBaselineDestination.UseVisualStyleBackColor = true;
            this.btnBrowseBaselineDestination.Click += new System.EventHandler(this.BtnBrowseBaselineDestination_Click);
            // 
            // txtBaselineDestinationPath
            // 
            this.txtBaselineDestinationPath.Location = new System.Drawing.Point(5, 88);
            this.txtBaselineDestinationPath.Name = "txtBaselineDestinationPath";
            this.txtBaselineDestinationPath.Size = new System.Drawing.Size(292, 23);
            this.txtBaselineDestinationPath.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Baseline Destination Path";
            // 
            // btnBrowseSQLSource
            // 
            this.btnBrowseSQLSource.Location = new System.Drawing.Point(303, 36);
            this.btnBrowseSQLSource.Name = "btnBrowseSQLSource";
            this.btnBrowseSQLSource.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseSQLSource.TabIndex = 17;
            this.btnBrowseSQLSource.Text = "...";
            this.btnBrowseSQLSource.UseVisualStyleBackColor = true;
            this.btnBrowseSQLSource.Click += new System.EventHandler(this.BtnBrowseSQLSource_Click);
            // 
            // txtSQLSourcePath
            // 
            this.txtSQLSourcePath.Location = new System.Drawing.Point(5, 37);
            this.txtSQLSourcePath.Name = "txtSQLSourcePath";
            this.txtSQLSourcePath.Size = new System.Drawing.Size(292, 23);
            this.txtSQLSourcePath.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "SQL Source Path";
            // 
            // BaselineBuilderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "BaselineBuilderControl";
            this.Size = new System.Drawing.Size(1302, 755);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpageBaselineBuildLog.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnBrowseBaselineDestination;
        private System.Windows.Forms.TextBox txtBaselineDestinationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseSQLSource;
        private System.Windows.Forms.TextBox txtSQLSourcePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkDVS32;
        private System.Windows.Forms.CheckBox chkDVM32;
        private System.Windows.Forms.CheckBox chkDVS31;
        private System.Windows.Forms.CheckBox chkDVM31;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtODBCParms;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.Button btnBuildBaseline;
        private System.Windows.Forms.Label lblConenctionParms;
        private System.Windows.Forms.TreeView treeViewTestSuites;
        private System.Windows.Forms.Label lblTestSuites;
        private System.Windows.Forms.RichTextBox txtTestCases;
        private System.Windows.Forms.Label lblSQLs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpageBaselineBuildLog;
        private System.Windows.Forms.RichTextBox logBaselineBuild;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox chkIgnoreEmbeddedConnStr;
    }
}
