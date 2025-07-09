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
    public class clsApplicationTypesData
    {

        public static DataTable GetAllApplicationTypes()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from ApplicationTypes ;";

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

        public static bool GetApplicationTypeID(Nullable<int> ApplicationTypeID,ref string ApplicationTypeTitle,ref Nullable<float> ApplicationFees)
        {
            bool IsFounded = false;
            DataTable dataTable = new DataTable();
            string query = @"select * from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                                ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);

                                IsFounded = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsFounded;
        }

        public static bool GetApplicationTypeTitle(ref Nullable<int> ApplicationTypeID, string ApplicationTypeTitle, ref Nullable<float> ApplicationFees)
        {
            bool IsFounded = false;
            DataTable dataTable = new DataTable();
            string query = @"select * from ApplicationTypes where ApplicationTypeTitle = @ApplicationTypeTitle;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);

                                IsFounded = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsFounded;
        }

        public static Nullable<int> AddApplicationTypeID(string ApplicationTypeTitle, Nullable<float> ApplicationFees)
        {
            Nullable<int> AppTypeID = null;
            DataTable dataTable = new DataTable();
            string query = @"INSERT INTO ApplicationTypes
                                       (ApplicationTypeTitle
                                       ,ApplicationFees)
                                 VALUES
                                       (@ApplicationTypeTitle
                                       ,@ApplicationFees);
                                select SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int intResult))
                        {
                            AppTypeID = intResult;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return AppTypeID;
        }


        public static Nullable<bool> UpdateApplicationTypeID(Nullable<int> ApplicationTypeID, string ApplicationTypeTitle, Nullable<float> ApplicationFees)
        {
            Nullable<bool> IsRowAffected = null;
            DataTable dataTable = new DataTable();
            string query = @"UPDATE ApplicationTypes
                            SET  ApplicationTypeTitle = @ApplicationTypeTitle
                                ,ApplicationFees = @ApplicationFees
                            WHERE ApplicationTypeID = @ApplicationTypeID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
                    try
                    {
                        connection.Open();

                        int result = command.ExecuteNonQuery();
                        if (result != 0)
                        {
                            IsRowAffected = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsRowAffected;
        }


        public static Nullable<bool> DeleteApplicationType(Nullable<int> ApplicationTypeID)
        {

            Nullable<bool> IsDeleted = null;
            string query = @"DELETE FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    try
                    {
                        connection.Open();

                        int Result = command.ExecuteNonQuery();
                        if (Result != 0)
                        {
                            IsDeleted = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsDeleted;
        }

    }
}
