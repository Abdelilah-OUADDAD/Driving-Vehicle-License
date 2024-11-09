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
    public partial class frmNewLocalDriving : Form
    {
        
        
     
        DataTable dtPerson;
        
        public frmNewLocalDriving()
        {
            InitializeComponent();
            ctrlDetailsPerson.DataBack += _FillDataTable;
        }

        private void _FillDataTable(object sender , DataTable dtp)
        {
            dtPerson = dtp;
            
        }

        private void _FillCombo()
        {
            cmbLicenseClass.Items.Add("Class 1 - Small Motorcycle");
            cmbLicenseClass.Items.Add("Class 2 - Heavy Motorcycle License");
            cmbLicenseClass.Items.Add("Class 3 - Ordinary driving license");
            cmbLicenseClass.Items.Add("Class 4 - Commercial");
            cmbLicenseClass.Items.Add("Class 5 - Agricultural");
            cmbLicenseClass.Items.Add("Class 6 - Small and medium bus");
            cmbLicenseClass.Items.Add("Class 7 - Truck and heavy vehicle");

            cmbLicenseClass.SelectedItem = "Class 3 - Ordinary driving license";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlAddUser1.PersonIDForUser != 0)
            {
                tabControl.SelectTab(tabApp);
                btnSave.Enabled = true;

            }
        }

        private void frmNewLocalDriving_Load(object sender, EventArgs e)
        {
            _FillCombo();
            lblAppDate.Text = DateTime.Now.ToString();
            lblAppFess.Text = "15";
            
            lblCreatedBy.Text = Main.UserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNoteSameClassName = false;
            foreach (DataRow row in clsApplicant.GetLocaleDrivingLicenseApplicationView().Rows)
            {
               
                    if (row["NationalNo"].ToString() == dtPerson.Rows[0]["NationalNo"].ToString() &&
                    row["ClassName"].ToString() == cmbLicenseClass.Text)
                    {
                         isNoteSameClassName = true;
                        break;
                    }
                
            }

            if (isNoteSameClassName == false) { 
                clsApplicant App = new clsApplicant();
                App.ApplicantPersonID = (int)dtPerson.Rows[0]["PersonID"];
                App.ApplicationTypeID = 1;
                App.ApplicationStatus = 1;
                App.ApplicationDate = DateTime.Now;
                App.PaidFees = 15;
                App.CreatedByUserID = Main.UserID ;
                App.LastStatusDate = DateTime.Now;

                switch (cmbLicenseClass.Text)
                {
                    case "Class 1 - Small Motorcycle":
                        App.LicenseClassID = 1;
                        break;
                    case "Class 2 - Heavy Motorcycle License":
                        App.LicenseClassID =2;
                        break;
                    case "Class 3 - Ordinary driving license":
                        App.LicenseClassID = 3;
                        break;
                    case "Class 4 - Commercial":
                        App.LicenseClassID = 4;
                        break;
                    case "Class 5 - Agricultural":
                        App.LicenseClassID = 5;
                        break;
                    case "Class 6 - Small and medium bus":
                        App.LicenseClassID = 6;
                        break;
                    case "Class 7 - Truck and heavy vehicle":
                        App.LicenseClassID = 7;
                        break;
                }
                if (App.Save())
                {
                    lblAppID.Text = App.LocalDrivingLicenseApplicationID.ToString();
                    MessageBox.Show("Data Add Successfully !!","Saved");
                
                }
                else
                {
                    MessageBox.Show("Data Add Failed", "Saved");

                }
            }
            else
            {
                MessageBox.Show("Person already have a license with same applied driving class, Choose different driving class","Not allowed",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
