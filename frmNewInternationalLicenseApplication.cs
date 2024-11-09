using DVLDControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        }

        DataTable dtLic;
        clsApplicant clsInterLicense = new clsApplicant();
        int ApplicationID { get; set; }
        clsApplicant cls;
       
        private void FillLicenseInfo()
        {
            dtLic = clsApplicant.GetLicensesID(Convert.ToInt32(textBox1.Text));
            int LDLappId = -1;
            try
            {
                DataTable dtAp = clsApplicant.GetApplicationID((int)dtLic.Rows[0]["ApplicationID"]);
                DataTable dtPerson = clsPerson.GetPerson((int)dtAp.Rows[0]["ApplicantPersonID"]);

                foreach (DataRow row in clsApplicant.GetLocaleDrivingLicenseApplicationView().Rows)
                {
                    if (row["NationalNo"].ToString() == dtPerson.Rows[0]["NationalNo"].ToString() &&
                        (int)dtLic.Rows[0]["LicenseClass"] == clsApplicant.ClassName(row["ClassName"].ToString()))
                    {
                        LDLappId = (int)row["LocalDrivingLicenseApplicationID"];
                        break;
                    }
                }
                
                ApplicationID = Convert.ToInt32(dtLic.Rows[0]["ApplicationID"]);
                lblLocalLicenseID.Text = dtLic.Rows[0]["LicenseID"].ToString();

                bool IsAppIDFound = false;

                if (LDLappId != -1)
                {
                    ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID = LDLappId;
                    ctrlDriverLicenseInfo1.LicenseID = (int)dtLic.Rows[0]["LicenseID"];
                    ctrlDriverLicenseInfo1.FillDrivingInfo();
                    IsAppIDFound = true;

                }
                if (IsAppIDFound == false)
                {
                    MessageBox.Show($"Local Driving License Application ID is not Found {(int)dtLic.Rows[0]["ApplicationID"]}"
                    , "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (clsApplicant.FindInternationalLicense(int.Parse(textBox1.Text)) == false)
                {
                    if (Convert.ToBoolean(dtLic.Rows[0]["IsActive"]) == true)
                    {
                        btnIssue.Enabled = true;
                    }
                    else
                    {
                        btnIssue.Enabled = false;
                        LinkNewLicense.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show($"Person already have an active international with ID = {textBox1.Text}","Message",MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LinkNewLicense.Enabled = true;
                    dtLic = clsApplicant.GetInternationalLicenseWithLicenseID(Convert.ToInt32(textBox1.Text));
                    ApplicationID = Convert.ToInt32(dtLic.Rows[0]["ApplicationID"]);
                }
            }
            catch(Exception ex)  
            {
                MessageBox.Show($"Selected License is not Found {ex.Message} ", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

      
        

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
            if (cls.SaveApplication())
            {

                //-- Add International License
                clsInterLicense.ApplicationID = cls.ApplicationID;
                clsInterLicense.DriverID = 8;
                clsInterLicense.IssuedUsingLocalLicenseID = Convert.ToInt32(dtLic.Rows[0]["LicenseID"]);
                clsInterLicense.IssueDate = DateTime.Now;
                clsInterLicense.ExpirationDate = DateTime.Now.AddYears(1);
                clsInterLicense.IsActive = true;
                clsInterLicense.CreatedByUserID = Main.UserID;


                if (MessageBox.Show($"Are you sure you want to issue  the license? ", "Data Saved"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (clsInterLicense.SaveInternationalLicense())
                    {
                        MessageBox.Show($"International License Issue Successfully with ID = {clsInterLicense.InternationalLicense} ");
                        LinkNewLicense.Enabled = true;


                        lblInterLicenseID.Text = clsInterLicense.InternationalLicense.ToString();
                        lblInterAppID.Text = cls.ApplicationID.ToString();
                    }
                }
                else
                    MessageBox.Show($"License Issue Failed ", "Data Saved");
            }
         
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                FillLicenseInfo();
        }

        private void linkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseHistory frm = new FormLicenseHistory(ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
        }

        private void LinkNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo();
            DataTable dt = clsApplicant.GetInternationalLicenseWithLicenseID(int.Parse(textBox1.Text));
            frm.FillInterDrivingInfo((int)dt.Rows[0]["InternationalLicenseID"], ApplicationID, Convert.ToInt32(dt.Rows[0]["IssuedUsingLocalLicenseID"]));
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
