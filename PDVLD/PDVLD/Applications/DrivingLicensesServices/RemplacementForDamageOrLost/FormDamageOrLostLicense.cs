using DriverLayoutControll;
using PDVLD.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Applications.DrivingLicensesServices.RemplacementForDamageOrLost
{
    public partial class FormDamageOrLostLicense: Form
    {
        public FormDamageOrLostLicense()
        {
            InitializeComponent();
        }

        enum enMode { enDamage = 0,enLost = 1}
        enMode Mode;

        int? LicenseID { get; set; }
       

        private void ctrlLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            rbDamage.Checked = true;
            lblAppDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.UserName;

        }

        private void FormDamageOrLostLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = clsGlobal.UserName;
            rbDamage_CheckedChanged(null, null);
        }

        private void rbDamage_CheckedChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = clsApplicationTypes.GetApplicationTypeID(4).ApplicationFees.ToString();
            lblTitle.Text = "Replacement for Damaged License";
            Mode = enMode.enDamage;
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = clsApplicationTypes.GetApplicationTypeID(3).ApplicationFees.ToString();
            lblTitle.Text = "Replacement for Lost License";
            Mode = enMode.enLost;
        }

        private void ctrlLicenseInfoWithFilter1_OnLostOrDamageLicense(int arg1, bool arg2)
        {
            LicenseID = arg1;
            lblOldLicenseID.Text = arg1.ToString();
            btnReplacement.Enabled = arg2;
            linkLabelShowHistoryLicense.Enabled = true;
        }

        private void ctrlLicenseInfoWithFilter1_OnLostOrDamageWithoutLicense(bool arg1, bool arg2)
        {
            btnReplacement.Enabled = arg1;
            linkLabelShowHistoryLicense.Enabled = arg2;
            lblOldLicenseID.Text = "[???]";
            LicenseID = null;
        }

        private void linkLabelShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormShowLicenseInfo frm = new FormShowLicenseInfo(LicenseID.Value);
            frm.ShowDialog();
        }

        private void linkLabelShowHistoryLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses clslicense = clsLicenses.GetLicenseID(LicenseID.Value);
            FormLicenseHistory frm = new FormLicenseHistory(
                clsApplications.GetApplicationID(clslicense.ApplicationID.Value).ApplicantPersonID.Value
                , clslicense.DriverID.Value);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            clsApplications applications = new clsApplications();
            clsLicenses GetDataLicense = clsLicenses.GetLicenseID(LicenseID.Value);
            applications.ApplicantPersonID = clsApplications.GetApplicationID(GetDataLicense.ApplicationID.Value).ApplicantPersonID;
            applications.ApplicationDate = DateTime.Now;

            if(Mode == enMode.enLost)
                applications.ApplicationTypeID = 3;
            else
                applications.ApplicationTypeID = 4;

            applications.ApplicationStatus = 3;
            applications.LastStatusDate = DateTime.Now;
            applications.PaidFees = Convert.ToSingle(lblAppFees.Text);
            applications.CreatedByUserID = clsGlobal.UserID;

            if (MessageBox.Show("Are you sure you want to Issue a Replacement the License? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
            {
                if (applications.Save())
                {
                    clsLicenses licenses = new clsLicenses();
                    licenses.ApplicationID = applications.ApplicationID;
                    licenses.DriverID = clsDrivers.GetDriverWithPersonID(applications.ApplicantPersonID.Value).DriverID.Value;
                    licenses.LicenseClass = GetDataLicense.LicenseClass;
                    licenses.IssueDate = DateTime.Now;

                    clsLicenseClass licenseClass = clsLicenseClass.GetLicenseClassID(licenses.LicenseClass.Value);

                    licenses.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength.Value);
                    licenses.Notes = "";
                    licenses.PaidFees = licenseClass.ClassFees;
                    licenses.IsActive = true;
                    licenses.IssueReason = applications.ApplicationTypeID;
                    licenses.CreatedByUserID = clsGlobal.UserID;


                    clsLicenses cls = new clsLicenses(LicenseID, GetDataLicense.ApplicationID, GetDataLicense.DriverID, GetDataLicense.LicenseClass,
                        GetDataLicense.IssueDate, GetDataLicense.ExpirationDate, GetDataLicense.Notes, GetDataLicense.PaidFees, false,
                        GetDataLicense.IssueReason, GetDataLicense.CreatedByUserID);
                    if (cls.Save())
                    {
                        if (licenses.Save())
                        {

                            MessageBox.Show($"License Replaced Successfully with ID = {licenses.LicenseID}", "License Issued", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ctrlLicenseInfoWithFilter1.EnableFilterText();
                            ctrlLicenseInfoWithFilter1.StartButtonSearch();
                            btnReplacement.Enabled = false;
                            linkLabelShowNewLicense.Enabled = true;
                            LicenseID = licenses.LicenseID.Value;
                            lblLRAppID.Text = applications.ApplicationID.ToString();
                            lblRepacementLicenseID.Text = licenses.LicenseID.ToString();
                        }
                        else
                        {
                            MessageBox.Show($"License Replaced Failed", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Update License for continue to Replaced License is Failed", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
