using DVLDControls;
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

namespace DVLDProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Log_In()
        {
            DataTable dtLog = clsUser.GetAllUser();
            bool isLogin = false;
            foreach (DataRow row in dtLog.Rows)
            {
                if ((row["UserName"].ToString() == txtUserName.Text) && (row["Password"].ToString() == txtPassword.Text) &&
                    Convert.ToBoolean(row["IsActive"]) == true)
                {
                    isLogin = true;
                    Main frm = new Main();
                    Main.PersonIDFromUser = (int)row["PersonID"];
                    Main.UserName = (string)row["UserName"];
                    Main.UserID = (int)row["UserID"];

                    frm.ShowDialog();
                }
            }
            if (!isLogin)
                MessageBox.Show("Your Code Password or UserName is incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Log_In();
        }

        const string FileRegister = @"C:\RegisterText\Register.txt";
        string[] FillText;
        private void Login_Load(object sender, EventArgs e)
        {
             FillText = File.ReadAllLines(FileRegister);
            if( FillText.Length >= 2) { 
                txtUserName.Text = FillText[0];
                txtPassword.Text = FillText[1];
                File.WriteAllLines(FileRegister, FillText);
                
                checkRemeber.Checked = true;
            }
            
        }

        private void checkRemeber_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRemeber.Checked == true)
            {
                string Fill = txtUserName.Text + "\n" + txtPassword.Text;
                File.WriteAllText(FileRegister, Fill);
            }
            else
            {
                string Fill = "";
                File.WriteAllText(FileRegister, Fill);
            }
            

        }
    }
}
