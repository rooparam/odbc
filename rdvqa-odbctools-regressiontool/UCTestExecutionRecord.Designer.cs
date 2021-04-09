
namespace rdvqa_odbctools_regressiontool
{
    partial class UCTestExecutionRecord
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
            this.MainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lblComments = new System.Windows.Forms.Label();
            this.lblTestCaseID = new System.Windows.Forms.Label();
            this.btnMoreInfo = new System.Windows.Forms.Button();
            this.MainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContainer
            // 
            this.MainContainer.ColumnCount = 3;
            this.MainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MainContainer.Controls.Add(this.lblComments, 0, 0);
            this.MainContainer.Controls.Add(this.lblTestCaseID, 0, 0);
            this.MainContainer.Controls.Add(this.btnMoreInfo, 2, 0);
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(0, 0);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.RowCount = 1;
            this.MainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainContainer.Size = new System.Drawing.Size(78, 28);
            this.MainContainer.TabIndex = 0;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblComments.Location = new System.Drawing.Point(18, 0);
            this.lblComments.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(48, 25);
            this.lblComments.TabIndex = 1;
            this.lblComments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTestCaseID
            // 
            this.lblTestCaseID.AutoSize = true;
            this.lblTestCaseID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTestCaseID.Location = new System.Drawing.Point(3, 0);
            this.lblTestCaseID.Name = "lblTestCaseID";
            this.lblTestCaseID.Size = new System.Drawing.Size(9, 28);
            this.lblTestCaseID.TabIndex = 0;
            this.lblTestCaseID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMoreInfo
            // 
            this.btnMoreInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoreInfo.Location = new System.Drawing.Point(72, 3);
            this.btnMoreInfo.Name = "btnMoreInfo";
            this.btnMoreInfo.Size = new System.Drawing.Size(3, 22);
            this.btnMoreInfo.TabIndex = 2;
            this.btnMoreInfo.UseVisualStyleBackColor = true;
            // 
            // UCTestExecutionRecord
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.MainContainer);
            this.MinimumSize = new System.Drawing.Size(80, 30);
            this.Name = "UCTestExecutionRecord";
            this.Size = new System.Drawing.Size(78, 28);
            this.MainContainer.ResumeLayout(false);
            this.MainContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainContainer;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Label lblTestCaseID;
        private System.Windows.Forms.Button btnMoreInfo;
    }
}
