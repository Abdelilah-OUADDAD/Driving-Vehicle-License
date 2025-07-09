using DriverLayoutControl;
using DriverLayoutControll;
using PDVLD.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Applications.DrivingLicensesServices
{
    public partial class FormAddLocalLicense: Form
    {
        int PersonID { get; set; }
        int LDLAppID { get; set; }
        Nullable<int> ClassLicenseId;
        enum enMode { enAddNew = 0, enUpdate = 1}

        enMode Mode = enMode.enAddNew;
        public FormAddLocalLicense()
        {
            InitializeComponent();
            Mode = enMode.enAddNew;
        }

        public FormAddLocalLicense(int PersonID,int LDLAppID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
            this.LDLAppID = LDLAppID;
            lblTitle.Text = "Update Local Driving License Application";
            Mode = enMode.enUpdate;
            ctrlShowCardWithFilter1.SendDataShowCard(PersonID);
        }

        
        private void FormAddLocalLicense_Load(object sender, EventArgs e)
        {

            foreach (DataRow row in clsLicenseClass.FindAllClassName().Rows)
            {
                cmbLicenseClass.Items.Add(row[0]);
            }
            cmbLicenseClass.SelectedIndex = 2;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblApplicationFees.Text = "15";
            lblCreatedBy.Text = clsGlobal.UserName;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlShowCardWithFilter1.IsFoundPerson)
            {
                btnSave.Enabled = true;
                tabControl1.SelectedTab = tpApplicationInfo;
            }
            else
                btnSave.Enabled = false;
            
        }

        void AddLocalDrivingApp()
        {
            clsLocalDrivingLicenseApplications clsLocal = clsLocalDrivingLicenseApplications.FindPersonHaveLDLDriving(PersonID, ClassLicenseId.Value);
            if (clsLocal != null)
            {
                MessageBox.Show($@"Choose another License Class,the selected Person Already have an active application for the selected 
                class with id = {clsLocal.ApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsApplications applications = new clsApplications();
            applications.ApplicantPersonID = PersonID;
            applications.ApplicationDate = DateTime.Now;
            applications.ApplicationTypeID = 1;
            applications.ApplicationStatus = 1;
            applications.LastStatusDate = DateTime.Now;
            applications.PaidFees = clsApplicationTypes.GetApplicationTypeID(1).ApplicationFees;

            applications.CreatedByUserID = clsUsers.GetUsersWithUserName(clsGlobal.UserName).UserID;

            if (applications.Save())
            {
                clsLocalDrivingLicenseApplications clsLocal1 = new clsLocalDrivingLicenseApplications();
                clsLocal1.ApplicationID = applications.ApplicationID;
                clsLocal1.LicenseClassID = ClassLicenseId;
                if (clsLocal1.Save())
                {
                    MessageBox.Show("Data Saved Successfully!!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDLApplicationID.Text = clsLocal1.LocalDrivingLicenseApplicationID.ToString();
                }
                else
                    MessageBox.Show("Data Fail to saved!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UpdateLocalDrivingApp()
        {
            clsLocalDrivingLicenseApplications clsLocal = clsLocalDrivingLicenseApplications.FindPersonHaveLDLDriving(PersonID, ClassLicenseId.Value);
            if (clsLocal != null)
            {
                MessageBox.Show($@"Choose another License Class,the selected Person Already have an active application for the selected 
                class with id = {clsLocal.ApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsLocalDrivingLicenseApplications GetLocal = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseID(LDLAppID);
            clsLocalDrivingLicenseApplications clsLocal1 = new clsLocalDrivingLicenseApplications(LDLAppID, GetLocal.ApplicationID, ClassLicenseId);
            if(clsLocal1.Save())
                MessageBox.Show("Data Updated Successfully!!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Data Fail to Updated!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.enAddNew)
                AddLocalDrivingApp();
            else
                UpdateLocalDrivingApp();

        }

        private void ctrlShowCardWithFilter1_SendPersonID(int obj)
        {
            PersonID = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {

           ClassLicenseId = clsLicenseClass.GetLicenseClassName(cmbLicenseClass.SelectedItem.ToString()).LicenseClassID;
        }
    }
}
