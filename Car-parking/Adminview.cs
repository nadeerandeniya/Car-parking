using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_parking
{
    public partial class Adminview : Form
    {
        public Adminview()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Entrygate().Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new availableSlot().Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Tickets().Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new Clears().Show();
        }
    }
}
