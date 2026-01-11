using DriverLayoutControl;
using PDVLD.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Users
{
    public partial class FormAddNewUser: Form
    {
        public FormAddNewUser()
        {
            InitializeComponent();
            lblTitle.Text = "Add New User";
            Mode = enMode.enAddNew;
            EmptyLogInfo();
        }
        enum enMode { enAddNew = 0,enUpdate =1}
        enMode Mode = enMode.enAddNew;
        public FormAddNewUser(int personID)
        {
            InitializeComponent();
            lblTitle.Text = "Update User";
            PersonID = personID;
            FillLogInfo(personID);

            Mode = enMode.enUpdate;
            ctrlShowCardWithFilter1.SendDataShowCard(personID);
        }

        void FillLogInfo(int personID)
        {
            clsUsers cls = clsUsers.GetUserWithPersonID(personID);

            lblUserID.Text = cls.UserID.ToString();
            txtUserName.Text = cls.UserName;
            txtPassword.Text = cls.Password;
            txtConfirmPassword.Text = cls.Password;
            checkActive.Checked = cls.IsActive.Value;
        }

        void EmptyLogInfo()
        {
            
            lblUserID.Text = "???";
            txtUserName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            checkActive.Checked = false;
        }

        bool IsLoginInfo = false;
        Nullable<int> PersonID = null;
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.enUpdate)
            {
                btnSave.Enabled = true;
                tabControl1.SelectedTab = tpLogInfo;
                return;
            }
           
            if (IsLoginInfo)
            {
                btnSave.Enabled = true;
                tabControl1.SelectedTab = tpLogInfo;
            }
            else
                MessageBox.Show("Selected person already has a user ,choose another one");
           
        }

        void FormNext_PrintID(object sender,int personID)
        {

            if (!clsUsers.FindPersonID(personID))
            {
                IsLoginInfo = true;
                if (clsPeople.GetPeopleID(personID) != null)
                    PersonID = clsPeople.GetPeopleID(personID).PersonID;
            }
            else
                IsLoginInfo = false;

        }

        void FormNext_NationalNo(object sender, string NationalNo)
        {

            if (!clsUsers.FindNationalNo(NationalNo))
            {
                IsLoginInfo = true;
                if (clsPeople.GetPeopleNationalNo(NationalNo) != null)
                    PersonID = clsPeople.GetPeopleNationalNo(NationalNo).PersonID;
            }
            else
                IsLoginInfo = false;

        }

        private void FormAddNewUser_Load(object sender, EventArgs e)
        {
            ctrlShowCardWithFilter1.onPersonID += FormNext_PrintID;
            ctrlShowCardWithFilter1.onNationalNo += FormNext_NationalNo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewUser()
        {
            if (!clsUsers.FindUsersName(txtUserName.Text))
            {
                if (txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
                {
                    clsUsers users = new clsUsers();
                    users.PersonID = PersonID;
                    users.UserName = txtUserName.Text;
                    users.Password = txtPassword.Text;
                    if (checkActive.Checked)
                        users.IsActive = true;
                    else
                        users.IsActive = false;

                    if (users.Save())
                    {
                        MessageBox.Show($"Users {users.UserID} Saved Successfully !", "Saved");
                        lblUserID.Text = users.UserID.ToString();
                    }
                    else
                        MessageBox.Show($"Users is failed !", "Saved");
                }
            }
        }

        private void UpdateUser()
        {
            clsUsers users = new clsUsers(int.Parse(lblUserID.Text),PersonID,txtUserName.Text, ComputeHash(txtPassword.Text),checkActive.Checked);
            if (users != null)
            {
                if (users.Save())
                    MessageBox.Show("Update user Successfully !", "Updated");
                else
                    MessageBox.Show("Update user Failed !", "Updated");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (Mode == enMode.enAddNew)
                    AddNewUser();
                else
                    UpdateUser();
            }
        }
        static string ComputeHash(string input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (Mode == enMode.enAddNew)
            {
                if (clsUsers.FindUsersName(txtUserName.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Already have this User Name Choose Another one !!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUserName, "");
                    clsValidation.ValidationTextBox(txtUserName, "User Name Should be have a value !", errorProvider1, e);
                }
            }
            else
            {
                if (clsUsers.SearchUserNameAndPersonID(PersonID, txtUserName.Text))
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUserName, "");
                }else if (clsUsers.FindUsersName(txtUserName.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Already have this User Name Choose Another one !!");
                }
                    clsValidation.ValidationTextBox(txtUserName, "User Name Should be have a value !", errorProvider1, e);
            }
                

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtPassword, "Password Should be have a value !", errorProvider1, e);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtConfirmPassword, "Confirm Password Should be have a value !", errorProvider1, e);
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password and Confirm Password is different !!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }
    }
}
