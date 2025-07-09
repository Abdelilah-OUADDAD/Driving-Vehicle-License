using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDVLD.Users;
using DriverLayoutControl;

namespace PDVLD.People.Controle
{
    public partial class ctrlShowCardWithFilter: UserControl
    {
        public ctrlShowCardWithFilter()
        {
            InitializeComponent();
        }

        public delegate void DataBackPerson(object sender, int PrintID);

        public event DataBackPerson onPersonID;

        public delegate void DataBackNational(object sender, string NationalNo);

        public event DataBackNational onNationalNo;

        //-- EVENT 
        public event Action<int> SendPersonID;

        public bool IsFoundPerson = false;
        public void SendDataShowCard(int PersonID)
        {
            textBox1.Text = PersonID.ToString();
            gbFilter.Enabled = false;
            cmbFilter.SelectedItem = "Person ID";
            
            btnSearch_Click(null,null);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "Person ID")
            {
                ctrlShowCard2.FillShowPerson(int.Parse(textBox1.Text));
                onPersonID?.Invoke(this, int.Parse(textBox1.Text));
                IsFoundPerson = ctrlShowCard2.IsFoundPerson;
            }
            else
            {
                ctrlShowCard2.FillShowPersonWithNationalNo(textBox1.Text);
                onNationalNo?.Invoke(this, textBox1.Text);
                IsFoundPerson = ctrlShowCard2.IsFoundPerson;
            }

            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlShowCardWithFilter_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedItem = "Person ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddNewPerson frm = new FormAddNewPerson(clsPeople.enMode.enAddNew);
            frm.ShowDialog();
        }

        private void ctrlShowCard2_SendPersonID(int obj)
        {
            if(SendPersonID != null)
            {
                SendPersonID(obj);
            }
        }
    }
}
