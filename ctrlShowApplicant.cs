using DVLDControls;
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
    public partial class ctrlShowApplicant : UserControl
    {
        public ctrlShowApplicant()
        {
            InitializeComponent();
        }
        DataTable dataApplication;
        public delegate void DelegateEventBack(object sender,int AppID,string ClassName,string FullName,int CreatedByID);
        public event DelegateEventBack DataBack;
        public void FillDetailsApp(int LDLApp)
        {
            DataTable dataLDLAppview = clsApplicant.GetLocaleDrivingLicenseApplicationViewID(LDLApp);
            DataTable dataLDLApp = clsApplicant.GetLocaleDrivingLicenseApplicationID(LDLApp);
            dataApplication = clsApplicant.GetApplicationID((int)dataLDLApp.Rows[0][1]);

            //--- Fills LocalDrivingLicenseAppView
            lblAppID.Text = dataLDLAppview.Rows[0][0].ToString();
            lblLicense.Text = dataLDLAppview.Rows[0][1].ToString();
            lblPassedTest.Text = dataLDLAppview.Rows[0][5].ToString()+"/3";

            //---- Fills Application
            lblID.Text = dataApplication.Rows[0][0].ToString();
            lblFees.Text = dataApplication.Rows[0][6].ToString();
            lblType.Text = clsApplicant.GetApplicationTypesID((int)dataApplication.Rows[0][3]).Rows[0][1].ToString();
            DataTable dtFullName = clsPerson.GetPerson((int)dataApplication.Rows[0][1]);
            string FullName = dtFullName.Rows[0][2].ToString()+ " " + dtFullName.Rows[0][3].ToString() + " "+
                dtFullName.Rows[0][4].ToString() + " "+ dtFullName.Rows[0][5].ToString();
            lblApplicant.Text = FullName;
            lblDate.Text = dataApplication.Rows[0][2].ToString();
            lblStatusDate.Text = dataApplication.Rows[0][5].ToString();
            lblCreatedBy.Text = clsUser.GetUserPersonID((int)dataApplication.Rows[0][7]).Rows[0][2].ToString();

            switch (Convert.ToInt32(dataApplication.Rows[0][4]))
            {
                case 1:
                    lblStatus.Text = "New";
                    break;
                case 2:
                    lblStatus.Text = "Cancelled";
                    break;
                case 3:
                    lblStatus.Text = "Completed";
                    break;
            }
            DataBack?.Invoke(this, (int)dataLDLAppview.Rows[0][0], lblLicense.Text, FullName, (int)dataApplication.Rows[0][7]);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPersonDetails frm = new FormPersonDetails((int)dataApplication.Rows[0][1]);
            frm.ShowDialog();
        }
    }
}
