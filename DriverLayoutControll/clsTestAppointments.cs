using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsTestAppointments
    {
        public int? TestAppointmentID { get; set; }
        public int? TestTypeID { get; set; }
        public int? LocalDrivingLicenseApplicationID { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public float? PaidFees { get; set; }
        public int? CreatedByUserID { get; set; }
        public bool? IsLocked { get; set; }
        public int? RetakeTestApplicationID { get; set; }

        enum enMode { enAddNew = 0, enUpdate = 1 }
        enMode Mode = enMode.enAddNew;
        public clsTestAppointments()
        {
            TestAppointmentID = null;
            TestTypeID = null;
            LocalDrivingLicenseApplicationID = null;
            AppointmentDate = null;
            PaidFees = null;
            CreatedByUserID = null;
            IsLocked = null;
            RetakeTestApplicationID = null;
            Mode = enMode.enAddNew;
        }

        public clsTestAppointments(int? testAppointmentID, int? testTypeID, int? localDrivingLicenseApplicationID,
            DateTime? appointmentDate, float? paidFees, int? createdByUserID, bool? isLocked, int? retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            Mode = enMode.enUpdate;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

        public static DataTable GetTestAppointmentWithLDLApp(int LDLAppID,int TestTypeID)
        {
            return clsTestAppointmentData.GetTestAppointmentWithLDLApp(LDLAppID, TestTypeID);
        }

        public static clsTestAppointments GetTestAppointmentID(int TestAppointmentID)
        {
            int? TestTypeID = null,LocalDrivingLicenseApplicationID = null, CreatedByUserID = null, RetakeTestApplicationID = null;
            DateTime? AppointmentDate = null;
            float? PaidFees = null;
            bool? IsLocked = null;

            if (clsTestAppointmentData.GetTestAppointmentID(TestAppointmentID,ref TestTypeID,ref LocalDrivingLicenseApplicationID,ref AppointmentDate
                ,ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate
                , PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            return null;
        }

        public static clsTestAppointments GetTestAppointmentLDLAppID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int?  TestAppointmentID = null, CreatedByUserID = null, RetakeTestApplicationID = null;
            DateTime? AppointmentDate = null;
            float? PaidFees = null;
            bool? IsLocked = null;

            if (clsTestAppointmentData.GetTestAppointmentLDLAppID(ref TestAppointmentID,  TestTypeID, LocalDrivingLicenseApplicationID, ref AppointmentDate
                , ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate
                , PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            return null;
        }

        private  int? _AddTestAppointment()
        {
            return clsTestAppointmentData.AddTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate
                , PaidFees,CreatedByUserID, IsLocked, RetakeTestApplicationID);
        }

        private bool? _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(TestAppointmentID, AppointmentDate);
        }

        public bool Save()
        {
            if (Mode == enMode.enAddNew)
            {
                TestAppointmentID = _AddTestAppointment();
                if (TestAppointmentID != null)
                    return true;
            }
            else
            {
                if (_UpdateTestAppointment().Value)
                    return true;
            }
            return false;
        }

        public static int? TestTrial(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.TestTrial(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static int? CountPassedTest(int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentData.CountPassedTest(LocalDrivingLicenseApplicationID);
        }

        public static bool FindPassedTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.FindPassedTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsHaveTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentData.IsHaveTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool UpdateTestAppointmentLocked(int TestAppointmentID,bool IsLocked)
        {
            return clsTestAppointmentData.UpdateTestAppointmentLocked(TestAppointmentID, IsLocked);
        }
    }
}
