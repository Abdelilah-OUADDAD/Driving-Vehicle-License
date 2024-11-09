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
    public partial class frmInternationalLicenseInfo : Form
    {
        public frmInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void FillInterDrivingInfo(int InterLicenseID, int ApplicationID, int LicenseID)
        {
            ctrlDriverInterLicenseInfo1.ApplicationID = ApplicationID;
            ctrlDriverInterLicenseInfo1.LicenseID = LicenseID;
            ctrlDriverInterLicenseInfo1.InterLicenseID = InterLicenseID;
            ctrlDriverInterLicenseInfo1.FillInterDrivingInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
