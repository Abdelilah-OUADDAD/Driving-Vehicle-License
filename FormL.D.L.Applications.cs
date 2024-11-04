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
    public partial class FormL : Form
    {
        public FormL()
        {
            InitializeComponent();

        }

        private void FormL_Load(object sender, EventArgs e)
        {
            _FillCombo();
            dataGridView1.DataSource = clsApplicant.GetLocaleDrivingLicenseApplicationView();
        }

        private void _FillCombo()
        {
            cmbFilter.Items.Add("None");
            cmbFilter.Items.Add("L.D.L.AppID");
            cmbFilter.Items.Add("Class Name");
            cmbFilter.Items.Add("National No");
            cmbFilter.Items.Add("FullName");
            cmbFilter.Items.Add("Application Date");
            cmbFilter.Items.Add("Passed Test Count");
            cmbFilter.Items.Add("Status");

            cmbFilter.SelectedItem = "None";
        }


        

        private void FilterText(DataTable data, int Col)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("L.D.L.AppID");
            dt.Columns.Add("Class Name");
            dt.Columns.Add("National No");
            dt.Columns.Add("FullName");
            dt.Columns.Add("Application Date");
            dt.Columns.Add("Passed Test Count");
            dt.Columns.Add("Status");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][Col].ToString().ToLower().StartsWith(textBox1.Text.ToLower()))
                {
                    dt.Rows.Add(data.Rows[i]["LocalDrivingLicenseApplicationID"], data.Rows[i]["ClassName"], data.Rows[i]["NationalNo"], data.Rows[i]["FullName"],
                        data.Rows[i]["ApplicationDate"], data.Rows[i]["PassedTestCount"], data.Rows[i]["Status"]);
                }
            }
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable data = clsApplicant.GetLocaleDrivingLicenseApplicationView();

            switch (cmbFilter.Text)
            {
                case "None":
                    break;
                case "L.D.L.AppID":
                    FilterText(data, 0);
                    break;
                case "Class Name":
                    FilterText(data, 1);
                    break;
                case "National No":
                    FilterText(data, 2);
                    break;
                case "FullName":
                    FilterText(data, 3);
                    break;
                case "Application Date":
                    FilterText(data, 4);
                    break;
                case "Passed Test Count":
                    FilterText(data, 5);
                    break;
                case "Status":
                    FilterText(data, 6);
                    break;
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.Text != "None")
            {
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
            }
        }

        private void showDetailsApplicantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowApplicant form = new FormShowApplicant((int)dataGridView1.CurrentRow.Cells[0].Value);
            form.ShowDialog();
        }

        private void scheduleVisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scheduleVisionToolStripMenuItem.Enabled = true;
            frmVisionTestAppointment frm = new frmVisionTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FormL_Load(sender, e);
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            scheduleToolStripMenuItem.Enabled = true;
            frmWrittenTestAppointment frm = new frmWrittenTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FormL_Load(sender, e);            
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStreetTestAppointment frm = new frmStreetTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FormL_Load(sender, e);
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIssueDriverLicenseFirstTime frm = new FormIssueDriverLicenseFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        DataTable dtLocalview;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtLocalview = clsApplicant.GetLocaleDrivingLicenseApplicationViewID((int)dataGridView1.CurrentRow.Cells[0].Value);
            if ((int)dtLocalview.Rows[0]["PassedTestCount"] == 3)
            {
                scheduleTestToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                deletApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                DataTable dtLDLApp = clsApplicant.GetLocaleDrivingLicenseApplicationID((int)dataGridView1.CurrentRow.Cells[0].Value);
                if (clsApplicant.FindLicense((int)dtLDLApp.Rows[0]["ApplicationID"]) == true)
                {
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                }
                else
                {
                    issueDrivingLicenseToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                scheduleTestToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                deletApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = false;
                if ((int)dtLocalview.Rows[0]["PassedTestCount"] == 0)
                {
                    scheduleVisionToolStripMenuItem.Enabled = true;
                    scheduleToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                }
                else
                {
                    if ((int)dtLocalview.Rows[0]["PassedTestCount"] == 1)
                    {
                        scheduleToolStripMenuItem.Enabled = true;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        scheduleVisionToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        if ((int)dtLocalview.Rows[0]["PassedTestCount"] == 2)
                        {
                            scheduleStreetTestToolStripMenuItem.Enabled = true;
                            scheduleVisionToolStripMenuItem.Enabled = false;
                            scheduleToolStripMenuItem.Enabled = false;
                            issueDrivingLicenseToolStripMenuItem.Enabled = false;
                            showLicenseToolStripMenuItem.Enabled = false;
                        }
                            
                    }
                }
            }
            


        }

        
        private void scheduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FormLicenseHistory frm = new FormLicenseHistory((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }
    }
}
