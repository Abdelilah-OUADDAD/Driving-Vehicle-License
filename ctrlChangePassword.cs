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
    public partial class ctrlChangePassword : UserControl
    {
        public ctrlChangePassword()
        {
            InitializeComponent();
        }
        DataTable dtUser;
        public void FillUser(int PersonID)
        {
            
            ctrlShowUser1.FillUser(PersonID);
            dtUser = clsUser.GetUserPersonID(PersonID);
        }

        private bool IsValidated()
        {
            if(string.IsNullOrWhiteSpace(txtCurrent.Text))
            {
                return false;
            }else if (string.IsNullOrWhiteSpace(txtCurrent.Text))
            {
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtCurrent.Text) || txtNew.Text != txtConfirme.Text) 
            {
                return false;
            }
            return true;
        }

        private bool NewPasswordIsDifferentThAnOldPassword()
        {
            if (txtCurrent.Text != txtNew.Text)
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidated() && NewPasswordIsDifferentThAnOldPassword())
            {
                if ((string)dtUser.Rows[0]["Password"] == txtCurrent.Text)
                {
                    clsUser user = new clsUser((int)dtUser.Rows[0]["UserID"],(int) dtUser.Rows[0]["PersonID"], dtUser.Rows[0]["UserName"].ToString(),
                        txtNew.Text,(bool) dtUser.Rows[0]["IsActive"]);
                    user.Save();
                    if (user.isUpdated)
                        MessageBox.Show($"Update UserID : {user.UserID} successfully ");
                    else
                        MessageBox.Show($"Update UserID : {user.UserID} Failed ");
                }
                else
                {
                    MessageBox.Show("Password current is incorect","Warning");
                }
            }
            else
            {
                MessageBox.Show("Something is not filled or incorrect or your Password is same");
            }
           
        }

        private void ErrorValidating(TextBox textBox, CancelEventArgs e, string Caption)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, Caption);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }
        private void txtCurrent_Validating(object sender, CancelEventArgs e)
        {
            ErrorValidating(txtCurrent,e, "Current Password should be have a value");
           
        }

        private void txtNew_Validating(object sender, CancelEventArgs e)
        {
            ErrorValidating(txtNew, e, "New Password should be have a value");
        }

        private void txtConfirme_Validating(object sender, CancelEventArgs e)
        {
            ErrorValidating(txtConfirme, e, "Confirme Password should be have a value");
            if (txtNew.Text != txtConfirme.Text)
            {
                e.Cancel=true;
                txtConfirme.Focus();
                errorProvider1.SetError(txtConfirme,"Password Incorrect !!! ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirme,"");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Close();
        }
    }
}
