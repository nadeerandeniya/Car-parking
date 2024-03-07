using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Car_parking
{
    public partial class Entrygate : Form
    {
        public Entrygate()
        {
            InitializeComponent();
            bind_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Adminview().Show();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //create database connection
            Connect Newconnect = new Connect();
            Newconnect.Connection();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.conString;

            //add new parked vehicle owner data to database
            string querry1 = "INSERT INTO vehicle_owners(owner_name,owner_phone)" +
                " Values('" + vehicleowner.Text.ToString() + "','" + phone.Text.ToString() + "')";
            SqlCommand cmd2 = new SqlCommand(querry1, cmd.Connection);
            cmd2.ExecuteNonQuery();

            string querry = "SELECT owner_id FROM vehicle_owners";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, cmd.Connection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            int owner_id = dataTable.Rows.Count;

            //add new parked vehicle data to database
            string querry2 = "INSERT INTO vehicle(vehicle_type,vehicle_no,vehicle_owner)" +
                " Values('" + comboBox1.Text.ToString() + "','" + vehicleno.Text.ToString() + "','" + owner_id + "')";
            SqlCommand cmd3 = new SqlCommand(querry2, cmd.Connection);
            cmd3.ExecuteNonQuery();

            string querry5 = "SELECT vehicle_id FROM vehicle";
            SqlDataAdapter adapter2 = new SqlDataAdapter(querry5, cmd.Connection);

            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);

            int vehicle_id = dataTable2.Rows.Count;

            //add new parked vehicle parking data to database
            string querry3 = "INSERT INTO parkings(slot_id,vehicle_number,vehicle_owner,intime,indate,note,vehicle_own_phone)" +
                " Values('" + slot.Text.ToString()+"','"+ vehicle_id + "','"+ owner_id + "','"+ timetext.Text.ToString() + "','"+ datetext.Text.ToString() + "','"+phone.Text.ToString()+"','"+phone.Text.ToString()+"')";
            SqlCommand cmd4 = new SqlCommand(querry3, cmd.Connection);
            cmd4.ExecuteNonQuery();

            string querry6 = "Update parking_slots SET status='Parked' WHERE slot_id='"+ slot.Text.ToString() + "'";
            SqlCommand cmd5 = new SqlCommand(querry6, cmd.Connection);
            cmd5.ExecuteNonQuery();


            MessageBox.Show("Successfuly added");
            this.Close();
        }

        private void bind_data()
        {
            Connect Newconnect = new Connect();
            Newconnect.Connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.conString;

            SqlCommand cmd2 = new SqlCommand("Select slot_id AS No,slot_name AS Code From parking_slots WHERE status='Available '", cmd.Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd2;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int No;
            No= e.RowIndex;
            DataGridViewRow rowslist=dataGridView1.Rows[No];
            slot.Text = rowslist.Cells[0].Value.ToString();

        }
    }
}
