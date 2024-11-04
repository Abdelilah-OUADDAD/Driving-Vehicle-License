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
    public partial class FormLicenseHistory : Form
    {
        public FormLicenseHistory()
        {
            InitializeComponent();
        }

        public FormLicenseHistory(int LDLApplication)
        {
            InitializeComponent();
            FillControl(LDLApplication);
        }

        private void FillControl(int LDLApplication)
        {
            DataTable dtLDLApplication = clsApplicant.GetLocaleDrivingLicenseApplicationID(LDLApplication);
            DataTable dtApplication = clsApplicant.GetApplicationID((int)dtLDLApplication.Rows[0]["ApplicationID"]);
            
            DataTable dtGetApplicantID = new DataTable();
            dtGetApplicantID.Columns.Add("ApplicationID", typeof(int));
            foreach (DataRow row in clsApplicant.GetApplication().Rows)
            {
                if ((int)row["ApplicantPersonID"] == (int)dtApplication.Rows[0]["ApplicantPersonID"] && Convert.ToInt32(row["ApplicationStatus"]) == 3)
                {
                    dtGetApplicantID.Rows.Add(row["ApplicationID"]);
                    
                }
            }
            DataTable dtLicense = new DataTable();
            dtLicense.Columns.Add("Lic.ID", typeof(int));
            dtLicense.Columns.Add("App.ID", typeof(int));
            dtLicense.Columns.Add("Class Name", typeof(string));
            dtLicense.Columns.Add("Issue Date", typeof(DateTime));
            dtLicense.Columns.Add("Expiration Date", typeof(DateTime));
            dtLicense.Columns.Add("IsActive", typeof(bool));
            foreach (DataRow row in clsApplicant.GetLicenses().Rows)
            {
                foreach (DataRow row2 in dtGetApplicantID.Rows)
                {
                    if ((int)row["ApplicationID"] == (int)row2["ApplicationID"])
                    {
                        dtLicense.Rows.Add(row["LicenseID"], row["ApplicationID"], clsApplicant.GetLicensesClassName(Convert.ToInt32( row["LicenseClass"])), row["IssueDate"]
                            , row["ExpirationDate"], row["IsActive"]);
                    }
                }
            }
            ctrlLicenseHistory2.PersonID = (int)dtApplication.Rows[0]["ApplicantPersonID"];
            ctrlLicenseHistory2.dtLicense = dtLicense;
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
