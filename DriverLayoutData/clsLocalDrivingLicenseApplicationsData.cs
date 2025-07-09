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
    public class clsLocalDrivingLicenseApplicationsData
    {
        public static DataTable GetLocalDrivingLicenseApplications()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from LocalDrivingLicenseApplications ;";

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

        public static DataTable GetLocalDrivingLicenseApplicationsView()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from LocalDrivingLicenseApplications_View ;";

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

        public static bool GetLocalDrivingLicenseID(Nullable<int> LocalDrivingLicenseApplicationID, ref Nullable<int> ApplicationID
            , ref Nullable<int> LicenseClassID)
        {
            bool IsFounded = false;
            DataTable dataTable = new DataTable();
            string query = @"select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                LicenseClassID = (int)reader["LicenseClassID"];

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

        public static Nullable<int> AddLocalDrivingLicenseApplication(Nullable<int> ApplicationID, Nullable<int> LicenseClassID)
        {
            Nullable<int> LDLAppID = null;
            DataTable dataTable = new DataTable();
            string query = @"INSERT INTO LocalDrivingLicenseApplications
                                       (ApplicationID
                                       ,LicenseClassID)
                                 VALUES
                                       (@ApplicationID
                                       ,@LicenseClassID);
                                select SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int intResult))
                        {
                            LDLAppID = intResult;
                        }

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return LDLAppID;
        }


        public static Nullable<bool> UpdateLocalDrivingLicenseApplication(Nullable<int> LocalDrivingLicenseApplicationID, Nullable<int> ApplicationID
            , Nullable<int> LicenseClassID)
        {
            Nullable<bool> IsRowAffected = null;
            DataTable dataTable = new DataTable();
            string query = @"UPDATE LocalDrivingLicenseApplications
                            SET  ApplicationID = @ApplicationID
                                ,LicenseClassID = @LicenseClassID
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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


        public static bool DeleteLocalDrivingLicenseApplication(Nullable<int> LocalDrivingLicenseApplicationID)
        {

            bool IsDeleted = false;
            string query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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

        public static bool FindPersonHaveLDLDriving(ref Nullable<int> LocalDrivingLicenseApplicationID,ref Nullable<int> ApplicationID, int ApplicantPersonID,int LicenseClassID)
        {
            bool IsFounded = false;

            string query = @"select Applications.ApplicationID , LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID 
                                from Applications inner join LocalDrivingLicenseApplications
                                on Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                                where LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID 
                                and Applications.ApplicantPersonID = @ApplicantPersonID
                                and Applications.ApplicationStatus != 2;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                ApplicationID = (int)reader["ApplicationID"];
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
    }
}
