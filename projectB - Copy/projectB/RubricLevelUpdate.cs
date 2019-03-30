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
    public partial class RubricLevelUpdate : Form
    {
        public int cid;
        public RubricLevelUpdate(int rid)
        {
            InitializeComponent();
            cid = rid;
        }

        private void RubricLevelUpdate_Load(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            SqlDataReader dr = null;
            //   string query = "SELECT * FROM Student WHERE Id={0},studentid";
            SqlCommand cmd = new SqlCommand("SELECT * FROM RubricLevel WHERE Id=" + cid, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();

            d.Read();

            comboBox1.Text = d[1].ToString();

            textBox1.Text = d[2].ToString();
            comboBox2.Text = d[3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
           
            string q2uery =
               "UPDATE RubricLevel SET Details='" + textBox1.Text.ToString() + "' , RubricId = '" + comboBox1.Text + "',MeasurementLevel='"+comboBox2.Text+"' where Id='" + cid + "'";
            SqlCommand c2ommand = new SqlCommand(q2uery, con);
            c2ommand.ExecuteNonQuery();


            MessageBox.Show("RubricLevel updated Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();

        }
    }
}
