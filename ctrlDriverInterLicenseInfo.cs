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
    public partial class ctrlDriverInterLicenseInfo : UserControl
    {
        public ctrlDriverInterLicenseInfo()
        {
            InitializeComponent();
        }
        public int ApplicationID { get; set; }
        public int LicenseID { get; set; }
        public int InterLicenseID { get; set; }
        public void FillInterDrivingInfo()
        {
            DataTable dtLocalDriving = clsApplicant.GetApplicationID(ApplicationID);
           
            

            DataTable dtPerson = new DataTable();
            dtPerson.Columns.Add("PersonID", typeof(int));
            dtPerson.Columns.Add("Gendor", typeof(int));
            dtPerson.Columns.Add("DateOfBirth", typeof(DateTime));
            dtPerson.Columns.Add("ImagePath", typeof(string));
            dtPerson.Columns.Add("FirstName", typeof(string));
            dtPerson.Columns.Add("SecondName", typeof(string));
            dtPerson.Columns.Add("ThirdName", typeof(string));
            dtPerson.Columns.Add("LastName", typeof(string));
            dtPerson.Columns.Add("NationalNo", typeof(string));

            foreach (DataRow row in clsPerson.GetAllPeople().Rows)
            {
                if (row["PersonID"].ToString() == dtLocalDriving.Rows[0]["ApplicantPersonID"].ToString())
                {
                    dtPerson.Rows.Add(row["PersonID"], row["Gendor"], row["DateOfBirth"], row["ImagePath"], row["FirstName"],
                        row["SecondName"], row["ThirdName"], row["LastName"], row["NationalNo"]);
                    break;
                }
            }

            lblName.Text = dtPerson.Rows[0]["FirstName"].ToString()+ " " + dtPerson.Rows[0]["SecondName"].ToString() + " " +
                 dtPerson.Rows[0]["ThirdName"].ToString() + " " + dtPerson.Rows[0]["LastName"].ToString() ;
            lblNationalNo.Text = dtPerson.Rows[0]["NationalNo"].ToString();

            lblDateOfBirth.Text = dtPerson.Rows[0]["DateOfBirth"].ToString();

            if ((int)dtPerson.Rows[0]["Gendor"] == 0)
            {
                lblGendor.Text = "Male";
            }
            else if ((int)dtPerson.Rows[0]["Gendor"] == 0)
            {
                lblGendor.Text = "Female";
            }


            try
            {
                pictureBox1.Load(dtPerson.Rows[0]["ImagePath"].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            DataTable dtLicense = new DataTable();
            dtLicense.Columns.Add("LicenseID", typeof(int));
            dtLicense.Columns.Add("DriverID", typeof(int));
            dtLicense.Columns.Add("IssueDate", typeof(DateTime));
            dtLicense.Columns.Add("ExpirationDate", typeof(DateTime));
            dtLicense.Columns.Add("IsActive", typeof(bool));



            foreach (DataRow row in clsApplicant.GetInternationalLicense().Rows)
            {
                    if ((int)row["ApplicationID"] == this.ApplicationID && (int)row["IssuedUsingLocalLicenseID"] == this.LicenseID)
                    {
                        dtLicense.Rows.Add(row["IssuedUsingLocalLicenseID"], row["DriverID"], row["IssueDate"], row["ExpirationDate"], row["IsActive"]);
                        break;
                    }
            }
            lblLicenseID.Text = dtLicense.Rows[0]["LicenseID"].ToString();
            lblDriverID.Text = dtLicense.Rows[0]["DriverID"].ToString();
            lblIssueDate.Text = dtLicense.Rows[0]["IssueDate"].ToString();
            lblExpirationDate.Text = dtLicense.Rows[0]["ExpirationDate"].ToString();
            

            if ((bool)dtLicense.Rows[0]["IsActive"] == true)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
            lblIntLicenseID.Text = this.InterLicenseID.ToString();
            lblAppID.Text = this.ApplicationID.ToString(); 



        }
    }
}
