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
    public class clsDetainedLicenseData
    {

        public static DataTable GetAllDetainedLicenses()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from DetainedLicenses ;";

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

        public static DataTable GetAllDetainedLicensesView()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from DetainedLicenses_View ;";

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

        public static bool GetDetainedID(int? DetainedID,ref int? LicenseID, ref DateTime? DetainDate, ref float? FineFees, ref int? CreatedByUserID,
            ref bool? IsReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {

            bool isFound = false;
            string query = @"select * from DetainedLicenses where DetainID = @DetainedID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainedID", DetainedID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = (bool)reader["IsReleased"];
                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["ReleaseDate"];
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

        public static bool GetDetainedWithLicenseID (ref int? DetainID, int? LicenseID, ref DateTime? DetainDate, ref float? FineFees, ref int? CreatedByUserID,
            ref bool? IsReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {

            bool isFound = false;
            string query = @"select * from DetainedLicenses where LicenseID = @LicenseID order by DetainID desc;";

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
                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = Convert.ToSingle(reader["FineFees"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsReleased = (bool)reader["IsReleased"] ;
                                ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"];
                                ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"];
                                ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["ReleaseDate"];
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

        public static int? AddDetained(int? LicenseID, DateTime? DetainDate, float? FineFees, int? CreatedByUserID,
            bool? IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {

            int? NewID = null;
            string query = @"INSERT INTO DetainedLicenses
                               (LicenseID
                               ,DetainDate
                               ,FineFees
                               ,CreatedByUserID
                               ,IsReleased
                               ,ReleaseDate
                               ,ReleasedByUserID
                               ,ReleaseApplicationID)
                         VALUES
                               (@LicenseID 
                               ,@DetainDate
                               ,@FineFees
                               ,@CreatedByUserID
                               ,@IsReleased
                               ,@ReleaseDate
                               ,@ReleasedByUserID
                               ,@ReleaseApplicationID)
		                       select SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);
                    if(ReleaseDate == null)
                        command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

                    if(ReleasedByUserID == null)
                        command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

                    if(ReleaseApplicationID == null)
                        command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();
                        if(Result != null && int.TryParse(Result.ToString(), out int intResult))
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

        public static bool UpdateDetained(int? DetainedID, int? LicenseID, DateTime? DetainDate, float? FineFees, int? CreatedByUserID,
            bool? IsReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {

            bool RowAffect = false;
            string query = @"UPDATE DetainedLicenses
                           SET LicenseID = @LicenseID
                              ,DetainDate = @DetainDate
                              ,FineFees = @FineFees
                              ,CreatedByUserID = @CreatedByUserID 
                              ,IsReleased = @IsReleased
                              ,ReleaseDate = @ReleaseDate
                              ,ReleasedByUserID = @ReleasedByUserID
                              ,ReleaseApplicationID = @ReleaseApplicationID
                         WHERE DetainID = @DetainedID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainedID", DetainedID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);
                    if (ReleaseDate == null)
                        command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);

                    if (ReleasedByUserID == null)
                        command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

                    if (ReleaseApplicationID == null)
                        command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                    try
                    {
                        connection.Open();

                        int RowsNumber = command.ExecuteNonQuery();
                        
                        if (RowsNumber != 0)
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

        public static bool CheckIsDetained(int LicenseID)
        {

            bool isFound = false;
            string query = @"select x='yes' from DetainedLicenses where LicenseID = @LicenseID and IsReleased = 'false';";

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


    }

}
