using DriverLayoutControll;
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

namespace PDVLD.Applications.DrivingLicensesServices.International_License
{
    public partial class FormListInternationalLicenseApplication: Form
    {
        public FormListInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void FormListInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            dt = clsInternationalLicenses.GetInternationalLicense();

            dataGridView1.DataSource = dt;
            if(dt.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Int.License ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Application ID";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "Driver ID";
                dataGridView1.Columns[2].Width = 90;

                dataGridView1.Columns[3].HeaderText = "L.License ID";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Issue Date";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Expiration Date";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Is Active";
                dataGridView1.Columns[6].Width = 90;
            }
            cmbFilter.SelectedItem = "None";
            lblRecords.Text = dt.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterString = "";
            switch (cmbFilter.SelectedItem)
            {
                case "Int.License ID":
                    FilterString = "InternationalLicenseID";
                    break;

                case "Application ID":
                    FilterString = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterString = "DriverID";
                    break;

                case "L.License ID":
                    FilterString = "IssuedUsingLocalLicenseID";
                    break;
            }

            if(txtFilter.Text.Trim() == "")
            {
                FormListInternationalLicenseApplication_Load(null,null);
                return;
            }

            dt.DefaultView.RowFilter = string.Format("{0} = {1}", FilterString, txtFilter.Text);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "None")
                txtFilter.Visible = false;
            else
                txtFilter.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormInternationalLicense frm = new FormInternationalLicense();
            frm.ShowDialog();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowPerson frm = new FormShowPerson(clsApplications.GetApplicationID((int)dataGridView1.CurrentRow.Cells[1].Value).ApplicantPersonID.Value);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowInternationalLicenseInfo frm = new FormShowInternationalLicenseInfo((int)dataGridView1.CurrentRow.Cells[3].Value);
            frm.ShowDialog();
        }

        private void showPersonHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLicenseHistory frm = new FormLicenseHistory(
                clsApplications.GetApplicationID((int)dataGridView1.CurrentRow.Cells[1].Value).ApplicantPersonID.Value
                , (int)dataGridView1.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
    }
}
