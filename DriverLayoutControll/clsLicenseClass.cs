using DriverLayoutData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutControll
{
    public class clsLicenseClass
    {
        public int? LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int? MinimumAllowedAge { get; set; }
        public int? DefaultValidityLength { get; set; }
        public float? ClassFees { get; set; }

        public clsLicenseClass()
        {
            LicenseClassID = null;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = null;
            DefaultValidityLength = null;
            ClassFees = null;
        }

        public clsLicenseClass(int? licenseClassID, string className, string classDescription, int? minimumAllowedAge, int? defaultValidityLength,
            float? classFees)
        {
            LicenseClassID = licenseClassID;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            DefaultValidityLength = defaultValidityLength;
            ClassFees = classFees;
        }

        public static DataTable FindAllClassName()
        {
            return clsLicenseClassData.GetAllClassName();
        }

        public static clsLicenseClass GetLicenseClassName(string ClassName)
        {
            int? licenseClassID = null, minimumAllowedAge = null, defaultValidityLength = null;
            string classDescription = "";
            float? classFees = null;
            if (clsLicenseClassData.GetLicenseClassName(ref licenseClassID, ClassName,ref classDescription,ref minimumAllowedAge,
                ref defaultValidityLength,ref classFees))
            {
                return new clsLicenseClass(licenseClassID, ClassName, classDescription, minimumAllowedAge,defaultValidityLength, classFees);
            }
            return null;
        }

        public static clsLicenseClass GetLicenseClassID(int LicenseClassID)
        {
            int? minimumAllowedAge = null, defaultValidityLength = null;
            string classDescription = "", ClassName = "";
            float? classFees = null;
            if (clsLicenseClassData.GetLicenseClassID(LicenseClassID,ref ClassName, ref classDescription, ref minimumAllowedAge,
                ref defaultValidityLength, ref classFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
            }
            return null;
        }

    }
}
