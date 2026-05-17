using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace yuasdw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyDatabase db = new MyDatabase();

        string[,] userCredentials =
        {
            {"admin", "cashier", "Admin User" },
            {"admin", "password", "Admin User" },
            {"Ellaine Sarcaoga", "Xian Nicole", "Yanyan Ramil" },
            {"Admin Department", "Staff Department", "Admin Staff" }
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            if (db.TestConnection() == true)
            {
                MessageBox.Show("Connected to DataBase");
            }
            else
            {
                MessageBox.Show("Database Connection Failed");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Please enter username.", "Validation");
                tbUsername.Focus();
            }
            else if (tbPassword.Text == "")
            {
                MessageBox.Show("Please enter password.", "Validation");
                tbPassword.Focus();
            }
            else
            {
                string query = @"
                SELECT *
                FROM tbllogincredentials 
                WHERE user_username = @username 
                AND user_password = @password 
                AND is_active = 1";
                DataTable dt = db.ExecuteReturnQuery(query,
                    new MySqlParameter("@username", tbUsername.Text),
                    new MySqlParameter("@password", tbPassword.Text));

                if(dt.Rows.Count == 1)
                {
                    frmHome frm = new frmHome();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username / Password!");
                }    
            }
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}