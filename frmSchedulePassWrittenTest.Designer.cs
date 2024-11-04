namespace DVLDProject
{
    partial class frmSchedulePassWrittenTest
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
            this.ctrlSchedulePassTest1 = new DVLDProject.ctrlSchedulePassTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlSchedulePassTest1
            // 
            this.ctrlSchedulePassTest1.AppDate = new System.DateTime(((long)(0)));
            this.ctrlSchedulePassTest1.AppID = 0;
            this.ctrlSchedulePassTest1.ClassName = null;
            this.ctrlSchedulePassTest1.CreatedByUserID = 0;
            this.ctrlSchedulePassTest1.FullName = null;
            this.ctrlSchedulePassTest1.Location = new System.Drawing.Point(12, 12);
            this.ctrlSchedulePassTest1.Name = "ctrlSchedulePassTest1";
            this.ctrlSchedulePassTest1.PaidFees = 0D;
            this.ctrlSchedulePassTest1.Size = new System.Drawing.Size(533, 531);
            this.ctrlSchedulePassTest1.TabIndex = 0;
            this.ctrlSchedulePassTest1.TestAppointmentID = 0;
            this.ctrlSchedulePassTest1.TestTypeID = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(195, 842);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 47);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 671);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 135);
            this.textBox1.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 671);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Notes :";
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Location = new System.Drawing.Point(235, 608);
            this.rbFail.Name = "rbFail";
            this.rbFail.Size = new System.Drawing.Size(59, 24);
            this.rbFail.TabIndex = 27;
            this.rbFail.TabStop = true;
            this.rbFail.Text = "Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Location = new System.Drawing.Point(143, 608);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(69, 24);
            this.rbPass.TabIndex = 26;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(39, 612);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "Result :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(356, 842);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 47);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSchedulePassWrittenTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 914);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rbFail);
            this.Controls.Add(this.rbPass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlSchedulePassTest1);
            this.Name = "frmSchedulePassWrittenTest";
            this.Text = "frmShcedulPassWrittenTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlSchedulePassTest ctrlSchedulePassTest1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
    }
}