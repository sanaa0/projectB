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
    public partial class AttendanceUpdate : Form
    {
        public AttendanceUpdate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }

        private void AttendanceUpdate_Load(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();


          


            String query = "SELECT FirstName,LastName,RegistrationNumber,Name as Attendance ,StudentAttendance.StudentId FROM [Student] JOIN StudentAttendance ON StudentAttendance.StudentId = [Student].Id  JOIN Lookup on Lookup.LookupId = StudentAttendance.AttendanceStatus";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter VD = new SqlDataAdapter(cmd);
            DataTable table = new DataTable(cmd.ToString());

            VD.Fill(table);
            dataGridView1.DataSource = table; //showing required data in dataGrid
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int a = 1;
            int aa = 0;

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();


            string q11uery = "SELECT Id from ClassAttendance where AttendanceDate='" + dateTimePicker1.Value.Date + "' ";
            SqlCommand c11ommand = new SqlCommand(q11uery, con);

            SqlDataReader dr1 = c11ommand.ExecuteReader();
            dr1.Read();
            aa = Convert.ToInt32(dr1[0]);
            dr1.Close();


            string q01uery = "SELECT StudentId from StudentAttendance where AttendanceDate='" + aa + "' ";
            SqlCommand c01ommand = new SqlCommand(q01uery, con);

            SqlDataReader dr10 = c11ommand.ExecuteReader();
            dr10.Read();
            aa = Convert.ToInt32(dr10[0]);
            dr10.Close();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

               // int b = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                string texte = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string textet = dataGridView1.Rows[i].Cells[4].Value.ToString();

                if (texte == "Present")
                {
                    string q1uery = "SELECT LookupId from Lookup WHERE Name='Present' AND Category='ATTENDANCE_STATUS' ";
                    SqlCommand c1ommand = new SqlCommand(q1uery, con);

                    SqlDataReader dr = c1ommand.ExecuteReader();
                    dr.Read();
                    a = Convert.ToInt32(dr[0]);
                    dr.Close();
                }
                if (texte == "Absent")
                {

                    string q1uery = "SELECT LookupId from Lookup WHERE Name='Absent' AND Category='ATTENDANCE_STATUS' ";
                    SqlCommand c1ommand = new SqlCommand(q1uery, con);

                    SqlDataReader dr = c1ommand.ExecuteReader();
                    dr.Read();
                    a = Convert.ToInt32(dr[0]);
                    dr.Close();
                }
                if (texte == "Late")
                {

                    string q1uery = "SELECT LookupId from Lookup WHERE Name='Late' AND Category='ATTENDANCE_STATUS' ";
                    SqlCommand c1ommand = new SqlCommand(q1uery, con);

                    SqlDataReader dr = c1ommand.ExecuteReader();
                    dr.Read();
                    a = Convert.ToInt32(dr[0]);
                    dr.Close();
                }
                if (texte == "Leave")
                {

                    string q1uery = "SELECT LookupId from Lookup WHERE Name='Leave' AND Category='ATTENDANCE_STATUS' ";
                    SqlCommand c1ommand = new SqlCommand(q1uery, con);

                    SqlDataReader dr = c1ommand.ExecuteReader();
                    dr.Read();
                    a = Convert.ToInt32(dr[0]);
                    dr.Close();

                }
                
                
                    //your code goes here
                    string q4uery = "update StudentAttendance set AttendanceStatus='" + a + "' where AttendanceId='" + aa + "' and StudentId='"+textet+"' ";
                    SqlCommand c4ommand = new SqlCommand(q4uery, con);
                    c4ommand.ExecuteNonQuery();
                   
                
                
            }
            MessageBox.Show("updated");
        }
    }
}