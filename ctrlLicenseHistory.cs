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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDProject
{
    public partial class ctrlLicenseHistory : UserControl
    {
        public DataTable dtLicense = new DataTable();
        public DataTable dtLicenseInternational = new DataTable();
        public int PersonID { get; set; }
        public ctrlLicenseHistory()
        {
            InitializeComponent();
            
           
        }

        private void ctrlLicenseHistory_Load(object sender, EventArgs e)
        {
            if (dtLicense.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtLicense;
                lblRecord.Text = dtLicense.Rows.Count.ToString();
                dataGridView2.DataSource = dtLicenseInternational;
                lblRecordInter.Text = dtLicenseInternational.Rows.Count.ToString();
                ctrlDetailsPerson1.Form_DataBack(PersonID);
                
            }
        }
       
       
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DataTable dtLic = clsApplicant.GetLicensesID((int)dataGridView1.CurrentRow.Cells[0].Value);
            int LDLappId = -1;

            DataTable dtAp = clsApplicant.GetApplicationID((int)dtLic.Rows[0]["ApplicationID"]);
            DataTable dtPerson = clsPerson.GetPerson((int)dtAp.Rows[0]["ApplicantPersonID"]);

            foreach (DataRow row in clsApplicant.GetLocaleDrivingLicenseApplicationView().Rows)
            {
                if (row["NationalNo"].ToString() == dtPerson.Rows[0]["NationalNo"].ToString() &&
                    (int)dtLic.Rows[0]["LicenseClass"] == clsApplicant.ClassName(row["ClassName"].ToString()))
                {
                    LDLappId = (int)row["LocalDrivingLicenseApplicationID"];
                    break;
                }
            }
            if (LDLappId != -1) {
                frmLicenseInfo.LicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                frmLicenseInfo frm = new frmLicenseInfo(LDLappId);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error LDLAPPID not found !!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void showInterLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo();
            frm.FillInterDrivingInfo((int)dataGridView2.CurrentRow.Cells[0].Value, (int)dataGridView2.CurrentRow.Cells[1].Value,
                (int)dataGridView2.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
    }
}
