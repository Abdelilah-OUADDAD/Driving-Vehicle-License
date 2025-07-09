using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsDrivers
    {
        public int? DriverID { get; set; } 
        public int? PersonID { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime? CreatedDate { get; set; }

        enum enMode { enAddNew = 0, enUpdate = 1}
        enMode Mode;

        public clsDrivers()
        {
            DriverID = null;
            PersonID = null;
            CreatedByUserID = null;
            CreatedDate = null;
            Mode = enMode.enAddNew;
        }

        public clsDrivers(int? DriverID, int? PersonID, int? CreatedByUserID, DateTime? CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            Mode = enMode.enUpdate;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }

        public static DataTable GetAllDriversView()
        {
            return clsDriversData.GetAllDriversView();
        }

        public static clsDrivers GetDriverID(int DriverID)
        {
            int? PersonID = null, CreatedByUserID = null;
            DateTime? CreatedDate = null;
            if (clsDriversData.GetDriverID(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate))
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            return null;
        }

        public static clsDrivers GetDriverWithPersonID(int PersonID)
        {
            int? DriverID = null, CreatedByUserID = null;
            DateTime? CreatedDate = null;
            if (clsDriversData.GetDriverWithPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            return null;
        }

        private int? _AddNewDriver()
        {
            return clsDriversData.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
        }

        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriver(DriverID,PersonID, CreatedByUserID, CreatedDate);
        }

        public bool Save()
        {
            if(Mode == enMode.enAddNew)
            {
                this.DriverID = _AddNewDriver();
                if (DriverID != null)
                    return true;
            }
            else
            {
                if (_UpdateDriver())
                    return true;
            }
            return false;
        }

    }
}
