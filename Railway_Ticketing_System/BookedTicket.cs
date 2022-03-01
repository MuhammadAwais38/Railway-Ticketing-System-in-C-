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
    public partial class BookedTicket : Form
    {
        public int userId;
        public BookedTicket(int userId)
        {
            InitializeComponent();
            this.userId = userId;  
        }
        void loadForm()
        {
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=RailwaySystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                string query = "SELECT * FROM dbo.Tickets where userId =  " + userId + " ";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
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
        private void BookedTicket_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'railwaySystemDataSet3.Tickets' table. You can move, or remove it, as needed.

            loadForm();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel(userId);
            this.Hide();
            userPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm();
        }
    }
}
