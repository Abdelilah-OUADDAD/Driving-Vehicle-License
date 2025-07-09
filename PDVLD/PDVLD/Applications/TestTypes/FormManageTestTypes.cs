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

namespace PDVLD.Applications.TestTypes
{
    public partial class FormManageTestTypes: Form
    {
        public FormManageTestTypes()
        {
            InitializeComponent();
        }

        private void FormManageTestTypes_Load(object sender, EventArgs e)
        {
            DataTable dt = clsTestTypes.GetAllTestTypes();

            dataGridView1.DataSource = dt;

            if(dt != null)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[0].HeaderText = "Title";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[0].HeaderText = "Description";
                dataGridView1.Columns[0].Width = 190;

                dataGridView1.Columns[0].HeaderText = "Fees";
                dataGridView1.Columns[0].Width = 90;

            }
            lblRecord.Text = dt.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormEditTestType frm = new FormEditTestType(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), dataGridView1.CurrentRow.Cells[1].Value.ToString()
                , dataGridView1.CurrentRow.Cells[2].Value.ToString(),float.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
            frm.ShowDialog();
            FormManageTestTypes_Load(null, null);
        }
    }
}
