using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_parking
{
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
            bind_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bind_data()
        {
            Connect Newconnect = new Connect();
            Newconnect.Connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.conString;

            SqlCommand cmd2 = new SqlCommand("SELECT vehicle_type,price FROM dbo.fees_table", cmd.Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd2;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);

            cartext.Text = "200.00";
            biketext.Text = "200.00";
            weeltext.Text = "200.00";
            jeeptext.Text = "200.00";
            bustext.Text = "200.00";
            othertext.Text = "200.00";

        }
    }
}
