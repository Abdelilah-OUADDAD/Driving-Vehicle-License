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

namespace PDVLD.Applications.TestTypes
{
    public partial class FormEditTestType: Form
    {
        public FormEditTestType()
        {
            InitializeComponent();
        }

        public FormEditTestType(int ID,string Title,string Description,float fees)
        {
            InitializeComponent();
            lblID.Text = ID.ToString();
            txtTitle.Text = Title;
            txtDescription.Text = Description;
            txtFees.Text = fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTestTypes clsTest = new clsTestTypes(int.Parse(lblID.Text), txtTitle.Text, txtDescription.Text, float.Parse(txtFees.Text));
            if (clsTest.Save())
                MessageBox.Show("Data Update Successfully !", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Data Updated Failed !", "Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
