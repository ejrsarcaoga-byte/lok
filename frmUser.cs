using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
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
    public partial class frmUser : Form
    {
        MyDatabase db = new MyDatabase();

        bool isUpdate = false;
        int selectedUserID = -1;
        int selectedLoginID = -1;

        private static bool isSaving = false;

        string originalFirstName, originalMiddleName, originalLastName;
        string originalEmail, originalAddress, originalUsername, originalPassword;
        DateTime originalBirthDate;

        public frmUser()
        {
            InitializeComponent();
            this.FormClosing += frmUser_FormClosing;
        }

        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHome home = new frmHome();
            home.Show();
        }


        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadUsers();
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LoadUsers()
        {
            string query = @"
                SELECT 
                    tbluserinformation.userID,
                    tbllogincredentials.LoginID,
                    tbluserinformation.firstname,
                    tbluserinformation.middlename,
                    tbluserinformation.lastname,
                    tbluserinformation.emailAddress,
                    tbluserinformation.homeAddress,
                    tbluserinformation.birthDate,
                    tbllogincredentials.user_username,
                    tbllogincredentials.user_password
                FROM tbllogincredentials
                INNER JOIN tbluserinformation
                ON tbllogincredentials.userID = tbluserinformation.userID";

            DataTable dt = db.ExecuteReturnQuery(query);
            dgvUsers.DataSource = dt;

            if (dgvUsers.Columns.Contains("userID"))
                dgvUsers.Columns["userID"].Visible = false;

            if (dgvUsers.Columns.Contains("LoginID"))
                dgvUsers.Columns["LoginID"].Visible = false;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

            selectedUserID = Convert.ToInt32(row.Cells["userID"].Value);
            selectedLoginID = Convert.ToInt32(row.Cells["LoginID"].Value);

            txtFirstName.Text = row.Cells["firstname"].Value.ToString();
            txtMiddleName.Text = row.Cells["middlename"].Value.ToString();
            txtLastName.Text = row.Cells["lastname"].Value.ToString();
            txtEmail.Text = row.Cells["emailAddress"].Value.ToString();
            txtAddress.Text = row.Cells["homeAddress"].Value.ToString();
            dtBirthDate.Value = Convert.ToDateTime(row.Cells["birthDate"].Value);
            txtUsername.Text = row.Cells["user_username"].Value.ToString();
            txtPassword.Text = row.Cells["user_password"].Value.ToString();

            originalFirstName = txtFirstName.Text;
            originalMiddleName = txtMiddleName.Text;
            originalLastName = txtLastName.Text;
            originalEmail = txtEmail.Text;
            originalAddress = txtAddress.Text;
            originalBirthDate = dtBirthDate.Value;
            originalUsername = txtUsername.Text;
            originalPassword = txtPassword.Text;

            isUpdate = true;
        }


        private void ClearFields()
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

            selectedUserID = -1;
            selectedLoginID = -1;

            isUpdate = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isUpdate || selectedUserID == -1 || selectedLoginID == -1)
            {
                MessageBox.Show("Please select a user first!");
                return;
            }

            if (
                txtFirstName.Text == originalFirstName &&
                txtMiddleName.Text == originalMiddleName &&
                txtLastName.Text == originalLastName &&
                txtEmail.Text == originalEmail &&
                txtAddress.Text == originalAddress &&
                txtUsername.Text == originalUsername &&
                txtPassword.Text == originalPassword &&
                dtBirthDate.Value == originalBirthDate
            )
            {
                MessageBox.Show("No changes detected.");
                return;
            }

            string query1 = @"
                UPDATE tbluserinformation
                SET firstname=@fname,
                    middlename=@mname,
                    lastname=@lname,
                    emailAddress=@email,
                    homeAddress=@hadd,
                    birthDate=@bDate
                WHERE userID=@uid";

            string query2 = @"
                UPDATE tbllogincredentials
                SET user_username=@username,
                    user_password=@password
                WHERE LoginID=@lid";

            db.ExecuteNoReturnQuery(query1,
                new MySqlParameter("@fname", txtFirstName.Text),
                new MySqlParameter("@mname", txtMiddleName.Text),
                new MySqlParameter("@lname", txtLastName.Text),
                new MySqlParameter("@email", txtEmail.Text),
                new MySqlParameter("@hadd", txtAddress.Text),
                new MySqlParameter("@bDate", dtBirthDate.Value),
                new MySqlParameter("@uid", selectedUserID)
            );

            db.ExecuteNoReturnQuery(query2,
                new MySqlParameter("@username", txtUsername.Text),
                new MySqlParameter("@password", txtPassword.Text),
                new MySqlParameter("@lid", selectedLoginID)
            );

            MessageBox.Show("Updated Successfully!");

            LoadUsers();
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isSaving) return;

            isSaving = true;
            btnSave.Enabled = false;

            try
            {
                using (MySqlConnection con = new MySqlConnection(
                    "Server=localhost;Port=3306;Database=sarcaoga_db;Uid=root;Pwd=;"))
                {
                    con.Open();

                    if (isUpdate && selectedUserID > 0 && selectedLoginID > 0)
                    {

                        string query1 = @"
                    UPDATE tbluserinformation
                    SET firstname=@fname,
                        middlename=@mname,
                        lastname=@lname,
                        emailAddress=@email,
                        homeAddress=@hadd,
                        birthDate=@bDate
                    WHERE userID=@uid";

                        MySqlCommand cmd1 = new MySqlCommand(query1, con);
                        cmd1.Parameters.AddWithValue("@fname", txtFirstName.Text);
                        cmd1.Parameters.AddWithValue("@mname", txtMiddleName.Text);
                        cmd1.Parameters.AddWithValue("@lname", txtLastName.Text);
                        cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd1.Parameters.AddWithValue("@hadd", txtAddress.Text);
                        cmd1.Parameters.AddWithValue("@bDate", dtBirthDate.Value);
                        cmd1.Parameters.AddWithValue("@uid", selectedUserID);
                        cmd1.ExecuteNonQuery();

                        string query2 = @"
                    UPDATE tbllogincredentials
                    SET user_username=@username,
                        user_password=@password
                    WHERE LoginID=@lid";

                        MySqlCommand cmd2 = new MySqlCommand(query2, con);
                        cmd2.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd2.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd2.Parameters.AddWithValue("@lid", selectedLoginID);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("User Updated Successfully!");
                    }
                    else
                    {
                        string query1 = @"
                    INSERT INTO tbluserinformation
                    (firstname, middlename, lastname, emailAddress, homeAddress, birthDate)
                    VALUES
                    (@fname, @mname, @lname, @email, @hadd, @bDate)";

                        MySqlCommand cmd1 = new MySqlCommand(query1, con);

                        cmd1.Parameters.AddWithValue("@fname", txtFirstName.Text);
                        cmd1.Parameters.AddWithValue("@mname", txtMiddleName.Text);
                        cmd1.Parameters.AddWithValue("@lname", txtLastName.Text);
                        cmd1.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd1.Parameters.AddWithValue("@hadd", txtAddress.Text);
                        cmd1.Parameters.AddWithValue("@bDate", dtBirthDate.Value);

                        cmd1.ExecuteNonQuery();

                        int newUserID = Convert.ToInt32(cmd1.LastInsertedId);

                        string query2 = @"
                    INSERT INTO tbllogincredentials
                    (userID, user_username, user_password, is_active)
                    VALUES
                    (@uid, @username, @password, 1)";

                        MySqlCommand cmd2 = new MySqlCommand(query2, con);

                        cmd2.Parameters.AddWithValue("@uid", newUserID);
                        cmd2.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd2.Parameters.AddWithValue("@password", txtPassword.Text);

                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("User Added Successfully!");
                    }

                    LoadUsers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                isSaving = false;
                btnSave.Enabled = true;
            }
        }

        private void btnDeactivate_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to deactivate this account?", "Account Deactivation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[1].Value);
                    string query = "UPDATE tbllogincredentials SET is_active = 0 where LoginID = @id";

                    int affectedRows = db.ExecuteNoReturnQuery(query,
                        new MySqlParameter("@id", id));
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Account is deactivated!");
                    }
                }
            }
        }
    }
}