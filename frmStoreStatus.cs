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
    public partial class frmStoreStatus : Form
    {
        public frmStoreStatus()
        {
            InitializeComponent();
            this.FormClosing += FrmStoreStatus_FormClosing;
        }

        private void FrmStoreStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }



        private void frmStoreStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
