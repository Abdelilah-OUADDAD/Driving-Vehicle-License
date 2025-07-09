using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DriverLayoutControl.clsPeople;
using static System.Net.Mime.MediaTypeNames;

namespace DriverLayoutControll
{
    public class clsApplicationTypes
    {
        public Nullable<int> ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public Nullable<float> ApplicationFees{ get; set; }

        enum enMode { enAddNew = 0, enUpdate = 1 }

        enMode Mode = enMode.enAddNew;

        public clsApplicationTypes()
        {
            ApplicationTypeID = null;
            ApplicationTypeTitle = "";
            ApplicationFees = null;
            Mode = enMode.enAddNew;
        }

        public clsApplicationTypes(Nullable<int> applicationTypeID, string applicationTypeTitle, Nullable<float> applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
            Mode = enMode.enUpdate;
        }
        public static clsApplicationTypes GetApplicationTypeID(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            Nullable<float> ApplicationFees = null;

            if (clsApplicationTypesData.GetApplicationTypeID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            return null;
        }

        public static clsApplicationTypes GetApplicationTypeTitle(string ApplicationTypeTitle)
        {
            Nullable<int> ApplicationTypeID = null;
            Nullable<float> ApplicationFees = null;

            if (clsApplicationTypesData.GetApplicationTypeTitle(ref ApplicationTypeID, ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            return null;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        private Nullable<int> _AddApplicationTypeID()
        {
            return clsApplicationTypesData.AddApplicationTypeID(ApplicationTypeTitle, ApplicationFees);
        }
        private Nullable<bool> _UpdateApplicationTypeID()
        {
            return clsApplicationTypesData.UpdateApplicationTypeID(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }
        public bool Save()
        {
            if (Mode == enMode.enAddNew)
            {
                this.ApplicationTypeID = _AddApplicationTypeID();
                if (this.ApplicationTypeID != null)
                    return true;
            }
            else if (Mode == enMode.enUpdate)
            {
                if (_UpdateApplicationTypeID().Value)
                    return true;
            }
            return false;
        }

        public static Nullable<bool> DeleteApplication(int ApplicationTypeID)
        {
            return clsApplicationTypesData.DeleteApplicationType(ApplicationTypeID);
        }

        public static string IssueReasonTypes(int IssueReason)
        {
            switch (IssueReason)
            {
                case 1:
                    return "First Time";
                case 2:
                    return "Renew Driving License";
                case 3:
                    return "Replacement for a Lost";
                case 4:
                    return "Replacement for a Damaged";
                default :
                    return "First Time";
                
            }
        }
    }
}
