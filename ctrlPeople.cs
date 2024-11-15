﻿using DVLDControls;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace DVLDProject
{
    public partial class ctrlPeople : UserControl
    {
        public ctrlPeople()
        {
            InitializeComponent();
            _FilleComboBox();
        }

        public clsPerson clsperson;
        Guid guid = Guid.NewGuid();
        private void _AddPerson()
        {
            clsperson = new clsPerson();
            clsperson.NationalNo = txtNationalNO.Text;
            clsperson.FirstName = txtFirstName.Text;
            clsperson.ThirdName = txtThirdName.Text;
            clsperson.SecondName = txtSecondName.Text;
            clsperson.LastName = txtLastName.Text;
            clsperson.DateOfBirth = dtpDOB.Value;

            clsperson.Address = txtAddress.Text;
            clsperson.Email = txtEmail.Text;
            clsperson.Phone = txtPhone.Text;
            clsperson.NationalityCountryID = clsPerson.GetIDCountry(comboNCID.Text);
            if (filter != "")
            {
                clsperson.ImagePath = $@"C:\DVLD-People-Images\{guid}.{ImageFilter}";
            }
            else 
            {
                clsperson.ImagePath = ""; 
            }

            if (rbMale.Checked)
            {
                clsperson.Gendor = 0;
            }
            else
            {
                clsperson.Gendor = 1;
            }
            clsperson.Save();
            if (clsperson.PersonID != -1)
            {
                MessageBox.Show("Add Person " + clsperson.PersonID + " Successfully !!");
            }
        }

        private void _UpdatePerson()
        {
            int Gender;
            if (rbMale.Checked)
            {
                Gender = 0;
            }
            else
            {
                Gender = 1;
            }
            int Country = clsPerson.GetIDCountry(comboNCID.Text);
            clsperson = new clsPerson(int.Parse(lblPersonID.Text), txtNationalNO.Text, txtFirstName.Text, txtSecondName.Text, txtThirdName.Text
                , txtLastName.Text, dtpDOB.Value, Gender, txtAddress.Text, txtPhone.Text, txtEmail.Text, Country,
                $@"C:\DVLD-People-Images\{guid}.{ImageFilter}");

            clsperson.Save();
            if (clsperson.isUpdated == true)
            {
                MessageBox.Show("Update Person " + clsperson.PersonID + " Successfully !!");
            }
            else
            {
                MessageBox.Show("Update Person " + clsperson.PersonID + " Failled !!");

            }
        }

        private void linkLabelSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Title = "Image";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                linkLabelRemove.Visible = true;
                
            }
        }

        private void _ValideTextBox(TextBox textBox)
        {
            textBox.Focus();
            MessageBox.Show("Some fields are not validate!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK);

        }
        private bool _CheckValidationText()
        {
            if (txtNationalNO.Text == "")
            {
                _ValideTextBox(txtNationalNO);
                return true;
            }
            else if (txtFirstName.Text == "")
            {
                _ValideTextBox(txtFirstName);
                return true;
            }
            else if (txtSecondName.Text == "")
            {
                _ValideTextBox(txtSecondName);
                return true;
            }
            else if (txtThirdName.Text == "")
            {
                _ValideTextBox(txtThirdName);
                return true;
            }
            else if (txtLastName.Text == "")
            {
                _ValideTextBox(txtLastName);
                return true;
            }
            else if (txtPhone.Text == "")
            {
                _ValideTextBox(txtPhone);
                return true;
            }
            else if (txtAddress.Text == "")
            {
                _ValideTextBox(txtAddress);
                return true;
            }
            //else if (txtEmail.Text == "")
            //{
                //_ValideTextBox(txtEmail);
              //  return true;
            //}

            return false;
        }


        public delegate void SendDataBack(object sender, int id);
        public static event SendDataBack DataBack;

        string ImageFilter;
        string filter = "";
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (clsPerson.Mode == clsPerson.enMode.enUpdate)
            {
                if (_CheckValidationText() != true)
                {
                     filter = openFileDialog1.FileName;
                    if (filter != "")
                    {
                        ImageFilter = filter.Split('.').Last();
                        File.Delete(dtperson.Rows[0]["ImagePath"].ToString());
                        File.Copy(openFileDialog1.FileName, Path.Combine(@"C:\DVLD-People-Images\", Path.GetFileName(guid.ToString() + "." + ImageFilter)), true);
                    }
                    _UpdatePerson();
                }
            }
            else
            {
                if (_CheckValidationText() != true)
                {
                      
                     filter = openFileDialog1.FileName;
                    if (filter != "") {
                        ImageFilter = filter.Split('.').Last();
                        File.Copy(openFileDialog1.FileName, Path.Combine(@"C:\DVLD-People-Images\", Path.GetFileName(guid.ToString() + "." + ImageFilter), openFileDialog1.Filter), true);
                    }
                    _AddPerson();
                    lblAddNew.Text = "Update Person";
                    lblPersonID.Text = clsperson.PersonID.ToString();
                }
            }
            
            FormManagePeople frm = new FormManagePeople();
            frm._RefreshData();
            try { DataBack?.Invoke(this, clsperson.PersonID); }catch(Exception ex) { Console.WriteLine(ex.Message); }
            
            
        }

        private void _ErrorValidating(TextBox textBox, CancelEventArgs e, string NameText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, NameText);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void txtNationalNO_Validating(object sender, CancelEventArgs e)
        {
            DataTable dtPeople = clsPerson.GetAllPeople();
            if (string.IsNullOrWhiteSpace(txtNationalNO.Text))
            {
                _ErrorValidating(txtNationalNO, e, "NationalNO should have a value");
            }
            else
            {
                if (clsPerson.Mode == clsPerson.enMode.enAddNew)
                {
                    foreach (DataRow row in dtPeople.Rows)
                    {

                        if (row["NationalNo"].ToString().ToLower() == txtNationalNO.Text.ToLower())
                        {
                            e.Cancel = true;
                            txtNationalNO.Focus();
                            errorProvider1.SetError(txtNationalNO, "NationalNO already have a value");
                            return;
                        }
                        else
                        {
                            e.Cancel = false;
                            errorProvider1.SetError(txtNationalNO, "");
                        }
                    }
                }
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtFirstName, e, "FirstName should have a value");

        }

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtSecondName, e, "SecondName should have a value");
        }

        private void txtThirdName_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtThirdName, e, "ThirdName should have a value");
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtLastName, e, "LastName should have a value");
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtAddress, e, "Address should have a value");
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtPhone, e, "Phone should have a value");
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
           // _ErrorValidating(txtEmail, e, "Email should have a value");
            if (txtEmail.Text.EndsWith("@gmail.com")|| txtEmail.Text == "")
            {
                
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
            else
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Email Should have @gmail.com");
            }
        }

        private void _FilleComboBox()
        {
            foreach (DataRow row in clsPerson.GetAllCountry().Rows)
            {
                comboNCID.Items.Add(row["CountryName"]);
            }
            comboNCID.SelectedItem = "Jordan";

            
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {

            ((Form)this.TopLevelControl).Close();


        }
        DataTable dtperson;
        public void EditPerson(int PersonID)
        {

            _FilleComboBox();

            lblAddNew.Text = "Update Person";
            dtperson = clsPerson.GetPerson(PersonID);
            lblPersonID.Text = dtperson.Rows[0]["PersonID"].ToString();
            txtNationalNO.Text = dtperson.Rows[0]["NationalNo"].ToString();
            txtFirstName.Text = dtperson.Rows[0]["FirstName"].ToString();
            txtThirdName.Text = dtperson.Rows[0]["ThirdName"].ToString();
            txtSecondName.Text = dtperson.Rows[0]["SecondName"].ToString();
            txtLastName.Text = dtperson.Rows[0]["LastName"].ToString();
            dtpDOB.Value = (DateTime)dtperson.Rows[0]["DateOfBirth"];

            txtAddress.Text = dtperson.Rows[0]["Address"].ToString();
            txtEmail.Text = dtperson.Rows[0]["Email"].ToString();
            txtPhone.Text = dtperson.Rows[0]["Phone"].ToString();
            comboNCID.SelectedItem = clsPerson.GetNameCountry((int)dtperson.Rows[0]["NationalityCountryID"]);
            try { pictureBox1.Load(dtperson.Rows[0]["ImagePath"].ToString()); openFileDialog1.FileName = dtperson.Rows[0]["ImagePath"].ToString(); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            int Gendor = int.Parse(dtperson.Rows[0]["Gendor"].ToString());
            if (Gendor == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }
            clsPerson.Mode = clsPerson.enMode.enUpdate;
            
        }

        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.FileName = "";
            pictureBox1.Image = null;
        }

        private void ctrlPeople_Load(object sender, EventArgs e)
        {
            dtpDOB.MaxDate = DateTime.Now.AddYears(-18);
            
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.person_boy;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.person_girl;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
