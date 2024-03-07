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

namespace Car_parking
{
    public partial class Clears : Form
    {
        public Clears()
        {
            InitializeComponent();
            bind_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Adminview().Show();
        }

        private void bind_data()
        {
            Connect Newconnect = new Connect();
            Newconnect.Connection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.conString;

            SqlCommand cmd2 = new SqlCommand("SELECT dbo.parkings.id,dbo.parking_slots.slot_name AS Slot,  " +
                " dbo.parkings.intime AS InTime," +
                " dbo.parkings.indate AS InDate," +
                " dbo.parkings.outtime AS OutTime," +
                " dbo.parkings.outdate AS OutDate," +
                " dbo.parkings.price AS Price," +
                " dbo.parkings.note AS Note," +
                " dbo.vehicle.vehicle_type AS VehicleType," +
                " dbo.vehicle.vehicle_no AS VehicleNo," +
                " dbo.vehicle_owners.owner_name As OwnerName," +
                " dbo.vehicle_owners.owner_phone AS OwnerPhoneNo FROM dbo.parkings LEFT JOIN dbo.parking_slots ON dbo.parking_slots.slot_id = dbo.parkings.slot_id LEFT JOIN dbo.vehicle ON dbo.vehicle.vehicle_id = dbo.parkings.vehicle_number LEFT JOIN dbo.vehicle_owners ON dbo.vehicle_owners.owner_id = dbo.parkings.vehicle_owner", cmd.Connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd2;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int No;
            No = e.RowIndex;
            DataGridViewRow rowslist = dataGridView1.Rows[No];
            parking_id.Text = rowslist.Cells[0].Value.ToString();
            slot.Text = rowslist.Cells[1].Value.ToString();
            vehicleno.Text = rowslist.Cells[9].Value.ToString();
            vehicleowner.Text = rowslist.Cells[10].Value.ToString();
            phone.Text = rowslist.Cells[11].Value.ToString();
        }

        
    }
}
