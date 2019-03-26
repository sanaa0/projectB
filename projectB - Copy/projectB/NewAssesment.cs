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

            string query = "INSERT INTO AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + DateTime.Now + "','" + DateTime.Now + "','" + comboBox2.Text.ToString() + "')";
         
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();

            MessageBox.Show("AssessmentComponent Added Succesfully");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assessmentmainpage n = new assessmentmainpage();
            this.Hide();
            n.Show();
        }
    }
}
