using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverLayoutControll;
using DriverLayoutControl;
using PDVLD.People.Controle;

namespace PDVLD.Applications.DrivingLicensesServices.Control
{
    public partial class ctrlDrivingLicenseApplicationInfo: UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public event Action<int, string, string> OnLicenseDrivingManagement;

        int PersonID { get; set; }
        public void FillInfoDrivingLicenseApp(int lDLAppID)
        {
           
            clsLocalDrivingLicenseApplications clsLocal = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(lDLAppID);

            
            lblDLAppID.Text = clsLocal.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = clsLicenseClass.GetLicenseClassID(clsLocal.LicenseClassID.Value).ClassName ;
            lblPassedTests.Text = clsTestAppointments.CountPassedTest(lDLAppID).ToString() + "/3";
            clsApplications applications = clsApplications.GetApplicationID(clsLocal.ApplicationID.Value);

            lblID.Text = applications.ApplicationID.ToString();
            lblFees.Text = applications.PaidFees.ToString();
            lblType.Text = clsApplicationTypes.GetApplicationTypeID(applications.ApplicationTypeID.Value).ApplicationTypeTitle;
            lblApplicant.Text = clsPeople.GetPeopleID( applications.ApplicantPersonID.Value).FullName;
            lblDate.Text = applications.ApplicationDate.ToString();
            lblStatusDate.Text = applications.LastStatusDate.ToString();
            lblCreatedBy.Text = clsUsers.GetUsersID( applications.CreatedByUserID.Value).UserName;

            switch (applications.ApplicationStatus.Value)
            {
                case 1:
                    lblStatus.Text = "New";
                    break;

                case 2:
                    lblStatus.Text = "Canceled";
                    break;

                default:
                    lblStatus.Text = "Completed";
                    break;
            }

            PersonID = applications.ApplicantPersonID.Value;

            if (OnLicenseDrivingManagement != null)
                OnLicenseDrivingManagement(lDLAppID, lblAppliedForLicense.Text, lblApplicant.Text);
        }

        private void LinkLabelPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormShowPerson frm = new FormShowPerson(PersonID);
            frm.ShowDialog();
        }
    }
}
