using DVLDControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDProject
{
    public partial class FormManageUser : Form
    {
        public FormManageUser()
        {
            InitializeComponent();
        }
        DataTable data;
        DataTable dtUser;
        private void _Refresh()
        {
            dtUser = new DataTable();
            dtUser.Columns.Add("User ID", typeof(int));
            dtUser.Columns.Add("Person ID", typeof(int));
            dtUser.Columns.Add("Full Name", typeof(string));
            dtUser.Columns.Add("User Name", typeof(string));
            dtUser.Columns.Add("Is Active", typeof(bool));
            foreach (DataRow row in clsUser.GetAllUser().Rows)
            {
                //-- Fill FullName
                DataTable dtPer = clsPerson.GetPerson(Convert.ToInt32(row["PersonID"]));
                string FullName = clsPerson.FullName(dtPer.Rows[0]["FirstName"].ToString(), dtPer.Rows[0]["SecondName"].ToString(),
                    dtPer.Rows[0]["ThirdName"].ToString(), dtPer.Rows[0]["LastName"].ToString() );
                //- Fille Datatable
                dtUser.Rows.Add(row["UserID"],  row["PersonID"], FullName
                    , row["UserName"], row["IsActive"]);

            }
            dataGridView1.DataSource = dtUser;
            lblRecord.Text = dtUser.Rows.Count.ToString();
        }
        private void FormManageUser_Load(object sender, EventArgs e)
        {
            _Refresh();
            _FillCombo();
            _FillComboIsActive();
        }

        private void _FillCombo()
        {
            cmbFilter.Items.Add("None");
            cmbFilter.Items.Add("User ID");
            cmbFilter.Items.Add("Person ID");
            cmbFilter.Items.Add("Full Name");
            cmbFilter.Items.Add("User Name");
            cmbFilter.Items.Add("Is Active");

            cmbFilter.SelectedItem = "None";
        }

        private void _FillComboIsActive()
        {
            cmbIsActive.Items.Add("All");

            cmbIsActive.Items.Add("Yes");
            cmbIsActive.Items.Add("No");

            cmbIsActive.SelectedItem = "All";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem != "None" && cmbFilter.SelectedItem != "Is Active")
            {
                textBox1.Visible = true;
                cmbIsActive.Visible = false;
            } 
            else if (cmbFilter.SelectedItem == "Is Active")
            {
                textBox1.Visible = false;
                cmbIsActive.Visible = true;
            }
            else 
            {
                textBox1.Visible = false;
                cmbIsActive.Visible = false;
            }
        }
       
       
        private void FilterData(int column)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("User ID", typeof(int));
            dataTable.Columns.Add("Person ID", typeof(int));
            dataTable.Columns.Add("Full Name", typeof(string));
            dataTable.Columns.Add("User Name", typeof(string));
            dataTable.Columns.Add("Is Active", typeof(bool));
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][column].ToString().ToLower().StartsWith(textBox1.Text.ToLower()))
                {
                    DataTable dtPer = clsPerson.GetPerson(Convert.ToInt32(data.Rows[i]["Person ID"]));
                    string FullName = clsPerson.FullName(dtPer.Rows[0]["FirstName"].ToString(), dtPer.Rows[0]["SecondName"].ToString(),
                        dtPer.Rows[0]["ThirdName"].ToString(), dtPer.Rows[0]["LastName"].ToString());

                    dataTable.Rows.Add(data.Rows[i]["User ID"], data.Rows[i]["Person ID"], FullName ,data.Rows[i]["User Name"],
                         data.Rows[i]["Is Active"]);
                }
            }
            dataGridView1.DataSource = dataTable;
            
        }
        private void FilterDataIsActive(int column)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("User ID", typeof(int));
            dataTable.Columns.Add("Person ID", typeof(int));
            dataTable.Columns.Add("Full Name", typeof(string));
            dataTable.Columns.Add("User Name", typeof(string));
            dataTable.Columns.Add("Is Active", typeof(bool));

            for (int i = 0; i < data.Rows.Count; i++)
            {
                //bool IsActive = (bool)cmbIsActive.Tag;
                if (data.Rows[i][column].ToString().ToLower().StartsWith(cmbIsActive.Tag.ToString().ToLower()))
                {
                    DataTable dtPer = clsPerson.GetPerson(Convert.ToInt32(data.Rows[i]["Person ID"]));
                    string FullName = clsPerson.FullName(dtPer.Rows[0]["FirstName"].ToString(), dtPer.Rows[0]["SecondName"].ToString(),
                        dtPer.Rows[0]["ThirdName"].ToString(), dtPer.Rows[0]["LastName"].ToString());

                    dataTable.Rows.Add(data.Rows[i]["User ID"], data.Rows[i]["Person ID"], FullName, data.Rows[i]["User Name"],
                         data.Rows[i]["Is Active"]);
                }
            }
            dataGridView1.DataSource = dataTable;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            data = dtUser;

            switch (cmbFilter.Text)
            {
                case "User ID":
                    FilterData(0);
                    break;

                case "Person ID":
                    FilterData(1);
                    break;

                case "Full Name":
                    FilterData(2);
                    break;
                
                case "User Name":
                    FilterData(3);
                    break;
                
                case "IsActive":
                    FilterData(4);
                    break;
            }
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            data = dtUser;

            switch (cmbIsActive.Text)
            {
                case "Yes":
                    cmbIsActive.Tag = true;
                    FilterDataIsActive(4);
                    break;

                case "No":
                    cmbIsActive.Tag = false;
                    FilterDataIsActive(4);
                    break;
                case "All":
                    cmbIsActive.Tag = "";
                    FilterDataIsActive(4);
                    break;


            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser();
            clsUser.Mode = clsUser.enMode.enAddNew;
            frm.ShowDialog();
            _Refresh();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser();
            clsUser.Mode = clsUser.enMode.enAddNew;
            frm.ShowDialog();
            _Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser((int)dataGridView1.CurrentRow.Cells[1].Value);
            clsUser.Mode = clsUser.enMode.enUpdate;
            frm.ShowDialog();
            _Refresh();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowUser frm = new FormShowUser((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void chengePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword frm = new FormChangePassword((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            _Refresh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Do you want To Delete UserID {(int)dataGridView1.CurrentRow.Cells[0].Value}",
                "Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dataGridView1.CurrentRow.Cells[1].Value))
                {
                    MessageBox.Show($"UserID {(int)dataGridView1.CurrentRow.Cells[0].Value} Deleted Successfully !","Delete User");
                }
                else
                {
                    MessageBox.Show($"UserID {(int)dataGridView1.CurrentRow.Cells[0].Value} Deleted Failed !","Delete User");
                }
                _Refresh();
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem == "User ID" || cmbFilter.SelectedItem == "Person ID")
            {
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

        
    }
}
