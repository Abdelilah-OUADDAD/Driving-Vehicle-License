using DVLDControls;
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
    public partial class ctrlShowUser : UserControl
    {
        public ctrlShowUser()
        {
            InitializeComponent();
        }

        public void FillUser(int PersonID)
        {
            
            ctrlDetailsPerson1.Form_DataBack(PersonID);
            DataTable dataTable = clsUser.GetUserPersonID(PersonID);

            lblUserID.Text = dataTable.Rows[0]["UserID"].ToString();
            lblUserName.Text = dataTable.Rows[0]["UserName"].ToString();
            lblIsActive.Text = dataTable.Rows[0]["IsActive"].ToString();
        }

        
    }
}
