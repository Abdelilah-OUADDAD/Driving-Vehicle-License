using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsTest
    {

        public int? TestID { get; set; }
        public int? TestAppointmentID { get; set; }
        public bool? TestResult { get; set; }
        public string Notes { get; set; }
        public int? CreatedByUserID { get; set; }


        enum enMode { enAddNew = 0, enUpdate = 1}

        enMode Mode = enMode.enAddNew;
        public clsTest()
        {
            TestID = null;
            TestAppointmentID = null;
            TestResult = null;
            Notes = "";
            CreatedByUserID = null;
            Mode = enMode.enAddNew;
        }

        public clsTest(int? testID, int? testAppointmentID, bool? testResult, string notes, int? createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            Mode = enMode.enUpdate;
        }

        public static DataTable GetAllTest()
        {
            return clsTestData.GetAllTest();
        }

        public static clsTest GetTestID(int TestID)
        {
            int? testAppointmentID = null, createdByUserID = null;
            bool? testResult = null;
            string notes = "";
            if (clsTestData.GetTestID(TestID,ref testAppointmentID,ref testResult,ref notes,ref createdByUserID))
                return new clsTest(TestID,testAppointmentID, testResult, notes, createdByUserID);

            return null;
        }

        public static clsTest GetTestAppointmentID(int testAppointmentID)
        {
            int? TestID = null, createdByUserID = null;
            bool? testResult = null;
            string notes = "";
            if (clsTestData.GetTestAppointmentID(ref TestID, testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new clsTest(TestID, testAppointmentID, testResult, notes, createdByUserID);

            return null;
        }

        private int? _AddNewTest()
        {
            return clsTestData.AddNewTest(TestAppointmentID,TestResult,Notes,CreatedByUserID);
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(TestID,TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        public bool Save()
        {
            if(Mode == enMode.enAddNew)
            {
                TestID = _AddNewTest();
                if (TestID != null)
                    return true;
            }
            else
            {
                if (_UpdateTest())
                    return true;
            }
            return false;
        }
    }
}
