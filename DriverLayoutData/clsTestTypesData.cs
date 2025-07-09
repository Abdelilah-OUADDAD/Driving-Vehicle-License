using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;

namespace DriverLayoutData
{
    public class clsTestTypesData
    {
        public static DataTable GetAllTestTypes()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from TestTypes;";

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

        public static bool GetTestTypeID(int TestTypeID,ref string TestTypeTitle, ref string TestTypeDescription ,ref float? TestTypeFees)
        {

            bool isFound = false;
            string query = @"select * from TestTypes where TestTypeID = @TestTypeID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("TestTypeID", @TestTypeID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestTypeTitle = (string)reader["TestTypeTitle"];
                                TestTypeDescription = (string)reader["TestTypeDescription"];
                                TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);

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

        public static Nullable<int> AddTestTypes(string TestTypeTitle, string TestTypeDescription, Nullable<float> TestTypeFees)
        {
            Nullable<int> IsRowAdded = null;

            string query = @"INSERT INTO TestTypes
                               (TestTypeTitle
                               ,TestTypeDescription
                               ,TestTypeFees)
                         VALUES
                               (@TestTypeTitle
                               ,@TestTypeDescription
                               ,@TestTypeFees);
                           select SCOPE_IDENTITY() ;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                    command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                    command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
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

        public static Nullable<bool> UpdateTestTypes(Nullable<int> TestTypeID, string TestTypeTitle, string TestTypeDescription,Nullable<float> TestTypeFees)
        {
            Nullable<bool> RowAffected = null;

            string query = @"UPDATE TestTypes
                               SET TestTypeTitle = @TestTypeTitle
                                  ,TestTypeDescription = @TestTypeDescription                                  
                                  ,TestTypeFees = @TestTypeFees
                             WHERE TestTypeID = @TestTypeID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                    command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                    command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
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

    }
}
