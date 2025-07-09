using DriverLayoutControll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Applications.ManageApplicationTypes
{
    public partial class FormEditApplicationType: Form
    {
        public FormEditApplicationType()
        {
            InitializeComponent();
        }
        
        public FormEditApplicationType(int applicationTypeID,string Title,float Fees)
        {
            InitializeComponent();
            lblID.Text = applicationTypeID.ToString();
            txtTitle.Text = Title;
            txtFees.Text = Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsManageApplicationTypes clsManage = new clsManageApplicationTypes(int.Parse(lblID.Text),txtTitle.Text,float.Parse(txtFees.Text));
            if (clsManage.Save())
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Data Saved Failed.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
