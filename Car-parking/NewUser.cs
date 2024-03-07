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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Car_parking
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connect Newconnect = new Connect();
            Newconnect.Connection();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.conString;

            string querry = "INSERT INTO usertable(username,password)" +
                " Values('" + newusername.Text.ToString() + "','" + newpassword.Text.ToString() + "')";
            SqlCommand cmd2 = new SqlCommand(querry, cmd.Connection);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Successfuly added");

            this.Close();
        }
    }
}
