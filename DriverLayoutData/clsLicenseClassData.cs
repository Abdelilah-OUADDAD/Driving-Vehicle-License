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
    public class clsLicenseClassData
    {
        public static DataTable GetAllClassName()
        {

            DataTable dataTable = new DataTable();
            string query = @"select ClassName from LicenseClasses ;";

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


        public static bool GetLicenseClassName(ref int? licenseClassID,string ClassName,ref string classDescription, ref int? minimumAllowedAge,
          ref int? defaultValidityLength, ref float? classFees)
        {
            bool isFound = false;
            DataTable dataTable = new DataTable();
            string query = @"select * from LicenseClasses where ClassName = @ClassName;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ClassName", ClassName);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                licenseClassID = (int)reader["LicenseClassID"];
                                classDescription = (string)reader["ClassDescription"];
                                minimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                                defaultValidityLength = (byte)reader["DefaultValidityLength"];
                                classFees = Convert.ToSingle(reader["classFees"]);

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

        public static bool GetLicenseClassID(int? licenseClassID, ref string ClassName, ref string classDescription, ref int? minimumAllowedAge,
          ref int? defaultValidityLength,ref float? classFees)
        {
            bool isFound = false;
            DataTable dataTable = new DataTable();
            string query = @"select * from LicenseClasses where LicenseClassID = @LicenseClassID;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ClassName = (string)reader["ClassName"];
                                classDescription = (string)reader["ClassDescription"];
                                minimumAllowedAge = Convert.ToByte(reader["MinimumAllowedAge"]);
                                defaultValidityLength = Convert.ToByte(reader["DefaultValidityLength"]);
                                classFees = Convert.ToSingle(reader["classFees"]);

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
