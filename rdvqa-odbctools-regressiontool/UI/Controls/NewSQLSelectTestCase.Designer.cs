
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTestQueries = new System.Windows.Forms.Button();
            this.txtQueries = new System.Windows.Forms.TextBox();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDatasources = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbConnections = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlControlPanel = new System.Windows.Forms.Panel();
            this.btnAddTCs = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.pnlControlPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(866, 662);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 314);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.16949F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.83051F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 295);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLog.Location = new System.Drawing.Point(18, 33);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(824, 259);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(18, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(824, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Query Execution Log";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(3, 311);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(860, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTestQueries);
            this.panel3.Controls.Add(this.txtQueries);
            this.panel3.Controls.Add(this.txtTags);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cmbDatasources);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cmbConnections);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(860, 308);
            this.panel3.TabIndex = 3;
            // 
            // btnTestQueries
            // 
            this.btnTestQueries.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTestQueries.Location = new System.Drawing.Point(85, 260);
            this.btnTestQueries.Name = "btnTestQueries";
            this.btnTestQueries.Size = new System.Drawing.Size(757, 33);
            this.btnTestQueries.TabIndex = 13;
            this.btnTestQueries.Text = "Test Query(s)";
            this.btnTestQueries.UseVisualStyleBackColor = true;
            this.btnTestQueries.Click += new System.EventHandler(this.btnTestQueries_Click);
            // 
            // txtQueries
            // 
            this.txtQueries.Location = new System.Drawing.Point(85, 94);
            this.txtQueries.Multiline = true;
            this.txtQueries.Name = "txtQueries";
            this.txtQueries.Size = new System.Drawing.Size(757, 154);
            this.txtQueries.TabIndex = 12;
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(85, 45);
            this.txtTags.Multiline = true;
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(757, 37);
            this.txtTags.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tags";
            // 
            // cmbDatasources
            // 
            this.cmbDatasources.FormattingEnabled = true;
            this.cmbDatasources.Location = new System.Drawing.Point(522, 12);
            this.cmbDatasources.Name = "cmbDatasources";
            this.cmbDatasources.Size = new System.Drawing.Size(320, 23);
            this.cmbDatasources.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Datasource";
            // 
            // cmbConnections
            // 
            this.cmbConnections.FormattingEnabled = true;
            this.cmbConnections.Location = new System.Drawing.Point(85, 12);
            this.cmbConnections.Name = "cmbConnections";
            this.cmbConnections.Size = new System.Drawing.Size(320, 23);
            this.cmbConnections.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Connection";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 609);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(860, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pnlControlPanel
            // 
            this.pnlControlPanel.Controls.Add(this.btnAddTCs);
            this.pnlControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControlPanel.Location = new System.Drawing.Point(3, 612);
            this.pnlControlPanel.Name = "pnlControlPanel";
            this.pnlControlPanel.Size = new System.Drawing.Size(860, 47);
            this.pnlControlPanel.TabIndex = 0;
            // 
            // btnAddTCs
            // 
            this.btnAddTCs.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddTCs.Location = new System.Drawing.Point(435, 6);
            this.btnAddTCs.Name = "btnAddTCs";
            this.btnAddTCs.Size = new System.Drawing.Size(407, 33);
            this.btnAddTCs.TabIndex = 14;
            this.btnAddTCs.Text = "Add Test Cases";
            this.btnAddTCs.UseVisualStyleBackColor = true;
            this.btnAddTCs.Click += new System.EventHandler(this.btnAddTCs_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(40, 28);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(69, 15);
            this.lblConnection.TabIndex = 0;
            this.lblConnection.Text = "Connection";
            // 
            // NewSQLSelectTestCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "NewSQLSelectTestCase";
            this.Size = new System.Drawing.Size(866, 662);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlControlPanel;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTestQueries;
        private System.Windows.Forms.TextBox txtQueries;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDatasources;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbConnections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button btnAddTCs;
    }
}
