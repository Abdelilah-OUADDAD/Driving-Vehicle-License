namespace PDVLD.People.Controle
{
    partial class FormShowPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowPerson));
            this.ctrlShowCard1 = new PDVLD.People.Controle.ctrlShowCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlShowCard2 = new PDVLD.People.Controle.ctrlShowCard();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlShowCard1
            // 
            this.ctrlShowCard1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowCard1.Name = "ctrlShowCard1";
            this.ctrlShowCard1.Size = new System.Drawing.Size(1031, 488);
            this.ctrlShowCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(814, 573);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 55);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlShowCard2
            // 
            this.ctrlShowCard2.Location = new System.Drawing.Point(3, 115);
            this.ctrlShowCard2.Name = "ctrlShowCard2";
            this.ctrlShowCard2.Size = new System.Drawing.Size(1031, 439);
            this.ctrlShowCard2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(354, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = "Person Details";
            // 
            // FormShowPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1046, 639);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlShowCard2);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormShowPerson";
            this.Text = "Show Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlShowCard ctrlShowCard1;
        private System.Windows.Forms.Button btnClose;
        private ctrlShowCard ctrlShowCard2;
        private System.Windows.Forms.Label label1;
    }
}