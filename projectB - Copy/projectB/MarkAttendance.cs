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
    public partial class MarkAttendance : Form
    {
        public MarkAttendance()
        {
            InitializeComponent();
        }

      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int aa = 0;
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();


            string q11uery = "SELECT Id from ClassAttendance where AttendanceDate='" + DateTime.Now.Date + "' ";
            SqlCommand c11ommand = new SqlCommand(q11uery, con);

            SqlDataReader dr1 = c11ommand.ExecuteReader();
            while (dr1.Read())
            {
                aa++;
            }
            dr1.Close();


            if (aa==0)
            {
                string query = "INSERT INTO ClassAttendance(AttendanceDate) VALUES('" + DateTime.Now.Date + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                AttendanceMark n = new AttendanceMark();
                this.Hide();
                n.Show();


            }

            else
            {
                MessageBox.Show("this date's Attendance is already Marked");
            }








        }

        private void MarkAttendance_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewAttendance n = new ViewAttendance();
            this.Hide();
            n.Show();
        }
    }
}
