namespace DVLDProject
{
    partial class frmInternationalLicenseInfo
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
            this.ctrlDriverInterLicenseInfo1 = new DVLDProject.ctrlDriverInterLicenseInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDriverInterLicenseInfo1
            // 
            this.ctrlDriverInterLicenseInfo1.ApplicationID = 0;
            this.ctrlDriverInterLicenseInfo1.InterLicenseID = 0;
            this.ctrlDriverInterLicenseInfo1.LicenseID = 0;
            this.ctrlDriverInterLicenseInfo1.Location = new System.Drawing.Point(12, 114);
            this.ctrlDriverInterLicenseInfo1.Name = "ctrlDriverInterLicenseInfo1";
            this.ctrlDriverInterLicenseInfo1.Size = new System.Drawing.Size(1010, 454);
            this.ctrlDriverInterLicenseInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(175, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(637, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driver International License Info";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(817, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 49);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 666);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDriverInterLicenseInfo1);
            this.Name = "frmInternationalLicenseInfo";
            this.Text = "frmInternationalLicenseInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlDriverInterLicenseInfo ctrlDriverInterLicenseInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}