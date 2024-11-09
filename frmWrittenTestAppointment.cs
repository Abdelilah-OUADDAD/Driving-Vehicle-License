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
    public partial class frmWrittenTestAppointment : Form
    {
        public frmWrittenTestAppointment()
        {
            InitializeComponent();
        }

        public frmWrittenTestAppointment(int LDLApplicant)
        {
            InitializeComponent();
            ctrlShowApplicant1.DataBack += FormLoad_Data;
            ctrlShowApplicant1.FillDetailsApp(LDLApplicant);
        }
        int AppID { get; set; }
        string ClassName { get; set; }
        string FullName { get; set; }
        int CreatedByID { get; set; }
        private void FormLoad_Data(object sender, int AppID, string ClassName, string FullName, int CreatedByID)
        {
            this.AppID = AppID;
            this.ClassName = ClassName;
            this.FullName = FullName;
            this.CreatedByID = CreatedByID;
        }
        DataTable dtTestApp;
        private void _FillDataGrid()
        {
            dtTestApp = clsApplicant.GetTestAppointments();
            DataTable dtChose = new DataTable();

            dtChose.Columns.Add("TestAppointmentID", typeof(int));
            dtChose.Columns.Add("AppointmentDate", typeof(DateTime));
            dtChose.Columns.Add("PaidFees", typeof(double));
            dtChose.Columns.Add("IsLocked", typeof(bool));
            foreach (DataRow row in dtTestApp.Rows)
            {
                if ((int)row[1] == 2 && (int)row[2] == AppID)
                    dtChose.Rows.Add(row[0], row[3], row[4], row[6]);
            }
            dataGridView1.DataSource = dtChose;
            lblRecord.Text = dtChose.Rows.Count.ToString();
        }

        private void frmWrittenTestAppointment_Load(object sender, EventArgs e)
        {
            _FillDataGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmScheduleWrittenTest frm = new frmScheduleWrittenTest(AppID, ClassName, FullName, CreatedByID, -1, false,true);
            frm.ShowDialog();
            _FillDataGrid();
        }

        private void taskTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((bool)dataGridView1.CurrentRow.Cells[3].Value == false)
            {
                frmSchedulePassWrittenTest frm = new frmSchedulePassWrittenTest((int)dataGridView1.CurrentRow.Cells[0].Value, AppID, ClassName, FullName,
                    (DateTime)dataGridView1.CurrentRow.Cells[1].Value, CreatedByID);
                frm.ShowDialog();
                _FillDataGrid();
                ctrlShowApplicant1.FillDetailsApp(AppID);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleWrittenTest frm = new frmScheduleWrittenTest(AppID, ClassName, FullName, CreatedByID,
                (int)dataGridView1.CurrentRow.Cells[0].Value,  true, false);
            frm.ShowDialog();
            _FillDataGrid();
        }
    }
}
