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
    public partial class frmScheduleWrittenTest : Form
    {
        public frmScheduleWrittenTest()
        {
            InitializeComponent();
        }

        public frmScheduleWrittenTest( int AppID, string ClassName, string FullName, int CreatedByID)
        {
            InitializeComponent();
            
            ctrlScheduleTest1.AppID = AppID;
            ctrlScheduleTest1.ClassName = ClassName;
            ctrlScheduleTest1.FullName = FullName;
            ctrlScheduleTest1.CreatedByID = CreatedByID;
            ctrlScheduleTest1.TestTypeID = 2;
            ctrlScheduleTest1.PaidFees = 20;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
