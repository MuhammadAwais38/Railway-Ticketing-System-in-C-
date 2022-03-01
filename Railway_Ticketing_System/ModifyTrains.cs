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
    public partial class ModifyTrains : Form
    {
        public bool update = false;
        int id;
        public ModifyTrains()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtTrainName.Text.Trim() == "" || txtSource.Text.Trim() == "" || txtDestination.Text.Trim() == "" || txtArrivalTime.Text.Trim() == "" || txtDepartureTime.Text.Trim() == "" || txtDate.Text.Trim() == "")
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
                    string query = "INSERT INTO dbo.Trains (TrainName, Source, Destination, ArrivalTime, DepartureTime, Date) VALUES ('" + txtTrainName.Text.Trim() + "','" + txtSource.Text.Trim() + "','" + txtDestination.Text.Trim() + "','" + txtArrivalTime.Text.Trim() + "','" + txtDepartureTime.Text.Trim() + "','" + txtDate.Text.Trim() + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    int infectedRows = sqlCommand.ExecuteNonQuery();
                    if (infectedRows > 0)
                    {
                        MessageBox.Show("Train Added Successfully");
                        this.trainsTableAdapter.Fill(this.railwaySystemDataSet.Trains);
                        id = 0;
                        txtTrainName.Text = "";
                        txtSource.Text = "";
                        txtDestination.Text = "";
                        txtArrivalTime.Text = "";
                        txtDepartureTime.Text = "";
                        txtDate.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Hide();
            adminPanel.Show();
        }

        private void ModifyTrains_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'railwaySystemDataSet.Trains' table. You can move, or remove it, as needed.
            this.trainsTableAdapter.Fill(this.railwaySystemDataSet.Trains);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Row No:" + e.RowIndex
                +"\nId:"+dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()
                + "\nTrain Name:" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()
                + "\nSource:" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()
                + "\nDestination:" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()
                + "\nArivial Time:" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()
                + "\nDeparture Time:" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()
                + "\nDate:" + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()

                ) ;
            update = true;
            id =(int) dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            txtTrainName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSource.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDestination.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtArrivalTime.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDepartureTime.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


        }

        private void btnUpdateTrain_Click(object sender, EventArgs e)
        {
            if (update)
            {
                if (txtTrainName.Text.Trim() == "" || txtSource.Text.Trim() == "" || txtDestination.Text.Trim() == "" || txtArrivalTime.Text.Trim() == "" || txtDepartureTime.Text.Trim() == "" || txtDate.Text.Trim() == "")
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
                        string query = "UPDATE dbo.Trains set TrainName = '" + txtTrainName.Text.Trim() + "', Source = '" + txtSource.Text.Trim() + "', Destination= '" + txtDestination.Text.Trim() + "', ArrivalTime='" + txtArrivalTime.Text.Trim() + "', DepartureTime='" + txtDepartureTime.Text.Trim() + "', Date='" + txtDate.Text.Trim() + "' WHERE Id = " + id + "";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        int infectedRows = sqlCommand.ExecuteNonQuery();
                        if (infectedRows > 0)
                        {
                            MessageBox.Show("Train Record Updated Successfully");
                            update = false;
                            this.trainsTableAdapter.Fill(this.railwaySystemDataSet.Trains);
                            id =0;
                            txtTrainName.Text = "";
                            txtSource.Text = "";
                            txtDestination.Text = "";
                            txtArrivalTime.Text = "";
                            txtDepartureTime.Text = "";
                            txtDate.Text = "";

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
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        private void btnDeleteTrain_Click(object sender, EventArgs e)
        {
            if (update)
            {
                if (txtTrainName.Text.Trim() == "" || txtSource.Text.Trim() == "" || txtDestination.Text.Trim() == "" || txtArrivalTime.Text.Trim() == "" || txtDepartureTime.Text.Trim() == "" || txtDate.Text.Trim() == "")
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
                        string query = "DELETE FROM dbo.Trains  WHERE Id = " + id + "";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        int infectedRows = sqlCommand.ExecuteNonQuery();
                        if (infectedRows > 0)
                        {
                            MessageBox.Show("Train Record Deleted Successfully");
                            update = false;
                            this.trainsTableAdapter.Fill(this.railwaySystemDataSet.Trains);
                            id = 0;
                            txtTrainName.Text = "";
                            txtSource.Text = "";
                            txtDestination.Text = "";
                            txtArrivalTime.Text = "";
                            txtDepartureTime.Text = "";
                            txtDate.Text = "";

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
            else
            {
                MessageBox.Show("Please select a row");
            }
        }
    }
}
