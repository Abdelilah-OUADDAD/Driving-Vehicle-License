using DriverLayoutControll;
using PDVLD.Applications.DrivingLicensesServices.International_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDVLD.Applications.DrivingLicensesServices
{
    public partial class FormLicenseHistory: Form
    {
        public FormLicenseHistory()
        {
            InitializeComponent();
        }
        int DriverID { get; set; }
        public FormLicenseHistory(int personID,int driverID)
        {
            InitializeComponent();
            ctrlShowCardWithFilter1.SendDataShowCard(personID);
            DriverID = driverID;
        }

        void FillDataLicenseLocal()
        {
            DataTable dt = clsLicenses.GetLicenseLocal(DriverID);

            if (dt.Rows.Count > 0)
            {
                dataGridViewLocal.DataSource = dt;

                dataGridViewLocal.Columns[0].HeaderText = "Lic.ID";
                dataGridViewLocal.Columns[0].Width = 90;

                dataGridViewLocal.Columns[1].HeaderText = "App.ID";
                dataGridViewLocal.Columns[1].Width = 90;

                dataGridViewLocal.Columns[2].HeaderText = "Class Name";
                dataGridViewLocal.Columns[2].Width = 190;

                dataGridViewLocal.Columns[3].HeaderText = "Issue Date";
                dataGridViewLocal.Columns[3].Width = 110;

                dataGridViewLocal.Columns[4].HeaderText = "Expiration Date";
                dataGridViewLocal.Columns[4].Width = 110;

                dataGridViewLocal.Columns[5].HeaderText = "Is Active";
                dataGridViewLocal.Columns[5].Width = 90;
            }

            lblRecordsLocal.Text = dt.Rows.Count.ToString();
        }

        void FillDataLicenseInternational()
        {
            DataTable dt = clsInternationalLicenses.GetLicenseInter(DriverID);

            if (dt.Rows.Count > 0)
            {
                dataGridViewInter.DataSource = dt;

                dataGridViewInter.Columns[0].HeaderText = "Int.License ID";
                dataGridViewInter.Columns[0].Width = 90;

                dataGridViewInter.Columns[1].HeaderText = "Application.ID";
                dataGridViewInter.Columns[1].Width = 90;

                dataGridViewInter.Columns[2].HeaderText = "L.License ID";
                dataGridViewInter.Columns[2].Width = 190;

                dataGridViewInter.Columns[3].HeaderText = "Issue Date";
                dataGridViewInter.Columns[3].Width = 110;

                dataGridViewInter.Columns[4].HeaderText = "Expiration Date";
                dataGridViewInter.Columns[4].Width = 110;

                dataGridViewInter.Columns[5].HeaderText = "Is Active";
                dataGridViewInter.Columns[5].Width = 90;
            }

            lblRecordsInter.Text = dt.Rows.Count.ToString();
        }

        private void FormLicenseHistory_Load(object sender, EventArgs e)
        {
            FillDataLicenseLocal();
            FillDataLicenseInternational();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLocalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowLicenseInfo frm = new FormShowLicenseInfo((int)dataGridViewLocal.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showInternationalLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowInternationalLicenseInfo frm = new FormShowInternationalLicenseInfo((int)dataGridViewInter.CurrentRow.Cells[2].Value);
            frm.ShowDialog();
        }
    }
}
