using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;

namespace PDVLD.Global
{
    public class clsUtil
    {
        public static string GetGuide()
        {
            Guid g = Guid.NewGuid();
            return g.ToString();
        }

        public static string CreateFile(string ImagePath)
        {
            string path = "C:\\DVLD-People-Images";
            bool b = System.IO.Directory.Exists(path);
            if (!b)
            {
                System.IO.Directory.CreateDirectory(path);
            }
            //System.IO.Directory.(path,ImagePath,Encoding.UTF8);

            //File.Copy(path, ImagePath);

            return ImagePath;
        }

        public static string DateTimeString(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
        
    }
}
