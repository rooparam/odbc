
namespace Rocket.RDVQA.Tools.UI.Forms
{
    partial class NewConnection
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
            this.btnAddConnection = new System.Windows.Forms.Button();
            this.btnBrowseKS = new System.Windows.Forms.Button();
            this.btnBrowseTS = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.txtKeyStore = new System.Windows.Forms.TextBox();
            this.txtTrustStore = new System.Windows.Forms.TextBox();
            this.txtConnectionName = new System.Windows.Forms.TextBox();
            this.chkKeyStore = new System.Windows.Forms.CheckBox();
            this.chkTrustStore = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddConnection);
            this.panel1.Controls.Add(this.btnBrowseKS);
            this.panel1.Controls.Add(this.btnBrowseTS);
            this.panel1.Controls.Add(this.txtConnectionString);
            this.panel1.Controls.Add(this.txtKeyStore);
            this.panel1.Controls.Add(this.txtTrustStore);
            this.panel1.Controls.Add(this.txtConnectionName);
            this.panel1.Controls.Add(this.chkKeyStore);
            this.panel1.Controls.Add(this.chkTrustStore);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(630, 345);
            this.panel1.TabIndex = 0;
            // 
            // btnAddConnection
            // 
            this.btnAddConnection.Location = new System.Drawing.Point(138, 296);
            this.btnAddConnection.Name = "btnAddConnection";
            this.btnAddConnection.Size = new System.Drawing.Size(470, 34);
            this.btnAddConnection.TabIndex = 4;
            this.btnAddConnection.Text = "Add Connection";
            this.btnAddConnection.UseVisualStyleBackColor = true;
            this.btnAddConnection.Click += new System.EventHandler(this.btnAddConnection_Click);
            // 
            // btnBrowseKS
            // 
            this.btnBrowseKS.Enabled = false;
            this.btnBrowseKS.Font = new System.Drawing.Font("Wingdings 3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBrowseKS.Location = new System.Drawing.Point(569, 250);
            this.btnBrowseKS.Name = "btnBrowseKS";
            this.btnBrowseKS.Size = new System.Drawing.Size(40, 24);
            this.btnBrowseKS.TabIndex = 3;
            this.btnBrowseKS.Text = "Æ";
            this.btnBrowseKS.UseVisualStyleBackColor = true;
            // 
            // btnBrowseTS
            // 
            this.btnBrowseTS.Enabled = false;
            this.btnBrowseTS.Font = new System.Drawing.Font("Wingdings 3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBrowseTS.Location = new System.Drawing.Point(569, 212);
            this.btnBrowseTS.Name = "btnBrowseTS";
            this.btnBrowseTS.Size = new System.Drawing.Size(40, 24);
            this.btnBrowseTS.TabIndex = 3;
            this.btnBrowseTS.Text = "Æ";
            this.btnBrowseTS.UseVisualStyleBackColor = true;
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(138, 56);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConnectionString.Size = new System.Drawing.Size(471, 142);
            this.txtConnectionString.TabIndex = 2;
            // 
            // txtKeyStore
            // 
            this.txtKeyStore.Enabled = false;
            this.txtKeyStore.Location = new System.Drawing.Point(138, 251);
            this.txtKeyStore.Name = "txtKeyStore";
            this.txtKeyStore.Size = new System.Drawing.Size(426, 23);
            this.txtKeyStore.TabIndex = 2;
            // 
            // txtTrustStore
            // 
            this.txtTrustStore.Enabled = false;
            this.txtTrustStore.Location = new System.Drawing.Point(138, 213);
            this.txtTrustStore.Name = "txtTrustStore";
            this.txtTrustStore.Size = new System.Drawing.Size(426, 23);
            this.txtTrustStore.TabIndex = 2;
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Location = new System.Drawing.Point(138, 21);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(471, 23);
            this.txtConnectionName.TabIndex = 2;
            // 
            // chkKeyStore
            // 
            this.chkKeyStore.AutoSize = true;
            this.chkKeyStore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkKeyStore.Location = new System.Drawing.Point(42, 253);
            this.chkKeyStore.Name = "chkKeyStore";
            this.chkKeyStore.Size = new System.Drawing.Size(76, 19);
            this.chkKeyStore.TabIndex = 1;
            this.chkKeyStore.Text = "Key Store";
            this.chkKeyStore.UseVisualStyleBackColor = true;
            this.chkKeyStore.CheckedChanged += new System.EventHandler(this.chkKeyStore_CheckedChanged);
            // 
            // chkTrustStore
            // 
            this.chkTrustStore.AutoSize = true;
            this.chkTrustStore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkTrustStore.Location = new System.Drawing.Point(42, 215);
            this.chkTrustStore.Name = "chkTrustStore";
            this.chkTrustStore.Size = new System.Drawing.Size(83, 19);
            this.chkTrustStore.TabIndex = 1;
            this.chkTrustStore.Text = "Trust Store";
            this.chkTrustStore.UseVisualStyleBackColor = true;
            this.chkTrustStore.CheckedChanged += new System.EventHandler(this.chkTrustStore_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Connection String";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // NewConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 365);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(666, 404);
            this.MinimizeBox = false;
            this.Name = "NewConnection";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "New Connection";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddConnection;
        private System.Windows.Forms.Button btnBrowseKS;
        private System.Windows.Forms.Button btnBrowseTS;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.TextBox txtKeyStore;
        private System.Windows.Forms.TextBox txtTrustStore;
        private System.Windows.Forms.TextBox txtConnectionName;
        private System.Windows.Forms.CheckBox chkKeyStore;
        private System.Windows.Forms.CheckBox chkTrustStore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}