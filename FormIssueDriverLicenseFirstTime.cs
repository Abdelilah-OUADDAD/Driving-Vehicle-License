using DVLDControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDProject
{
    public partial class FormIssueDriverLicenseFirstTime : Form
    {
        public FormIssueDriverLicenseFirstTime()
        {
            InitializeComponent();
        }
        DataTable dt;
        int CreatedByID { get; set; }
        public FormIssueDriverLicenseFirstTime(int LDLApp)
        {
            InitializeComponent();
            ctrlShowApplicant1.DataBack += Form_LoadData;
            ctrlShowApplicant1.FillDetailsApp(LDLApp);
            dt = clsApplicant.GetLocaleDrivingLicenseApplicationID(LDLApp);
        }

        private void Form_LoadData(object sender, int AppID, string ClassName, string FullName, int CreatedByID)
        {
            this.CreatedByID = CreatedByID;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsApplicant clsapplicant = new clsApplicant();
            
            clsapplicant.ApplicationID = (int)dt.Rows[0]["ApplicationID"];
            clsapplicant.DriverID = 9;
            clsapplicant.LicenseClass = (int)dt.Rows[0]["LicenseClassID"];
            clsapplicant.IssueDate = DateTime.Now;
            clsapplicant.ExpirationDate = DateTime.Now;
            clsapplicant.IsActive = true;
            clsapplicant.ExpirationDate = DateTime.Now;
            clsapplicant.PaidFees = 20;
            clsapplicant.CreatedByUserID = this.CreatedByID;
            clsapplicant.IssueReason =1;
            clsapplicant.Notes = textBox1.Text;
            if (clsapplicant.SaveLicenses())
                MessageBox.Show($"License Issue Successfully with ID = {clsapplicant.LicenseID} ");
            else
                MessageBox.Show($"License Issue Failed ");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
