﻿using System;
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
    public partial class Main : Form
    {
        public static int PersonIDFromUser { get; set; }
        public static int UserID { get; set; }
        public static string UserName { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagePeople frm = new FormManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageUser frm = new FormManageUser();
            frm.ShowDialog();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowUser frm = new FormShowUser(PersonIDFromUser);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword frm = new FormChangePassword(PersonIDFromUser);
            frm.ShowDialog();
        }

        private void mangeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDriving frm = new frmNewLocalDriving();
            frm.ShowDialog();
        }

        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormL formL = new FormL();
            formL.ShowDialog();
        }

        private void rempleceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReplacementForDamageLicense frm = new FormReplacementForDamageLicense();
            frm.ShowDialog();
        }
    }
}