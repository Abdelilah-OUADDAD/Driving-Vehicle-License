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
            DataTable dtGrid = clsPerson.GetAllPeople();
            dt = new DataTable();
            dt.Columns.Add("Person ID", typeof(int));
            dt.Columns.Add("National No", typeof(string));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Second Name", typeof(string));
            dt.Columns.Add("Third Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("Date Of Birth", typeof(DateTime));
            dt.Columns.Add("Gendor", typeof(string));
            dt.Columns.Add("Nationality", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Email", typeof(string));

            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                dt.Rows.Add(Convert.ToInt32(dtGrid.Rows[i]["PersonID"]),Convert.ToString(dtGrid.Rows[i]["NationalNo"]), Convert.ToString(dtGrid.Rows[i]["FirstName"]),
                    Convert.ToString(dtGrid.Rows[i]["SecondName"]), Convert.ToString(dtGrid.Rows[i]["ThirdName"]), Convert.ToString(dtGrid.Rows[i]["LastName"])
                    ,Convert.ToDateTime(dtGrid.Rows[i]["DateOfBirth"]),clsPerson.GenderName(Convert.ToInt16(dtGrid.Rows[i]["Gendor"])), 
                    clsPerson.GetNameCountry(Convert.ToInt32(dtGrid.Rows[i]["NationalityCountryID"])), dtGrid.Rows[i]["Phone"].ToString()
                    , dtGrid.Rows[i]["Email"].ToString());
            }
            dataGridView1.DataSource = dt;
            lblRecord.Text = dt.Rows.Count.ToString();
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
            
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            FormAddEditPeople form2 = new FormAddEditPeople();
            clsPerson.Mode = clsPerson.enMode.enAddNew;
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
                    data.Rows.Add(Convert.ToInt32(dt.Rows[i]["Person ID"]), dt.Rows[i]["National No"].ToString(), dt.Rows[i]["First Name"].ToString(),
                    dt.Rows[i]["Second Name"].ToString(), dt.Rows[i]["Third Name"].ToString(), dt.Rows[i]["Last Name"].ToString(),
                     Convert.ToDateTime(dt.Rows[i]["Date Of Birth"]), dt.Rows[i]["Gendor"].ToString(),
                    dt.Rows[i]["Nationality"], dt.Rows[i]["Phone"].ToString()
                    , dt.Rows[i]["Email"].ToString()); 
                }
            }
            dataGridView1.DataSource = data;
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
           DataTable data = new DataTable();
           data.Columns.Add("Person ID", typeof(int));
           data.Columns.Add("National No", typeof(string));
           data.Columns.Add("First Name", typeof(string));
           data.Columns.Add("Second Name", typeof(string));
           data.Columns.Add("Third Name", typeof(string));
           data.Columns.Add("Last Name", typeof(string));
           data.Columns.Add("Date Of Birth", typeof(DateTime));
           data.Columns.Add("Gendor", typeof(string));
           data.Columns.Add("Nationality", typeof(string));
           data.Columns.Add("Phone", typeof(string));
           data.Columns.Add("Email", typeof(string));

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
                    MessageBox.Show($"PersonID {(int)dataGridView1.CurrentRow.Cells[0].Value} was not deleted because it has linked to it "
                        ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem == "PersonID" || cmbFilter.SelectedItem == "Phone") {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
