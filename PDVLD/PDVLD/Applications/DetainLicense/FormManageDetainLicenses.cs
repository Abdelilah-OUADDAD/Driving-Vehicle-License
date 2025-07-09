using DriverLayoutControll;
using PDVLD.Applications.DrivingLicensesServices;
using PDVLD.People.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Applications.DetainLicense
{
    public partial class FormManageDetainLicenses: Form
    {
        public FormManageDetainLicenses()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void FormManageDetainLicenses_Load(object sender, EventArgs e)
        {
            
            dt = clsDetainedLicenses.GetAllDetainedLicensesView();
            dataGridView1.DataSource = dt;
            if(dt.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "D.ID";
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].HeaderText = "L.ID";
                dataGridView1.Columns[1].Width = 80;

                dataGridView1.Columns[2].HeaderText = "D.Date";
                dataGridView1.Columns[2].Width = 180;

                dataGridView1.Columns[3].HeaderText = "Is Release";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Fine Fees";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Release Date";
                dataGridView1.Columns[5].Width = 180;

                dataGridView1.Columns[6].HeaderText = "N.NO";
                dataGridView1.Columns[6].Width = 80;

                dataGridView1.Columns[7].HeaderText = "Full Name";
                dataGridView1.Columns[7].Width = 200;

                dataGridView1.Columns[8].HeaderText = "Release.App.ID";
                dataGridView1.Columns[8].Width = 130;

            }
            lblRecords.Text = dt.Rows.Count.ToString();
            cmbFilter.SelectedItem = "None";
            cmbTrueFalse.SelectedItem = "None";
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterString = "";
            switch (cmbFilter.SelectedItem)
            {
                case "DetainID":
                    FilterString = "DetainID";
                    break;
                case "National No":
                    FilterString = "NationalNo";
                    break;
                case "Full Name":
                    FilterString = "FullName";
                    break;
                case "Release Application ID":
                    FilterString = "ReleaseApplicationID";
                    break;
                default:
                    FilterString = "None";
                    break;
            }

            if(FilterString == "None" || txtFilter.Text.Trim() == "")
            {
                dt = clsDetainedLicenses.GetAllDetainedLicensesView();
                dataGridView1.DataSource = dt;
                return;
            }

            if (FilterString == "DetainID" || FilterString == "ReleaseApplicationID")
                dt.DefaultView.RowFilter = string.Format("{0} = {1}", FilterString , txtFilter.Text);
            else
                dt.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterString, txtFilter.Text);



        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "Is Released")
            {
                txtFilter.Visible = false;
                cmbTrueFalse.Visible = true;
            }
            else if (cmbFilter.SelectedItem.ToString() == "None")
            {
                txtFilter.Visible = false;
                cmbTrueFalse.Visible = false;
                dt = clsDetainedLicenses.GetAllDetainedLicensesView();
                dataGridView1.DataSource = dt;
            }
            else
            {
                txtFilter.Visible = true;
                cmbTrueFalse.Visible = false;
            }

        }

        private void cmbTrueFalse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTrueFalse.SelectedItem.ToString() == "Yes" )
                dt.DefaultView.RowFilter = string.Format("{0} = {1}", "IsReleased", true);
            else if(cmbTrueFalse.SelectedItem.ToString() == "No")
                dt.DefaultView.RowFilter = string.Format("{0} = {1}", "IsReleased", false);

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            FormDetainLicenses frm = new FormDetainLicenses();
            frm.ShowDialog();
            FormManageDetainLicenses_Load(null, null);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            FormRealeseDetainedLicense frm = new FormRealeseDetainedLicense();
            frm.ShowDialog();
            FormManageDetainLicenses_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (clsDetainedLicenses.CheckIsDetained((int)dataGridView1.CurrentRow.Cells[1].Value))
                releaseDetainLicenseToolStripMenuItem.Enabled = true;
            else
                releaseDetainLicenseToolStripMenuItem.Enabled = false;
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowPerson frm = new FormShowPerson(clsApplications.GetApplicationID(
                clsLicenses.GetLicenseID((int)dataGridView1.CurrentRow.Cells[1].Value).ApplicationID.Value).ApplicantPersonID.Value);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowLicenseInfo frm = new FormShowLicenseInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLicenses clslicense = clsLicenses.GetLicenseID((int)dataGridView1.CurrentRow.Cells[1].Value);
            FormLicenseHistory frm = new FormLicenseHistory(
                clsApplications.GetApplicationID(clslicense.ApplicationID.Value).ApplicantPersonID.Value
                , clslicense.DriverID.Value);
            frm.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRealeseDetainedLicense frm = new FormRealeseDetainedLicense((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            FormManageDetainLicenses_Load(null, null);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() ==  "DetainID" || cmbFilter.SelectedItem.ToString() == "Release Application ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
