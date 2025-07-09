using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControl
{
    public class clsCountries
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountries()
        {
            CountryID = -1;
            CountryName = "";
        }

        public clsCountries(int countryID,string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
        }
        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }

        public static clsCountries GetCountryID(int CountryID)
        {
             string CountryName = "";
            if( clsCountriesData.GetCountryID(CountryID, ref CountryName))
                return new clsCountries(CountryID, CountryName);

            return null;
        }

        public static clsCountries GetCountryName(string CountryName)
        {
            int CountryID = -1;
            if( clsCountriesData.GetCountryName(CountryName,ref CountryID) )
                return new clsCountries(CountryID,CountryName);

            return null;
        }
    }
}
