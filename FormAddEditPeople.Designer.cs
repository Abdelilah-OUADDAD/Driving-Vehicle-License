namespace DVLDProject
{
    partial class FormAddEditPeople
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
            this.ctrlPeople1 = new DVLDProject.ctrlPeople();
            this.SuspendLayout();
            // 
            // ctrlPeople1
            // 
            this.ctrlPeople1.Location = new System.Drawing.Point(12, 12);
            this.ctrlPeople1.Name = "ctrlPeople1";
            this.ctrlPeople1.Size = new System.Drawing.Size(1144, 710);
            this.ctrlPeople1.TabIndex = 0;
            this.ctrlPeople1.Load += new System.EventHandler(this.ctrlPeople1_Load);
            // 
            // FormAddEditPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 729);
            this.Controls.Add(this.ctrlPeople1);
            this.Name = "FormAddEditPeople";
            this.Text = "FormAddEditPeople";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPeople ctrlPeople1;
    }
}