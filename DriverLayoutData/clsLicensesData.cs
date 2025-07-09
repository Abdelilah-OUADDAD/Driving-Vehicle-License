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
    public class clsLicensesData
    {

        public static bool GetLicenseID(int? LicenseID,ref int? ApplicationID,ref int? DriverID, ref int? LicenseClass, ref DateTime? IssueDate,
            ref DateTime? ExpirationDate, ref string Notes , ref float? PaidFees , ref bool? IsActive, ref int? IssueReason,ref int? CreatedByUserID)
        {
            bool isFound = false;

            string query = "select * from Licenses where LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                Notes = reader["Notes"] is DBNull ? "" : (string)reader["Notes"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = Convert.ToByte(reader["IssueReason"]);
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


        public static bool GetLicensesWithApplicationID(ref int? LicenseID, int? ApplicationID, ref int? DriverID, ref int? LicenseClass, ref DateTime? IssueDate,
             ref DateTime? ExpirationDate, ref string Notes, ref float? PaidFees, ref bool? IsActive, ref int? IssueReason, ref int? CreatedByUserID)
        {
            bool isFound = false;

            string query = "select * from Licenses where ApplicationID = @ApplicationID";

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
                                LicenseID = (int)reader["LicenseID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                Notes = reader["Notes"] is DBNull ? "": (string)reader["Notes"];
                                PaidFees = Convert.ToSingle(reader["PaidFees"]);
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = Convert.ToByte(reader["IssueReason"]);
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

        public static bool GetLicenseIsActive(int LicenseID)
        {
            bool IsActive = false;

            string query = @"SELECT x = 'yes'FROM Licenses
                                where LicenseID = @LicenseID and IsActive = 'true' and GETDATE() < ExpirationDate
                                                             and LicenseClass = 3   ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                IsActive = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return IsActive;
        }

        public static bool GetLicenseIsExpirationDateOver(int LicenseID)
        {
            bool IsActive = false;

            string query = @"SELECT x = 'yes'FROM Licenses
                                where LicenseID = @LicenseID and IsActive = 'true' and ExpirationDate > GETDATE()  ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                IsActive = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return IsActive;
        }

        public static bool CheckLicenseIsActive(int LicenseID)
        {
            bool IsActive = false;

            string query = @"SELECT x = 'yes'FROM Licenses
                                where LicenseID = @LicenseID and IsActive = 'true' ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                IsActive = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return IsActive;
        }

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Licenses";

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

        public static DataTable GetLicenseLocal(int DriverID)
        {
            DataTable dt = new DataTable();

            string query = @"SELECT LicenseID,ApplicationID, className = (select ClassName from LicenseClasses where LicenseClassID = LicenseClass) 
                                ,IssueDate ,ExpirationDate,IsActive
                                FROM Licenses
                                where DriverID = @DriverID";

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

        public static int? AddNewLicense(int? ApplicationID, int? DriverID, int? LicenseClass, DateTime? IssueDate,
            DateTime? ExpirationDate, string Notes, float? PaidFees, bool? IsActive, int? IssueReason, int? CreatedByUserID)
        {
            int? PeopleID = null;

            string query = @"INSERT INTO Licenses
                               (ApplicationID
                               ,DriverID
                               ,LicenseClass
                               ,IssueDate
                               ,ExpirationDate
                               ,Notes
                               ,PaidFees
                               ,IsActive
                               ,IssueReason
                               ,CreatedByUserID)
                            VALUES
                               (@ApplicationID
                               ,@DriverID
                               ,@LicenseClass
                               ,@IssueDate
                               ,@ExpirationDate
                               ,@Notes
                               ,@PaidFees
                               ,@IsActive
                               ,@IssueReason
                               ,@CreatedByUserID)
                        select SCOPE_IDENTITY(); ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    if(Notes == "" )
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);


                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int intResult))
                        {
                            PeopleID = intResult;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }

                }

            }

            return PeopleID;
        }


        public static bool UpdateLicense(int? LicenseID, int? ApplicationID, int? DriverID, int? LicenseClass, DateTime? IssueDate,
            DateTime? ExpirationDate, string Notes, float? PaidFees, bool? IsActive, int? IssueReason, int? CreatedByUserID)
        {
            bool RowAffect = false;

            string query = @"UPDATE Licenses
                           SET  ApplicationID = @ApplicationID
                               ,DriverID = @DriverID
                               ,LicenseClass = @LicenseClass
                               ,IssueDate = @IssueDate
                               ,ExpirationDate = @ExpirationDate
                               ,Notes = @Notes
                               ,PaidFees = @PaidFees
                               ,IsActive = @IsActive
                               ,IssueReason = @IssueReason
                               ,CreatedByUserID = @CreatedByUserID
                         WHERE LicenseID = @LicenseID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    if (Notes == "")
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);

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

            string query = @"DELETE FROM Licenses
                             WHERE LicenseID = @LicenseID";

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
