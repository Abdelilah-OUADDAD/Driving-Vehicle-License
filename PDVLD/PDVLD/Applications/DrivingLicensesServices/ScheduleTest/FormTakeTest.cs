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
    public partial class FormTakeTest: Form
    {
        public FormTakeTest()
        {
            InitializeComponent();
        }
        int LDLAppID { get; set; }
        int TestTypeID { get; set; }
        int? TestAppointmentID { get; set; }
        // Add put number = 0  || edit put number = 1
        int AddOREdit = 0;
        public FormTakeTest(int LDLAppID, string DrivingClass, string Name, int TestTypeID, int? testAppointmentID)
        {
            InitializeComponent();

            this.LDLAppID = LDLAppID;
            this.TestTypeID = TestTypeID;
            this.TestAppointmentID = testAppointmentID;

            FillForm(DrivingClass);
        }

        void FillForm(string DrivingClass)
        {
            lblDLAppID.Text = LDLAppID.ToString();
            lblDClass.Text = DrivingClass;
            lblName.Text = Name;
            lblFees.Text = clsTestTypes.GetTestTypeID(TestTypeID).TestTypeFees.ToString();
            lblDate.Text = clsUtil.DateTimeString( clsTestAppointments.GetTestAppointmentID(TestAppointmentID.Value).AppointmentDate.Value);
            lblTrial.Text = clsTestAppointments.TestTrial(LDLAppID, TestTypeID).ToString();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTest test = new clsTest();
            test.TestAppointmentID = TestAppointmentID;
            if (rbPass.Checked)
                test.TestResult = true;
            else
                test.TestResult = false;

            test.Notes = txtNotes.Text;
            test.CreatedByUserID = clsGlobal.UserID;

            if ((MessageBox.Show("Are you sure you want to save? After that you cannot change the pass/fail result after you save"
                , "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) && test.Save())
            {
                lblTestID.Text = test.TestID.ToString();

                if (clsTestAppointments.UpdateTestAppointmentLocked(TestAppointmentID.Value, true))
                {
                    MessageBox.Show("Data Saved Successfully !", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Data Failed to Saved !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTakeTest_Load(object sender, EventArgs e)
        {
            rbPass.Checked = true;

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
        }
    }
}
