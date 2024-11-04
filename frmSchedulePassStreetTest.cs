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
    public partial class frmSchedulePassStreetTest : Form
    {
        public frmSchedulePassStreetTest()
        {
            InitializeComponent();
        }

        public frmSchedulePassStreetTest(int TestAppointmentID, int AppID, string ClassName, string FullName, DateTime AppDate, int CreatedByUserID)
        {
            InitializeComponent();
            ctrlSchedulePassTest1.AppID = AppID;
            ctrlSchedulePassTest1.ClassName = ClassName;
            ctrlSchedulePassTest1.FullName = FullName;
            ctrlSchedulePassTest1.AppDate = AppDate;
            ctrlSchedulePassTest1.TestAppointmentID = TestAppointmentID;
            ctrlSchedulePassTest1.CreatedByUserID = CreatedByUserID;
            ctrlSchedulePassTest1.TestTypeID = 3;
            ctrlSchedulePassTest1.PaidFees = 30;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbPass.Checked)
            {
                clsApplicant.AddTest(ctrlSchedulePassTest1.TestAppointmentID, true, textBox1.Text, ctrlSchedulePassTest1.CreatedByUserID);
            }
            else if (rbFail.Checked)
            {
                clsApplicant.AddTest(ctrlSchedulePassTest1.TestAppointmentID, false, textBox1.Text, ctrlSchedulePassTest1.CreatedByUserID);
            }
            clsApplicant applicant = new clsApplicant(ctrlSchedulePassTest1.TestAppointmentID, ctrlSchedulePassTest1.TestTypeID,
                ctrlSchedulePassTest1.AppID, ctrlSchedulePassTest1.AppDate, ctrlSchedulePassTest1.PaidFees, ctrlSchedulePassTest1.CreatedByUserID, true);

            if (applicant.SaveTestApp())
            {
                MessageBox.Show("Data Saved Successfully !!", "Saved");

            }
            else
            {
                MessageBox.Show("Data Failed !!", "Saved");
            }
            ctrlSchedulePassTest1.UpdateStatusApplication();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
