namespace DVLDProject
{
    partial class FormReplacementForDamageLicense
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbRemplacement = new System.Windows.Forms.GroupBox();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbDamage = new System.Windows.Forms.RadioButton();
            this.gbApplication = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblRemplaceLicenseID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.linkLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.LinkNewLicense = new System.Windows.Forms.LinkLabel();
            this.ctrlDriverLicenseInfo1 = new DVLDProject.ctrlDriverLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.gbRemplacement.SuspendLayout();
            this.gbApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.textBox1);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Location = new System.Drawing.Point(26, 173);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(578, 129);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(480, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 63);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(161, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "LicenseID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(113, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Replacement For Damage License";
            // 
            // gbRemplacement
            // 
            this.gbRemplacement.Controls.Add(this.rbLost);
            this.gbRemplacement.Controls.Add(this.rbDamage);
            this.gbRemplacement.Location = new System.Drawing.Point(664, 173);
            this.gbRemplacement.Name = "gbRemplacement";
            this.gbRemplacement.Size = new System.Drawing.Size(235, 129);
            this.gbRemplacement.TabIndex = 2;
            this.gbRemplacement.TabStop = false;
            this.gbRemplacement.Text = "Rempalcement For:";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Location = new System.Drawing.Point(19, 84);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(124, 24);
            this.rbLost.TabIndex = 1;
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbDamage
            // 
            this.rbDamage.AutoSize = true;
            this.rbDamage.Location = new System.Drawing.Point(19, 41);
            this.rbDamage.Name = "rbDamage";
            this.rbDamage.Size = new System.Drawing.Size(163, 24);
            this.rbDamage.TabIndex = 0;
            this.rbDamage.Text = "Damaged License";
            this.rbDamage.UseVisualStyleBackColor = true;
            this.rbDamage.CheckedChanged += new System.EventHandler(this.rbDamage_CheckedChanged);
            // 
            // gbApplication
            // 
            this.gbApplication.Controls.Add(this.lblCreatedBy);
            this.gbApplication.Controls.Add(this.lblOldLicenseID);
            this.gbApplication.Controls.Add(this.lblRemplaceLicenseID);
            this.gbApplication.Controls.Add(this.label9);
            this.gbApplication.Controls.Add(this.label10);
            this.gbApplication.Controls.Add(this.label11);
            this.gbApplication.Controls.Add(this.lblAppFees);
            this.gbApplication.Controls.Add(this.lblAppDate);
            this.gbApplication.Controls.Add(this.lblAppID);
            this.gbApplication.Controls.Add(this.label5);
            this.gbApplication.Controls.Add(this.label4);
            this.gbApplication.Controls.Add(this.label3);
            this.gbApplication.Location = new System.Drawing.Point(12, 761);
            this.gbApplication.Name = "gbApplication";
            this.gbApplication.Size = new System.Drawing.Size(981, 197);
            this.gbApplication.TabIndex = 4;
            this.gbApplication.TabStop = false;
            this.gbApplication.Text = "Application Info:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(759, 145);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(36, 20);
            this.lblCreatedBy.TabIndex = 11;
            this.lblCreatedBy.Text = "???";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(759, 96);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(36, 20);
            this.lblOldLicenseID.TabIndex = 10;
            this.lblOldLicenseID.Text = "???";
            // 
            // lblRemplaceLicenseID
            // 
            this.lblRemplaceLicenseID.AutoSize = true;
            this.lblRemplaceLicenseID.Location = new System.Drawing.Point(759, 46);
            this.lblRemplaceLicenseID.Name = "lblRemplaceLicenseID";
            this.lblRemplaceLicenseID.Size = new System.Drawing.Size(36, 20);
            this.lblRemplaceLicenseID.TabIndex = 9;
            this.lblRemplaceLicenseID.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(543, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Created By:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(543, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Old License ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(543, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(174, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Remplaced License ID:";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Location = new System.Drawing.Point(199, 145);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(36, 20);
            this.lblAppFees.TabIndex = 5;
            this.lblAppFees.Text = "???";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Location = new System.Drawing.Point(199, 96);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(36, 20);
            this.lblAppDate.TabIndex = 4;
            this.lblAppDate.Text = "???";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Location = new System.Drawing.Point(199, 46);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(36, 20);
            this.lblAppID.TabIndex = 3;
            this.lblAppID.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Application Fees:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Application Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "L.R.Application ID:";
            // 
            // btnIssue
            // 
            this.btnIssue.Enabled = false;
            this.btnIssue.Location = new System.Drawing.Point(830, 977);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(183, 61);
            this.btnIssue.TabIndex = 5;
            this.btnIssue.Text = "Issue Remplacement";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(654, 977);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 61);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // linkLicenseHistory
            // 
            this.linkLicenseHistory.AutoSize = true;
            this.linkLicenseHistory.Location = new System.Drawing.Point(65, 993);
            this.linkLicenseHistory.Name = "linkLicenseHistory";
            this.linkLicenseHistory.Size = new System.Drawing.Size(161, 20);
            this.linkLicenseHistory.TabIndex = 7;
            this.linkLicenseHistory.TabStop = true;
            this.linkLicenseHistory.Text = "Show License History";
            this.linkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseHistory_LinkClicked);
            // 
            // LinkNewLicense
            // 
            this.LinkNewLicense.AutoSize = true;
            this.LinkNewLicense.Enabled = false;
            this.LinkNewLicense.Location = new System.Drawing.Point(268, 993);
            this.LinkNewLicense.Name = "LinkNewLicense";
            this.LinkNewLicense.Size = new System.Drawing.Size(175, 20);
            this.LinkNewLicense.TabIndex = 8;
            this.LinkNewLicense.TabStop = true;
            this.LinkNewLicense.Text = "Show New License Info";
            this.LinkNewLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkNewLicense_LinkClicked);
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID = 0;
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(12, 308);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(1001, 447);
            this.ctrlDriverLicenseInfo1.TabIndex = 3;
            // 
            // FormReplacementForDamageLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1047, 1050);
            this.Controls.Add(this.LinkNewLicense);
            this.Controls.Add(this.linkLicenseHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.gbApplication);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.gbRemplacement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbFilter);
            this.Name = "FormReplacementForDamageLicense";
            this.Text = "FormReplacementForDamageLicense";
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.gbRemplacement.ResumeLayout(false);
            this.gbRemplacement.PerformLayout();
            this.gbApplication.ResumeLayout(false);
            this.gbApplication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbRemplacement;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamage;
        private ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private System.Windows.Forms.GroupBox gbApplication;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblRemplaceLicenseID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblAppID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel linkLicenseHistory;
        private System.Windows.Forms.LinkLabel LinkNewLicense;
    }
}