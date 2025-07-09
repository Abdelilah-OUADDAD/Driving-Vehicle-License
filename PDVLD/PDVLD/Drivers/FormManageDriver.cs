using DriverLayoutControll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Drivers
{
    public partial class FormManageDriver: Form
    {
        public FormManageDriver()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void FormManageDriver_Load(object sender, EventArgs e)
        {
            dt = clsDrivers.GetAllDriversView();
            dataGridView1.DataSource = dt;

            if(dt.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Driver ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 90;

                dataGridView1.Columns[2].HeaderText = "National No.";
                dataGridView1.Columns[2].Width = 90;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 190;

                dataGridView1.Columns[4].HeaderText = "Date";
                dataGridView1.Columns[4].Width = 110;

                dataGridView1.Columns[5].HeaderText = "Active License";
                dataGridView1.Columns[5].Width = 100;
            }

            lblRecords.Text = dt.Rows.Count.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterString = "";

            switch (comboBox1.SelectedItem)
            {
                case "Driver ID":
                    FilterString = "DriverID";
                    break;

                case "Person ID":
                    FilterString = "PersonID";
                    break;

                case "National No.":
                    FilterString = "NationalNo";
                    break;

                case "Full Name":
                    FilterString = "FullName";
                    break;

                default:
                    FilterString = "None";
                    break;
            }

            if(FilterString == "None" || textBox1.Text.Trim() == "")
            {
                FormManageDriver_Load(null, null);
                return;
            }

            if(FilterString == "DriverID" || FilterString == "PersonID")
            {
                dt.DefaultView.RowFilter = string.Format("{0} = {1}", FilterString, textBox1.Text);
            }
            else
                dt.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterString, textBox1.Text);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "None")
                textBox1.Visible = false;
            else
                textBox1.Visible = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Driver ID" || comboBox1.SelectedItem.ToString() == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
