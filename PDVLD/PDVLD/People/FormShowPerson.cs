using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.People.Controle
{
    public partial class FormShowPerson: Form
    {
        public FormShowPerson()
        {
            InitializeComponent();
        }
        public FormShowPerson(int PersonID)
        {
            InitializeComponent();
            if (PersonID > 0)
            {
                ctrlShowCard2.FillShowPerson(PersonID);
            }
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
