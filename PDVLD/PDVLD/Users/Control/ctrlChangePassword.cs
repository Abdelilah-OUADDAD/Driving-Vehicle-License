using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDVLD.People.Controle;
using DriverLayoutControl;

namespace PDVLD.Users.Control
{
    public partial class ctrlChangePassword: UserControl 
    {
        public ctrlChangePassword()
        {
            InitializeComponent();
        }

        public event Action<int,string,bool> OnPasswordChange;

        public void SendDataToControl(int personID)
        {
            ctrlShowCard1.FillShowPerson(personID);
            clsUsers users = clsUsers.GetUserWithPersonID(personID);
            if (users != null)
            {
                lblUserID.Text = users.UserID.ToString();
                lblUserName.Text = users.UserName;
                if (users.IsActive.Value)
                    lblIsActive.Text = "Yes";
                else
                    lblIsActive.Text = "No";

                if (OnPasswordChange != null)
                    OnPasswordChange(users.UserID.Value, users.UserName, users.IsActive.Value);
            }
        }

        private void ctrlChangePassword_Load(object sender, EventArgs e)
        {
            
        }
    }
}
