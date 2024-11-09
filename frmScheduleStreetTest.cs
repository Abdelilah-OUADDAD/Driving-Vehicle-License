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
    public partial class frmScheduleStreetTest : Form
    {
        public frmScheduleStreetTest()
        {
            InitializeComponent();
        }
        public frmScheduleStreetTest( int AppID, string ClassName, string FullName, int CreatedByID, int TestAppointmentID ,
            bool IsEdit, bool IsSave)
        {
            InitializeComponent();

            ctrlScheduleTest1.IsEdit = IsEdit;
            ctrlScheduleTest1.IsSave = IsSave;
            ctrlScheduleTest1.TestAppointmentID = TestAppointmentID;
            ctrlScheduleTest1.AppID = AppID;
            ctrlScheduleTest1.ClassName = ClassName;
            ctrlScheduleTest1.FullName = FullName;
            ctrlScheduleTest1.CreatedByID = CreatedByID;
            ctrlScheduleTest1.TestTypeID = 3;
            ctrlScheduleTest1.PaidFees = 30;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
