using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverLayoutControll;
using DriverLayoutControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PDVLD.Applications.DrivingLicensesServices.Control
{
    public partial class ctrlLicenseInfoWithFilter: UserControl
    {
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public enum enMode { enInternational , enRenew , enLostOrDamage  }
        enMode Mode;

        public enum enMode2 { enDetain }
        enMode2 Mode2;

        public enum enMode3 { enReleases }
        enMode3 Mode3;


        private bool _ActiveDetainSearch { get; set; }
        public bool ActiveDetainSearch
        {

            get { return _ActiveDetainSearch; }

            set
            {
                if (Mode2 == enMode2.enDetain)
                    _ActiveDetainSearch = value;
            }
        }


        private bool _ActiveReleaseSearch { get; set; }
        public bool ActiveReleaseSearch
        {

            get { return _ActiveReleaseSearch; }

            set
            {
                if (Mode3 == enMode3.enReleases)
                    _ActiveReleaseSearch = value;
            }
        }

        private bool _ActiveInternationalSearch { get; set; }
        public bool ActiveInternationalSearch { 
            
            get { return _ActiveInternationalSearch; }

            set 
            { 
                if (Mode == enMode.enInternational)
                    _ActiveInternationalSearch = value;
            } 
        }

        private bool _ActiveRenewSearch { get; set; }
        public bool ActiveRenewSearch
        {

            get { return _ActiveRenewSearch; }

            set
            {
                if (Mode == enMode.enInternational)
                    _ActiveRenewSearch = value;
            }
        }

        private bool _ActiveLostOrDamageSearch { get; set; }
        public bool ActiveLostOrDamageSearch
        {

            get { return _ActiveLostOrDamageSearch; }

            set
            {
                if (Mode == enMode.enInternational)
                    _ActiveLostOrDamageSearch = value;
            }
        }

       

        public event Action<int,bool> OnInternationalLicense;
        public event Action<int,bool> OnLicenseChange;
        public event Action<int,DateTime,bool,int> OnRenewLicenseChange;

        public event Action<int, bool> OnDetainChange;
        public event EventHandler OnDetainChangeWithoutLicense;

        public event Action<int, bool> OnLostOrDamageLicense;
        public event Action<bool,bool> OnLostOrDamageWithoutLicense;

        public class EventReleaseChange : EventArgs
        {
            public int? DetainID { get; set; }
            public DateTime? DetainDate { get; set; }
            public float? ApplicationFees { get; set; }
            public int? LicenseID { get; set; }
            public string CreatedBy { get; set; }
            public float? FineFees { get; set; }

            public EventReleaseChange(int? detainID, DateTime? detainDate, float? applicationFees, int? licenseID, string createdBy, float? fineFees)
            {
                DetainID = detainID;
                DetainDate = detainDate;
                ApplicationFees = applicationFees;
                LicenseID = licenseID;
                CreatedBy = createdBy;
                FineFees = fineFees;
            }
        }

        public event EventHandler<EventReleaseChange> OnReleaseChange;

        protected virtual void RaiseOnReleaseChange(int? detainID, DateTime? detainDate, float? applicationFees, int? licenseID
            , string createdBy, float? fineFees)
        {
            OnReleaseChange?.Invoke(this, new EventReleaseChange(detainID, detainDate, applicationFees, licenseID, createdBy, fineFees));
        }

        void InternationalSearch()
        {
            clsInternationalLicenses clsInternational = clsInternationalLicenses.GetInternationalLicenseLocalID(int.Parse(textBox1.Text));
            if (clsInternational != null)
            {
                MessageBox.Show($"Person already have an active international license with ID = {clsInternational.InternationalLicenseID}",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (OnInternationalLicense != null)
                    OnInternationalLicense(int.Parse(textBox1.Text), false);

                return;
            }

            if (clsLicenses.GetLicenseID(int.Parse(textBox1.Text)) != null)
            {
                if (clsLicenses.FindLicenseIsActive(int.Parse(textBox1.Text)))
                {
                    if (OnLicenseChange != null)
                        OnLicenseChange(int.Parse(textBox1.Text), true);
                }
                else
                {
                    if (OnLicenseChange != null)
                        OnLicenseChange(int.Parse(textBox1.Text), false);

                    MessageBox.Show("License is not Active !!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        void RenewSearch()
        {
            clsLicenses licenses = clsLicenses.GetLicenseID(int.Parse(textBox1.Text));
            if (licenses != null)
            {
                if (clsLicenses.FindLicenseIsExpirationDateOver(int.Parse(textBox1.Text)))
                {
                    MessageBox.Show($"Select License is not yet expired ,it will expired on : {licenses.ExpirationDate}",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (OnRenewLicenseChange != null)
                        OnRenewLicenseChange(licenses.LicenseID.Value, licenses.ExpirationDate.Value, false, licenses.LicenseClass.Value);
                    return;
                }
                if(clsLicenses.CheckLicenseIsActive(int.Parse(textBox1.Text)))
                {
                    if (OnRenewLicenseChange != null)
                        OnRenewLicenseChange(licenses.LicenseID.Value,licenses.ExpirationDate.Value,true,licenses.LicenseClass.Value);
                }
                else
                {
                    if (OnRenewLicenseChange != null)
                        OnRenewLicenseChange(licenses.LicenseID.Value, licenses.ExpirationDate.Value, false, licenses.LicenseClass.Value);
                }
            }
        }

        void LostOrDamageSearch()
        {
            clsLicenses licenses = clsLicenses.GetLicenseID(int.Parse(textBox1.Text));
            if (licenses != null)
            {
                if (clsLicenses.CheckLicenseIsActive(int.Parse(textBox1.Text)))
                {
                    if (OnLostOrDamageLicense != null)
                        OnLostOrDamageLicense(licenses.LicenseID.Value, true);
                }
                else
                {
                    if (OnLostOrDamageLicense != null)
                        OnLostOrDamageLicense(licenses.LicenseID.Value, false);

                    MessageBox.Show("Select License is not Active, Chose an Active License.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (OnLostOrDamageWithoutLicense != null)
                    OnLostOrDamageWithoutLicense(false, false);
            }
        }

        void DetainSearch()
        {
            clsLicenses licenses = clsLicenses.GetLicenseID(int.Parse(textBox1.Text));
            if (licenses != null)
            {
                if (clsLicenses.CheckLicenseIsActive(int.Parse(textBox1.Text)) && !clsDetainedLicenses.CheckIsDetained(int.Parse(textBox1.Text)))
                {
                    if (OnDetainChange != null)
                        OnDetainChange(licenses.LicenseID.Value, true);
                }
                else
                {
                    if (OnDetainChange != null)
                        OnDetainChange(licenses.LicenseID.Value, false);

                    MessageBox.Show("Selected License is already detained, Choose another One", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (OnDetainChangeWithoutLicense != null)
                    OnDetainChangeWithoutLicense?.Invoke(this,null);
            }
        }

        void ReleaseSearch()
        {
            clsLicenses licenses = clsLicenses.GetLicenseID(int.Parse(textBox1.Text));
            
            if (licenses != null)
            {
                if (clsLicenses.CheckLicenseIsActive(int.Parse(textBox1.Text)) && clsDetainedLicenses.CheckIsDetained(int.Parse(textBox1.Text)))
                {
                    clsDetainedLicenses detain = clsDetainedLicenses.GetDetainedWithLicenseID(licenses.LicenseID.Value);
                    if (OnReleaseChange != null)
                    {
                        RaiseOnReleaseChange(detain.DetainID, detain.DetainDate, clsApplicationTypes.GetApplicationTypeID(5).ApplicationFees, detain.LicenseID
                            , clsUsers.GetUsersID(detain.CreatedByUserID.Value).UserName, detain.FineFees);
                    }
                }
                else
                {
                    if (OnReleaseChange != null)
                        RaiseOnReleaseChange(null, null, null, int.Parse(textBox1.Text), null, null);

                    MessageBox.Show("Selected License is not detained, Choose another One", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (OnDetainChangeWithoutLicense != null)
                    OnDetainChangeWithoutLicense?.Invoke(this, null);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.FillData(int.Parse(textBox1.Text));
            if (_ActiveInternationalSearch)
                InternationalSearch();
            else if (_ActiveRenewSearch)
                RenewSearch();
            else if (_ActiveLostOrDamageSearch)
                LostOrDamageSearch();
            else if (_ActiveDetainSearch)
                DetainSearch();
            else if (_ActiveReleaseSearch)
                ReleaseSearch();
        }

        public void EnableFilterText()
        {
            gbFilter.Enabled = false;
        }

        public void StartButtonSearch()
        {
            btnSearch_Click(null, null);
        }

        public void FillDataModeRelease(int LicenseID)
        {
            _ActiveReleaseSearch = true;
            textBox1.Text = LicenseID.ToString();
            btnSearch_Click(null, null);
            gbFilter.Enabled = false;
        }

    }
}
