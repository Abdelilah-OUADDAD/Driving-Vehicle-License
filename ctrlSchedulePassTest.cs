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
    public partial class ctrlSchedulePassTest : UserControl
    {
        public int AppID { get; set; }
        public int TestAppointmentID { get; set; }
        public string ClassName { get; set; }
        public string FullName { get; set; }
        public DateTime AppDate { get; set; }
        public int CreatedByUserID { get; set; }
        public int TestTypeID { get; set; }
        public double PaidFees { get; set; }

        public ctrlSchedulePassTest()
        {
            InitializeComponent();
        }

        private void ctrlSchedulePassTest_Load(object sender, EventArgs e)
        {
            int countTrial = 0;
            lblAppID.Text = AppID.ToString();
            lblDClass.Text = ClassName;
            lblName.Text = FullName;
            lblFees.Text = this.PaidFees.ToString();
            lblDate.Text = AppDate.ToString();
            lblTestID.Text = "Not Taken Yet";

            DataTable dt = clsApplicant.GetTestAppointments();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)dt.Rows[i]["TestTypeID"] == this.TestTypeID)
                {
                    if ((int)dt.Rows[i]["LocalDrivingLicenseApplicationID"] == AppID && (bool)dt.Rows[i]["IsLocked"] == true)
                    {
                        countTrial++;
                    }

                }
            }
            
            lblTrial.Text = countTrial.ToString();
        }

        public void UpdateStatusApplication()
        {
            DataTable data = clsApplicant.GetLocaleDrivingLicenseApplicationView();
            DataTable dataLocaleDrivingLicenseApplication = clsApplicant.GetLocaleDrivingLicenseApplicationID(this.AppID);
            DataTable dataApplicant = clsApplicant.GetApplicationID((int)dataLocaleDrivingLicenseApplication.Rows[0]["ApplicationID"]);
           // clsApplicant cls;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ( (int)data.Rows[i]["PassedTestCount"] == 1 && (int)data.Rows[i]["LocalDrivingLicenseApplicationID"] == this.AppID)
                {
                    clsApplicant cls = new clsApplicant(Convert.ToInt32(dataApplicant.Rows[0]["ApplicationID"]), Convert.ToInt32(dataApplicant.Rows[0]["ApplicantPersonID"]), Convert.ToDateTime(dataApplicant.Rows[0]["ApplicationDate"]),
                    Convert.ToInt32(dataApplicant.Rows[0]["ApplicationTypeID"]), 1, Convert.ToDateTime(dataApplicant.Rows[0]["LastStatusDate"]), Convert.ToDouble(dataApplicant.Rows[0]["PaidFees"]),
                    Convert.ToInt32(dataApplicant.Rows[0]["CreatedByUserID"]));
                    cls.Save();
                }
                else if ( (int)data.Rows[i]["PassedTestCount"] == 2  &&  (int)data.Rows[i]["LocalDrivingLicenseApplicationID"] == this.AppID)
                {
                    clsApplicant cls = new clsApplicant(Convert.ToInt32(dataApplicant.Rows[0]["ApplicationID"]), Convert.ToInt32(dataApplicant.Rows[0]["ApplicantPersonID"]), Convert.ToDateTime(dataApplicant.Rows[0]["ApplicationDate"]),
                    Convert.ToInt32( dataApplicant.Rows[0]["ApplicationTypeID"]), 2, Convert.ToDateTime(dataApplicant.Rows[0]["LastStatusDate"]), Convert.ToDouble(dataApplicant.Rows[0]["PaidFees"]),
                    Convert.ToInt32( dataApplicant.Rows[0]["CreatedByUserID"]));
                    cls.Save();
                }
                else if ( (int)data.Rows[i]["PassedTestCount"] == 3 && (int)data.Rows[i]["LocalDrivingLicenseApplicationID"] == this.AppID)
                {
                    clsApplicant cls = new clsApplicant(Convert.ToInt32(dataApplicant.Rows[0]["ApplicationID"]), Convert.ToInt32(dataApplicant.Rows[0]["ApplicantPersonID"]), Convert.ToDateTime(dataApplicant.Rows[0]["ApplicationDate"]),
                    Convert.ToInt32(dataApplicant.Rows[0]["ApplicationTypeID"]), 3, Convert.ToDateTime(dataApplicant.Rows[0]["LastStatusDate"]), Convert.ToDouble(dataApplicant.Rows[0]["PaidFees"]),
                    Convert.ToInt32(dataApplicant.Rows[0]["CreatedByUserID"]));
                    cls.Save();
                }
            }

        }
    }
}
