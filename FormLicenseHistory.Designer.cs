﻿namespace DVLDProject
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlLicenseHistory2 = new DVLDProject.ctrlLicenseHistory();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(447, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "License History";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(996, 986);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 41);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlLicenseHistory2
            // 
            this.ctrlLicenseHistory2.Location = new System.Drawing.Point(12, 95);
            this.ctrlLicenseHistory2.Name = "ctrlLicenseHistory2";
            this.ctrlLicenseHistory2.PersonID = 0;
            this.ctrlLicenseHistory2.Size = new System.Drawing.Size(1160, 885);
            this.ctrlLicenseHistory2.TabIndex = 1;
           
            // 
            // FormLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 1050);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLicenseHistory2);
            this.Controls.Add(this.label1);
            this.Name = "FormLicenseHistory";
            this.Text = "FormLicenseHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrlLicenseHistory ctrlLicenseHistory2;
        private System.Windows.Forms.Button btnClose;
    }
}