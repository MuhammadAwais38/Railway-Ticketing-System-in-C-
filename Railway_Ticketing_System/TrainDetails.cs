using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_Ticketing_System
{
    public partial class TrainDetails : Form
    {
        public TrainDetails()
        {
            InitializeComponent();
        }

        private void TrainDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'railwaySystemDataSet1.Trains' table. You can move, or remove it, as needed.
            this.trainsTableAdapter.Fill(this.railwaySystemDataSet1.Trains);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel();
            this.Hide();
            userPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
