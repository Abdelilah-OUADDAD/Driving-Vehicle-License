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
    public partial class frmRenewLocalDrivingLicense : Form
    {
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            lblCreatedBy.Text = Main.UserName;
            lblIssueDate.Text = DateTime.Now.ToString();
            lblAppFees.Text = "5";
            lblAppDate.Text = DateTime.Now.ToString();
        }

        DataTable dtLic;
        clsApplicant clsapplicant = new clsApplicant();
        int ApplicationID { get; set; }
        clsApplicant cls;
        bool isRenew = false;
        bool isShowLicense = false;

        
        private void FillLicenseInfo()
        {
            dtLic = clsApplicant.GetLicensesID(Convert.ToInt32(textBox1.Text));
            int LDLappId = -1;

            DataTable dtAp = clsApplicant.GetApplicationID((int)dtLic.Rows[0]["ApplicationID"]);
            DataTable dtPerson = clsPerson.GetPerson((int)dtAp.Rows[0]["ApplicantPersonID"]);

            foreach (DataRow row in clsApplicant.GetLocaleDrivingLicenseApplicationView().Rows)
            {
                if (row["NationalNo"].ToString() == dtPerson.Rows[0]["NationalNo"].ToString() &&
                    (int)dtLic.Rows[0]["LicenseClass"] == clsApplicant.ClassName( row["ClassName"].ToString()) )
                {
                    LDLappId = (int)row["LocalDrivingLicenseApplicationID"];
                    break;
                }
            }
            try
            {
                ApplicationID = Convert.ToInt32(dtLic.Rows[0]["ApplicationID"]);
                lblOldLicenseID.Text = dtLic.Rows[0]["LicenseID"].ToString();
                lblLicenseFees.Text = dtLic.Rows[0]["PaidFees"].ToString();
                int Appfess = Convert.ToInt32(lblAppFees.Text) ;
                double LicenseFees = Convert.ToDouble(lblLicenseFees.Text);
                double Result = Appfess + LicenseFees;
                lblTotalFees.Text = Result.ToString();
                lblExpirationDATE.Text = dtLic.Rows[0]["ExpirationDate"].ToString();

               
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
                if (DateTime.Now > (DateTime)dtLic.Rows[0]["ExpirationDate"] &&
                    (bool)dtLic.Rows[0]["IsActive"] == true)
                {
                     btnRenew.Enabled = true;
                    isShowLicense = true;
                }
                else if ((bool)dtLic.Rows[0]["IsActive"] == false)
                {
                    MessageBox.Show("Select License is not Active ");
                    LinkNewLicense.Enabled = false;
                    btnRenew.Enabled = false;
                }
                else
                {
                    MessageBox.Show($@"Select License is not yet expiration ,it will expire on : 
                        {Convert.ToDateTime(dtLic.Rows[0]["ExpirationDate"])}");
                    LinkNewLicense.Enabled = false;
                    btnRenew.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Selected License is not Found {ex.Message}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillLicenseInfo();
        }

        private void btnRenew_Click(object sender, EventArgs e)
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
                //-- Update License
                clsApplicant clsUp = new clsApplicant(Convert.ToInt32(dtLic.Rows[0]["LicenseID"]), Convert.ToInt32(dtLic.Rows[0]["ApplicationID"])
                    , Convert.ToInt32(dtLic.Rows[0]["DriverID"]), Convert.ToInt32(dtLic.Rows[0]["LicenseClass"]), Convert.ToDateTime(dtLic.Rows[0]["IssueDate"])
                    , Convert.ToDateTime(dtLic.Rows[0]["ExpirationDate"]), dtLic.Rows[0]["Notes"].ToString(), Convert.ToDouble(dtLic.Rows[0]["PaidFees"]),
                    false, Convert.ToInt32(dtLic.Rows[0]["IssueReason"]), Convert.ToInt32(dtLic.Rows[0]["CreatedByUserID"]));

                if (clsUp.SaveLicenses())
                {
                    //-- Add License
                    clsapplicant.ApplicationID = cls.ApplicationID;
                    clsapplicant.DriverID = 9;
                    clsapplicant.LicenseClass = (int)dt.Rows[0]["LicenseClassID"];
                    clsapplicant.IssueDate = DateTime.Now;
                    clsapplicant.ExpirationDate = DateTime.Now.AddYears(10);
                    clsapplicant.Notes = txtNotes.Text;
                    clsapplicant.IsActive = true;
                    clsapplicant.PaidFees = 20;
                    clsapplicant.CreatedByUserID = Main.UserID;
                    clsapplicant.IssueReason = 4;


                    if (MessageBox.Show($"Are you sure you want to issue a Remplacement for the license? ", "Data Saved"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        if (clsapplicant.SaveLicenses())
                        {
                            MessageBox.Show($"License Issue Successfully with ID = {clsapplicant.LicenseID} ");
                            LinkNewLicense.Enabled = true;
                            lblRenewedLicenseID.Text = clsapplicant.LicenseID.ToString();
                            lbRLlAppID.Text = cls.ApplicationID.ToString();
                           
                        }
                    }
                    else
                        MessageBox.Show($"License Issue Failed ", "Data Saved");
                }
            }
        }

        private void linkLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormLicenseHistory frm = new FormLicenseHistory(ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
        }

       
        private void LinkNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseInfo.LicenseID = clsapplicant.LicenseID;
            frmLicenseInfo frm = new frmLicenseInfo(ctrlDriverLicenseInfo1.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
