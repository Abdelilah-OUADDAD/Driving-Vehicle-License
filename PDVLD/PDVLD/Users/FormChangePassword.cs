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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PDVLD.Users
{
    public partial class FormChangePassword: Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }
        Nullable<int> PersonID = null;
        Nullable<int> userID = null;
        string userName = "";
        Nullable<bool> isActive = null;
        clsUsers users;
        public FormChangePassword(int personID)
        {
            InitializeComponent();
            ctrlChangePassword1.SendDataToControl(personID);
            PersonID = personID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                users = new clsUsers(userID, PersonID, userName, ComputeHash(txtNewPassword.Text), isActive);
                if (users != null)
                {
                    if (users.Save())
                        MessageBox.Show("Update user Successfully !", "Updated");
                    else
                        MessageBox.Show("Update user Failed !", "Updated");
                }
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

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!clsUsers.CheckCurrentPassword(userName,txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword,"Password Incorrect Try Again !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");
                clsValidation.ValidationTextBox(txtCurrentPassword, "Current Password Should be have a value.", errorProvider1, e);
            }
        }

        private void ctrlChangePassword1_OnPasswordChange(int arg1, string arg2, bool arg3)
        {
            userID = arg1;
            userName = arg2;
            isActive = arg3;
            
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            clsValidation.ValidationTextBox(txtNewPassword, "New Password Should be have a value.", errorProvider1, e);

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "New Password and Confirm Password is difference should be have same password !!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
                clsValidation.ValidationTextBox(txtConfirmPassword, "Confirm Password Should be have a value.", errorProvider1, e);
            }
        }
    }
}
