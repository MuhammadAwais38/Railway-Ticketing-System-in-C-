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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModifyTrains modifyTrains = new ModifyTrains();
            this.Hide();
            modifyTrains.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ApproveTickets approveTickets = new ApproveTickets();
            this.Hide();
            approveTickets.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }
    }
}
