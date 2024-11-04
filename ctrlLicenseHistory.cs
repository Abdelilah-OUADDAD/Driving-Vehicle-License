using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDProject
{
    public partial class ctrlLicenseHistory : UserControl
    {
        public DataTable dtLicense = new DataTable();
        public int PersonID { get; set; }
        public ctrlLicenseHistory()
        {
            InitializeComponent();
            
           
        }

        private void ctrlLicenseHistory_Load(object sender, EventArgs e)
        {
            if (dtLicense.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtLicense;
                ctrlDetailsPerson1.Form_DataBack(PersonID);
                lblRecord.Text = dataGridView1.Rows.Count.ToString();
            }
        }
    }
}
