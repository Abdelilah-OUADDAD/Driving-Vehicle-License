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
    public partial class FormShowUser : Form
    {
        public FormShowUser()
        {
            InitializeComponent();
        }

        public FormShowUser(int PersonID)
        {
            InitializeComponent();
            ctrlShowUser1.FillUser(PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
