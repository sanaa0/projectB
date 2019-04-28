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

            textBox2.Text = d[1].ToString();

            textBox1.Text = d[2].ToString();
            comboBox2.Text = d[3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            int cc =Convert.ToInt32( comboBox2.Text);
            string q1uery = "SELECT RubricId from RubricLevel where Id='" + cid + "'";
            SqlCommand c1md = new SqlCommand(q1uery, con);
            SqlDataReader d1 = c1md.ExecuteReader();
            d1.Read();
            int c = Convert.ToInt32(   d1[0]);
            d1.Close();
            int i = 0;
            int jo = 0;
            string query = "SELECT MeasurementLevel from RubricLevel where RubricId='" + c + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader d = cmd.ExecuteReader();
            List<int> t = new List<int>();
            while (d.Read())
            {
                if ((Convert.ToInt32(d[0]) == cc)){

                }
                else {
                    t.Add(Convert.ToInt32(d[0]));
                    i++;
                }
            }

            d.Close();
            for (int j = 0; j < i; j++)
            {
                if (Convert.ToInt32(comboBox2.Text) == t[j] )
                {
                    MessageBox.Show("this level already exists");
                    RubricLevelUpdate na = new RubricLevelUpdate(cid);
                    this.Hide();
                    na.Show();
                    jo = 1;
                }
            }
            if (Convert.ToInt32(comboBox2.Text) > 5 || Convert.ToInt32(comboBox2.Text) < 0)
            {
                MessageBox.Show("this level cant exists");
                RubricLevelUpdate na = new RubricLevelUpdate(cid);
                this.Hide();
                na.Show();
                jo = 1;
            }
            // 
            if (jo == 0)
            {

                string q2uery =
               "UPDATE RubricLevel SET Details='" + textBox1.Text.ToString() + "' , RubricId = '" + textBox2.Text + "',MeasurementLevel='" + comboBox2.Text + "' where Id='" + cid + "'";
                SqlCommand c2ommand = new SqlCommand(q2uery, con);
                c2ommand.ExecuteNonQuery();


                MessageBox.Show("RubricLevel updated Succesfully");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();

        }

       
    }
}
