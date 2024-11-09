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
    public partial class FormManageTestTypes : Form
    {
        public FormManageTestTypes()
        {
            InitializeComponent();
        }

        private void _Refresh()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Fees", typeof(double));
            foreach (DataRow row in clsApplicant.GetTestTypes().Rows)
            {
                dt.Rows.Add(row["TestTypeID"], row["TestTypeTitle"], row["TestTypeDescription"], row["TestTypeFees"]);
            }

            dataGridView1.DataSource = dt;
            int Counter = dt.Rows.Count;
            lblRecord.Text = Counter.ToString();
        }

        private void FormManageTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Refresh();
        }
    }
}
