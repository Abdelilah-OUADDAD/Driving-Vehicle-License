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
    public partial class frmUpdateTestType : Form
    {
        public frmUpdateTestType()
        {
            InitializeComponent();
        }
        int TestTypeID {  get; set; }
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();
            lblID.Text = TestTypeID.ToString();
            DataTable dt = clsApplicant.GetTestTypesID(TestTypeID);
            txtTitle.Text = dt.Rows[0]["TestTypeTitle"].ToString();
            txtDescribtion.Text = dt.Rows[0]["TestTypeDescription"].ToString();
            txtFees.Text = dt.Rows[0]["TestTypeFees"].ToString();
            this.TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplicant clsTestType = new clsApplicant(TestTypeID,txtTitle.Text,txtDescribtion.Text,Convert.ToDouble(txtFees.Text));
           
            if (MessageBox.Show("Are you sur you want updated", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsTestType.SaveTestTypes())
                {
                    MessageBox.Show("Test Type Update Successfully !!", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Test Type Update Failed !!", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
    }
}
