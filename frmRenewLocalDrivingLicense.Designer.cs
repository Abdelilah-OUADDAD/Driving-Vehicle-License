namespace DVLDProject
{
    partial class frmRenewLocalDrivingLicense
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
            this.gbApplication = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblExpirationDATE = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lbRLlAppID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.LinkNewLicense = new System.Windows.Forms.LinkLabel();
            this.linkLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.ctrlDriverLicenseInfo1 = new DVLDProject.ctrlDriverLicenseInfo();
            this.gbFilter.SuspendLayout();
            this.gbApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnSearch);
            this.gbFilter.Controls.Add(this.textBox1);
            this.gbFilter.Controls.Add(this.label2);
            this.gbFilter.Location = new System.Drawing.Point(12, 100);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(578, 88);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(479, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 63);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(164, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "LicenseID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(166, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Renew License Application";
            // 
            // gbApplication
            // 
            this.gbApplication.Controls.Add(this.txtNotes);
            this.gbApplication.Controls.Add(this.lblNotes);
            this.gbApplication.Controls.Add(this.lblTotalFees);
            this.gbApplication.Controls.Add(this.label16);
            this.gbApplication.Controls.Add(this.lblCreatedBy);
            this.gbApplication.Controls.Add(this.label14);
            this.gbApplication.Controls.Add(this.lblLicenseFees);
            this.gbApplication.Controls.Add(this.lblAppFees);
            this.gbApplication.Controls.Add(this.label8);
            this.gbApplication.Controls.Add(this.label12);
            this.gbApplication.Controls.Add(this.lblExpirationDATE);
            this.gbApplication.Controls.Add(this.lblOldLicenseID);
            this.gbApplication.Controls.Add(this.lblRenewedLicenseID);
            this.gbApplication.Controls.Add(this.label9);
            this.gbApplication.Controls.Add(this.label10);
            this.gbApplication.Controls.Add(this.label11);
            this.gbApplication.Controls.Add(this.lblIssueDate);
            this.gbApplication.Controls.Add(this.lblAppDate);
            this.gbApplication.Controls.Add(this.lbRLlAppID);
            this.gbApplication.Controls.Add(this.label5);
            this.gbApplication.Controls.Add(this.label4);
            this.gbApplication.Controls.Add(this.label3);
            this.gbApplication.Location = new System.Drawing.Point(12, 636);
            this.gbApplication.Name = "gbApplication";
            this.gbApplication.Size = new System.Drawing.Size(981, 344);
            this.gbApplication.TabIndex = 5;
            this.gbApplication.TabStop = false;
            this.gbApplication.Text = "Application New License Info:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(195, 224);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(607, 99);
            this.txtNotes.TabIndex = 21;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 224);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(51, 20);
            this.lblNotes.TabIndex = 20;
            this.lblNotes.Text = "Notes";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(759, 181);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(36, 20);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.Text = "???";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(543, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 20);
            this.label16.TabIndex = 18;
            this.label16.Text = "Total Fees:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(759, 145);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(36, 20);
            this.lblCreatedBy.TabIndex = 17;
            this.lblCreatedBy.Text = "???";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(543, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 20);
            this.label14.TabIndex = 16;
            this.label14.Text = "Created By:";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Location = new System.Drawing.Point(191, 181);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(36, 20);
            this.lblLicenseFees.TabIndex = 15;
            this.lblLicenseFees.Text = "???";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Location = new System.Drawing.Point(192, 145);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(36, 20);
            this.lblAppFees.TabIndex = 14;
            this.lblAppFees.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "License Fees:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Application Fees:";
            // 
            // lblExpirationDATE
            // 
            this.lblExpirationDATE.AutoSize = true;
            this.lblExpirationDATE.Location = new System.Drawing.Point(759, 115);
            this.lblExpirationDATE.Name = "lblExpirationDATE";
            this.lblExpirationDATE.Size = new System.Drawing.Size(36, 20);
            this.lblExpirationDATE.TabIndex = 11;
            this.lblExpirationDATE.Text = "???";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Location = new System.Drawing.Point(759, 79);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(36, 20);
            this.lblOldLicenseID.TabIndex = 10;
            this.lblOldLicenseID.Text = "???";
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.AutoSize = true;
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(759, 38);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(36, 20);
            this.lblRenewedLicenseID.TabIndex = 9;
            this.lblRenewedLicenseID.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(543, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Expiration Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(543, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Old License ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(543, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Renewed License ID:";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(191, 115);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(36, 20);
            this.lblIssueDate.TabIndex = 5;
            this.lblIssueDate.Text = "???";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Location = new System.Drawing.Point(192, 79);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(36, 20);
            this.lblAppDate.TabIndex = 4;
            this.lblAppDate.Text = "???";
            // 
            // lbRLlAppID
            // 
            this.lbRLlAppID.AutoSize = true;
            this.lbRLlAppID.Location = new System.Drawing.Point(191, 38);
            this.lbRLlAppID.Name = "lbRLlAppID";
            this.lbRLlAppID.Size = new System.Drawing.Size(36, 20);
            this.lbRLlAppID.TabIndex = 3;
            this.lbRLlAppID.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Issue Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Application Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "R.L.Application ID:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(738, 986);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 43);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.Location = new System.Drawing.Point(887, 986);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(107, 43);
            this.btnRenew.TabIndex = 7;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // LinkNewLicense
            // 
            this.LinkNewLicense.AutoSize = true;
            this.LinkNewLicense.Enabled = false;
            this.LinkNewLicense.Location = new System.Drawing.Point(262, 1009);
            this.LinkNewLicense.Name = "LinkNewLicense";
            this.LinkNewLicense.Size = new System.Drawing.Size(175, 20);
            this.LinkNewLicense.TabIndex = 15;
            this.LinkNewLicense.TabStop = true;
            this.LinkNewLicense.Text = "Show New License Info";
            this.LinkNewLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkNewLicense_LinkClicked);
            // 
            // linkLicenseHistory
            // 
            this.linkLicenseHistory.AutoSize = true;
            this.linkLicenseHistory.Location = new System.Drawing.Point(59, 1009);
            this.linkLicenseHistory.Name = "linkLicenseHistory";
            this.linkLicenseHistory.Size = new System.Drawing.Size(161, 20);
            this.linkLicenseHistory.TabIndex = 14;
            this.linkLicenseHistory.TabStop = true;
            this.linkLicenseHistory.Text = "Show License History";
            this.linkLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenseHistory_LinkClicked);
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.LicenseID = 0;
            this.ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID = 0;
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(12, 194);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(1001, 436);
            this.ctrlDriverLicenseInfo1.TabIndex = 3;
            // 
            // frmRenewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1003, 1050);
            this.Controls.Add(this.LinkNewLicense);
            this.Controls.Add(this.linkLicenseHistory);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbApplication);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbFilter);
            this.Name = "frmRenewLocalDrivingLicense";
            this.Text = "frmRenewLocalDrivingLicense";
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
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
        private ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private System.Windows.Forms.GroupBox gbApplication;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblExpirationDATE;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lbRLlAppID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.LinkLabel LinkNewLicense;
        private System.Windows.Forms.LinkLabel linkLicenseHistory;
    }
}