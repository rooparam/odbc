
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrosweDest = new System.Windows.Forms.Button();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtBaselineDest = new System.Windows.Forms.TextBox();
            this.txtSQLSource = new System.Windows.Forms.TextBox();
            this.btnBuildBaseline = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "SQL Input Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Baseline Output Directory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "ODBC Connection String";
            // 
            // btnBrosweDest
            // 
            this.btnBrosweDest.Location = new System.Drawing.Point(736, 56);
            this.btnBrosweDest.Name = "btnBrosweDest";
            this.btnBrosweDest.Size = new System.Drawing.Size(30, 23);
            this.btnBrosweDest.TabIndex = 14;
            this.btnBrosweDest.Text = "...";
            this.btnBrosweDest.UseVisualStyleBackColor = true;
            this.btnBrosweDest.Click += new System.EventHandler(this.btnBrosweDest_Click);
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(736, 21);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseSource.TabIndex = 15;
            this.btnBrowseSource.Text = "...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtBaselineDest
            // 
            this.txtBaselineDest.Location = new System.Drawing.Point(180, 56);
            this.txtBaselineDest.Name = "txtBaselineDest";
            this.txtBaselineDest.Size = new System.Drawing.Size(550, 23);
            this.txtBaselineDest.TabIndex = 12;
            // 
            // txtSQLSource
            // 
            this.txtSQLSource.Location = new System.Drawing.Point(180, 21);
            this.txtSQLSource.Name = "txtSQLSource";
            this.txtSQLSource.Size = new System.Drawing.Size(550, 23);
            this.txtSQLSource.TabIndex = 13;
            this.txtSQLSource.Tag = "Source Path";
            // 
            // btnBuildBaseline
            // 
            this.btnBuildBaseline.Location = new System.Drawing.Point(555, 212);
            this.btnBuildBaseline.Name = "btnBuildBaseline";
            this.btnBuildBaseline.Size = new System.Drawing.Size(175, 39);
            this.btnBuildBaseline.TabIndex = 20;
            this.btnBuildBaseline.Text = "Build Baseline";
            this.btnBuildBaseline.UseVisualStyleBackColor = true;
            this.btnBuildBaseline.Click += new System.EventHandler(this.btnBuildBaseline_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(351, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 39);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(180, 92);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConnectionString.Size = new System.Drawing.Size(550, 103);
            this.txtConnectionString.TabIndex = 22;
            // 
            // BaselineBuilderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuildBaseline);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrosweDest);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.txtBaselineDest);
            this.Controls.Add(this.txtSQLSource);
            this.Name = "BaselineBuilderControl";
            this.Size = new System.Drawing.Size(788, 270);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrosweDest;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtBaselineDest;
        private System.Windows.Forms.TextBox txtSQLSource;
        private System.Windows.Forms.Button btnBuildBaseline;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}
