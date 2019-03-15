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
    public partial class UpdateRubric : Form
    {
        public int r;
        public int c;
        public UpdateRubric( int rid , int cloId)
        {
            InitializeComponent();
            r = rid;
            c = cloId;
        }

        private void UpdateRubric_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet.Clo);
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            SqlDataReader dr = null;
            //   string query = "SELECT * FROM Student WHERE Id={0},studentid";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Rubric WHERE Id=" + r, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();

            d.Read();


            textBox5.Text = d[1].ToString();
            comboBox1.SelectedValue = c;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            string q2uery =
               "UPDATE Rubric SET Details='"+textBox5.Text.ToString()+ "' , CloId = '"+comboBox1.SelectedValue+"' where Id='"+r+"'";
            SqlCommand c2ommand = new SqlCommand(q2uery, con);
            c2ommand.ExecuteNonQuery();


            MessageBox.Show("Rubric updated Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new_ruberic n = new new_ruberic(c);
            this.Hide();
            n.Show();

        }
    }
}
