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
    public partial class BookATicket : Form
    {
        public int userId;
        public BookATicket(int userId)
        {
            this.userId = userId;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BookATicket_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'railwaySystemDataSet2.Trains' table. You can move, or remove it, as needed.
            this.trainsTableAdapter.Fill(this.railwaySystemDataSet2.Trains);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel(userId);
            this.Hide();
            userPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtAddress.Text.Trim() == "" || (cbMale.Checked || cbFemale.Checked) == false || txtNationality.Text.Trim() == "" || cbSelectTrain.SelectedItem == null)
            {
                MessageBox.Show("Please fill all the fields");
            }
            else if (cbMale.Checked && cbFemale.Checked) {
                MessageBox.Show("Please Select One Option");
            }
            else
            {
                string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=RailwaySystem;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                try
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO dbo.Tickets (Name, Address, PhoneNo, Gender, Nationality, SelectTrain,userId) VALUES ('" + txtName.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPhoneNo.Text.Trim() + "','" + (cbMale.Checked ? ("Male") : (cbFemale.Checked ? ("Female") : ("Male")) )+ "','" + txtNationality.Text.Trim() + "','" + cbSelectTrain.SelectedValue + "',"+userId+")";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    int infectedRows = sqlCommand.ExecuteNonQuery();
                    if (infectedRows > 0)
                    {
                        MessageBox.Show("Your Ticket is Booked Successfully, Please wait for Ticket Master Response");
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

        private void cbMale_CheckedChanged(object sender, EventArgs e)
        {   
            if (cbFemale.Checked)
            {
                cbFemale.Checked = false;
            }
            
        }

        private void cbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMale.Checked)
            {
                cbMale.Checked = false;
            }
            
        }
    }
}
