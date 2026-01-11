using DriverLayoutControl;
using PDVLD.Applications.DetainLicense;
using PDVLD.Applications.DrivingLicensesServices;
using PDVLD.Applications.DrivingLicensesServices.International_License;
using PDVLD.Applications.DrivingLicensesServices.RemplacementForDamageOrLost;
using PDVLD.Applications.DrivingLicensesServices.RenewDrivingLicense;
using PDVLD.Applications.ManageApplicationTypes;
using PDVLD.Applications.TestTypes;
using PDVLD.Drivers;
using PDVLD.Global;
using PDVLD.People;
using PDVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD
{
    public partial class Main: Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nullable<int> PersonID = clsUsers.GetUsersWithUserName(clsGlobal.UserName).PersonID;
            FormUserInfo frm = new FormUserInfo(PersonID.Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nullable<int> PersonID = clsUsers.GetUsersWithUserName(clsGlobal.UserName).PersonID;
            FormChangePassword frm = new FormChangePassword(PersonID.Value);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPeople frm = new FormPeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageUsers frm = new FormManageUsers();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageApplicationType frm = new FormManageApplicationType();
            frm.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageTestTypes frm = new FormManageTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddLocalLicense frm = new FormAddLocalLicense();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLocalDrivingLicenseApplication frm = new FormLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageDriver frm = new FormManageDriver();
            frm.ShowDialog();
        }

        private void internationnalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInternationalLicense frm = new FormInternationalLicense();
            frm.ShowDialog();
        }

        private void internationnalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListInternationalLicenseApplication frm = new FormListInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRenewDrivingLicense frm = new FormRenewDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDammageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDamageOrLostLicense frm = new FormDamageOrLostLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDetainLicenses frm = new FormDetainLicenses();
            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRealeseDetainedLicense frm = new FormRealeseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageDetainLicenses frm = new FormManageDetainLicenses();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLocalDrivingLicenseApplication frm = new FormLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRealeseDetainedLicense frm = new FormRealeseDetainedLicense();
            frm.ShowDialog();
        }
    }
}
