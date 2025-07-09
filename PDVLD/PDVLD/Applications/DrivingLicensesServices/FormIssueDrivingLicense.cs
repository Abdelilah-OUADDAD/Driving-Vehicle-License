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

namespace PDVLD.Applications.DrivingLicensesServices
{
    public partial class FormIssueDrivingLicense: Form
    {
        public FormIssueDrivingLicense()
        {
            InitializeComponent();
        }
        int PersonID { get; set; }
        int LDLAppID { get; set; }
        public FormIssueDrivingLicense(int lDLAppID)
        {
            InitializeComponent();
            LDLAppID = lDLAppID;
            ctrlDrivingLicenseApplicationInfo1.FillInfoDrivingLicenseApp(lDLAppID);
            PersonID = clsApplications.GetApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(lDLAppID).ApplicationID.Value).ApplicantPersonID.Value;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDrivers drivers = clsDrivers.GetDriverWithPersonID(PersonID);
            if (drivers == null)
            {
                drivers = new clsDrivers();
                
                drivers.PersonID = PersonID;
                drivers.CreatedByUserID = clsGlobal.UserID;
                drivers.CreatedDate = DateTime.Now;
                if (!drivers.Save())
                    MessageBox.Show("Data Failed !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            clsLocalDrivingLicenseApplications clsLocal = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(LDLAppID);

            clsLicenses licenses = new clsLicenses();
            licenses.ApplicationID = clsLocal.ApplicationID.Value;
            licenses.DriverID = drivers.DriverID;
            licenses.LicenseClass = clsLocal.LicenseClassID;
            licenses.IssueDate = DateTime.Now;

            clsLicenseClass licenseClass = clsLicenseClass.GetLicenseClassID(licenses.LicenseClass.Value);

            licenses.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength.Value);
            licenses.Notes = txtNote.Text;
            licenses.PaidFees = licenseClass.ClassFees;
            licenses.IsActive = true;
            licenses.IssueReason = 1;
            licenses.CreatedByUserID = clsGlobal.UserID;

            clsApplications applications = clsApplications.GetApplicationID(licenses.ApplicationID.Value);
            applications.LastStatusDate = DateTime.Now;
            applications.ApplicationStatus = 3;
            if (applications.Save())
            {
                if (licenses.Save())
                    MessageBox.Show($"License Issue Successfully with License ID = {licenses.LicenseID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                else
                    MessageBox.Show($"License Issue Failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show($"Application failed to change from 'New' to 'Completed' !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
