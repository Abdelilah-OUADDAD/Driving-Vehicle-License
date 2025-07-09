using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsLocalDrivingLicenseApplications
    {
        public Nullable<int> LocalDrivingLicenseApplicationID { get; set; }
        public Nullable<int> ApplicationID { get; set; }
        public Nullable<int> LicenseClassID { get; set; }

        enum enMode { enAddNew = 0, enUpdate = 1 }

        enMode Mode = enMode.enAddNew;

        public clsLocalDrivingLicenseApplications()
        {
            LocalDrivingLicenseApplicationID = null;
            ApplicationID = null;
            LicenseClassID = null;
            Mode = enMode.enAddNew;
        }

        public clsLocalDrivingLicenseApplications(Nullable<int> localDrivingLicenseApplicationID, Nullable<int> applicationID, Nullable<int> licenseClassID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            ApplicationID = applicationID;
            LicenseClassID = licenseClassID;
            Mode = enMode.enUpdate;
        }
        public static clsLocalDrivingLicenseApplications GetLocalDrivingLicenseID(int localDrivingLicenseApplicationID)
        {
            Nullable<int> applicationID = null, licenseClassID = null;

            if (clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseID(localDrivingLicenseApplicationID, ref applicationID, ref licenseClassID))
            {
                return new clsLocalDrivingLicenseApplications(localDrivingLicenseApplicationID, applicationID, licenseClassID);
            }
            return null;
        }

        public static DataTable GetLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplications();
        }

        public static DataTable GetLocalDrivingLicenseApplicationsView()
        {
            return clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsView();
        }

        private Nullable<int> _AddLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsData.AddLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);
        }
        private Nullable<bool> _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID,
                ApplicationID, LicenseClassID);
        }
        public bool Save()
        {
            if (Mode == enMode.enAddNew)
            {
                this.LocalDrivingLicenseApplicationID = _AddLocalDrivingLicenseApplication();
                if (this.LocalDrivingLicenseApplicationID != null)
                    return true;
            }
            else if (Mode == enMode.enUpdate)
            {
                if (_UpdateLocalDrivingLicenseApplication().Value)
                    return true;
            }
            return false;
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }

        public static clsLocalDrivingLicenseApplications FindPersonHaveLDLDriving(int ApplicantPersonID, int LicenseClassID)
        {
            Nullable<int> LocalDrivingLicenseApplicationID = null, ApplicationID = null;
            if (clsLocalDrivingLicenseApplicationsData.FindPersonHaveLDLDriving(ref LocalDrivingLicenseApplicationID, ref ApplicationID,
                ApplicantPersonID, LicenseClassID))
                return new clsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);

            return null;
        }
    }
}
