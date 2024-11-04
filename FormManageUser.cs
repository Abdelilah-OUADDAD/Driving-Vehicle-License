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

        private void _Refresh()
        {
            dataGridView1.DataSource = clsUser.GetAllUser();
        }
        private void FormManageUser_Load(object sender, EventArgs e)
        {
            _Refresh();
            _FillCombo();
        }

        private void _FillCombo()
        {
            cmbFilter.Items.Add("None");
            cmbFilter.Items.Add("UserID");
            cmbFilter.Items.Add("PersonID");
            cmbFilter.Items.Add("UserName");
            cmbFilter.Items.Add("Password");
            cmbFilter.Items.Add("IsActive");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        DataTable data;
        private void _FillDataTableFromDataGrid()
        {
            
            data = clsUser.GetAllUser();
        }

        private void FilterData(int column)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("PersonID", typeof(int));
            dataTable.Columns.Add("UserName", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.Columns.Add("IsActive", typeof(string));
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][column].ToString().ToLower().StartsWith(textBox1.Text.ToLower()))
                {
                    dataTable.Rows.Add(data.Rows[i]["UserID"], data.Rows[i]["PersonID"], data.Rows[i]["UserName"], data.Rows[i]["Password"], data.Rows[i]["IsActive"]);
                }
            }
            dataGridView1.DataSource = dataTable;
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _FillDataTableFromDataGrid();

            switch (cmbFilter.Text)
            {
                case "UserID":
                    FilterData(0);
                    break;

                case "PersonID":
                    FilterData(1);
                    break;

                case "UserName":
                    FilterData(2);
                    break;
                case "Password":
                    FilterData(3);
                    break;
                case "IsActive":
                    FilterData(4);
                    break;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser();
            frm.ShowDialog();
            _Refresh();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser();
            frm.ShowDialog();
            _Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser((int)dataGridView1.CurrentRow.Cells[1].Value);
            
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
    }
}
