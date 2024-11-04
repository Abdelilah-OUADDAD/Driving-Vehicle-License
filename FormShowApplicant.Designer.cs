namespace DVLDProject
{
    partial class FormShowApplicant
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
            this.ctrlShowApplicant1 = new DVLDProject.ctrlShowApplicant();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowApplicant1
            // 
            this.ctrlShowApplicant1.Location = new System.Drawing.Point(12, 23);
            this.ctrlShowApplicant1.Name = "ctrlShowApplicant1";
            this.ctrlShowApplicant1.Size = new System.Drawing.Size(967, 539);
            this.ctrlShowApplicant1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(752, 577);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormShowApplicant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 638);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowApplicant1);
            this.Name = "FormShowApplicant";
            this.Text = "FormShowApplicant";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowApplicant ctrlShowApplicant1;
        private System.Windows.Forms.Button btnClose;
    }
}