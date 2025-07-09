using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutData
{
    public class clsTestAppointmentData
    {

        public static DataTable GetAllTestAppointments()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from TestAppointments;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return dataTable;
        }

        public static DataTable GetTestAppointmentWithLDLApp(int LDLAppID,int TestTypeID)
        {

            DataTable dataTable = new DataTable();
            string query = @"select TestAppointmentID,AppointmentDate,PaidFees,IsLocked 
                            from TestAppointments where LocalDrivingLicenseApplicationID = @LDLAppID and TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return dataTable;
        }


        public static bool GetTestAppointmentID(int? TestAppointmentID, ref int? TestTypeID, ref int? LocalDrivingLicenseApplicationID,
            ref DateTime? AppointmentDate,ref float? PaidFees,ref int? CreatedByUserID,ref bool? IsLocked,ref int? RetakeTestApplicationID)
        {

            bool isFound = false;
            string query = @"select * from TestAppointments where TestAppointmentID = @TestAppointmentID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestTypeID = (int)reader["TestTypeID"];
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];
                                RetakeTestApplicationID = reader["RetakeTestApplicationID"] is DBNull ? null : (int?)reader["RetakeTestApplicationID"];


                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        public static bool GetTestAppointmentLDLAppID(ref int? TestAppointmentID, int? TestTypeID, int? LocalDrivingLicenseApplicationID,
           ref DateTime? AppointmentDate, ref float? PaidFees, ref int? CreatedByUserID, ref bool? IsLocked, ref int? RetakeTestApplicationID)
        {

            bool isFound = false;
            string query = @"select * from TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                and TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];
                                RetakeTestApplicationID = reader["RetakeTestApplicationID"] is DBNull ? null : (int?)reader["RetakeTestApplicationID"];


                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isFound;
        }

        public static Nullable<int> AddTestAppointment(int? TestTypeID, int? LocalDrivingLicenseApplicationID,
            DateTime? AppointmentDate, float? PaidFees, int? CreatedByUserID, bool? IsLocked,int? RetakeTestApplicationID)
        {
            Nullable<int> IsRowAdded = null;

            string query = @"INSERT INTO TestAppointments
                               (TestTypeID
                               ,LocalDrivingLicenseApplicationID
                               ,AppointmentDate
                               ,PaidFees
                               ,CreatedByUserID
                               ,IsLocked
                               ,RetakeTestApplicationID)
                         VALUES
                               (@TestTypeID
                               ,@LocalDrivingLicenseApplicationID
                               ,@AppointmentDate
                               ,@PaidFees
                               ,@CreatedByUserID
                               ,@IsLocked
                               ,@RetakeTestApplicationID)
                           select SCOPE_IDENTITY() ;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    if(RetakeTestApplicationID == null)
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int intResult))
                        {
                            IsRowAdded = intResult;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsRowAdded;
        }

        public static Nullable<bool> UpdateTestAppointment(int? TestAppointmentID,DateTime? AppointmentDate)
        {
            Nullable<bool> RowAffected = null;

            string query = @"UPDATE TestAppointments
                               SET AppointmentDate = @AppointmentDate 
                             WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);

                    try
                    {
                        connection.Open();

                        Nullable<int> Result = command.ExecuteNonQuery();

                        if (Result != null)
                        {
                            RowAffected = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return RowAffected;
        }

        public static bool UpdateTestAppointmentLocked(int? TestAppointmentID,bool? IsLocked)
        {
            bool RowAffected = false;

            string query = @"UPDATE TestAppointments
                               SET IsLocked = @IsLocked
                             WHERE TestAppointmentID = @TestAppointmentID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

                    try
                    {
                        connection.Open();

                        Nullable<int> Result = command.ExecuteNonQuery();

                        if (Result != null)
                        {
                            RowAffected = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return RowAffected;
        }

        public static int? TestTrial(int? LocalDrivingLicenseApplicationID, int? TestTypeID)
        {

            int? CountNumber = null;
            string query = @"select count( TestAppointments.LocalDrivingLicenseApplicationID)
                                from TestAppointments inner join Tests 
                                on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                where Tests.TestResult = 'false' and TestAppointments.TestTypeID = @TestTypeID
                                and TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();
                        
                        if (Result != null && int.TryParse(Result.ToString() ,out int RowCount))
                        {
                            CountNumber = RowCount;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return CountNumber;
        }

        public static int? CountPassedTest(int? LocalDrivingLicenseApplicationID)
        {

            int? CountNumber = null;
            string query = @"select  count(TestAppointments.TestTypeID)
                            from TestAppointments inner join Tests 
                            on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            where Tests.TestResult = 'true' and TestAppointments.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int RowCount))
                        {
                            CountNumber = RowCount;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return CountNumber;
        }

        public static bool FindPassedTest(int? LocalDrivingLicenseApplicationID, int? TestTypeID)
        {

            bool isPassed = false;
            string query = @"select  x = 'yes'
                            from TestAppointments inner join Tests 
                            on TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            where Tests.TestResult = 'true' and TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and 
                            TestAppointments.TestTypeID = @TestTypeID and TestAppointments.IsLocked = 'true';";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                isPassed = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isPassed;
        }

        public static bool IsHaveTestAppointment(int? LocalDrivingLicenseApplicationID, int? TestTypeID)
        {

            bool isPassed = false;
            string query = @"select  x = 'yes'
                            from TestAppointments 
                            where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and 
                            TestAppointments.TestTypeID = @TestTypeID and IsLocked = 'false'
                            order by TestAppointments.TestAppointmentID desc;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                isPassed = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return isPassed;
        }

    }
}
