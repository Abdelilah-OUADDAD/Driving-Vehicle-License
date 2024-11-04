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
    public partial class FormAddNewUser : Form
    {
        public FormAddNewUser()
        {
            InitializeComponent();
        }
        
        public FormAddNewUser(int PersonID)
        {
            InitializeComponent();
            GetUserAndUpdateThem(PersonID);
        }

        

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlAddUser1.PersonIDForUser != 0)
            {
                tabControl.SelectTab(tabLogin);
                btnSave.Enabled = true;

            }

        }

        clsUser user;

        private void AddEditeUser()
        {
            if (clsUser.Mode == clsUser.enMode.enUpdate)
            {
                user = new clsUser(int.Parse(lblUserID.Text), ctrlAddUser1.PersonIDForUser, txtUserName.Text, txtPassword.Text, checkActive.Checked);
                user.Save();
                if (user.isUpdated)
                {
                    MessageBox.Show("Data Updated Successefully !!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data Failed to update !!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                user = new clsUser();
                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.PersonID = ctrlAddUser1.PersonIDForUser;
                if (checkActive.Checked)
                {
                    user.IsActive = true;
                }
                else
                {
                    user.IsActive = false;
                }

                user.Save();
                lblUserID.Text = user.UserID.ToString();
                lblTitle.Text = "Update User";
                if (user.isAdd)
                {
                    MessageBox.Show("Data Saved Successefully !!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data Failed to Saved !!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool _CheckValidateText()
        {
            if (txtUserName.Text == "")
            {
                return false;
            }
            else if (txtPassword.Text == "")
            {
                return false;
            }
            else if (txtConfirmPass.Text == "" || txtConfirmPass.Text != txtPassword.Text)
            {
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_CheckValidateText())
            {
                if (clsUser.GetUserID(ctrlAddUser1.PersonIDForUser))
                {
                    if (clsUser.Mode == clsUser.enMode.enUpdate)
                    {
                        AddEditeUser();
                    }
                    else
                    {
                        MessageBox.Show($"{ctrlAddUser1.PersonIDForUser} ID already he is a User Choose an other Person !", "Alert \a", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    AddEditeUser();
                }
            }


        }



        private void _ErrorValidating(TextBoxBase textBox, CancelEventArgs e, string NameText)
        {

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                //e.Cancel = true;
                //textBox.Focus();
                errorProvider1.SetError(textBox, NameText);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                _ErrorValidating(txtConfirmPass, e, "Confirme Password should have a value");
            }
            else
            {
                if (txtPassword.Text != txtConfirmPass.Text)
                {
                    //e.Cancel = true;
                    //txtConfirmPass.Focus();
                    errorProvider1.SetError(txtConfirmPass, "Confirme Password is not same Password Above");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtConfirmPass, "");
                }
            }

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtUserName, e, "User Name should have a value");
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            _ErrorValidating(txtPassword, e, "Password should have a value");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetUserAndUpdateThem(int PersonID)
        {
            ctrlAddUser1.FillDetailsPerson(PersonID);

            DataTable dtUser = clsUser.GetUserPersonID(PersonID);
            lblTitle.Text = "Update User";
            lblUserID.Text = dtUser.Rows[0]["UserID"].ToString();
            txtUserName.Text = dtUser.Rows[0]["UserName"].ToString();
            txtPassword.Text = dtUser.Rows[0]["Password"].ToString();
            txtConfirmPass.Text = txtPassword.Text;
            ctrlAddUser1.PersonIDForUser = PersonID;
            if (dtUser.Rows[0]["IsActive"].ToString() == "True")
            {
                checkActive.Checked = true;
            }
            clsUser.Mode = clsUser.enMode.enUpdate;

        }
    }

}
