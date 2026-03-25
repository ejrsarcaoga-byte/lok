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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister();
            this.Hide();
            frm.Show();
        }

        private void btnStoreStatus_Click(object sender, EventArgs e)
        {
            frmStoreStatus frm = new frmStoreStatus();
            this.Hide();
            frm.Show();
        }

        private void btnVendors_Click(object sender, EventArgs e)
        {
            frmVendors frm = new frmVendors();
            this.Hide();
            frm.Show();
        }

        private void btnPriceBook_Click(object sender, EventArgs e)
        {
            frmPricebook frm = new frmPricebook();
            this.Hide();
            frm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            this.Hide();
            frm.Show();
        }

        private void btnTimeClock_Click(object sender, EventArgs e)
        {
            frmTimeClock frm = new frmTimeClock();
            this.Hide();
            frm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.Show();
        }
    }
}
