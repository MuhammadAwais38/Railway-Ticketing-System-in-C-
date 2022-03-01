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
    
    public partial class UserPanel : Form
    {
        public int userId;
        public UserPanel(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        public UserPanel()
        {
            InitializeComponent();
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TrainDetails trainDetails = new TrainDetails();
            this.Hide();
            trainDetails.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BookATicket bookATicket = new BookATicket(userId);    
            this.Hide();
            bookATicket.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BookedTicket bookedTicket = new BookedTicket(userId);
            this.Hide();
            bookedTicket.Show();
        }
    }
}
