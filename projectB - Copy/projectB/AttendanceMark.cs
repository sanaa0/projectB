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
    public partial class AttendanceMark : Form
    {
        public AttendanceMark()
        {
            InitializeComponent();
        }

        private void AttendanceMark_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet.Student);
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT RegistrationNumber, FirstName,LastName ,Id FROM Student";
            SqlCommand cmd = new SqlCommand(query, con);



            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, "ss");
            /// <summary>
            /// combo box for attendance
            /// </summary>

            dataGridView1.DataSource = ds.Tables["ss"];
            DataGridViewComboBoxColumn col1 = new DataGridViewComboBoxColumn();
            col1.HeaderText = "Attendance";
            col1.Items.Add("Present");
            col1.Items.Add("Absent");
            col1.Items.Add("Leave");
            col1.Items.Add("Late");
            dataGridView1.Columns.Add(col1);


           


        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            int a=1;
            int aa = 0;
            
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();


            string q11uery = "SELECT Id from ClassAttendance where AttendanceDate='" + DateTime.Now.Date + "' ";
            SqlCommand c11ommand = new SqlCommand(q11uery, con);

            SqlDataReader dr1 = c11ommand.ExecuteReader();
            dr1.Read();
            aa = Convert.ToInt32(dr1[0]);
            dr1.Close();

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {

                int b = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                string texte = dataGridView1.Rows[i].Cells[4].Value.ToString();
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

                string q4uery = "INSERT INTO StudentAttendance(AttendanceId,StudentId,AttendanceStatus) Values('"+aa+"','" + b + "','"+a+"')";
                SqlCommand c4ommand = new SqlCommand(q4uery, con);
                c4ommand.ExecuteNonQuery();

               


            }


            MessageBox.Show("Attendance Marked Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }
    }
}
