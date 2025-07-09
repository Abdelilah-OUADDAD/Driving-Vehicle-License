using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutData
{
    public class clsPeopleData
    {
        
        public static bool GetPeopleID(int PersonID,ref string NationalNo,ref string FirstName, ref string SecondName,ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref byte Gendor,ref string Address, ref string Phone, ref string Email,
            ref int NationalityCountryID,ref string ImagePath)
        {
            bool isFound = false;

            string query = "select * from People where PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"])) 
            {

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                NationalNo = (string)reader["NationalNo"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                LastName = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = (byte)reader["Gendor"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];
                                NationalityCountryID = (int)reader["NationalityCountryID"];

                                if (reader["ThirdName"] == DBNull.Value)
                                    ThirdName = "";
                                else
                                    ThirdName = (string)reader["ThirdName"];

                                if (reader["Email"] == DBNull.Value)
                                    Email = "";
                                else
                                    Email = (string)reader["Email"];

                                if (reader["ImagePath"] == DBNull.Value)
                                    ImagePath = "";
                                else
                                    ImagePath = (string)reader["ImagePath"];
                                
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


        public static bool GetPeopleNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email,
            ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            string query = "select * from People where NationalNo = @NationalNo";

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
                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                NationalityCountryID = (int)reader["NationalityCountryID"];
                                LastName = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = (byte)reader["Gendor"];
                                Address = (string)reader["Address"];
                                Phone = (string)reader["Phone"];

                                if (reader["ThirdName"] == DBNull.Value)
                                    ThirdName = "";
                                else
                                    ThirdName = (string)reader["ThirdName"];

                                if (reader["Email"] == DBNull.Value)
                                    Email = "";
                                else
                                    Email = (string)reader["Email"];
                                
                                if (reader["ImagePath"] == DBNull.Value)
                                    ImagePath = "";
                                else
                                    ImagePath = (string)reader["ImagePath"];

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

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT PersonID
                                  ,NationalNo
                                  ,FirstName
                                  ,SecondName
                                  ,ThirdName
                                  ,LastName
                                  ,DateOfBirth
                                  ,Gendor
                                  ,Phone
                                  ,Email
                                  ,Nationality = (select CountryName from Countries where CountryID = NationalityCountryID)
                                  
                              FROM People";

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

        public static int AddNewPeople(string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email,
            int NationalityCountryID,  string ImagePath)
        {
            int PeopleID = -1;

            string query = @"INSERT INTO People
                               (NationalNo
                               ,FirstName
                               ,SecondName
                               ,ThirdName
                               ,LastName
                               ,DateOfBirth
                               ,Gendor
                               ,Address
                               ,Phone
                               ,Email
                               ,NationalityCountryID
                               ,ImagePath)
                            VALUES
                               (@NationalNo
                               ,@FirstName
                               ,@SecondName
                               ,@ThirdName
                               ,@LastName
                               ,@DateOfBirth
                               ,@Gendor
                               ,@Address
                               ,@Phone
                               ,@Email
                               ,@NationalityCountryID
                               ,@ImagePath)
                        select SCOPE_IDENTITY(); ";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);

                    if (ThirdName == "")
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);

                    if (Email == "")
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", Email);

                    if(ImagePath == null)
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);


                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        
                        if (Result != null && int.TryParse(Result.ToString(),out int intResult))
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


        public static bool UpdatePeople(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            bool RowAffect = false;

            string query = @"UPDATE People
                           SET NationalNo = @NationalNo
                              ,FirstName = @FirstName
                              ,SecondName = @SecondName
                              ,ThirdName = @ThirdName
                              ,LastName = @LastName
                              ,DateOfBirth = @DateOfBirth
                              ,Gendor = @Gendor
                              ,Address = @Address
                              ,Phone = @Phone
                              ,Email = @Email
                              ,NationalityCountryID = @NationalityCountryID
                              ,ImagePath = @ImagePath
                         WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Gendor", Gendor);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    if (ThirdName == "")
                        command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ThirdName", ThirdName);

                    if (Email == "")
                        command.Parameters.AddWithValue("@Email", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Email", Email);

                    if (ImagePath == null)
                        command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImagePath", ImagePath);

                    try
                    {
                        connection.Open();
                        int Result = command.ExecuteNonQuery();

                        if (Result != 0 )
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

        public static bool DeletePeople(int PersonID)
        {
            bool RowAffect = false;

            string query = @"DELETE FROM People
                             WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool FindNationaleNo(string NationalNo)
        {
            bool isFound = false;

            string query = "select x = 'yes' from People where NationalNo = @NationalNo";

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
    }
}
