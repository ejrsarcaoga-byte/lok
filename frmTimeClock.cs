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
    public partial class frmTimeClock : Form
    {
        public frmTimeClock()
        {
            InitializeComponent();
            this.FormClosing += frmTimeClock_FormClosing;
        }
        private void frmTimeClock_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }


        private void frmTimeClock_Load(object sender, EventArgs e)
        {

        }
    }
}
