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
    public class clsApplicationData
    {
        public static DataTable GetAllApplications()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from Applications ;";

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

        public static bool GetApplicationID(Nullable<int> ApplicationID,ref Nullable<int> ApplicantPersonID,ref Nullable<DateTime> ApplicationDate, 
            ref Nullable<int> ApplicationTypeID, ref Nullable<int> ApplicationStatus, ref Nullable<DateTime> LastStatusDate, ref Nullable<float> PaidFees,
            ref Nullable<int> CreatedByUserID)
        {
            bool IsFounded = false;
            string query = @"select * from Applications where ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicantPersonID = (int)reader["ApplicantPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = (byte)reader["ApplicationStatus"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static Nullable<int> AddApplicationID( Nullable<int> ApplicantPersonID, Nullable<DateTime> ApplicationDate,
           Nullable<int> ApplicationTypeID, Nullable<int> ApplicationStatus, Nullable<DateTime> LastStatusDate, Nullable<float> PaidFees,
           Nullable<int> CreatedByUserID)
        {
            Nullable<int> AppID = null;
            DataTable dataTable = new DataTable();
            string query = @"INSERT INTO Applications
                                       (ApplicantPersonID
                                       ,ApplicationDate
                                       ,ApplicationTypeID
                                       ,ApplicationStatus
                                       ,LastStatusDate
                                       ,PaidFees
                                       ,CreatedByUserID)
                                 VALUES
                                       (@ApplicantPersonID
                                       ,@ApplicationDate
                                       ,@ApplicationTypeID
                                       ,@ApplicationStatus
                                       ,@LastStatusDate
                                       ,@PaidFees
                                       ,@CreatedByUserID);
                                select SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int intResult))
                        {
                            AppID = intResult;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return AppID;
        }


        public static Nullable<bool> UpdateApplicationID(Nullable<int> ApplicationID, Nullable<int> ApplicantPersonID, Nullable<DateTime> ApplicationDate,
           Nullable<int> ApplicationTypeID, Nullable<int> ApplicationStatus, Nullable<DateTime> LastStatusDate, Nullable<float> PaidFees,
           Nullable<int> CreatedByUserID)
        {
            Nullable<bool> IsRowAffected = null;
            DataTable dataTable = new DataTable();
            string query = @"UPDATE Applications
                            SET  ApplicantPersonID = @ApplicantPersonID
                                ,ApplicationDate = @ApplicationDate
                                ,ApplicationTypeID = @ApplicationTypeID
                                ,ApplicationStatus = @ApplicationStatus
                                ,LastStatusDate = @LastStatusDate
                                ,PaidFees = @PaidFees
                                ,CreatedByUserID = @CreatedByUserID
                            WHERE ApplicationID = @ApplicationID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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


        public static Nullable<bool> DeleteApplication(Nullable<int> ApplicationID)
        {

            Nullable<bool> IsDeletedApp = null;
            string query = @"DELETE FROM Applications
                             WHERE ApplicationID = @ApplicationID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        connection.Open();

                        int Result = command.ExecuteNonQuery();
                        if (Result != 0)
                        {
                            IsDeletedApp = true;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsDeletedApp;
        }

        public static bool IsCompleted(Nullable<int> LDLApplicationID, ref Nullable<int> ApplicationID , ref Nullable<int> ApplicantPersonID 
        ,ref Nullable<int> ApplicationTypeID , ref Nullable<int> ApplicationStatus , ref Nullable<int> CreatedByUserID 
        ,ref Nullable<float> PaidFees , ref Nullable<DateTime> ApplicationDate , ref Nullable<DateTime> LastStatusDate)
        {

            bool IsDeletedApp = false;
            string query = @"Select Applications.ApplicationID, Applications.ApplicantPersonID ,  Applications.ApplicationDate, Applications.ApplicationTypeID
                                ,Applications.ApplicationStatus, Applications.LastStatusDate ,Applications.PaidFees,Applications.CreatedByUserID
                                from Applications inner join LocalDrivingLicenseApplications
                                on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                                WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                and ApplicationStatus != 3";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLApplicationID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicantPersonID = (int)reader["ApplicantPersonID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = Convert.ToByte( reader["ApplicationStatus"]);
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = Convert.ToSingle( reader["PaidFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                IsDeletedApp = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return IsDeletedApp;
        }
    }
}
