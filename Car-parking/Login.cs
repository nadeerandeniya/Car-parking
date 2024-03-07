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

namespace Car_parking
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect Newconnect=new Connect();
            Newconnect.Connection();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.conString;

            //cmd.CommandText = "SELECT * FROM usertable WHERE username='" + username.Text + "' AND password='" + password.Text + "'";

            string querry= "SELECT * FROM usertable WHERE username='" + username.Text + "' AND password='" + password.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, cmd.Connection);

            DataTable dataTable= new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count>0)
            {
                new Adminview().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User Name or Password is Wrong..!");
            }
        }
    }
}
