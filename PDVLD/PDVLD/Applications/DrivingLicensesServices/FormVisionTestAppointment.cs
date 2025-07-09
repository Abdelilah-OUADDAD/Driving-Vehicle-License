using DriverLayoutControll;
using PDVLD.Applications.DrivingLicensesServices.ScheduleTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PDVLD.Applications.DrivingLicensesServices
{
    public partial class FormVisionTestAppointment: Form
    {
        public FormVisionTestAppointment()
        {
            InitializeComponent();
        }
        int LDLAppID { get; set; }
        int TestTypeID { get; set; }
        string DrivingClass { get; set; }
        string Name { get; set; }
        public FormVisionTestAppointment(int LDLAppID,int TestTypeID)
        {
            InitializeComponent();
            this.LDLAppID = LDLAppID;
            this.TestTypeID = TestTypeID;
        }

        
        private void btnScheduleTest(object sender, EventArgs e)
        {
            if (clsTestAppointments.IsHaveTestAppointment(LDLAppID, TestTypeID))
            {

                MessageBox.Show("This Person Already Have a test Appointment", "Not Allowed", MessageBoxButtons.OK
                   , MessageBoxIcon.Error);
                return;
            }
                

            if (!clsTestAppointments.FindPassedTest(LDLAppID, TestTypeID))
            {

                FormScheduleTest frm = new FormScheduleTest(LDLAppID, DrivingClass, Name, TestTypeID, 0, null, null);
                frm.ShowDialog();
                FormVisionTestAppointment_Load(null, null);
                return;
            }
            else
                MessageBox.Show("This Person Already Passed this Test before, you can only retake failed test", "Not Allowed", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);


        }


        private void ctrlDrivingLicenseApplicationInfo1_OnLicenseDrivingManagement(int arg1, string arg2, string arg3)
        {
            LDLAppID = arg1;
            DrivingClass = arg2;
            Name = arg3;
        }

        void _LoadTitleAndTypeTest()
        {
            switch (TestTypeID)
            {
                case 1:
                    lblTitle.Text = "Vision Test Appointment";
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\Vision 512.png";
                    break;
                case 2:
                    lblTitle.Text = "Written Test Appointment";
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\Written Test 512.png";
                    break;
                case 3:
                    lblTitle.Text = "Written Test Appointment";
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\driving-test 512.png";
                    break;
                default:
                    lblTitle.Text = "Vision Test Appointment";
                    pbImageGeneral.ImageLocation = "C:\\Users\\Dell\\source\\repos\\PDVLD_Project\\PDVLD\\PDVLD\\Resources\\Vision 512.png";
                    break;
            }
        }

        private void FormVisionTestAppointment_Load(object sender, EventArgs e)
        {
            _LoadTitleAndTypeTest();
            if (LDLAppID > 0)
            {
                ctrlDrivingLicenseApplicationInfo1.FillInfoDrivingLicenseApp(LDLAppID);
            }

            DataTable data = clsTestAppointments.GetTestAppointmentWithLDLApp(LDLAppID, TestTypeID);
            dataGridView1.DataSource = data;
            if(data.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 150;

                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 90;

                dataGridView1.Columns[3].HeaderText = "Is Look";
                dataGridView1.Columns[3].Width = 60;

            }
            lblRecords.Text = data.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FormScheduleTest frm = new FormScheduleTest(LDLAppID, DrivingClass, Name, TestTypeID, 1, (int)dataGridView1.CurrentRow.Cells[0].Value
                , Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
            FormVisionTestAppointment_Load(null, null);
            
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(bool)dataGridView1.CurrentRow.Cells[3].Value)
            {
                FormTakeTest frm = new FormTakeTest(LDLAppID, DrivingClass, Name, TestTypeID, (int)dataGridView1.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                FormVisionTestAppointment_Load(null, null);
            }
            else
                MessageBox.Show("Test is Locked, Already do the test !","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
