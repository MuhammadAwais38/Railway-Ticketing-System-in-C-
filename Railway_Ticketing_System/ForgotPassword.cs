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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             if (txtEmail.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtConPassword.Text.Trim() == "" || txtPassword.Text.Trim() != txtConPassword.Text.Trim())
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
                    string query = "UPDATE dbo.Users SET  Password = '" + txtPassword.Text.Trim() + "' WHERE Email =  '" + txtEmail.Text.Trim() + "';";
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
    }
}
