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
    public partial class NewRubricLevel : Form
    {
       public int cid;
        public NewRubricLevel(int rid)
        {
            InitializeComponent();
            cid = rid;
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            int i=0;
            int jo = 0;
            string query = "SELECT MeasurementLevel from RubricLevel where RubricId='" + cid + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader d = cmd.ExecuteReader();
            List<int> t = new List<int>();
            while (d.Read())
            {
                t.Add(Convert.ToInt32(d[0]));
                i++;
            }
            
            d.Close();
            for (int j = 0; j < i; j++) {
                if ( Convert.ToInt32 ( comboBox1.Text) == t[j])
                {
                    MessageBox.Show("this level already exists");
                    NewRubricLevel na = new NewRubricLevel(cid);
                    this.Hide();
                    na.Show();
                     jo = 1;
                }
                    }
            if (Convert.ToInt32(comboBox1.Text) > 5 || Convert.ToInt32(comboBox1.Text) < 0)
            {
                MessageBox.Show("this level cant exists");
                NewRubricLevel na = new NewRubricLevel(cid);
                this.Hide();
                na.Show();
                jo = 1;
            }
            // 
            if (jo == 0)
            {

                SqlCommand command = new SqlCommand("INSERT INTO RubricLevel(RubricId,Details,MeasurementLevel) VALUES(" + cid + ",'" + textBox1.Text.ToString() + "','" + comboBox1.Text + "')", con);

                command.ExecuteNonQuery();



                MessageBox.Show("RubricLevels Added Succesfully");
                NewRubricLevel n = new NewRubricLevel(cid);
                this.Hide();
                n.Show();
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
