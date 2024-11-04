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
                if ((row["UserName"].ToString() == txtUserName.Text) && (row["Password"].ToString() == txtPassword.Text))
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
    }
}
