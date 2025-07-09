using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControl
{
    public class clsUsers
    {
        public Nullable<int> UserID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public static clsPeople people;
        enum enMode { enAddNew = 0, enUpdate = 1 }
        enMode Mode = enMode.enAddNew;
        public clsUsers()
        {
            UserID = null;
            PersonID = null;
            UserName = "";
            Password = "";
            IsActive = null;
            Mode = enMode.enAddNew;
        }
        public clsUsers(Nullable<int> userID, Nullable<int> personID, string userName, string password, Nullable<bool> isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Mode = enMode.enUpdate;
        }

        public static clsUsers GetUserWithPersonID(int PersonID)
        {
            Nullable<int> UserID = null;string UserName = "", Password = "";
            Nullable<bool> IsActive = null;
            if (clsUsersData.GetUsersWithPersonID(ref UserID, PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }

        public static clsUsers GetUsersWithUserName(string UserName)
        {
            Nullable<int> UserID = null;
            Nullable<int> PersonID = null;
            string Password = "";
            Nullable<bool> IsActive = null;
            if (clsUsersData.GetUsersWithUserName(ref UserID,ref PersonID, UserName, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }

        public static clsUsers GetUsersID(int UserID)
        {
            string UserName = "";
            Nullable<int> PersonID = null;
            string Password = "";
            Nullable<bool> IsActive = null;
            if (clsUsersData.GetUsersID(UserID, ref PersonID,ref UserName, ref Password, ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }
        public static bool GetLogin(string UserName, string Password)
        {
            return clsUsersData.GetLogin(UserName, Password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }

        public static bool FindPersonID(int PersonID)
        {
            return clsUsersData.GetUsersAboutPersonID(PersonID);
        }

        public static bool FindNationalNo(string NationalNo)
        {
            return clsUsersData.GetUsersAboutNationalNo(NationalNo);
        }

        public static bool FindUsersName(string UserName)
        {
            return clsUsersData.GetUsersName(UserName);
        }

        private Nullable<int> _AddNewUser()
        {
            return clsUsersData.AddNewUser(PersonID,UserName,Password,IsActive);
        }

        private Nullable<bool> _UpdateUser()
        {
            return clsUsersData.UpdateUser(UserID,PersonID, UserName, Password, IsActive);
        }

        public bool Save()
        {
            if (Mode == enMode.enAddNew)
            {
                this.UserID = _AddNewUser();
                if(this.UserID != null)
                {
                    return true;
                }
            }
            else
            {
                if (_UpdateUser() != null? true : false)
                    return true;
            }
            return false;
        }

        public static bool SearchUserNameAndPersonID(Nullable<int> PersonID, string UserName)
        {
            return clsUsersData.SearchUserNameAndPersonID(PersonID, UserName);
        }

        public static bool DeleteUser(Nullable<int> UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool CheckCurrentPassword(string UserName,string Password)
        {
            return clsUsersData.CheckCurrentPassword(UserName, Password);
        }
    }
}
