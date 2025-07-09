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

namespace PDVLD.Applications.DrivingLicensesServices.RenewDrivingLicense
{
    public partial class FormRenewDrivingLicense: Form
    {
        public FormRenewDrivingLicense()
        {
            InitializeComponent();
        }

        int LicenseID { get; set; }

        private void FormRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToString("dd/MM/yyyy"); 
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.UserName;
            lblAppFees.Text = "7";
        }

        private void ctrlLicenseInfoWithFilter1_OnRenewLicenseChange(int arg1, DateTime arg2, bool arg3, int arg4)
        {
            LicenseID = arg1;
            lblLicenseFees.Text = clsLicenseClass.GetLicenseClassID(arg4).ClassFees.ToString();
            lblOldLicenseID.Text = arg1.ToString();
            lblExpirationDate.Text = arg2.ToString();
            lblTotalFees.Text = (int.Parse(lblLicenseFees.Text) + int.Parse(lblAppFees.Text)).ToString();

            linkLabelShowHistoryLicense.Enabled = true;
            btnRenew.Enabled = arg3;
        }

        private void linkLabelShowHistoryLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses clslicense = clsLicenses.GetLicenseID(LicenseID);
            FormLicenseHistory frm = new FormLicenseHistory(
                clsApplications.GetApplicationID(clslicense.ApplicationID.Value).ApplicantPersonID.Value
                , clslicense.DriverID.Value);
            frm.ShowDialog();
        }

        private void linkLabelShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormShowLicenseInfo frm = new FormShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsApplications applications = new clsApplications();
            clsLicenses GetDataLicense = clsLicenses.GetLicenseID(LicenseID);
            applications.ApplicantPersonID = clsApplications.GetApplicationID(GetDataLicense.ApplicationID.Value).ApplicantPersonID;
            applications.ApplicationDate = DateTime.Now;
            applications.ApplicationTypeID = 2;
            applications.ApplicationStatus = 3;
            applications.LastStatusDate = DateTime.Now;
            applications.PaidFees = clsApplicationTypes.GetApplicationTypeID(2).ApplicationFees;
            applications.CreatedByUserID = clsGlobal.UserID;

            if (MessageBox.Show("Are you sure you want to Renew the License? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
                    licenses.Notes = txtNotes.Text;
                    licenses.PaidFees = licenseClass.ClassFees;
                    licenses.IsActive = true;
                    licenses.IssueReason = 2;
                    licenses.CreatedByUserID = clsGlobal.UserID;


                    clsLicenses cls = new clsLicenses(LicenseID, GetDataLicense.ApplicationID, GetDataLicense.DriverID, GetDataLicense.LicenseClass,
                        GetDataLicense.IssueDate, GetDataLicense.ExpirationDate, GetDataLicense.Notes, GetDataLicense.PaidFees, false,
                        GetDataLicense.IssueReason, GetDataLicense.CreatedByUserID);
                    if (cls.Save())
                    {
                        if (licenses.Save())
                        {

                            MessageBox.Show($"License Renewed Successfully with ID = {licenses.LicenseID}", "License Issued", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            ctrlLicenseInfoWithFilter1.EnableFilterText();
                            ctrlLicenseInfoWithFilter1.StartButtonSearch();
                            btnRenew.Enabled = false;
                            linkLabelShowNewLicense.Enabled = true;
                            LicenseID = licenses.LicenseID.Value;
                            lblRLAppID.Text = applications.ApplicationID.ToString();
                            lblRenewLicenseID.Text = licenses.LicenseID.ToString();
                        }
                        else
                        {
                            MessageBox.Show($"License Renewed Failed", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Update License for continue to Renewed License is Failed", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
