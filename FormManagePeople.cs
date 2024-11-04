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
    public partial class FormManagePeople : Form
    {
        public FormManagePeople()
        {
            InitializeComponent();
        }

        

        public void _RefreshData()
        {
            dataGridView1.DataSource = clsPerson.GetAllPeople();
        }

        private void _FilleComboBox()
        {
            
            cmbFilter.Items.Add("None");
            cmbFilter.Items.Add("PersonID");
            cmbFilter.Items.Add("NationalNo.");
            cmbFilter.Items.Add("FirstName");
            cmbFilter.Items.Add("SecondName");
            cmbFilter.Items.Add("ThirdName");
            cmbFilter.Items.Add("LastName");
            cmbFilter.Items.Add("Nationality");
            cmbFilter.Items.Add("Gendor");
            cmbFilter.Items.Add("Phone");
            cmbFilter.Items.Add("Email");

            cmbFilter.SelectedItem = "None";

        }
        DataTable dt;


        private void Form1_Load(object sender, EventArgs e)
        {
            _RefreshData();
            _FilleComboBox();
            DataGridView dataGrid = dataGridView1;
            dt = new DataTable();
            dt.Columns.Add("PersonID", typeof(int));
            dt.Columns.Add("NationalNo", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("SecondName", typeof(string));
            dt.Columns.Add("ThirdName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(DateTime));
            dt.Columns.Add("Gendor", typeof(int));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("NationalityCountryID", typeof(int));
            dt.Columns.Add("ImagePath", typeof(string));
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                dt.Rows.Add(dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value, dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value
                        , dataGridView1.Rows[i].Cells[4].Value, dataGridView1.Rows[i].Cells[5].Value, dataGridView1.Rows[i].Cells[6].Value,
                        dataGridView1.Rows[i].Cells[7].Value, dataGridView1.Rows[i].Cells[8].Value, dataGridView1.Rows[i].Cells[9].Value, dataGridView1.Rows[i].Cells[10].Value,
                        dataGridView1.Rows[i].Cells[11].Value, dataGridView1.Rows[i].Cells[12].Value);

                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            FormAddEditPeople form2 = new FormAddEditPeople();
            form2.ShowDialog();
            Form1_Load(sender,e);
            
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "None")
            {
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
        }
        
        private void _FilterDataGrid(DataTable data, int cells)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][cells].ToString().ToLower().StartsWith(textBox1.Text.ToString().ToLower()))
                {
                    data.Rows.Add(dt.Rows[i][0], dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString()
                        , dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6],
                       dt.Rows[i][7], dt.Rows[i][8].ToString(), dt.Rows[i][9].ToString(), dt.Rows[i][10].ToString(),
                       dt.Rows[i][11], dt.Rows[i][12].ToString());
                }
            }
            dataGridView1.DataSource = data;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            DataTable data = new DataTable();
            data.Columns.Add("PersonID", typeof(int));
            data.Columns.Add("NationalNo", typeof(string));
            data.Columns.Add("FirstName", typeof(string));
            data.Columns.Add("SecondName", typeof(string));
            data.Columns.Add("ThirdName", typeof(string));
            data.Columns.Add("LastName", typeof(string));
            data.Columns.Add("DateOfBirth", typeof(DateTime));
            data.Columns.Add("Gendor", typeof(int));
            data.Columns.Add("Address", typeof(string));
            data.Columns.Add("Phone", typeof(string));
            data.Columns.Add("Email", typeof(string));
            data.Columns.Add("NationalityCountryID", typeof(int));
            data.Columns.Add("ImagePath", typeof(string));
            

            switch (cmbFilter.SelectedItem)
            {
                case "None":

                    break;

                case "PersonID":
                    _FilterDataGrid(data,0);
                    break;

                case "NationalNo.":
                    _FilterDataGrid(data,1);
                    break;
                case "FirstName":
                    _FilterDataGrid(data, 2);
                    break;
                case "SecondName":
                    _FilterDataGrid(data, 3);
                    break;
                case "ThirdName":
                    _FilterDataGrid(data, 4);
                    break;
                case "LastName":
                    _FilterDataGrid(data, 5);
                    break;
                case "Gendor":
                    _FilterDataGrid(data, 7);
                    break;
                case "Phone":
                    _FilterDataGrid(data, 9);
                    break;
                case "Email":
                    _FilterDataGrid(data, 10);
                    break;
                case "Nationality":
                    _FilterDataGrid(data, 11);
                    break;
               
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonDetails frm = new FormPersonDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddEditPeople form2 = new FormAddEditPeople();
            clsPerson.Mode = clsPerson.enMode.enAddNew;
            form2.ShowDialog();
            Form1_Load(sender, e);
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddEditPeople frm = new FormAddEditPeople();
            frm.SendPersonID((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            Form1_Load(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure Do you delete PersonID {(int)dataGridView1.CurrentRow.Cells[0].Value}","Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
               if(clsPerson.DeletePerson((int)dataGridView1.CurrentRow.Cells[0].Value) != -1)
                {
                    MessageBox.Show($"Delete PersonID {(int)dataGridView1.CurrentRow.Cells[0].Value} Successfully !!");
                }
                else
                {
                    MessageBox.Show($"Failed to Delete PersonID {(int)dataGridView1.CurrentRow.Cells[0].Value} ");

                }
            }
           // Form1_Load(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
