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
    public partial class ctrlScheduleTest : UserControl
    {
       
        public int AppID { get; set; }
        public string ClassName { get; set; }
        public string FullName { get; set; }
        public int CreatedByID { get; set; }
        public int TestTypeID { get; set; }
        public int PaidFees { get; set; }
        public ctrlScheduleTest()
        {
            InitializeComponent();
            
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplicant applicant = new clsApplicant();
            applicant.TestTypeID = this.TestTypeID;
            applicant.LocalDrivingLicenseApplicationID = AppID;
            applicant.AppointmentDate = dateTimePicker1.Value;
            applicant.PaidFees = this.PaidFees;
            applicant.CreatedByUserID = this.CreatedByID;
            applicant.IsLocked = false;
            if (applicant.SaveTestApp())
            {
                MessageBox.Show("Data Saved Successfully !!", "Saved");
            }
            else
            {
                MessageBox.Show("Data Failed !!", "Saved");
            }
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
            int countTrial = 0;
            lblAppID.Text = AppID.ToString();
            lblDClass.Text = ClassName;
            lblName.Text = FullName;
            lblFees.Text = this.PaidFees.ToString();
            dateTimePicker1.MinDate = DateTime.Now;


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
    }
}
