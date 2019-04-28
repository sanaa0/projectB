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
    public partial class NewAssesment : Form
    {
        public NewAssesment()
        {
            InitializeComponent();
        }

        private void NewAssesment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet.Clo);
            // TODO: This line of code loads data into the 'projectBDataSet.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet.Assessment);
            // TODO: This line of code loads data into the 'projectBDataSet.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet.Rubric);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string a =comboBox2.Text;
            

            string query111 = "SELECT Id from Assessment where Title='" + a + "'";
            SqlCommand cmd111 = new SqlCommand(query111, con);
            SqlDataReader d111 = cmd111.ExecuteReader();
            d111.Read();
            int khas = Convert.ToInt32(d111[0]);
            MessageBox.Show("the assid fetched is '" + khas + "'");
            d111.Close();
            // string q1=   ;
            SqlCommand cmd = new SqlCommand("select sum(TotalMarks) from AssessmentComponent where AssessmentId = '" + khas + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();
            
            d.Read();
            int b=0;
            MessageBox.Show("the value is '" + d[0] + "'");
           // string temp ="0";
            if (d[0] is DBNull)
            {
                b = 0;
            }
            else  
            {
                b = Convert.ToInt32(d[0]);
            }
            
            string bb = b.ToString();

           MessageBox.Show("the total assessments components added upto now is '"+bb+"' " );

            d.Close();

            SqlCommand cmd1 = new SqlCommand("select TotalMarks from Assessment where Id = '" + khas + "'", con);
            cmd1.CommandType = CommandType.Text;
            SqlDataReader d1 = cmd1.ExecuteReader();

            d1.Read();

            int b1 = Convert.ToInt32(d1[0]);
            d1.Close();
            string bb1 = b1.ToString();
              MessageBox.Show("the total marks reserved for this assessment are '"+bb1+"'");
            int l = Convert.ToInt32( textBox2.Text);
            int aa = l+b;
            string aaa = aa.ToString();
            MessageBox.Show( "when you try to add this assessment your total will become '"+aaa+"'");

            string va = comboBox1.Text.ToString();

            string query11 = "SELECT Id from Rubric where Details='" + va + "'";
            SqlCommand cmd11 = new SqlCommand(query11, con);
            SqlDataReader d11 = cmd11.ExecuteReader();
            d11.Read();
            int vva = Convert.ToInt32(d11[0]);
          //  MessageBox.Show("the id fetched is '" + vva + "'");
            d11.Close();

         



            if (b1 < aa)
            {
                MessageBox.Show("your limit of assesment has reached you can not add any more components to this");


                d1.Close();
            }
            else if (b==0)
            {
               

                d1.Close();
                d1.Close();
                string query = "INSERT INTO AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES('" + textBox1.Text.ToString() + "','" + vva + "','" + textBox2.Text.ToString() + "','" + DateTime.Now + "','" + DateTime.Now + "','" + khas + "')";

                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();

                MessageBox.Show("AssessmentComponent Added Succesfully");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assessmentmainpage n = new assessmentmainpage();
            this.Hide();
            n.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string va = comboBox3.Text;
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query1 = "SELECT Id from Clo where Name='" + va + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader d1 = cmd1.ExecuteReader();
            d1.Read();
            int vva = Convert.ToInt32(d1[0]);

            d1.Close();

            string query = "SELECT Details from Rubric where CloId='" + vva + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader d = cmd.ExecuteReader();
            List<string> t = new List<string>();

            while (d.Read())
            {
                t.Add(d[0].ToString());
            }

            comboBox1.DataSource = t;
            d.Close();
        }
    }
}
