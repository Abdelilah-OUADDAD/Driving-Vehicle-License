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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace DVLDProject
{
    public partial class FormPersonDetails : Form
    {
        
        public FormPersonDetails()
        {
            InitializeComponent();
            
        }
        int PersonID;
        public FormPersonDetails(int personID)
        {
            InitializeComponent();
            PersonID = personID;
        }



        private void FormPersonDetails_Load(object sender, EventArgs e)
        {

            ctrlDetailsPerson1.Form_DataBack(PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
