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
    public class clsInternationalLicenseData
    {
        public static DataTable GetInternationalLicense()
        {
            DataTable dt = new DataTable();

            string query = @"select InternationalLicenseID ,ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive
                                from InternationalLicenses";

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
        public static DataTable GetLicenseInter(int DriverID)
        {
            DataTable dt = new DataTable();

            string query = @"select InternationalLicenseID ,ApplicationID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive
                                from InternationalLicenses
                                where DriverID = @DriverID;";

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

        
        public static bool GetInternationalLicenseID(int? InternationalLicenseID,ref int? ApplicationID,ref int? DriverID,ref int? IssuedUsingLocalLicenseID,
            ref DateTime? IssueDate,ref DateTime? ExpirationDate, ref bool? IsActive,ref int? CreatedByUserID)
        {
            bool isFound = false;

            string query = "select * from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static bool GetInternationalLicenseLocalID(ref int? InternationalLicenseID, ref int? ApplicationID, ref int? DriverID, int? IssuedUsingLocalLicenseID,
            ref DateTime? IssueDate, ref DateTime? ExpirationDate, ref bool? IsActive, ref int? CreatedByUserID)
        {
            bool isFound = false;

            string query = "select * from InternationalLicenses where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                InternationalLicenseID = (int)reader["InternationalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static int? AddNewInternationalLicense( int? ApplicationID, int? DriverID, int? IssuedUsingLocalLicenseID,
            DateTime? IssueDate, DateTime? ExpirationDate, bool? IsActive, int? CreatedByUserID)
        {
            int? NewID = null;

            string query = @"INSERT INTO InternationalLicenses
                               (ApplicationID
                               ,DriverID
                               ,IssuedUsingLocalLicenseID
                               ,IssueDate
                               ,ExpirationDate
                               ,IsActive
                               ,CreatedByUserID)
                            VALUES
                               (@ApplicationID
                               ,@DriverID
                               ,@IssuedUsingLocalLicenseID
                               ,@IssueDate
                               ,@ExpirationDate
                               ,@IsActive
                               ,@CreatedByUserID)
                        select SCOPE_IDENTITY(); ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int intResult))
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


        public static bool UpdateInternationalLicense(int? InternationalLicenseID, int? ApplicationID, int? DriverID, int? IssuedUsingLocalLicenseID,
            DateTime? IssueDate, DateTime? ExpirationDate, bool? IsActive, int? CreatedByUserID)
        {
            bool RowAffect = false;

            string query = @"UPDATE InternationalLicenses
                           SET  ApplicationID = @ApplicationID
                               ,DriverID = @DriverID
                               ,IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
                               ,IssueDate = @IssueDate
                               ,ExpirationDate = @ExpirationDate
                               ,IsActive = @IsActive
                               ,CreatedByUserID = @CreatedByUserID
                         WHERE InternationalLicenseID = @InternationalLicenseID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    try
                    {
                        connection.Open();
                        int Result = command.ExecuteNonQuery();

                        if (Result != 0)
                        {
                            RowAffect = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return RowAffect;
        }

        public static bool DeleteLicense(int LicenseID)
        {
            bool RowAffect = false;

            string query = @"DELETE FROM InternationalLicenses
                             WHERE InternationalLicenseID = @InternationalLicenseID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();
                        int Result = command.ExecuteNonQuery();

                        if (Result != 0)
                        {
                            RowAffect = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return RowAffect;
        }
    }
}
