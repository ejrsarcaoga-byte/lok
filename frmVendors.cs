using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yuasdw
{
    public partial class frmVendors : Form
    {
        public frmVendors()
        {
            InitializeComponent();
            this.FormClosing += frmVendors_FormClosing;
        }
        private void frmVendors_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }


        private void frmVendors_Load(object sender, EventArgs e)
        {

        }
    }
}
