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
    public partial class UpdateClo : Form
    {
        public int cid;

        public UpdateClo( int id)
        {
            InitializeComponent();
            cid = id;
        }

        private void UpdateClo_Load(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Clo WHERE Id=" + cid, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();

            d.Read();


            textBox1.Text = d[1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

       string q1uery=     "UPDATE Clo SET Name='" + textBox1.Text.ToString() + "' , DateUpdated = '" + DateTime.Now + "' where Id='"+cid+"'";
            SqlCommand c1ommand = new SqlCommand(q1uery, con);
            c1ommand.ExecuteNonQuery();
            MessageBox.Show(" CLO successfully updated");      }

        private void button3_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewClo asses = new ViewClo();
            this.Hide();
            asses.Show();

        }
    }
}
