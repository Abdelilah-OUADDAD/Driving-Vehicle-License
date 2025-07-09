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

namespace PDVLD.Applications.ManageApplicationTypes
{
    public partial class FormManageApplicationType: Form
    {
        public FormManageApplicationType()
        {
            InitializeComponent();
        }

        private void FormManageApplicationType_Load(object sender, EventArgs e)
        {
            DataTable dt = clsManageApplicationTypes.GetAllApplicationTypes();
            dataGridView1.DataSource = dt;
            if (dt != null)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 190;

                dataGridView1.Columns[2].HeaderText = "Fees";
                dataGridView1.Columns[2].Width = 110;

            }

            lblRecord.Text = dt.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormEditApplicationType frm = new FormEditApplicationType((int)dataGridView1.CurrentRow.Cells[0].Value, dataGridView1.CurrentRow.Cells[1].Value.ToString()
                ,float.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
            frm.ShowDialog();
            FormManageApplicationType_Load(null, null);
        }
    }
}
