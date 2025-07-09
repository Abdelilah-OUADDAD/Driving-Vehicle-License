using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsDetainedLicenses
    {

        public int? DetainID { get; set; }
        public int? LicenseID { get; set; }
        public DateTime? DetainDate { get; set; }
        public float? FineFees { get; set; }
        public int? CreatedByUserID { get; set; }
        public bool? IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        enum enMode { enAddNew = 0,enUpdate = 1}

        enMode Mode = enMode.enAddNew;

        public clsDetainedLicenses()
        {
            DetainID = null;
            LicenseID = null;
            DetainDate = null;
            FineFees = null;
            CreatedByUserID = null;
            IsReleased = null;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;

            Mode = enMode.enAddNew;
        }

        public clsDetainedLicenses(int? detainedID, int? licenseID, DateTime? detainDate, float? fineFees, int? createdByUserID,
            bool? isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
        {
            DetainID = detainedID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;

            Mode = enMode.enUpdate;
        }


        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        public static DataTable GetAllDetainedLicensesView()
        {
            return clsDetainedLicenseData.GetAllDetainedLicensesView();
        }

        public static clsDetainedLicenses GetDetainedID(int DetainID)
        {
            int? licenseID = null,  createdByUserID = null, releasedByUserID =null, releaseApplicationID = null;
            DateTime? detainDate =null , releaseDate = null;
            float? fineFees = null;
            bool? isReleased = null;
            if (clsDetainedLicenseData.GetDetainedID(DetainID, ref licenseID, ref detainDate, ref fineFees, ref createdByUserID,
            ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
                return new clsDetainedLicenses(DetainID, licenseID, detainDate, fineFees, createdByUserID,
                                                    isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            return null;
        }

        public static clsDetainedLicenses GetDetainedWithLicenseID(int licenseID)
        {
            int? DetainID = null, createdByUserID = null, releasedByUserID = null, releaseApplicationID = null;
            DateTime? detainDate = null, releaseDate = null;
            float? fineFees = null;
            bool? isReleased = null;
            if (clsDetainedLicenseData.GetDetainedWithLicenseID(ref DetainID, licenseID, ref detainDate, ref fineFees, ref createdByUserID,
            ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
                return new clsDetainedLicenses(DetainID, licenseID, detainDate, fineFees, createdByUserID,
                                                    isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            return null;
        }

        private int? _AddNewDetained()
        {
            return clsDetainedLicenseData.AddDetained(LicenseID, DetainDate, FineFees, CreatedByUserID,
                                                    IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        private bool _UpdateDetained()
        {
            return clsDetainedLicenseData.UpdateDetained(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                                                    IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public bool Save()
        {
            if(Mode == enMode.enAddNew)
            {
                DetainID = _AddNewDetained();
                if (DetainID != null)
                    return true;
            }
            else
            {
                if (_UpdateDetained())
                    return true;
            }

            return false;
        }

        public static bool CheckIsDetained(int LicenseID)
        {
            return clsDetainedLicenseData.CheckIsDetained(LicenseID);
        }
    }
}
