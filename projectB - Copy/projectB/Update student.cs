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
    public partial class Updaye_student : Form
    {
        public int g;
        public Updaye_student(int studentid)
        {
            InitializeComponent();
            g = studentid;
        }

        private void Updaye_student_Load(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            SqlDataReader dr = null ;
         //   string query = "SELECT * FROM Student WHERE Id={0},studentid";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE Id="+g, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();

            d.Read();
            

            textBox1.Text = d[1].ToString();textBox2.Text = d[2].ToString();
            textBox3.Text = d[3].ToString(); textBox4.Text = d[4].ToString();
            textBox5.Text = d[5].ToString();
            /// <summary>
            /// Previous data
            /// </summary>


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a=5;
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            SqlDataReader dr = null;
           // SqlDataReader dr1 = null;
            if (radioButton1.Checked)
            {

                string q1uery = "SELECT LookupId from Lookup WHERE Name='Active' AND Category='STUDENT_STATUS' ";
                SqlCommand c1ommand = new SqlCommand(q1uery, con);
                dr = c1ommand.ExecuteReader();
                dr.Read();
                 a = Convert.ToInt32(dr[0]);
                dr.Close();
            }

            else if  (radioButton2.Checked)
            {
                string q1uery = "SELECT LookupId from Lookup WHERE Name='InActive' AND Category='STUDENT_STATUS' ";
                SqlCommand c1ommand = new SqlCommand(q1uery, con);
                dr = c1ommand.ExecuteReader();
                dr.Read();
                 a = Convert.ToInt32(dr[0]);
                dr.Close();
            }


            string q2uery =
                "UPDATE Student SET FirstName='" + textBox1.Text + "',LastName = '" + textBox2.Text + "',Contact='" + textBox3.Text + "',Email='" + textBox4.Text + "',RegistrationNumber='" + textBox5.Text + "',Status='"+a+"' WHERE Id ='"+ g +"' ";
            SqlCommand c2ommand = new SqlCommand(q2uery, con);
            c2ommand.ExecuteNonQuery();
           

            MessageBox.Show("User updated Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view_students n = new view_students();
            this.Hide();
            n.Show();
        }
    }
}
