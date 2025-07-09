using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsLicenses
    {
        public int? LicenseID { get; set; }
        public int? ApplicationID { get; set; }
        public int? DriverID { get; set; }
        public int? LicenseClass { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float? PaidFees { get; set; }
        public bool? IsActive { get; set; }
        public int? IssueReason { get; set; }
        public int? CreatedByUserID { get; set; }

        enum enMode { enAddNew = 0, enUpdate = 1 }
        enMode Mode = enMode.enAddNew;
        public clsLicenses()
        {
            LicenseID = null;
            ApplicationID = null;
            DriverID = null;
            LicenseClass = null;
            IssueDate = null;
            ExpirationDate = null;
            Notes = "";
            PaidFees = null;
            IsActive = null;
            IssueReason = null;
            CreatedByUserID = null;

            Mode = enMode.enAddNew;
        }

        public clsLicenses(int? LicenseID, int? ApplicationID, int? DriverID, int? LicenseClass, DateTime? IssueDate,
            DateTime? ExpirationDate, string Notes, float? PaidFees, bool? IsActive, int? IssueReason, int? CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.enUpdate;
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }

        public static DataTable GetLicenseLocal(int DriverID)
        {
            return clsLicensesData.GetLicenseLocal(DriverID);
        }

        public static bool FindLicenseIsActive(int LicenseID)
        {
            return clsLicensesData.GetLicenseIsActive(LicenseID);
        }

        public static bool FindLicenseIsExpirationDateOver(int LicenseID)
        {
            return clsLicensesData.GetLicenseIsExpirationDateOver(LicenseID);
        }

        public static bool CheckLicenseIsActive(int LicenseID)
        {
            return clsLicensesData.CheckLicenseIsActive(LicenseID);
        }

        public static clsLicenses GetLicenseID(int LicenseID)
        {
            int? ApplicationID = null, DriverID = null, LicenseClass = null, CreatedByUserID = null, IssueReason = null;
            DateTime? IssueDate = null, ExpirationDate = null;
            string Notes = ""; 
            float? PaidFees = null;
            bool? IsActive = null;
            if (clsLicensesData.GetLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate,
                 ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

            return null;
        }

        public static clsLicenses GetLicensesWithApplicationID(int ApplicationID)
        {
            int? LicenseID = null, DriverID = null, LicenseClass = null, CreatedByUserID = null, IssueReason = null;
            DateTime? IssueDate = null, ExpirationDate = null;
            string Notes = "";
            float? PaidFees = null;
            bool? IsActive = null;
            if (clsLicensesData.GetLicensesWithApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate,
                ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate,
                 ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

            return null;
        }

        private int? _AddNewLicense()
        {
            return clsLicensesData.AddNewLicense(ApplicationID, DriverID, LicenseClass, IssueDate,
            ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }

        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(LicenseID,ApplicationID, DriverID, LicenseClass, IssueDate,
            ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }

        public bool Save()
        {
            if(Mode == enMode.enAddNew)
            {
                LicenseID = _AddNewLicense();
                if (LicenseID != null)
                    return true;
            }
            else
                if (_UpdateLicense())
                    return true;

            return false;

        }
    }
}
