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
    public class clsDriversData
    {

        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Drivers";

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

        public static DataTable GetAllDriversView()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Drivers_View";

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

        public static bool GetDriverID(int? DriverID, ref int? PersonID,ref int? CreatedByUserID,ref DateTime? CreatedDate)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Drivers where DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];

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

        public static bool GetDriverWithPersonID(ref int? DriverID, int? PersonID, ref int? CreatedByUserID, ref DateTime? CreatedDate)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Drivers where PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DriverID = (int)reader["DriverID"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];

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

        public static int? AddNewDriver(int? PersonID, int? CreatedByUserID, DateTime? CreatedDate)
        {
            int? NewID = null;

            string query = @"INSERT INTO Drivers
                                       (PersonID
                                       ,CreatedByUserID
                                       ,CreatedDate)
                                 VALUES
                                       (@PersonID
                                       ,@CreatedByUserID
                                       ,@CreatedDate )
                            select SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(),out int intResult))
                        {

                            NewID = intResult;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return NewID;
        }

        public static bool UpdateDriver(int? DriverID,int? PersonID, int? CreatedByUserID, DateTime? CreatedDate)
        {
            bool RowAffected = false;

            string query = @"UPDATE Drivers
                               SET PersonID = @PersonID
                                  ,CreatedByUserID = @CreatedByUserID
                                  ,CreatedDate = @CreatedDate
                             WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    try
                    {
                        connection.Open();

                        int Result = command.ExecuteNonQuery();

                        if (Result != 0)
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

            return RowAffected = true;
        }
    }
}
