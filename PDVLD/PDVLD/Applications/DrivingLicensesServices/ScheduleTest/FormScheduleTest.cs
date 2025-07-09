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

namespace PDVLD.Applications.DrivingLicensesServices.ScheduleTest
{
    public partial class FormScheduleTest: Form
    {
        public FormScheduleTest()
        {
            InitializeComponent();
        }
        int LDLAppID {get; set;}
        int TestTypeID { get; set; }
        int? TestAppointmentID { get; set; }
        // Add put number = 0  || edit put number = 1
        int AddOREdit = 0;

        DateTime? AppointmentDate { get; set; }
        public FormScheduleTest(int LDLAppID,string DrivingClass,string Name,int TestTypeID,int Mode,int? testAppointmentID, DateTime? appointmentDate)
        {
            InitializeComponent();
            this.LDLAppID = LDLAppID;
            this.TestTypeID = TestTypeID;
            this.TestAppointmentID = testAppointmentID;
            this.AppointmentDate = appointmentDate;

            FillForm(DrivingClass, Mode);

        }

         void FillForm(string DrivingClass, int Mode)
        {
            int? RetakeTestId = null;
            lblDLAppID.Text = LDLAppID.ToString();
            lblDClass.Text = DrivingClass;
            lblName.Text = Name;
            lblFees.Text = clsTestTypes.GetTestTypeID(TestTypeID).TestTypeFees.ToString();
            dateTimePicker1.Text = AppointmentDate.ToString();
            lblTrial.Text = clsTestAppointments.TestTrial(LDLAppID, TestTypeID).ToString();
            lblRAppFees.Text = "0";
            lblTotalFees.Text = (int.Parse(lblFees.Text) + int.Parse(lblRAppFees.Text)).ToString();
            if(TestAppointmentID != null)
                 RetakeTestId = clsTestAppointments.GetTestAppointmentID(TestAppointmentID.Value).RetakeTestApplicationID;
            lblRTestAppID.Text = RetakeTestId.HasValue ?  RetakeTestId.ToString() : "N/A";
            if (int.Parse(lblTrial.Text) > 0)
            {
                gbRetakeTest.Enabled = true;
                btnSave.Enabled = true;
                dateTimePicker1.Enabled = true;
                if (clsTestAppointments.GetTestAppointmentWithLDLApp(LDLAppID, 1).Rows.Count >= 1)
                    lblRAppFees.Text = clsApplicationTypes.GetApplicationTypeID(7).ApplicationFees.ToString();
                else
                    lblRAppFees.Text = "0";

                lblTotalFees.Text = (int.Parse(lblFees.Text) + int.Parse(lblRAppFees.Text)).ToString();

            }

            AddOREdit = Mode;
            if (TestAppointmentID != null)
                AlreadyBookedAppointment();
        }

        clsTestAppointments cls;
        void AlreadyBookedAppointment()
        {
            
            cls = clsTestAppointments.GetTestAppointmentID(TestAppointmentID.Value);
            if (AddOREdit == 1 && cls.IsLocked == true)
            {
                lblMessage.Text = "Person already sat for the test, appointment Locked";
                btnSave.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else if (AddOREdit == 1)
            {
                btnSave.Enabled = true;
                dateTimePicker1.Enabled = true;
                gbRetakeTest.Enabled = true;
            }
            
        }


        void Add()
        {
            if (int.Parse(lblTrial.Text) > 0)
                AddRetakeApp();

            clsTestAppointments appointments = new clsTestAppointments();
            appointments.TestTypeID = TestTypeID;
            appointments.LocalDrivingLicenseApplicationID = LDLAppID;
            appointments.AppointmentDate = dateTimePicker1.Value;
            appointments.PaidFees = Convert.ToSingle(lblFees.Text);
            appointments.CreatedByUserID = clsGlobal.UserID;
            appointments.IsLocked = false;
            if (applications.ApplicationID != null)
                appointments.RetakeTestApplicationID = applications.ApplicationID;
            else
                appointments.RetakeTestApplicationID = null;


            if (appointments.Save())
            {
                MessageBox.Show("Data Saved Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Data Failed To Saved!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void Update()
        {
            
            if (cls.IsLocked == true)
                return;

            clsTestAppointments testAppointments = new clsTestAppointments(TestAppointmentID.Value, null, null, dateTimePicker1.Value,
             null, null, null,null);

            if (testAppointments.Save())
            {
                MessageBox.Show("Data Updated Successfully !", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Data Updated Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddOREdit == 0)
                Add();
            else
                Update();

        }
        clsApplications applications = new clsApplications();
        void AddRetakeApp()
        {
            
            applications.ApplicantPersonID = clsApplications.GetApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(LDLAppID).ApplicationID.Value
                ).ApplicantPersonID;

            applications.ApplicationDate = DateTime.Now;
            applications.ApplicationTypeID = 7;
            applications.ApplicationStatus = 1;
            applications.LastStatusDate = DateTime.Now;
            applications.PaidFees = Convert.ToSingle(lblRAppFees.Text);
            applications.CreatedByUserID = clsGlobal.UserID;

            if (applications.Save())
                lblRTestAppID.Text = applications.ApplicationID.ToString();
            else
            {
                MessageBox.Show("Error Data failed in Retake test !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormScheduleTest_Load(object sender, EventArgs e)
        {
            
            switch (TestTypeID)
            {
                case 1:
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\Vision 512.png";
                    break;
                case 2:
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\Written Test 512.png";
                    break;
                case 3:
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\driving-test 512.png";
                    break;
                default:
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\Vision 512.png";
                    break;
            }

            dateTimePicker1.MinDate = DateTime.Now;
            
        }
    }
}
