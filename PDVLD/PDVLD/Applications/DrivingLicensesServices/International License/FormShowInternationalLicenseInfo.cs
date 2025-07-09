using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Applications.DrivingLicensesServices.International_License
{
    public partial class FormShowInternationalLicenseInfo: Form
    {
        public FormShowInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public FormShowInternationalLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            ctrlInternationalLicenseInfo1.FillDate(LicenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
