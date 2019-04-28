using System;
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

namespace projectB
{
    public partial class Updateattendance_date : Form
    {
        public Updateattendance_date()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dd = dateTimePicker1.Value;
            DateTime d = dd.Date;
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string q11uery = "SELECT Id from ClassAttendance where AttendanceDate='" + d + "' ";
            SqlCommand c11ommand = new SqlCommand(q11uery, con);
            int aa;
            SqlDataReader dr1 = c11ommand.ExecuteReader();
           
            if (dr1.Read())
            {
               
                AttendanceUpdate ad = new AttendanceUpdate(d);
                this.Hide();
                ad.Show();
            }

        //    aa = Convert.ToInt32(dr1[0]);
          //  dr1.Close();


            else{
                MessageBox.Show("chose  another date");
            }
        }

      
    }
}
