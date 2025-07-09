using DriverLayoutControl;
using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DriverLayoutControl.clsPeople;

namespace DriverLayoutControll
{
    public class clsApplications
    {

        public Nullable<int> ApplicationID { get; set; } 
        public Nullable<int> ApplicantPersonID { get; set; }
        public Nullable<DateTime> ApplicationDate { get; set; }
        public Nullable<int> ApplicationTypeID { get; set; }
        public Nullable<int> ApplicationStatus { get; set; }
        public Nullable<DateTime> LastStatusDate { get; set; }
        public Nullable<float> PaidFees { get; set; }
        public Nullable<int> CreatedByUserID { get; set; }

        enum enMode { enAddNew = 0, enUpdate = 1}

        enMode Mode = enMode.enAddNew;

        public clsApplications()
        {
            ApplicationID = null;
            ApplicantPersonID = null;
            ApplicationDate = null;
            ApplicationTypeID = null;
            ApplicationStatus = null;
            LastStatusDate = null;
            PaidFees = null;
            CreatedByUserID = null;
            Mode = enMode.enAddNew;
        }

        public clsApplications(Nullable<int> applicationID, Nullable<int> applicantPersonID, Nullable<DateTime> applicationDate,
           Nullable<int> applicationTypeID, Nullable<int> applicationStatus, Nullable<DateTime> lastStatusDate, Nullable<float> paidFees,
           Nullable<int> createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            Mode = enMode.enUpdate;
        }
        public static clsApplications GetApplicationID(int ApplicationID)
        {
            Nullable<int>  ApplicantPersonID = null, ApplicationTypeID = null, ApplicationStatus = null, CreatedByUserID = null;
            Nullable<float> PaidFees = null; 
            Nullable<DateTime> ApplicationDate = null, LastStatusDate = null;
            if (clsApplicationData.GetApplicationID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
            ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            return null;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        private Nullable<int> _AddApplicationID()
        {
            return clsApplicationData.AddApplicationID(ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }
        private Nullable<bool> _UpdateApplicationID()
        {
            return clsApplicationData.UpdateApplicationID(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }
        public bool Save()
        {
            if (Mode == enMode.enAddNew)
            {
                this.ApplicationID = _AddApplicationID();
                if (this.ApplicationID != null)
                    return true;
            }
            else if (Mode == enMode.enUpdate)
            {
                if (_UpdateApplicationID().Value)
                    return true;
            }
            return false;
        }

        public static Nullable<bool> DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }

        public static clsApplications IsCompleted(int LDLApplicationID)
        {
            Nullable<int> ApplicationID = null;
            Nullable<int> ApplicantPersonID = null, ApplicationTypeID = null, ApplicationStatus = null, CreatedByUserID = null;
            Nullable<float> PaidFees = null;
            Nullable<DateTime> ApplicationDate = null, LastStatusDate = null;
            if ( clsApplicationData.IsCompleted(LDLApplicationID, ref ApplicationID, ref ApplicantPersonID
            , ref ApplicationTypeID, ref  ApplicationStatus, ref CreatedByUserID
            , ref PaidFees, ref ApplicationDate, ref LastStatusDate))
            {
                return new clsApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }

            return null;

        }
    }
}
