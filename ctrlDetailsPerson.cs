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
    public partial class ctrlDetailsPerson : UserControl
    {
       
        public ctrlDetailsPerson()
        {
            InitializeComponent();
            
        }


        DataTable dtPerson;
        private int _PersonID { get; set; }
        public delegate void SendDataBack(object sender, DataTable dtPerson);
        public static event SendDataBack DataBack;
        public void Form_DataBack(int PersonID)
        {
            _PersonID = PersonID; 
             dtPerson = clsPerson.GetPerson(PersonID);

            lblPersonID.Text = dtPerson.Rows[0]["PersonID"].ToString();
            lblName.Text = dtPerson.Rows[0]["FirstName"].ToString() + " " + dtPerson.Rows[0]["SecondName"].ToString() + " " + dtPerson.Rows[0]["ThirdName"].ToString()
                + " " + dtPerson.Rows[0]["LastName"].ToString();
            lblNationalNo.Text = dtPerson.Rows[0]["NationalNo"].ToString();
            if (Convert.ToInt32( dtPerson.Rows[0]["Gendor"]) == 0)
            {
                lblGendor.Text = "Male";
            }
            else if(Convert.ToInt32(dtPerson.Rows[0]["Gendor"]) == 1)
            {
                lblGendor.Text = "Female";
            }
            lblEmail.Text = dtPerson.Rows[0]["Email"].ToString();
            lblAddress.Text = dtPerson.Rows[0]["Address"].ToString();
            lblDOB.Text = dtPerson.Rows[0]["DateOfBirth"].ToString();
            lblPhone.Text = dtPerson.Rows[0]["Phone"].ToString();
            lblCountry.Text = clsPerson.GetNameCountry((int)dtPerson.Rows[0]["NationalityCountryID"]);


            try
            {
                pictureBox1.Load(dtPerson.Rows[0]["ImagePath"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DataBack?.Invoke(this, dtPerson);

        }
       
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FormAddEditPeople frm = new FormAddEditPeople();
            frm.SendPersonID(_PersonID);
            frm.ShowDialog();
            Form_DataBack(_PersonID);
        }
    }
}
