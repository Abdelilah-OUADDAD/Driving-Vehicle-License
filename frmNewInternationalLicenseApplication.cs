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
using static System.Net.Mime.MediaTypeNames;

namespace DVLDProject
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
            lblCreatedBy.Text = Main.UserName;
            lblIssueDate.Text = DateTime.Now.ToString();
            lblFees.Text = "50";
            lblAppDate.Text = DateTime.Now.ToString();
            lblExpirationDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = Main.UserName;
        }

        DataTable dtLic;
        clsApplicant clsapplicant = new clsApplicant();
        int ApplicationID { get; set; }
        private void FillLicenseInfo()
        {
            dtLic = clsApplicant.GetLicensesID(Convert.ToInt32(textBox1.Text));
            ApplicationID = Convert.ToInt32(dtLic.Rows[0]["ApplicationID"]);

            DataTable dtLocal = clsApplicant.GetLocaleDrivingLicenseApplication();
            foreach (DataRow dr in dtLocal.Rows)
            {
                if ((int)dr["ApplicationID"] == (int)dtLic.Rows[0]["ApplicationID"])
                {
                    ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID = Convert.ToInt32(dr["LocalDrivingLicenseApplicationID"]);

                    ctrlDriverLicenseInfo1.FillDrivingInfo();
                    break;
                }
            }

            if (Convert.ToBoolean(dtLic.Rows[0]["IsActive"]) == true)
            {
                btnIssue.Enabled = true;
            }
            else if (Convert.ToBoolean(dtLic.Rows[0]["IsActive"]) == false)
            {
                MessageBox.Show("Selected License is not Active,choose an Active License", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Selected License is not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
        clsApplicant cls;

        private void btnIssue_Click(object sender, EventArgs e)
        {
           
            DataTable dt = clsApplicant.GetLocaleDrivingLicenseApplicationID(ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID);
            DataTable dtApplication = clsApplicant.GetApplicationID(this.ApplicationID);
            cls = new clsApplicant();
            //-- Add Applicant
            cls.ApplicantPersonID = (int)dtApplication.Rows[0]["ApplicantPersonID"];
            cls.ApplicationDate = (DateTime)dtApplication.Rows[0]["ApplicationDate"];
            cls.ApplicationTypeID = (int)dtApplication.Rows[0]["ApplicationTypeID"];
            cls.ApplicationStatus = Convert.ToInt32(dtApplication.Rows[0]["ApplicationStatus"]);
            cls.LastStatusDate = (DateTime)dtApplication.Rows[0]["LastStatusDate"];
            cls.PaidFees = Convert.ToDouble(dtApplication.Rows[0]["PaidFees"]);
            cls.CreatedByUserID = (int)dtApplication.Rows[0]["CreatedByUserID"];
            cls.LicenseClassID = (int)dt.Rows[0]["LicenseClassID"];
            if (cls.Save())
            {

                //-- Add License
                clsapplicant.ApplicationID = cls.ApplicationID;
                clsapplicant.DriverID = 9;
                clsapplicant.LicenseClass = (int)dt.Rows[0]["LicenseClassID"];
                clsapplicant.IssueDate = DateTime.Now;
                clsapplicant.ExpirationDate = DateTime.Now;
                clsapplicant.Notes = dtLic.Rows[0]["Notes"].ToString();
                clsapplicant.IsActive = true;
                clsapplicant.ExpirationDate = DateTime.Now;
                clsapplicant.PaidFees = 20;
                clsapplicant.CreatedByUserID = Main.UserID;


                if (MessageBox.Show($"Are you sure you want to issue a Remplacement for the license? ", "Data Saved"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (clsapplicant.SaveLicenses())
                    {
                        MessageBox.Show($"License Issue Successfully with ID = {clsapplicant.LicenseID} ");
                        LinkNewLicense.Enabled = true;
                            
                            
                        lblLocalLicenseID.Text = clsapplicant.LicenseID.ToString();
                        lblAppDate.Text = cls.ApplicationID.ToString();
                    }
                }
                else
                    MessageBox.Show($"License Issue Failed ", "Data Saved");
            }
            
        }
    }
}
