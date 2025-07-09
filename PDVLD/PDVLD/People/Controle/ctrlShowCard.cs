using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverLayoutControl;

namespace PDVLD.People.Controle
{
    public partial class ctrlShowCard: UserControl
    {
        public ctrlShowCard()
        {
            InitializeComponent();
        }
        public bool IsFoundPerson = false;

        public event Action<int> SendPersonID;

        public void FillShowPerson(int PersonID)
        {
            clsPeople people = clsPeople.GetPeopleID(PersonID);
            if (people != null)
            {
                lblPersonID.Text = people.PersonID.ToString();
                lblName.Text = people.FullName;
                lblNationalNo.Text = people.NationalNo.ToString();
                lblEmail.Text = people.Email.ToString();
                lblAddress.Text = people.Address.ToString();
                lblDateOfBirth.Text = people.DateOfBirth.ToString();
                lblPhone.Text = people.Phone.ToString();
                pictureBox1.ImageLocation = people.ImagePath;

                if (people.Gendor == 0)
                    lblGender.Text = "Male";
                else
                    lblGender.Text = "Female";
                clsCountries cls = clsCountries.GetCountryID(people.NationalityCountryID);
                lblCountry.Text = cls.CountryName;
                IsFoundPerson = true;
                if (SendPersonID != null)
                    SendPersonID(people.PersonID);
            }
            else
            {
                EmptyShowPerson();
                MessageBox.Show("Person Not Found !", "Not Allowed");
            }
                
            
        }

        public void FillShowPersonWithNationalNo(string NationalNo)
        {

            clsPeople people = clsPeople.GetPeopleNationalNo(NationalNo);
            if (people != null)
            {
                lblPersonID.Text = people.PersonID.ToString();
                lblName.Text = people.FullName;
                lblNationalNo.Text = people.NationalNo.ToString();
                lblEmail.Text = people.Email.ToString();
                lblAddress.Text = people.Address.ToString();
                lblDateOfBirth.Text = people.DateOfBirth.ToString();
                lblPhone.Text = people.Phone.ToString();
                pictureBox1.ImageLocation = people.ImagePath;

                if (people.Gendor == 0)
                    lblGender.Text = "Male";
                else
                    lblGender.Text = "Female";
                clsCountries cls = clsCountries.GetCountryID(people.NationalityCountryID);
                lblCountry.Text = cls.CountryName;
                IsFoundPerson = true;
                if (SendPersonID != null)
                    SendPersonID(people.PersonID);

            }
            else
            {
                EmptyShowPerson();
                MessageBox.Show("Person Not Found !", "Not Allowed");
            }
        }

        private void EmptyShowPerson()
        {
            lblPersonID.Text = "[???]";
            lblName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblEmail.Text = "[???]";
            lblAddress.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblPhone.Text = "[???]";
            pictureBox1.ImageLocation = "[???]";
            lblGender.Text = "[???]";
            lblCountry.Text = "[???]";
        }
        private void LinkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblPersonID.Text != "[???]") 
            {
                FormAddNewPerson frm = new FormAddNewPerson(clsPeople.enMode.enUpdate, int.Parse(lblPersonID.Text));
                frm.ShowDialog();
                FillShowPerson(int.Parse(lblPersonID.Text));
            }
        }
    }
}
