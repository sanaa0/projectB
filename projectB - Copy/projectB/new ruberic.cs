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
    public partial class new_ruberic : Form
    {
        public int g;
        public new_ruberic( int cloID)
        {
            InitializeComponent();
           g = cloID;
        }

        private void new_ruberic_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet.Rubric);
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT * FROM Rubric WHERE CloId="+g;
            SqlCommand cmd = new SqlCommand(query, con);



            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, "ss");

            dataGridView1.DataSource = ds.Tables["ss"];


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

//            string query = "INSERT INTO Rubric(CloId,Details) VALUES(g,'" + textBox1.Text.ToString() + "')";
           
            SqlCommand command = new SqlCommand("INSERT INTO Rubric(CloId,Details) VALUES("+ g +",'" + textBox1.Text.ToString() + "')", con);
            
            command.ExecuteNonQuery();

            MessageBox.Show("Rubric Added Succesfully");
            new_ruberic n = new new_ruberic(g);
            this.Hide();
            n.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string selected = dataGridView1.CurrentCell.ColumnIndex.ToString();
            int cn = Convert.ToInt32(selected);
            if (cn == 2)
            {

                string rid = selectedRow.Cells[0].Value.ToString();
                int id = Convert.ToInt32(rid);
                UpdateRubric ur = new UpdateRubric(id, g);
                this.Hide();
                ur.Show();








            }
            else if (cn==3)
            {
                string rid = selectedRow.Cells[0].Value.ToString();

                string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection_string);
                con.Open();

                //            string query = "INSERT INTO Rubric(CloId,Details) VALUES(g,'" + textBox1.Text.ToString() + "')";
                SqlCommand c1ommand = new SqlCommand(" Delete  FROM RubricLevel WHERE RubricId='" + rid + "'", con);

                c1ommand.ExecuteNonQuery();

                SqlCommand c2ommand = new SqlCommand(" Delete  FROM AssessmentComponent WHERE RubricId='" + rid + "'", con);

                c2ommand.ExecuteNonQuery();

                SqlCommand command = new SqlCommand(" Delete  FROM Rubric WHERE Id='"+rid+"'", con);

                command.ExecuteNonQuery();

                MessageBox.Show("Rubric deleted Succesfully");
                new_ruberic n = new new_ruberic(g);
            this.Hide();
            n.Show();

            }
            else if (cn == 4)
            {
                string rid = selectedRow.Cells[0].Value.ToString();
                int rrid = Convert.ToInt32(rid);
                NewRubricLevel n = new NewRubricLevel(rrid);
                this.Hide();
                n.Show();
            }

            else if (cn == 5)
            {
                string rid = selectedRow.Cells[0].Value.ToString();
                int rrid = Convert.ToInt32(rid);
                viewRubricLevels n = new viewRubricLevels(rrid);
                this.Hide();
                n.Show();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewClo asses =  new ViewClo();
            this.Hide();
            asses.Show();

        }
    }
}
