using DriverLayoutControl;
using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControl
{
    public class clsPeople
    {
        public int PersonID { get; set; } 
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
       
        public string ThirdName{ get; set; }
        public string LastName{ get; set; }
        public DateTime DateOfBirth{ get; set; }
        public byte Gendor{ get; set; }
        public string Address{ get; set; } 
        public string Phone{ get; set; } 
        public string Email{ get; set; }
        public int NationalityCountryID{ get; set; }
        public string ImagePath { get; set; }

        public string FullName
        {
            get { return this.FirstName + " " + this.SecondName + " " + this.ThirdName + " " + this.LastName; }
        }


        public  enum enMode { enAddNew = 0, enUpdate = 1 }

        public static enMode Mode = enMode.enAddNew;
        public clsPeople() 
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.enAddNew;
        }

        public clsPeople(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath) 
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.enUpdate;
        }

       

        public static clsPeople GetPeopleID(int PersonID)
        {
            string NationalNo = "", FirstName ="",  SecondName = "", ThirdName = "",
            LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = -1;
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            if (clsPeopleData.GetPeopleID( PersonID,ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,
            ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
            ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName,
               LastName, DateOfBirth, Gendor, Address, Phone, Email,
               NationalityCountryID, ImagePath);
            }
            return null;
        }

        public static clsPeople GetPeopleNationalNo(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "",
            LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = -1, PersonID = -1;
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            if (clsPeopleData.GetPeopleNationalNo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName,
            ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
            ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName,
               LastName, DateOfBirth, Gendor, Address, Phone, Email,
               NationalityCountryID, ImagePath);
            }
            return null;
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }

        private int _AddNewPeople()
        {
            return clsPeopleData.AddNewPeople(NationalNo, FirstName, SecondName, ThirdName,
            LastName, DateOfBirth, Gendor, Address, Phone, Email,
            NationalityCountryID, ImagePath);
        }
        private bool _UpdatePeople()
        {
            return clsPeopleData.UpdatePeople(PersonID,NationalNo, FirstName, SecondName, ThirdName,
            LastName, DateOfBirth, Gendor, Address, Phone, Email,
            NationalityCountryID, ImagePath);
        }
        public bool Save()
        {
            if (Mode == enMode.enAddNew)
            {
                this.PersonID = _AddNewPeople();
                if (this.PersonID != -1)
                {
                    return true;
                }
            }
            else if(Mode == enMode.enUpdate)
            {
                if (_UpdatePeople())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool DeletePeople(int PersonID)
        {
            return clsPeopleData.DeletePeople(PersonID);
        }

        public static bool FindNationalNo(string NationalNo)
        {
            return clsPeopleData.FindNationaleNo(NationalNo);
        }
    }
}
