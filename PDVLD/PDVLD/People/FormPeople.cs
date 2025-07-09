using PDVLD.People.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriverLayoutControl;
namespace PDVLD.People
{
    public partial class FormPeople: Form
    {
        public FormPeople()
        {
            InitializeComponent();
        }

        DataTable data;

        private void FormPeople_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedItem = "None";

            data = clsPeople.GetAllPeople();

            dataGridView1.DataSource = data;
            if (data.Rows.Count != 0)
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "National No";
                dataGridView1.Columns[1].Width = 120;

                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 150;

                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 150;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 150;

                dataGridView1.Columns[6].HeaderText = "Date Of Birth";
                dataGridView1.Columns[6].Width = 110;

                dataGridView1.Columns[7].HeaderText = "Gender";
                dataGridView1.Columns[7].Width = 50;

                dataGridView1.Columns[8].HeaderText = "Phone";
                dataGridView1.Columns[8].Width = 120;

                dataGridView1.Columns[9].HeaderText = "Email";
                dataGridView1.Columns[9].Width = 200;

                dataGridView1.Columns[10].HeaderText = "Nationality";
                dataGridView1.Columns[10].Width = 60;
            }
            lblRecord.Text = data.Rows.Count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterName = "";

            switch (cmbFilter.SelectedItem)
            {
                case "Person ID":
                    FilterName = "PersonID";
                    break;

                case "National No":
                    FilterName = "NationalNo";
                    break;

                case "First Name":
                    FilterName = "FirstName";
                    break;

                case "Second Name":
                    FilterName = "SecondName";
                    break;

                case "Third Name":
                    FilterName = "ThirdName";
                    break;

                case "Last Name":
                    FilterName = "LastName";
                    break;

                case "Date Of Birth":
                    FilterName = "DateOfBirth";
                    break;

                case "Gender":
                    FilterName = "Gender";
                    break;

                case "Phone":
                    FilterName = "Phone";
                    break;

                case "Email":
                    FilterName = "Email";
                    break;

                case "Nationality":
                    FilterName = "Nationality";
                    break;
                default:
                    FilterName = "None";
                    break;

            }

            if (FilterName == "None" || textBox1.Text.Trim() == "")
            {
                dataGridView1.DataSource = clsPeople.GetAllPeople();
                return;
            }

            if (FilterName == "PersonID" || FilterName == "Phone")
            {
                data.DefaultView.RowFilter = string.Format("{0} = {1}", FilterName, textBox1.Text);

            }
            else
            {
                data.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterName, textBox1.Text);

            }
            dataGridView1.DataSource = data;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewPerson frm = new FormAddNewPerson(clsPeople.enMode.enAddNew);
            frm.ShowDialog();
            FormPeople_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewPerson frm = new FormAddNewPerson(clsPeople.enMode.enUpdate, (int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FormPeople_Load(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddNewPerson frm = new FormAddNewPerson(clsPeople.enMode.enAddNew);
            frm.ShowDialog();
            FormPeople_Load(null, null);
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() != "None")
            {
                textBox1.Visible = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "Phone" || cmbFilter.SelectedItem.ToString() == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (clsPeople.DeletePeople(personID) && MessageBox.Show($"Are you sure to delete PersonID {personID}", "Allowed",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                MessageBox.Show($"Person ID {personID} Deleted Successfully !!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"Person ID {personID} Deleted Failed !!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormPeople_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The Feature Is Not Implemented Yet", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The Feature Is Not Implemented Yet", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowPerson frm = new FormShowPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
