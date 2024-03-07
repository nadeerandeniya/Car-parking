using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Car_parking
{
   
    class Connect
    {
        public static SqlConnection conString = null;

        public void Connection()
        {
            conString = new SqlConnection("Data Source=DESKTOP-S2P3GV0;Initial Catalog=car_park;Integrated Security=True");
            conString.Open();
        }
    }

    
}
