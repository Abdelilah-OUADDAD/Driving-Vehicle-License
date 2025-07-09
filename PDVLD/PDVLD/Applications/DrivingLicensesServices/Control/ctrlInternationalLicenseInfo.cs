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

namespace PDVLD.Applications.DrivingLicensesServices.Control
{
    public partial class ctrlInternationalLicenseInfo: UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void FillDate(int LicenseID)
        {
            clsLicenses licenses = clsLicenses.GetLicenseID(LicenseID);
            clsPeople people = clsPeople.GetPeopleID(clsApplications.GetApplicationID(licenses.ApplicationID.Value).ApplicantPersonID.Value);
            clsInternationalLicenses InterLicense = clsInternationalLicenses.GetInternationalLicenseLocalID(LicenseID);

            lblName.Text = people.FullName;
            lblIntLicenseID.Text = InterLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = people.NationalNo;
            lblGendor.Text = people.Gendor == 0?"Male":"Female";
            lblIssueDate.Text = InterLicense.IssueDate.ToString();
            lblAppID.Text = InterLicense.ApplicationID.ToString();
            lblIsActive.Text = InterLicense.IsActive.ToString();
            lblDateOfBirth.Text = people.DateOfBirth.ToString();
            lblDriverID.Text = licenses.DriverID.ToString();
            lblExpirationDate.Text = InterLicense.ExpirationDate.ToString();
            pbImage.ImageLocation = people.ImagePath;
        }
    }
}
