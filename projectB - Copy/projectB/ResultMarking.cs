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
    public partial class ResultMarking : Form
    {
        /// <summary>
        /// specified buttons to load options according to prorly chosen options
        /// </summary>
        public int rid;
        public ResultMarking(int id)
        {
            InitializeComponent();
            rid = id;
        }

        private void ResultMarking_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.AssessmentComponent' table. You can move, or remove it, as needed.
            this.assessmentComponentTableAdapter.Fill(this.projectBDataSet.AssessmentComponent);
            // TODO: This line of code loads data into the 'projectBDataSet.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet.Assessment);
           /* string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT RegistrationNumber, FirstName,LastName ,Id FROM Student";
            SqlCommand cmd = new SqlCommand(query, con);



            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, "ss");

            dataGridView1.DataSource = ds.Tables["ss"];*/
        }

      /*  private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string cloid = selectedRow.Cells[4].Value.ToString();
            new_ruberic r = new new_ruberic(Convert.ToInt32(cloid));
            this.Hide();
            r.Show();
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            int va =  Convert.ToInt32(  comboBox3.Text);
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT Id from AssessmentComponent where AssessmentId='"+va+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader d = cmd.ExecuteReader();
            
            List<int> t = new List<int>();
            while(d.Read())
            {
                t.Add(Convert.ToInt32(d[0]));
            }
            comboBox1.DataSource = t;
            d.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            string va = comboBox1.Text;
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT RubricId from AssessmentComponent where Id='" + va + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader d = cmd.ExecuteReader();
            List<int> t = new List<int>();
            while (d.Read())
            {
                t.Add(Convert.ToInt32(d[0]));
            }
            
            comboBox4.DataSource = t;
            d.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string va = comboBox4.Text;
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT id,MeasurementLevel from RubricLevel where RubricId='" + va + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader d = cmd.ExecuteReader();
            List<int> t = new List<int>();
            while (d.Read())
            {
                t.Add(Convert.ToInt32(d[1]));
            }
            
            comboBox2.DataSource = t;
            d.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ci = comboBox2.Text;
            int c2 = Convert.ToInt32(ci);
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            string q1uery = "select id from RubricLevel where MeasurementLevel='"+c2+"'";
            SqlCommand c1ommand = new SqlCommand(q1uery, con);
            SqlDataReader w2 = c1ommand.ExecuteReader();
            w2.Read();
            int p = Convert.ToInt32(w2[0]);

            w2.Close();
            string query = "INSERT INTO StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) VALUES('"+rid+"','"+comboBox1.Text+ "','" + p + "','"+DateTime.Now+"')";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();

            MessageBox.Show("Marks Added Succesfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }
    }
}
