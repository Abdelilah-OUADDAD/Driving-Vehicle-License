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
            int PersonIDDriver = -1;
            foreach(DataRow row in clsApplicant.GetApplicationID((int)dt.Rows[0]["ApplicationID"]).Rows)
            {
                PersonIDDriver = Convert.ToInt32(row["ApplicantPersonID"]);
            }
            if (PersonIDDriver != -1) { 
                clsApplicant clsDriver = new clsApplicant();
                clsDriver.ApplicantPersonID = PersonIDDriver;
                clsDriver.CreatedByUserID = Main.UserID;
                clsDriver.CreateDate = DateTime.Now;

                if (clsDriver.SaveDrivers()) { 
                    clsApplicant clsapplicant = new clsApplicant();
            
                    clsapplicant.ApplicationID = (int)dt.Rows[0]["ApplicationID"];
                    clsapplicant.DriverID = clsDriver.DriverID;
                    clsapplicant.LicenseClass = (int)dt.Rows[0]["LicenseClassID"];
                    clsapplicant.IssueDate = DateTime.Now;
                    clsapplicant.ExpirationDate = DateTime.Now.AddYears(10) ;
                    clsapplicant.IsActive = true;
                    clsapplicant.PaidFees = 20;
                    clsapplicant.CreatedByUserID = this.CreatedByID;
                    clsapplicant.IssueReason =1;
                    clsapplicant.Notes = textBox1.Text;
                    if (clsapplicant.SaveLicenses())
                        MessageBox.Show($"License Issue Successfully with ID = {clsapplicant.LicenseID} ");
                    else
                        MessageBox.Show($"License Issue Failed ");
                }
            }
            else
            {

                MessageBox.Show($"Data Diver Failed to save ");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
