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
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Lookup' table. You can move, or remove it, as needed.
            this.lookupTableAdapter.Fill(this.projectBDataSet.Lookup);
            // TODO: This line of code loads data into the 'projectBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet.Student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a=1;
            
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "INSERT INTO ClassAttendance(AttendanceDate) VALUES('" + DateTime.Now + "')";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();


            string q11uery = "SELECT Id from ClassAttendance WHERE AttendanceDate= "+DateTime.Now;
            SqlCommand c11ommand = new SqlCommand(q11uery, con);

            SqlDataReader drr = c11ommand.ExecuteReader();
            drr.Read();
           int  aa = Convert.ToInt32(drr[0]);
            drr.Close();


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               

                string texte = dataGridView1.Rows[4].ToString();
                if (texte =="Present")
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

                string q4uery = "INSERT INTO StudentAttendance(AttendaneId,StudentId,AttendanceStatus) Values('"+aa+"''" + dataGridView1.Rows[4].ToString() +"','"+a+"')";
                SqlCommand c4ommand = new SqlCommand(query, con);
                c4ommand.ExecuteNonQuery();

                MessageBox.Show("Attendance Marked Succesfully");


            }
        }

       

        
    }
}
