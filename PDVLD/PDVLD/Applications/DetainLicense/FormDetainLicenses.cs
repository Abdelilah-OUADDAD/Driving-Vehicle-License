using DriverLayoutControll;
using PDVLD.Applications.DrivingLicensesServices;
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

namespace PDVLD.Applications.DetainLicense
{
    public partial class FormDetainLicenses: Form
    {
        public FormDetainLicenses()
        {
            InitializeComponent();
        }

        int? LicenseID { get; set; }
        private void FormDetainLicenses_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = clsGlobal.UserName;
        }

        private void ctrlLicenseInfoWithFilter1_OnDetainChangeWithoutLicense(object sender, EventArgs e)
        {
            lblLicenseID.Text = "[???]";
            btnDetain.Enabled = false;
            linkLabelHistoryLicense.Enabled = false;
            LicenseID = null;
            txtFees.Enabled = false;
        }

        private void ctrlLicenseInfoWithFilter1_OnDetainChange(int arg1, bool arg2)
        {
            LicenseID = arg1;
            lblLicenseID.Text = arg1.ToString();
            btnDetain.Enabled = arg2;
            linkLabelHistoryLicense.Enabled = true;
            txtFees.Enabled = arg2;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {
                clsDetainedLicenses detained = new clsDetainedLicenses();
                detained.LicenseID = LicenseID;
                detained.DetainDate = DateTime.Now;
                detained.FineFees = Convert.ToSingle(txtFees.Text);
                detained.CreatedByUserID = clsGlobal.UserID;
                detained.IsReleased = false;
                detained.ReleaseDate = null;
                detained.ReleasedByUserID = null;
                detained.ReleaseApplicationID = null;

                if (MessageBox.Show("Are you sure you want to detain this License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (detained.Save())
                    {
                        MessageBox.Show($"License Detained Successfully with ID = {detained.DetainID}", "Lisence Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblDetainID.Text = detained.DetainID.ToString();
                        btnDetain.Enabled = false;
                        linkLabelNewLicense.Enabled = true;
                        ctrlLicenseInfoWithFilter1.EnableFilterText();
                    }
                    else
                        MessageBox.Show($"License Detained Failed", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void linkLabelNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormShowLicenseInfo frm = new FormShowLicenseInfo(LicenseID.Value);
            frm.ShowDialog();
        }

        private void linkLabelHistoryLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses clslicense = clsLicenses.GetLicenseID(LicenseID.Value);
            FormLicenseHistory frm = new FormLicenseHistory(
                clsApplications.GetApplicationID(clslicense.ApplicationID.Value).ApplicantPersonID.Value
                , clslicense.DriverID.Value);
            frm.ShowDialog();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtFees, "Text Fees should be have a value !", errorProvider1, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
