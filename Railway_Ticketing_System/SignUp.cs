using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_Ticketing_System
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || textEmail.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtConPassword.Text.Trim() == "" || txtPassword.Text.Trim() != txtConPassword.Text.Trim())
            {
                MessageBox.Show("Please fill all the fields.");
            }
            else
            {
                string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=RailwaySystem;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                try
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO dbo.Users (Name, Email, Password) VALUES ('" + txtName.Text.Trim() + "','" + textEmail.Text.Trim() + "','" + txtPassword.Text.Trim() + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    int infectedRows = sqlCommand.ExecuteNonQuery();
                    if (infectedRows > 0)
                    {
                        login login = new login();
                        this.Hide();
                        login.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
