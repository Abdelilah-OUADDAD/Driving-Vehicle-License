namespace DVLDProject
{
    partial class FormShowUser
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
            this.ctrlShowUser1 = new DVLDProject.ctrlShowUser();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowUser1
            // 
            this.ctrlShowUser1.Location = new System.Drawing.Point(27, 12);
            this.ctrlShowUser1.Name = "ctrlShowUser1";
            this.ctrlShowUser1.Size = new System.Drawing.Size(1007, 552);
            this.ctrlShowUser1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(889, 570);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormShowUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 638);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowUser1);
            this.Name = "FormShowUser";
            this.Text = "FormShowUser";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlShowUser ctrlShowUser1;
        private System.Windows.Forms.Button btnClose;
    }
}