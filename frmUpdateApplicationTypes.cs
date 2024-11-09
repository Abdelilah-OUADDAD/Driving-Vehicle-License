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
    public partial class frmUpdateApplicationTypes : Form
    {
        public frmUpdateApplicationTypes()
        {
            InitializeComponent();
        }
        int ApplicationTypeID { get;set; }
        public frmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            lblID.Text = ApplicationTypeID.ToString();
            DataTable dataTable = clsApplicant.GetApplicationTypesID(ApplicationTypeID);
            txtTitle.Text = dataTable.Rows[0]["ApplicationTypeTitle"].ToString();
            txtFees.Text = dataTable.Rows[0]["ApplicationFees"].ToString();
            this.ApplicationTypeID = ApplicationTypeID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplicant clsApplicantType = new clsApplicant(ApplicationTypeID,txtTitle.Text,Convert.ToDouble(txtFees.Text));
            if (MessageBox.Show("Are you sur you want updated", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
            {
                if (clsApplicantType.SaveApplicationTypes())
                {
                    MessageBox.Show("Application Type Update Successfully !!", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Application Type Update Failed !!", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
