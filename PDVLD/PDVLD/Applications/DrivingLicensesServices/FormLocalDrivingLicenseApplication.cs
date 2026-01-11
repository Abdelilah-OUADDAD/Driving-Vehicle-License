using DriverLayoutControl;
using DriverLayoutControll;
using PDVLD.People;
using PDVLD.People.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Applications.DrivingLicensesServices
{
    public partial class FormLocalDrivingLicenseApplication: Form
    {
        public FormLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void FormLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            dt = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsView();
            dataGridView1.DataSource = dt;

            if (dt.Rows.Count != 0)
            {
                dataGridView1.Columns[0].HeaderText = "L.D.L.AppID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Driving Class";
                dataGridView1.Columns[1].Width = 190;

                dataGridView1.Columns[2].HeaderText = "National No.";
                dataGridView1.Columns[2].Width = 90;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 190;

                dataGridView1.Columns[4].HeaderText = "Application Date";
                dataGridView1.Columns[4].Width = 110;

                dataGridView1.Columns[5].HeaderText = "Passed Tests";
                dataGridView1.Columns[5].Width = 90;

                dataGridView1.Columns[6].HeaderText = "Status";
                dataGridView1.Columns[6].Width = 70;
            }

            lblRecord.Text = dt.Rows.Count.ToString();
            cmbFilter.SelectedItem = "None";
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbFilter.SelectedItem.ToString() == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterText = "";

            switch (cmbFilter.SelectedItem)
            {
                case "L.D.L.AppID":
                    FilterText = "LocalDrivingLicenseApplicationID";
                    break;

                case "FullName":
                    FilterText = "FullName";
                    break;

                case "Status":
                    FilterText = "Status";
                    break;

                default:
                    FilterText = "None";
                    break;
            }

            if(txtFilter.Text.Trim() == "" || FilterText == "None")
            {
                dt = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsView();
                dataGridView1.DataSource = dt;
                return;
            }

            if (FilterText == "LocalDrivingLicenseApplicationID")
                dt.DefaultView.RowFilter = string.Format("{0} = {1}", FilterText, txtFilter.Text);
            else
                dt.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterText, txtFilter.Text);


        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() != "None")
                txtFilter.Visible = true;
            else
                txtFilter.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddLocalLicense frm = new FormAddLocalLicense();
            frm.ShowDialog();
            FormLocalDrivingLicenseApplication_Load(null, null);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplications clsCancel = clsApplications.IsCompleted((int)dataGridView1.CurrentRow.Cells[0].Value);
            if (clsCancel == null)
                return;

            clsCancel.ApplicationStatus = 2;

            if (clsCancel.Save())
                MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Application Failed To cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            FormLocalDrivingLicenseApplication_Load(null, null);
        }

        
        private void scheduleVesionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVisionTestAppointment frm = new FormVisionTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value,1);
            frm.ShowDialog();
            FormLocalDrivingLicenseApplication_Load(null, null);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVisionTestAppointment frm = new FormVisionTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value, 2);
            frm.ShowDialog();
            FormLocalDrivingLicenseApplication_Load(null, null);
        }

        private void scheduleStreetTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormVisionTestAppointment frm = new FormVisionTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value, 3);
            frm.ShowDialog();
            FormLocalDrivingLicenseApplication_Load(null, null);
        }

        private void showApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowPerson frm = new FormShowPerson(clsApplications.GetApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(
                (int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID.Value).ApplicantPersonID.Value);
            frm.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddLocalLicense frm = new FormAddLocalLicense(clsApplications.GetApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(
                (int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID.Value).ApplicantPersonID.Value,
                (int)dataGridView1.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            FormLocalDrivingLicenseApplication_Load(null, null);

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do you want delete Local Driving Application", "Allow", MessageBoxButtons.YesNoCancel
                    , MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplication((int)dataGridView1.CurrentRow.Cells[0].Value))
                {                
                    MessageBox.Show("Deleted Successfully !!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Deleted Failed !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("You cannot delete this LocalDriveApp ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Cancelled")
            {
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
                issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                return;
            }
            if (clsLicenses.GetLicensesWithApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(
                    (int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID.Value) != null)
            {
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                scheduleTestToolStripMenuItem.Enabled = false;
                issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;
            }
            else
            {
                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                scheduleTestToolStripMenuItem.Enabled = true;
                issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;

                switch (clsTestAppointments.CountPassedTest((int)dataGridView1.CurrentRow.Cells[0].Value).Value)
                {
                    case 0:
                        scheduleVesionTestToolStripMenuItem.Enabled = true;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem1.Enabled = false;
                        break;
                    case 1:
                        scheduleVesionTestToolStripMenuItem.Enabled = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = true;
                        scheduleStreetTestToolStripMenuItem1.Enabled = false;
                        break;
                    case 2:
                        scheduleVesionTestToolStripMenuItem.Enabled = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem1.Enabled = true;
                        break;
                    default:
                        scheduleTestToolStripMenuItem.Enabled = false;
                        issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = true;
                        break;
                }

            }
        }

        private void issueDrivingLicensefirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIssueDrivingLicense frm = new FormIssueDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FormLocalDrivingLicenseApplication_Load(null, null);

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormShowLicenseInfo frm = new FormShowLicenseInfo(clsLicenses.GetLicensesWithApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(
                (int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID.Value).LicenseID.Value);
            frm.ShowDialog();
        }

        private void showPersonHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLicenseHistory frm = new FormLicenseHistory( clsApplications.GetApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(
                (int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID.Value).ApplicantPersonID.Value
                ,
                clsLicenses.GetLicensesWithApplicationID(
                clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(
                (int)dataGridView1.CurrentRow.Cells[0].Value).ApplicationID.Value).DriverID.Value);

            frm.ShowDialog();
        }
    }
}
