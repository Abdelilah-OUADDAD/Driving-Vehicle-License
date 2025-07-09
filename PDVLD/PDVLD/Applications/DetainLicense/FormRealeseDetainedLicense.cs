using DriverLayoutControll;
using PDVLD.Applications.DrivingLicensesServices;
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

namespace PDVLD.Applications.DetainLicense
{
    public partial class FormRealeseDetainedLicense: Form
    {
        public FormRealeseDetainedLicense()
        {
            InitializeComponent();
        }

        public FormRealeseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            ctrlLicenseInfoWithFilter1.FillDataModeRelease(LicenseID);
        }
        int? LicenseID { get; set; }
        int? DetainID { get; set; }


        private void linkLabelNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormShowLicenseInfo frm = new FormShowLicenseInfo(LicenseID.Value);
            frm.ShowDialog();
        }

        private void linkLabelHistoryLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses clslicense = clsLicenses.GetLicenseID(LicenseID.Value);
            FormLicenseHistory frm = new FormLicenseHistory(
                clsApplications.GetApplicationID(clslicense.ApplicationID.Value).ApplicantPersonID.Value
                , clslicense.DriverID.Value);
            frm.ShowDialog();
        }

        private void ctrlLicenseInfoWithFilter1_OnReleaseChange(object sender, DrivingLicensesServices.Control.ctrlLicenseInfoWithFilter.EventReleaseChange e)
        {
            lblDetainID.Text = e.DetainID != null ? e.DetainID.ToString() : "[???]";
            lblDetainDate.Text = e.DetainDate != null ? e.DetainDate.ToString() : "[???]";
            lblAppFees.Text = e.ApplicationFees != null ? e.ApplicationFees.ToString() : "[???]";
            lblLicenseID.Text = e.LicenseID != null ? e.LicenseID.ToString() : "[???]";
            lblCreatedBy.Text = e.CreatedBy != null ? e.CreatedBy.ToString() : "[???]";
            lblFineFees.Text = e.FineFees != null ? e.FineFees.ToString() : "[???]";
            lblTotalFees.Text = (e.ApplicationFees + e.FineFees).ToString();

            LicenseID = e.LicenseID;
            DetainID = e.DetainID;

            linkLabelHistoryLicense.Enabled = true;
            btnRelease.Enabled = e.DetainID != null ? true : false;

        }

        private void ctrlLicenseInfoWithFilter1_OnDetainChangeWithoutLicense(object sender, EventArgs e)
        {
            lblDetainID.Text = "[???]";
            lblDetainDate.Text = "[???]";
             lblAppFees.Text = "[???]";
             lblLicenseID.Text ="[???]";
             lblCreatedBy.Text ="[???]";
             lblFineFees.Text ="[???]";
             lblTotalFees.Text ="[???]";

            linkLabelHistoryLicense.Enabled = false;
            btnRelease.Enabled = false;

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                clsApplications applications = new clsApplications();
                applications.ApplicantPersonID = clsApplications.GetApplicationID(clsLicenses.GetLicenseID(LicenseID.Value).ApplicationID.Value).ApplicantPersonID;
                applications.ApplicationDate = DateTime.Now;
                applications.ApplicationTypeID = 5;
                applications.ApplicationStatus = 3;
                applications.LastStatusDate = DateTime.Now;
                applications.PaidFees = clsApplicationTypes.GetApplicationTypeID(5).ApplicationFees;
                applications.CreatedByUserID = clsGlobal.UserID;

                if (applications.Save())
                {
                    clsDetainedLicenses getDetain = clsDetainedLicenses.GetDetainedID(DetainID.Value);
                    clsDetainedLicenses detain = new clsDetainedLicenses(getDetain.DetainID, getDetain.LicenseID, getDetain.DetainDate, getDetain.FineFees
                        , getDetain.CreatedByUserID, true, DateTime.Now, clsGlobal.UserID, applications.ApplicationID);
                    
                    if (detain.Save())
                    {
                        MessageBox.Show("Detained License Released Successfully", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRelease.Enabled = false;
                        linkLabelNewLicense.Enabled = true;
                        ctrlLicenseInfoWithFilter1.EnableFilterText();
                        lblRAppID.Text = applications.ApplicationID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Detained License Released Failed", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
