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
    public partial class FormAddEditPeople : Form
    {
        public FormAddEditPeople()
        {
            InitializeComponent();
        }
        
        public void SendPersonID(int PersonID)
        {
            ctrlPeople1.EditPerson( PersonID);
        }

        private void ctrlPeople1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
