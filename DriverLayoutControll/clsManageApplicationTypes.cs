using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsManageApplicationTypes
    {
        public static Nullable<int> ApplicationTypeID { get; set; }
        public static string ApplicationTypeTitle { get; set; }
        public static Nullable<float> ApplicationFees { get; set; }

        enum enMode { enAddNew = 0,enUpdate = 1}
        enMode Mode = enMode.enAddNew;
        public clsManageApplicationTypes()
        {
            ApplicationTypeID = null;
            ApplicationTypeTitle = "";
            ApplicationFees = null;
            Mode = enMode.enAddNew;
        }

        public clsManageApplicationTypes(Nullable<int> applicationTypeID, string applicationTypeTitle, Nullable<float> applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
            Mode = enMode.enUpdate;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsManageApplicationTypesData.GetAllApplicationTypes();
        }

        private Nullable<int> _AddApplicationType()
        {
            return clsManageApplicationTypesData.AddApplicationType(ApplicationTypeTitle,ApplicationFees);
        }

        private Nullable<bool> _UpdateApplicationType()
        {
            return clsManageApplicationTypesData.UpdateApplicationType(ApplicationTypeID,ApplicationTypeTitle, ApplicationFees);
        }

        public bool Save()
        {
            if (Mode == enMode.enUpdate)
                return _UpdateApplicationType().Value;
            else
            {
                ApplicationTypeID = _AddApplicationType();
                if (ApplicationTypeID != null)
                    return true;            }
            return false;
                    
        }
    }
}
