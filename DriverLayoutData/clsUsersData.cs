using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DriverLayoutData
{
    public class clsUsersData
    {
        public static bool GetUsersWithPersonID(ref Nullable<int> UserID, Nullable<int> PersonID,ref string UserName,ref string Password,
            ref Nullable<bool> IsActive)
        {
            bool isFound = false;

            string query = @"select UserID ,UserName ,Password ,IsActive from Users 
                            where PersonID = @PersonID ";

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
                                UserID = (int)reader["UserID"];
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];

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

        public static bool GetLogin(string UserName, string Password)
        {
            bool isFound = false;

            string query = "select x = 'yes' from Users where UserName = @UserName and Password = @Password and IsActive = 'true'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
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

        public static DataTable GetAllUsers()
        {
 
            DataTable dataTable = new DataTable();
            string query = @"select Users.UserID , Users.PersonID ,FullName = 
                            (People.FirstName + ' ' + People.SecondName + ' '+ People.ThirdName+ ' ' + People.LastName),
                            Users.UserName ,Users.IsActive from Users inner join People 
                            on Users.PersonID = People.PersonID;";

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


        public static bool GetUsersAboutPersonID(int PersonID)
        {
            bool isFound = false;

            string query = @"select x='yes' from Users 
                            where PersonID = @PersonID ";

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

        public static bool GetUsersAboutNationalNo(string NationalNo)
        {
            bool isFound = false;

            string query = @"select x='yes' from Users inner join People
                            on Users.PersonID = People.PersonID 
                            where People.NationalNo = @NationalNo ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
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

        public static Nullable<int> AddNewUser(Nullable<int> PersonID, string UserName, string Password, Nullable<bool> IsActive)
        {
            Nullable<int> IsRowAdded = null;

            string query = @"INSERT INTO Users
                               (PersonID
                               ,UserName
                               ,Password
                               ,IsActive)
                         VALUES
                               (@PersonID
                               ,@UserName
                               ,@Password
                               ,@IsActive);
                           select SCOPE_IDENTITY() ;";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(),out int intResult))
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


        public static Nullable<bool> UpdateUser(Nullable<int> UserID, Nullable<int> PersonID, string UserName, string Password, Nullable<bool> IsActive)
        {
            Nullable<bool> RowAffected = null;

            string query = @"UPDATE Users
                               SET PersonID = @PersonID
                                  ,UserName = @UserName
                                  ,Password = @Password
                                  ,IsActive = @IsActive
                             WHERE UserID = @UserID";
            
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
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
                       // clsDataAccessSetting.SetEventLog(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return RowAffected;
        }

        public static bool GetUsersName(string UserName)
        {
            bool isFound = false;

            string query = @"select x='yes' from Users 
                            where UserName = @UserName ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
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

        public static bool SearchUserNameAndPersonID(Nullable<int> PersonID, string UserName)
        {
            bool isFound = false;

            string query = @"select x='yes' from Users 
                            where PersonID = @PersonID and UserName = @UserName ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
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

        public static bool DeleteUser(Nullable<int> UserID)
        {
            bool IsDeleted = false;

            string query = @"DELETE FROM Users
                            WHERE UserID = @UserID ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
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

        public static bool CheckCurrentPassword(string UserName, string Password)
        {
            bool isFound = false;

            string query = "select x = 'yes' from Users where UserName = @UserName and Password = @Password ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
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

        public static bool GetUsersWithUserName(ref Nullable<int> UserID,ref Nullable<int> PersonID, string UserName, ref string Password,
            ref Nullable<bool> IsActive)
        {
            bool isFound = false;

            string query = @"select UserID ,PersonID ,Password ,IsActive from Users 
                            where UserName = @UserName ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];

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

        public static bool GetUsersID( Nullable<int> UserID, ref Nullable<int> PersonID,ref string UserName, ref string Password,
           ref Nullable<bool> IsActive)
        {
            bool isFound = false;

            string query = @"select UserName ,PersonID ,Password ,IsActive from Users 
                            where UserID = @UserID ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserName = (string)reader["UserName"];
                                PersonID = (int)reader["PersonID"];
                                Password = (string)reader["Password"];
                                IsActive = (bool)reader["IsActive"];

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
