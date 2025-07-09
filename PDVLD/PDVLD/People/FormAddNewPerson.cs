
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
using DriverLayoutControl;

namespace PDVLD.People
{
    public partial class FormAddNewPerson: Form
    {
        public FormAddNewPerson()
        {
            InitializeComponent();
        }
        public FormAddNewPerson(clsPeople.enMode Mode)
        {
            InitializeComponent();
            clsPeople.Mode = Mode;
            lblTitle.Text = "Add New Person";
            txtNationalNo.Clear();
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtThirdName.Clear();
            txtLastName.Clear();
            dateTimePicker1.Value = DateTime.Now;
            rbMale.Enabled = true;
            txtAddresse.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cmbCountry.Text = "Jordan";
            pictureImage.ImageLocation = null;
        }

        public FormAddNewPerson(clsPeople.enMode Mode, int PersonID)
        {
            InitializeComponent();
            clsPeople.Mode = Mode;
            lblTitle.Text = "Update Person";
            FillForm(PersonID);
        }

        void FillForm(int PersonID)
        {
            clsPeople people = clsPeople.GetPeopleID(PersonID);
            if (people != null)
            {
                lblPersonID.Text = people.PersonID.ToString();
                txtNationalNo.Text = people.NationalNo;
                txtFirstName.Text = people.FirstName;
                txtSecondName.Text = people.SecondName;
                txtThirdName.Text = people.ThirdName;
                txtLastName.Text = people.LastName;
                dateTimePicker1.Value = people.DateOfBirth;

                if (people.Gendor == 0)
                    rbMale.Enabled = true;
                else
                    rbFemale.Enabled = true;

                txtAddresse.Text = people.Address;
                txtPhone.Text = people.Phone;
                txtEmail.Text = people.Email;
                clsCountries country = clsCountries.GetCountryID(people.NationalityCountryID);

                cmbCountry.Text = country.CountryName;

                if (people.ImagePath == "")
                    pictureImage.ImageLocation = null;
                else
                    pictureImage.ImageLocation = people.ImagePath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void FillCombo()
        {
            foreach (DataRow row in clsCountries.GetAllCountries().Rows)
            {
                cmbCountry.Items.Add(row[1].ToString());
            }
        }

        private void FormAddNewPerson_Load(object sender, EventArgs e)
        {
            FillCombo();
            cmbCountry.SelectedItem = "Jordan";
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
        }

        public void AddPerson()
        {
            clsPeople cls = new clsPeople();

            cls.NationalNo = txtNationalNo.Text;
            cls.FirstName = txtFirstName.Text;
            cls.SecondName = txtSecondName.Text;
            cls.ThirdName = txtThirdName.Text;
            cls.LastName = txtLastName.Text;
            cls.DateOfBirth = dateTimePicker1.Value;
            if (rbMale.Checked)
            {
                cls.Gendor = 0;
            }
            else if (rbFemale.Checked)
            {
                cls.Gendor = 1;
            }

            cls.Address = txtAddresse.Text;
            cls.Phone = txtPhone.Text;
            cls.Email = txtEmail.Text;
            clsCountries country = clsCountries.GetCountryName(cmbCountry.Text);
            cls.NationalityCountryID = country.CountryID;

            cls.ImagePath = pictureImage.ImageLocation;
            if (cls.Save())
            {
                MessageBox.Show($"Person ID {cls.PersonID} Add Successfully !", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPersonID.Text = cls.PersonID.ToString();
                lblTitle.Text = "Update Person";
                clsPeople.Mode = clsPeople.enMode.enUpdate;
            }
            else
            {
                MessageBox.Show($"Save Person operation failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdatePerson()
        {
            byte gender = 0;
            if (rbMale.Checked)
            {
                gender = 0;
            }
            else if (rbFemale.Checked)
            {
                gender = 1;
            }
            clsCountries cls = clsCountries.GetCountryName(cmbCountry.Text);
            clsPeople people = new clsPeople(int.Parse(lblPersonID.Text), txtNationalNo.Text, txtFirstName.Text, txtSecondName.Text, txtThirdName.Text,
            txtLastName.Text, Convert.ToDateTime(dateTimePicker1.Value), gender, txtAddresse.Text, txtPhone.Text, txtEmail.Text, cls.CountryID, pictureImage.ImageLocation);

            if (people.Save())
            {
                MessageBox.Show($"Person Updated Successfully !", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Person Updated failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                if (clsPeople.Mode == clsPeople.enMode.enAddNew)
                {
                    AddPerson();
                }
                else
                {
                    UpdatePerson();
                }
            }
        }

        private void LinkLabelImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureImage.ImageLocation = clsUtil.CreateFile(openFileDialog1.FileName);
                linkLabelRemove.Visible = true;

            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtFirstName, "First Name should be have a value", errorProvider1, e);
        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtSecondName, "First Name should be have a value", errorProvider1, e);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtLastName, "First Name should be have a value", errorProvider1, e);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (clsPeople.Mode == clsPeople.enMode.enAddNew)
            {
                if (clsPeople.FindNationalNo(txtNationalNo.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtNationalNo, "This Value is already stored choose another NationalNo");
                }
                else
                {
                    errorProvider1.SetError(txtNationalNo, null);
                }
                clsValidation.ValidationTextBox(txtNationalNo, "First Name should be have a value", errorProvider1, e);
            }
            else
            {
                clsValidation.ValidationTextBox(txtNationalNo, "First Name should be have a value", errorProvider1, e);

            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.ValidationEmail(txtEmail.Text.ToLower()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "should be do '@gmail.com'");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtPhone, "First Name should be have a value", errorProvider1, e);
        }

        private void txtAddresse_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtAddresse, "First Name should be have a value", errorProvider1, e);
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
                pictureImage.Image = Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
                pictureImage.Image = Properties.Resources.Female_512;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbMale.Checked)
                pictureImage.Image = Properties.Resources.Male_512;
            else
                pictureImage.Image = Properties.Resources.Female_512;

            linkLabelRemove.Visible = false;
        }
    }
}
