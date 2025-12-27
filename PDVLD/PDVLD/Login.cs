using DriverLayoutControl;
using PDVLD.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace PDVLD
{
    public partial class Login: Form
    {
        string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourDVLDlog";

        string ValueName = "UserName";
        string ValuePassword = "UserPassword";
        public Login()
        {
            InitializeComponent();
            string username = Registry.GetValue(KeyPath, ValueName, null) as string;
            string Password = Registry.GetValue(KeyPath, ValuePassword, null) as string;
            if (username != "" && Password != "")
            {
                checkRemember.Checked = true;
            }
            else
                checkRemember.Checked = false;
        }
        

        void ReceiveDataLog()
        {
            string username = Registry.GetValue(KeyPath, ValueName, null) as string;
            txtUsername.Text = username;

            string Password = Registry.GetValue(KeyPath, ValuePassword, null) as string;
            txtPassword.Text = Password;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (clsUsers.GetLogin(txtUsername.Text, txtPassword.Text))
            {
                clsGlobal.UserName = txtUsername.Text;
                clsGlobal.Password = txtPassword.Text;
                clsGlobal.UserID = clsUsers.GetUsersWithUserName(txtUsername.Text).UserID;
                if (checkRemember.Checked)
                    Remember();
                else
                    Forget();

                Main main = new Main();
                main.ShowDialog();
                txtPassword.Text = "";
            }
            else
                MessageBox.Show("User Name or Password Incorrect !","Login");
        }
        void Remember()
        {
            Registry.SetValue(KeyPath,ValueName,txtUsername.Text, RegistryValueKind.String);

            Registry.SetValue(KeyPath, ValuePassword, txtPassword.Text, RegistryValueKind.String);

        }

        void Forget()
        {
            Registry.SetValue(KeyPath, ValueName, "", RegistryValueKind.String);

            Registry.SetValue(KeyPath, ValuePassword, "", RegistryValueKind.String);

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


        private void checkRemember_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkRemember.Checked)
                ReceiveDataLog();
        }
    }
}
