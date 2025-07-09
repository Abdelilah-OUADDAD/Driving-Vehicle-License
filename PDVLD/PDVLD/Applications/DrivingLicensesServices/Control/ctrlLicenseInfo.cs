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
    public partial class ctrlLicenseInfo: UserControl
    {
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        public void FillData(int LicenseID)
        {
            clsLicenses licenses = clsLicenses.GetLicenseID(LicenseID);
            if (licenses != null)
            {
                lblClassName.Text = clsLicenseClass.GetLicenseClassID(licenses.LicenseClass.Value).ClassName;
                clsPeople people = clsPeople.GetPeopleID(clsApplications.GetApplicationID(licenses.ApplicationID.Value).ApplicantPersonID.Value);
                lblName.Text = people.FullName;
                lblLicenseID.Text = LicenseID.ToString();
                lblNationalNo.Text = people.NationalNo;
                lblGendor.Text = people.Gendor is 0 ? "Male" : "Female";
                lblIssueDate.Text = licenses.IssueDate.ToString();
                lblIssueReason.Text = clsApplicationTypes.IssueReasonTypes(licenses.IssueReason.Value);
                lblNotes.Text = licenses.Notes == "" ? "No Notes" : licenses.Notes;
                lblIsActive.Text = licenses.IsActive is true ? "Yes" : "No";
                lblDateOfBirth.Text = people.DateOfBirth.ToString();
                lblDriverID.Text = licenses.DriverID.ToString();
                lblExpirationDate.Text = licenses.ExpirationDate.ToString();

                clsDetainedLicenses cls = clsDetainedLicenses.GetDetainedWithLicenseID(LicenseID);
                lblIsDetained.Text = cls == null
                                        ? "No" : (cls.IsReleased as bool? == true ? "No" : "Yes");

                pbImage.ImageLocation = people.ImagePath;
            }
            else
            {
                EmptyData();
                MessageBox.Show("License ID Is Not Found !", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EmptyData()
        {
            lblClassName.Text = "[???]";
            lblName.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGendor.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblIssueReason.Text = "[???]";
            lblNotes.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblIsDetained.Text = "[???]";
            pbImage.ImageLocation = "[???]";
        }
    }
}
