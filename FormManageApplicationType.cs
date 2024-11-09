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
    public partial class FormManageApplicationType : Form
    {
        public FormManageApplicationType()
        {
            InitializeComponent();
        }
        private void _Refresh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Fees", typeof(double));
            foreach (DataRow row in clsApplicant.GetApplicationTypes().Rows)
            {
                dt.Rows.Add(row["ApplicationTypeID"], row["ApplicationTypeTitle"], row["ApplicationFees"]);
            }
           
            dataGridView1.DataSource = dt;
            int Counter = dt.Rows.Count;
            lblRecord.Text = Counter.ToString();
        }
        private void FormManageApplicationType_Load(object sender, EventArgs e)
        {
            _Refresh();
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes frm = new frmUpdateApplicationTypes((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
