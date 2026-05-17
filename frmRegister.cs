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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            this.FormClosing += frmRegister_FormClosing;
        }
        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
