using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace projectB
{
    public partial class newStudent : Form
    {
       // int status;
        
        public newStudent()
        {
            InitializeComponent();
        }
     

        private void newStudent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* string FirstName = textBox1.Text.ToString();
            string LastName = textBox2.Text.ToString();
            string Contact = textBox3.Text.ToString();
            string Email = textBox4.Text.ToString();
            string RegistrationNumber = textBox5.Text.ToString();
            // if (radioButton1.Checked) { }*/
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query ="INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES('"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"',5)";
            SqlCommand command = new SqlCommand(query,con);
            command.ExecuteNonQuery();
           
            MessageBox.Show("User Added Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentMain n = new studentMain();
            this.Hide();
            n.Show();
        }
    }
}
