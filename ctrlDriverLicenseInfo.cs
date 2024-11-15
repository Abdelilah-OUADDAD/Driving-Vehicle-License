﻿using DVLDControls;
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
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseID { get; set; }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
            
        }
        

        public void FillDrivingInfo()
        {
            DataTable dtLocalDriving = clsApplicant.GetLocaleDrivingLicenseApplicationViewID(LocalDrivingLicenseApplicationID);
            lblClass.Text = dtLocalDriving.Rows[0]["ClassName"].ToString();
            lblName.Text = dtLocalDriving.Rows[0]["FullName"].ToString();
            lblNationalNo.Text = dtLocalDriving.Rows[0]["NationalNo"].ToString();

            DataTable dtPerson = new DataTable();
            dtPerson.Columns.Add("PersonID", typeof(int));
            dtPerson.Columns.Add("Gendor", typeof(int));
            dtPerson.Columns.Add("DateOfBirth", typeof(DateTime));
            dtPerson.Columns.Add("ImagePath", typeof(string));

            foreach (DataRow row in clsPerson.GetAllPeople().Rows)
            {
                if (row["NationalNo"].ToString() == dtLocalDriving.Rows[0]["NationalNo"].ToString())
                {
                    dtPerson.Rows.Add(row["PersonID"], row["Gendor"], row["DateOfBirth"], row["ImagePath"]);
                    break;
                }
            }

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

           

            DataTable dtLicense = clsApplicant.GetLicensesID(this.LicenseID);

           
            lblLicenseID.Text = dtLicense.Rows[0]["LicenseID"].ToString();
            lblDriverID.Text = dtLicense.Rows[0]["DriverID"].ToString();
            lblIssueDate.Text = dtLicense.Rows[0]["IssueDate"].ToString();
            lblExpirationDate.Text = dtLicense.Rows[0]["ExpirationDate"].ToString();
            if (dtLicense.Rows[0]["Notes"].ToString() == "")
            {
                lblNotes.Text = "No Notes";
            }
            else
            {
                lblNotes.Text = dtLicense.Rows[0]["Notes"].ToString();
            }
            
            if ((bool)dtLicense.Rows[0]["IsActive"] == true)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }
            switch (Convert.ToInt32( dtLicense.Rows[0]["IssueReason"]))
            {
                case 1:
                    lblIssueReason.Text = "First Time";
                    break;
                case 2:
                    lblIssueReason.Text = "Renew License";
                    break;
                case 3:
                    lblIssueReason.Text = "Remplace for Lost";
                    break;
                case 4:
                    lblIssueReason.Text = "Remplace For Damaged";
                    break;
                case 5:
                    lblIssueReason.Text = "Release Detained ";
                    break;
                case 6:
                    lblIssueReason.Text = "New InterNational Liense";
                    break;
            }



        }

       
    }
}
