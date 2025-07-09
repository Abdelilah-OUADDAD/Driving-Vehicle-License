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
    public class clsManageApplicationTypesData
    {

        public static DataTable GetAllApplicationTypes()
        {

            DataTable dataTable = new DataTable();
            string query = @"select * from ApplicationTypes;";

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

        public static Nullable<int> AddApplicationType( string ApplicationTypeTitle, Nullable<float> ApplicationFees)
        {
            Nullable<int> IsRowAdded = null;

            string query = @"INSERT INTO ApplicationTypes
                               (ApplicationTypeTitle
                               ,ApplicationFees)
                         VALUES
                               (@ApplicationTypeTitle
                               ,@ApplicationFees);
                           select SCOPE_IDENTITY() ;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
                    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
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

        public static Nullable<bool> UpdateApplicationType(Nullable<int> ApplicationTypeID, string ApplicationTypeTitle, Nullable<float> ApplicationFees)
        {
            Nullable<bool> RowAffected = null;

            string query = @"UPDATE ApplicationTypes
                               SET ApplicationTypeTitle = @ApplicationTypeTitle
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
