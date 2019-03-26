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
    public partial class assesmentAdd : Form
    {
        public assesmentAdd()
        {
            InitializeComponent();
        }

        private void assesmentAdd_Load(object sender, EventArgs e)
        {
           /* string connection_string = "";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            string query = "INSERT INTO "
            SqlCommand command = new SqlCommand*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "INSERT INTO Assessment(Title,DateCreated,TotalMarks,TotalWeightage) VALUES('" + textBox1.Text.ToString() + "','" + DateTime.Now + "','" +Convert.ToInt32(textBox2.Text)+ "','" + Convert.ToInt32(textBox3.Text)+ "')";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();

            MessageBox.Show("Assessment Added Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assessmentmainpage n = new assessmentmainpage();

            this.Hide();
            n.Show();

        }
    }
}
