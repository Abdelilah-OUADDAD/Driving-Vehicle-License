using DriverLayoutControl;
using PDVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Users
{
    public partial class FormManageUsers: Form
    {
        public FormManageUsers()
        {
            InitializeComponent();
        }

        DataTable dt;
        private void FormManageUsers_Load(object sender, EventArgs e)
        {
            dt = clsUsers.GetAllUsers();
            dataGridView1.DataSource = dt;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 90;

                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 200;

                dataGridView1.Columns[3].HeaderText = "User Name";
                dataGridView1.Columns[3].Width = 150;

                dataGridView1.Columns[4].HeaderText = "Is Active";
                dataGridView1.Columns[4].Width = 90;
            }

            lblRecord.Text = dataGridView1.Rows.Count.ToString();
            cmbFilter.SelectedItem = "None";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterName = "";

            switch (cmbFilter.SelectedItem)
            {
                case "User ID":
                    FilterName = "UserID";
                    break;

                case "Person ID":
                    FilterName = "PersonID";
                    break;

                case "Full Name":
                    FilterName = "FullName";
                    break;

                case "User Name":
                    FilterName = "UserName";
                    break;

                case "Is Active":

                    return;


                default:
                    FilterName = "None";

                    break;
            }
            if (FilterName == "None" || textBox1.Text.Trim() == "")
            {
                dataGridView1.DataSource = clsUsers.GetAllUsers();
                return;
            }

            if (FilterName == "UserID" || FilterName == "PersonID")
            {
                dt.DefaultView.RowFilter = string.Format("{0} = {1}", FilterName, textBox1.Text);
            }
            else
            {
                dt.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterName, textBox1.Text);
            }
            dataGridView1.DataSource = dt;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() != "None" && cmbFilter.SelectedItem.ToString() != "Is Active")
            {
                textBox1.Visible = true;
                cmbActive.Visible = false;
                return;
            }
            if (cmbFilter.SelectedItem.ToString() == "Is Active")
            {
                cmbActive.Visible = true;
                textBox1.Visible = false;
                cmbActive.SelectedItem = "All";
                return;
            }
            if (cmbFilter.SelectedItem.ToString() == "None")
            {
                textBox1.Visible = false;
                cmbActive.Visible = false;
                dt = clsUsers.GetAllUsers();
                dataGridView1.DataSource = dt;
                return;
            }
        }

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActive.SelectedItem.ToString() == "Yes")
                dt.DefaultView.RowFilter = string.Format("{0} = true", "IsActive");
            else if(cmbActive.SelectedItem.ToString() == "No")
                dt.DefaultView.RowFilter = string.Format("{0} = false", "IsActive");
            else
            {
                dt = clsUsers.GetAllUsers();
                dataGridView1.DataSource = dt;
                return;
            }
               

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedItem.ToString() == "User ID" || cmbFilter.SelectedItem.ToString() == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser();
            frm.ShowDialog();
            FormManageUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
            FormManageUsers_Load(null, null);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser frm = new FormAddNewUser();
            frm.ShowDialog();
            FormManageUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure to delete PersonID {(int)dataGridView1.CurrentRow.Cells[0].Value}", "Allowed",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes &&
                clsUsers.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
                MessageBox.Show("User Deleted Successfully !!", "Deleted");
            else
                MessageBox.Show("User Deleted Failed !!", "Deleted");

            FormManageUsers_Load(null, null);

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword frm = new FormChangePassword((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInfo frm = new FormUserInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
