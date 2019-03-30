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
    public partial class assesmentUpdate : Form
    {
        public int cid;
        public assesmentUpdate(int aid)
        {
            InitializeComponent();
            cid = aid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string q1uery = "UPDATE Assessment SET Title='" + textBox1.Text.ToString() + "' , TotalMarks= '" + textBox2.Text.ToString() + "' ,TotalWeightage='" + textBox3.Text.ToString() + "' where Id='" + cid + "'";
            SqlCommand c1ommand = new SqlCommand(q1uery, con);
            c1ommand.ExecuteNonQuery();
            MessageBox.Show(" Assessment successfully updated");
            ViewAssessment n = new ViewAssessment();

            this.Hide();
            n.Show();
        }

        private void assesmentUpdate_Load(object sender, EventArgs e)
        {

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            SqlDataReader dr = null;
            //   string query = "SELECT * FROM Student WHERE Id={0},studentid";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Assessment WHERE Id=" + cid, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();

            d.Read();


            textBox1.Text = d[1].ToString(); textBox2.Text = d[3].ToString(); // already shows the data stored previously
            textBox3.Text = d[4].ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }
    }
}
