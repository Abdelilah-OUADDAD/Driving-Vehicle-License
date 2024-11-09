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
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillComboBox()
        {
            cmbFilter.Items.Add("None");
            cmbFilter.Items.Add("DriverID");
            cmbFilter.Items.Add("PersonID");
            cmbFilter.Items.Add("NationalNo");
            cmbFilter.Items.Add("FullName");
            cmbFilter.Items.Add("Date");
            cmbFilter.Items.Add("Active License");
            cmbFilter.SelectedItem = "None";
        }
        DataTable dtFill;
        private void _FillDataGridView()
        {
            dtFill = new DataTable();
            dtFill.Columns.Add("DriverID", typeof(int));
            dtFill.Columns.Add("Person ID", typeof(int));
            dtFill.Columns.Add("NationalNo", typeof(string));
            dtFill.Columns.Add("FullName", typeof(string));
            dtFill.Columns.Add("Date", typeof(DateTime));
            dtFill.Columns.Add("Active License", typeof(int));
            dtFill = clsApplicant.GetAllDriversView();
            dataGridDriver.DataSource = dtFill;
            int Counter = dtFill.Rows.Count;
            lblRecords.Text = Counter.ToString();

        }
        DataTable dt;
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            _FillDataGridView();
            
            dt = new DataTable();
            dt.Columns.Add("DriverID", typeof(int));
            dt.Columns.Add("Person ID", typeof(int));
            dt.Columns.Add("NationalNo", typeof(string));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Active License", typeof(int));
            for (int i = 0; i < dtFill.Rows.Count ; i++)
            {
                dt.Rows.Add(dataGridDriver.Rows[i].Cells[0].Value, dataGridDriver.Rows[i].Cells[1].Value, dataGridDriver.Rows[i].Cells[2].Value,
                    dataGridDriver.Rows[i].Cells[3].Value, dataGridDriver.Rows[i].Cells[4].Value, dataGridDriver.Rows[i].Cells[5].Value);
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem != "None")
            { textBox1.Visible = true; }
            else { textBox1.Visible = false; }
        }

        private void _FilterDataGrid(DataTable data, int cells)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][cells].ToString().ToLower().StartsWith(textBox1.Text.ToString().ToLower()))
                {
                    data.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString()
                        ,(DateTime) dt.Rows[i][4], dt.Rows[i][5]);
                }
            }
            dataGridDriver.DataSource = data;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("DriverID", typeof(int));
            data.Columns.Add("Person ID", typeof(int));
            data.Columns.Add("NationalNo", typeof(string));
            data.Columns.Add("FullName", typeof(string));
            data.Columns.Add("Date", typeof(DateTime));
            data.Columns.Add("Active License", typeof(int));



            switch (cmbFilter.SelectedItem)
            {
                case "None":

                    break;

                case "DriverID":
                    _FilterDataGrid(data, 0);
                    break;

                case "PersonID":
                    _FilterDataGrid(data, 1);
                    break;
                case "NationalNo":
                    _FilterDataGrid(data, 2);
                    break;
                case "FullName":
                    _FilterDataGrid(data, 3);
                    break;
                case "Date":
                    _FilterDataGrid(data, 4);
                    break;
                case "Active License":
                    _FilterDataGrid(data, 5);
                    break;

            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonDetails frm = new FormPersonDetails((int)dataGridDriver.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dtLicenseHistory = new DataTable();
            dtLicenseHistory.Columns.Add("ApplicationID");
            foreach (DataRow row in clsApplicant.GetApplication().Rows)
            {
                if ((int)row["ApplicantPersonID"] == (int)dataGridDriver.CurrentRow.Cells[1].Value)
                {
                    dtLicenseHistory.Rows.Add(row["ApplicationID"]);
                }
            }
            int LDLAppID = -1;
            foreach (DataRow row in clsApplicant.GetLocaleDrivingLicenseApplication().Rows)
            {
                for (int i = 0; i < dtLicenseHistory.Rows.Count; i++)
                {
                    if ((int)row["ApplicationID"] == Convert.ToInt32(dtLicenseHistory.Rows[i]["ApplicationID"]))
                    {
                        LDLAppID = Convert.ToInt32(row["LocalDrivingLicenseApplicationID"]);
                        break;
                    }
                }
            }

            FormLicenseHistory frm = new FormLicenseHistory(LDLAppID);
            frm.ShowDialog();
        }

        private void issueInternationalInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }
    }
}

