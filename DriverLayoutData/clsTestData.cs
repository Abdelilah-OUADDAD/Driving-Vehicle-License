using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutData
{
    public class clsTestData
    {

        public static DataTable GetAllTest()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "select * from Tests ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dt.Load(reader);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }

            }


            return dt;
        }


        public static bool GetTestID(int? TestID,ref int? TestAppointmentID,ref bool? TestResult ,ref string Notes,ref int? CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "select * from Tests where TestID = @TestID";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);
                    try
                    {
                        connection.Open();

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];
                                Notes = (string)reader["Notes"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message,EventLogEntryType.Error);
                    }
                }

            }


                return isFound;
        }

        public static bool GetTestAppointmentID(ref int? TestID, int? TestAppointmentID, ref bool? TestResult, ref string Notes, ref int? CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "select * from Tests where TestAppointmentID = @TestAppointmentID";

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
                                TestID = (int)reader["TestID"];
                                TestResult = (bool)reader["TestResult"];
                                Notes = (string)reader["Notes"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static int? AddNewTest(int? TestAppointmentID, bool? TestResult, string Notes, int? CreatedByUserID)
        {
            int? Number = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO Tests
                               (TestAppointmentID
                               ,TestResult
                               ,Notes
                               ,CreatedByUserID)
                         VALUES
                               (@TestAppointmentID
                               ,@TestResult
                               ,@Notes
                               ,@CreatedByUserID)
                          select SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    if(Notes == "")
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(),out int intResult))
                        {
                            Number = intResult;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }

            }


            return Number;
        }

        public static bool UpdateTest(int? TestID, int? TestAppointmentID, bool? TestResult, string Notes, int? CreatedByUserID)
        {
            bool isUpdated = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE Tests
                                   SET TestAppointmentID = @TestAppointmentID
                                      ,TestResult = @TestResult
                                      ,Notes = @Notes
                                      ,CreatedByUserID = @CreatedByUserID
                                 WHERE TestID = @TestID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", TestID);
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestResult", TestResult);
                    if (Notes == "")
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();

                        int Result = command.ExecuteNonQuery();
                        if (Result != 0)
                        {
                            isUpdated = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }

            }

            return isUpdated;
        }


    }
}
