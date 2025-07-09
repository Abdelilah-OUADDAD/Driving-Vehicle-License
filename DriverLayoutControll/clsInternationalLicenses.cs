using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsInternationalLicenses
    {

        public int? InternationalLicenseID { get; set; }
        public int? ApplicationID { get; set; }
        public int? DriverID { get; set; }
        public int? IssuedUsingLocalLicenseID { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedByUserID { get; set; }


        enum enMode { enAddNew = 0, enUpdate = 1 }
        enMode Mode = enMode.enAddNew;
        public clsInternationalLicenses()
        {
            InternationalLicenseID = null;
            ApplicationID = null;
            DriverID = null;
            IssuedUsingLocalLicenseID = null;
            IssueDate = null;
            ExpirationDate = null;
            IsActive = null;
            CreatedByUserID = null;

            Mode = enMode.enAddNew;
        }

        public clsInternationalLicenses(int? InternationalLicenseID, int? ApplicationID, int? DriverID, int? IssuedUsingLocalLicenseID,
            DateTime? IssueDate, DateTime? ExpirationDate, bool? IsActive, int? CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.enUpdate;
        }


        public static DataTable GetInternationalLicense()
        {
            return clsInternationalLicenseData.GetInternationalLicense();
        }

        public static DataTable GetLicenseInter(int DriverID)
        {
            return clsInternationalLicenseData.GetLicenseInter(DriverID);
        }

        public static clsInternationalLicenses GetInternationalLicenseID(int InternationalLicenseID)
        {
            int? ApplicationID = null, DriverID = null, IssuedUsingLocalLicenseID= null, CreatedByUserID = null;
            DateTime? IssueDate = null, ExpirationDate = null;
            bool? IsActive = null;
            if (clsInternationalLicenseData.GetInternationalLicenseID(InternationalLicenseID,ref ApplicationID,ref DriverID,ref IssuedUsingLocalLicenseID,
               ref IssueDate,ref ExpirationDate,ref IsActive,ref CreatedByUserID))
                return new clsInternationalLicenses(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
               IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            return null;
        }


        public static clsInternationalLicenses GetInternationalLicenseLocalID(int IssuedUsingLocalLicenseID)
        {
            int? ApplicationID = null, DriverID = null, InternationalLicenseID = null, CreatedByUserID = null;
            DateTime? IssueDate = null, ExpirationDate = null;
            bool? IsActive = null;
            if (clsInternationalLicenseData.GetInternationalLicenseLocalID(ref InternationalLicenseID, ref ApplicationID, ref DriverID, IssuedUsingLocalLicenseID,
               ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
                return new clsInternationalLicenses(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
               IssueDate, ExpirationDate, IsActive, CreatedByUserID);

            return null;
        }


        private int? _AddLicenseInter()
        {
            return clsInternationalLicenseData.AddNewInternationalLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID,
               IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        private bool _UpdateLicenseInter()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(InternationalLicenseID,ApplicationID, DriverID, IssuedUsingLocalLicenseID,
               IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public bool Save()
        {
            if(Mode == enMode.enAddNew)
            {
                InternationalLicenseID = _AddLicenseInter();
                if (InternationalLicenseID != 0)
                    return true;
            }
            else
            {
                if (_UpdateLicenseInter())
                    return true;
            }
            return false;
        }

    }
}
