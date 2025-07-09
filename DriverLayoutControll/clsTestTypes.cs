using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsTestTypes
    {

        public Nullable<int> TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public Nullable<float> TestTypeFees { get; set; }

        enum enMode { enAddNew = 0, enUpdate = 1 }
        enMode Mode = enMode.enAddNew;
        public clsTestTypes()
        {
            TestTypeID = null;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = null;
            Mode = enMode.enAddNew;
        }

        public clsTestTypes(Nullable<int> testTypeID, string testTypeTitle, string testTypeDescription, Nullable<float> testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
            Mode = enMode.enUpdate;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

        public static clsTestTypes GetTestTypeID(int TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            float? TestTypeFees = null;
            if (clsTestTypesData.GetTestTypeID(TestTypeID,ref TestTypeTitle,ref TestTypeDescription,ref TestTypeFees))
                return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

            return null;
        }
        private Nullable<int> _AddTestTypes()
        {
            return clsTestTypesData.AddTestTypes(TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        private Nullable<bool> _UpdateTestTypes()
        {
            return clsTestTypesData.UpdateTestTypes(TestTypeID,TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        public bool Save()
        {
            if (Mode == enMode.enUpdate)
                return _UpdateTestTypes().Value;
            else
            {
                TestTypeID = _AddTestTypes();
                if (TestTypeID != null)
                    return true;
            }
            return false;

        }
    }
}
