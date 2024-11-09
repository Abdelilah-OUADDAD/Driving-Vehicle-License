namespace DVLDProject
{
    partial class ctrlLicenseHistory
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLocal = new System.Windows.Forms.TabPage();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageInternational = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecordInter = new System.Windows.Forms.Label();
            this.ctrlDetailsPerson1 = new DVLDProject.ctrlDetailsPerson();
            this.contextMenuStripLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripInter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInterLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStripLocal.SuspendLayout();
            this.contextMenuStripInter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(17, 411);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1140, 477);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "License Driving";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLocal);
            this.tabControl1.Controls.Add(this.tabPageInternational);
            this.tabControl1.Location = new System.Drawing.Point(23, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1111, 420);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLocal
            // 
            this.tabPageLocal.Controls.Add(this.lblRecord);
            this.tabPageLocal.Controls.Add(this.label2);
            this.tabPageLocal.Controls.Add(this.dataGridView1);
            this.tabPageLocal.Controls.Add(this.label1);
            this.tabPageLocal.Location = new System.Drawing.Point(4, 29);
            this.tabPageLocal.Name = "tabPageLocal";
            this.tabPageLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLocal.Size = new System.Drawing.Size(1103, 387);
            this.tabPageLocal.TabIndex = 0;
            this.tabPageLocal.Text = "Local";
            this.tabPageLocal.UseVisualStyleBackColor = true;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(131, 332);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(19, 20);
            this.lblRecord.TabIndex = 3;
            this.lblRecord.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "#Records:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripLocal;
            this.dataGridView1.Location = new System.Drawing.Point(20, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1077, 241);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local License History:";
            // 
            // tabPageInternational
            // 
            this.tabPageInternational.Controls.Add(this.lblRecordInter);
            this.tabPageInternational.Controls.Add(this.label4);
            this.tabPageInternational.Controls.Add(this.dataGridView2);
            this.tabPageInternational.Controls.Add(this.label3);
            this.tabPageInternational.Location = new System.Drawing.Point(4, 29);
            this.tabPageInternational.Name = "tabPageInternational";
            this.tabPageInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInternational.Size = new System.Drawing.Size(1103, 387);
            this.tabPageInternational.TabIndex = 1;
            this.tabPageInternational.Text = "International";
            this.tabPageInternational.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "International Driver License:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.contextMenuStripInter;
            this.dataGridView2.Location = new System.Drawing.Point(29, 55);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1068, 270);
            this.dataGridView2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "# Record:";
            // 
            // lblRecordInter
            // 
            this.lblRecordInter.AutoSize = true;
            this.lblRecordInter.Location = new System.Drawing.Point(162, 338);
            this.lblRecordInter.Name = "lblRecordInter";
            this.lblRecordInter.Size = new System.Drawing.Size(18, 20);
            this.lblRecordInter.TabIndex = 3;
            this.lblRecordInter.Text = "0";
            // 
            // ctrlDetailsPerson1
            // 
            this.ctrlDetailsPerson1.Location = new System.Drawing.Point(156, 3);
            this.ctrlDetailsPerson1.Name = "ctrlDetailsPerson1";
            this.ctrlDetailsPerson1.Size = new System.Drawing.Size(1001, 402);
            this.ctrlDetailsPerson1.TabIndex = 0;
            // 
            // contextMenuStripLocal
            // 
            this.contextMenuStripLocal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStripLocal.Name = "contextMenuStripLocal";
            this.contextMenuStripLocal.Size = new System.Drawing.Size(227, 36);
            // 
            // contextMenuStripInter
            // 
            this.contextMenuStripInter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripInter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInterLicenseInfoToolStripMenuItem});
            this.contextMenuStripInter.Name = "contextMenuStripInter";
            this.contextMenuStripInter.Size = new System.Drawing.Size(267, 69);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // showInterLicenseInfoToolStripMenuItem
            // 
            this.showInterLicenseInfoToolStripMenuItem.Name = "showInterLicenseInfoToolStripMenuItem";
            this.showInterLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(266, 32);
            this.showInterLicenseInfoToolStripMenuItem.Text = "Show Inter.License Info";
            this.showInterLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showInterLicenseInfoToolStripMenuItem_Click);
            // 
            // ctrlLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlDetailsPerson1);
            this.Name = "ctrlLicenseHistory";
            this.Size = new System.Drawing.Size(1171, 894);
            this.Load += new System.EventHandler(this.ctrlLicenseHistory_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLocal.ResumeLayout(false);
            this.tabPageLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageInternational.ResumeLayout(false);
            this.tabPageInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStripLocal.ResumeLayout(false);
            this.contextMenuStripInter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDetailsPerson ctrlDetailsPerson1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageInternational;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordInter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLocal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInter;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInterLicenseInfoToolStripMenuItem;
    }
}
