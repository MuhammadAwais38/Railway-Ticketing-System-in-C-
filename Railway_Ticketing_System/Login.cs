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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text.Trim() == "awaisktk92@gmail.com" || txtPassword.Text.Trim() == "khan123")
            {
                AdminPanel adminPanel = new AdminPanel();
                this.Hide();
                adminPanel.Show();
            }
            else if (txtEmail.Text.Trim() == "" || txtPassword.Text.Trim() == "" )
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
                    string query = "SELECT COUNT(*) FROM dbo.Users WHERE Email =  '" + txtEmail.Text.Trim() + "' AND Password = '" +txtPassword.Text.Trim() + "';";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        string query1 = "SELECT * FROM dbo.Users WHERE Email =  '" + txtEmail.Text.Trim() + "' AND Password = '" + txtPassword.Text.Trim() + "';";
                        SqlCommand sqlCommand1 = new SqlCommand(query1, sqlConnection);
                        SqlDataAdapter adapter1 = new SqlDataAdapter(sqlCommand1);
                        DataTable dt1 = new DataTable();
                        adapter1.Fill(dt1);
                        UserPanel userPanel = new UserPanel((int)dt1.Rows[0][0]);
                        this.Hide();
                        userPanel.Show(); 
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
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

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword  =   new ForgotPassword();
            this.Hide();
            forgotPassword.Show();
        }
    }
}
