using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Users
{
    public partial class FormUserInfo: Form
    {
        public FormUserInfo()
        {
            InitializeComponent();
        }

        public FormUserInfo(int PersonID)
        {
            InitializeComponent();
            ctrlChangePassword1.SendDataToControl(PersonID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
