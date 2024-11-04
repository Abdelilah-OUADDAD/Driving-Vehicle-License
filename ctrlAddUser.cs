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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLDProject
{
    public partial class ctrlAddUser : UserControl
    {
        public ctrlAddUser()
        {
            InitializeComponent();
        }

        private void _FilleComboBox()
        {

            
            cmbFilter.Items.Add("PersonID");
            cmbFilter.Items.Add("NationalNo");
            cmbFilter.Items.Add("FirstName");
            cmbFilter.Items.Add("SecondName");
            cmbFilter.Items.Add("ThirdName");
            cmbFilter.Items.Add("LastName");
            cmbFilter.Items.Add("Nationality");
            cmbFilter.Items.Add("Gendor");
            cmbFilter.Items.Add("Phone");
            cmbFilter.Items.Add("Email");

            cmbFilter.SelectedItem = "NationalNo";

        }

        private void ctrlAddUser_Load(object sender, EventArgs e)
        {
            _FilleComboBox();
        }
        DataTable data;
        private void _FillDataTable()
        {

            data = clsPerson.GetAllPeople();
        }


       

        private void FilterData(int column)
        {
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
              
                if (data.Rows[i][column].ToString().ToLower() == textBox1.Text.ToLower())
                {
                    ctrlDetailsPerson1.Form_DataBack((int)data.Rows[i][0]);
                    PersonIDForUser = (int)data.Rows[i][0];
                    return;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FillDataTable();

            switch (cmbFilter.Text)
            {
                case "PersonID":
                    FilterData(0);
                    break;

                case "NationalNo":
                    FilterData(1);
                    break;

                case "FirstName":
                    FilterData(2);
                    break;
                case "SecondName":
                    FilterData(3);
                    break;
                case "ThirdName":
                    FilterData(4);
                    break;
                case "LastName":
                    FilterData(5);
                    break;
                case "Nationality":
                    FilterData(11);
                    break;
                case "Gendor":
                    FilterData(9);
                    break;
                case "Phone":
                    FilterData(9);
                    break;
                case "Email":
                    FilterData(10);
                    break;
            }
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            FormAddEditPeople form = new FormAddEditPeople();
            clsPerson.Mode = clsPerson.enMode.enAddNew;
            ctrlPeople.DataBack += Load_DataUse;
            form.ShowDialog();

        }
        public int PersonIDForUser;

        private void Load_DataUse(object sender ,int PersonID)
        {
            PersonIDForUser = PersonID;
            ctrlDetailsPerson1.Form_DataBack(PersonID);
            
        }

        public void FillDetailsPerson(int PersonID)
        {
            ctrlDetailsPerson1.Form_DataBack(PersonID);
        }

    }
}
