namespace PDVLD.Applications.DrivingLicensesServices
{
    partial class FormLicenseHistory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLicenseHistory));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewLocal = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicens = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLocalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsLocal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewInter = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInternationalLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsInter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlShowCardWithFilter1 = new PDVLD.People.Controle.ctrlShowCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocal)).BeginInit();
            this.cmsLocalLicens.SuspendLayout();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInter)).BeginInit();
            this.cmsInternationalLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(337, 426);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(27, 640);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1398, 337);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver License";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpLocal);
            this.tabControl1.Controls.Add(this.tpInternational);
            this.tabControl1.Location = new System.Drawing.Point(24, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1368, 306);
            this.tabControl1.TabIndex = 0;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.label3);
            this.tpLocal.Controls.Add(this.dataGridViewLocal);
            this.tpLocal.Controls.Add(this.lblRecordsLocal);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Location = new System.Drawing.Point(4, 29);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1360, 273);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Local License History:";
            // 
            // dataGridViewLocal
            // 
            this.dataGridViewLocal.AllowUserToAddRows = false;
            this.dataGridViewLocal.AllowUserToDeleteRows = false;
            this.dataGridViewLocal.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocal.ContextMenuStrip = this.cmsLocalLicens;
            this.dataGridViewLocal.Location = new System.Drawing.Point(17, 42);
            this.dataGridViewLocal.Name = "dataGridViewLocal";
            this.dataGridViewLocal.ReadOnly = true;
            this.dataGridViewLocal.RowHeadersWidth = 62;
            this.dataGridViewLocal.RowTemplate.Height = 28;
            this.dataGridViewLocal.Size = new System.Drawing.Size(1324, 187);
            this.dataGridViewLocal.TabIndex = 3;
            // 
            // cmsLocalLicens
            // 
            this.cmsLocalLicens.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsLocalLicens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLocalLicenseToolStripMenuItem});
            this.cmsLocalLicens.Name = "cmsLocalLicens";
            this.cmsLocalLicens.Size = new System.Drawing.Size(288, 44);
            // 
            // showLocalLicenseToolStripMenuItem
            // 
            this.showLocalLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLocalLicenseToolStripMenuItem.Image")));
            this.showLocalLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLocalLicenseToolStripMenuItem.Name = "showLocalLicenseToolStripMenuItem";
            this.showLocalLicenseToolStripMenuItem.Size = new System.Drawing.Size(287, 40);
            this.showLocalLicenseToolStripMenuItem.Text = "Show Local License Info";
            this.showLocalLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLocalLicenseToolStripMenuItem_Click);
            // 
            // lblRecordsLocal
            // 
            this.lblRecordsLocal.AutoSize = true;
            this.lblRecordsLocal.Location = new System.Drawing.Point(127, 241);
            this.lblRecordsLocal.Name = "lblRecordsLocal";
            this.lblRecordsLocal.Size = new System.Drawing.Size(18, 20);
            this.lblRecordsLocal.TabIndex = 2;
            this.lblRecordsLocal.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "#Records:";
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.label2);
            this.tpInternational.Controls.Add(this.dataGridViewInter);
            this.tpInternational.Controls.Add(this.lblRecordsInter);
            this.tpInternational.Controls.Add(this.label5);
            this.tpInternational.Location = new System.Drawing.Point(4, 29);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(1360, 273);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "International License History:";
            // 
            // dataGridViewInter
            // 
            this.dataGridViewInter.AllowUserToAddRows = false;
            this.dataGridViewInter.AllowUserToDeleteRows = false;
            this.dataGridViewInter.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewInter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInter.ContextMenuStrip = this.cmsInternationalLicense;
            this.dataGridViewInter.Location = new System.Drawing.Point(20, 42);
            this.dataGridViewInter.Name = "dataGridViewInter";
            this.dataGridViewInter.ReadOnly = true;
            this.dataGridViewInter.RowHeadersWidth = 62;
            this.dataGridViewInter.RowTemplate.Height = 28;
            this.dataGridViewInter.Size = new System.Drawing.Size(1324, 187);
            this.dataGridViewInter.TabIndex = 7;
            // 
            // cmsInternationalLicense
            // 
            this.cmsInternationalLicense.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInternationalLicenseInfoToolStripMenuItem});
            this.cmsInternationalLicense.Name = "cmsInternationalLicense";
            this.cmsInternationalLicense.Size = new System.Drawing.Size(347, 44);
            // 
            // showInternationalLicenseInfoToolStripMenuItem
            // 
            this.showInternationalLicenseInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showInternationalLicenseInfoToolStripMenuItem.Image")));
            this.showInternationalLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showInternationalLicenseInfoToolStripMenuItem.Name = "showInternationalLicenseInfoToolStripMenuItem";
            this.showInternationalLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(346, 40);
            this.showInternationalLicenseInfoToolStripMenuItem.Text = "Show International License Info";
            this.showInternationalLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLicenseInfoToolStripMenuItem_Click);
            // 
            // lblRecordsInter
            // 
            this.lblRecordsInter.AutoSize = true;
            this.lblRecordsInter.Location = new System.Drawing.Point(130, 241);
            this.lblRecordsInter.Name = "lblRecordsInter";
            this.lblRecordsInter.Size = new System.Drawing.Size(18, 20);
            this.lblRecordsInter.TabIndex = 6;
            this.lblRecordsInter.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "#Records:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1220, 983);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(176, 47);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlShowCardWithFilter1
            // 
            this.ctrlShowCardWithFilter1.Location = new System.Drawing.Point(387, 12);
            this.ctrlShowCardWithFilter1.Name = "ctrlShowCardWithFilter1";
            this.ctrlShowCardWithFilter1.Size = new System.Drawing.Size(1038, 597);
            this.ctrlShowCardWithFilter1.TabIndex = 0;
            // 
            // FormLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1479, 1050);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlShowCardWithFilter1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLicenseHistory";
            this.Text = "License History";
            this.Load += new System.EventHandler(this.FormLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocal)).EndInit();
            this.cmsLocalLicens.ResumeLayout(false);
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInter)).EndInit();
            this.cmsInternationalLicense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controle.ctrlShowCardWithFilter ctrlShowCardWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRecordsLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewInter;
        private System.Windows.Forms.Label lblRecordsInter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicens;
        private System.Windows.Forms.ToolStripMenuItem showLocalLicenseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLicenseInfoToolStripMenuItem;
    }
}