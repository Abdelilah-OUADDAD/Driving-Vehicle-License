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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PDVLD.Applications.DrivingLicensesServices.International_License
{
    public partial class FormInternationalLicense: Form
    {
        public FormInternationalLicense()
        {
            InitializeComponent();
        }

        int? LicenseID = null;

        private void FormInternationalLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblFees.Text = clsApplicationTypes.GetApplicationTypeID(6).ApplicationFees.Value.ToString();
            lblCreatedBy.Text = clsGlobal.UserName;

            btnIssue.Enabled = false;
            linkLabelHistory.Enabled = false;
            linkLabelInfo.Enabled = false;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(LicenseID != null)
            {
                clsLicenses licenses = clsLicenses.GetLicenseID(LicenseID.Value);

                clsInternationalLicenses cls = new clsInternationalLicenses();
                clsApplications applications = new clsApplications();
                applications.ApplicantPersonID = clsApplications.GetApplicationID(licenses.ApplicationID.Value).ApplicantPersonID;
                applications.ApplicationDate = DateTime.Now;
                applications.ApplicationTypeID = 6;
                applications.ApplicationStatus = 3;
                applications.LastStatusDate = DateTime.Now;
                applications.PaidFees = clsApplicationTypes.GetApplicationTypeID(6).ApplicationFees;
                applications.CreatedByUserID = clsGlobal.UserID;
                // --Add app for inter license
                if (MessageBox.Show("Are You sure you want to issue the license", "Confirm"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {

                    if (applications.Save())
                    {
                        cls.ApplicationID = applications.ApplicationID;
                        cls.DriverID = licenses.DriverID;
                        cls.IssuedUsingLocalLicenseID = LicenseID;
                        cls.IssueDate = DateTime.Now;
                        cls.ExpirationDate = DateTime.Now.AddYears(1);
                        cls.IsActive = true;
                        cls.CreatedByUserID = clsGlobal.UserID;

                        if (cls.Save())
                        {
                            MessageBox.Show($"International License Issued Successfully with ID={cls.InternationalLicenseID}"
                                , "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblILAppID.Text = cls.ApplicationID.ToString();
                            lblILLicenseID.Text = cls.InternationalLicenseID.ToString();
                            btnIssue.Enabled = false;
                            ctrlLicenseInfoWithFilter1.EnableFilterText();
                        }
                        else
                            MessageBox.Show($"International License Issued Failed !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show($"Application Failed To Saved !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

       
        private void ctrlLicenseInfoWithFilter1_OnLicenseChange(int arg1, bool arg2)
        {
            LicenseID = arg1;
            lblLocalLicenseID.Text = arg1.ToString();
            btnIssue.Enabled = arg2;
            linkLabelHistory.Enabled = true;
            linkLabelInfo.Enabled = false;
        }

        private void ctrlLicenseInfoWithFilter1_OnInternationalLicense(int arg1, bool arg2)
        {
            LicenseID = arg1;
            lblLocalLicenseID.Text = arg1.ToString();
            btnIssue.Enabled = arg2;
            linkLabelHistory.Enabled = true;
            linkLabelInfo.Enabled = true;
        }

        private void linkLabelHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses clslicense = clsLicenses.GetLicenseID(LicenseID.Value);
            FormLicenseHistory frm = new FormLicenseHistory(
                clsApplications.GetApplicationID(clslicense.ApplicationID.Value).ApplicantPersonID.Value
                ,clslicense.DriverID.Value);
            frm.ShowDialog();
        }

        private void linkLabelInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormShowInternationalLicenseInfo frm = new FormShowInternationalLicenseInfo(LicenseID.Value);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
