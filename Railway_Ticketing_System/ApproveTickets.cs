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
    public partial class ApproveTickets : Form
    {
        public ApproveTickets()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void formLoad()
        {
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=RailwaySystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT Id, Name, Address,PhoneNo,Gender, Nationality, SelectTrain, Status FROM dbo.Tickets where Status =  'pending' ;";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }
        private void ApproveTickets_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Hide();
            adminPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhoneNo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtGender.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNationality.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSelectTrain.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTicketId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            pnlApproveTickets.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlApproveTickets.Visible = false;
        }

       private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=RailwaySystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "Update dbo.Tickets set  Status = 'rejected' where Id =  "+Convert.ToInt32(txtTicketId.Text)+" ;";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    pnlApproveTickets.Visible=false;
                    formLoad();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

       private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=RailwaySystem;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "Update dbo.Tickets set  Status = 'approved' where Id =  " + Convert.ToInt32(txtTicketId.Text) + " ;";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    pnlApproveTickets.Visible = false;
                    formLoad();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
