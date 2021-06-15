
namespace Rocket.RDVQA.Tools.UI.Forms
{
    partial class NewTestSuite
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTestSuiteName = new System.Windows.Forms.TextBox();
            this.btnAddTestSuite = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddTestSuite);
            this.panel1.Controls.Add(this.txtTestSuiteName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(329, 105);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test Suite Name";
            // 
            // txtTestSuiteName
            // 
            this.txtTestSuiteName.Location = new System.Drawing.Point(4, 25);
            this.txtTestSuiteName.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtTestSuiteName.Name = "txtTestSuiteName";
            this.txtTestSuiteName.Size = new System.Drawing.Size(318, 35);
            this.txtTestSuiteName.TabIndex = 1;
            // 
            // btnAddTestSuite
            // 
            this.btnAddTestSuite.Location = new System.Drawing.Point(4, 70);
            this.btnAddTestSuite.Name = "btnAddTestSuite";
            this.btnAddTestSuite.Size = new System.Drawing.Size(318, 31);
            this.btnAddTestSuite.TabIndex = 2;
            this.btnAddTestSuite.Text = "Add Test Suite";
            this.btnAddTestSuite.UseVisualStyleBackColor = true;
            // 
            // NewTestSuite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 125);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTestSuite";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "New Test Suite";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddTestSuite;
        private System.Windows.Forms.TextBox txtTestSuiteName;
        private System.Windows.Forms.Label label1;
    }
}