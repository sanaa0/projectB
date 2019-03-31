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
    public partial class ViewAssessment : Form
    {
        string cloid;
        int aid;
        public ViewAssessment()
        {
            InitializeComponent();
        }

        private void ViewAssessment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet.Assessment);

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT * FROM Assessment";
            SqlCommand cmd = new SqlCommand(query, con);



            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, "ss");

            dataGridView1.DataSource = ds.Tables["ss"];


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            string selected = dataGridView1.CurrentCell.ColumnIndex.ToString();
            int cn = Convert.ToInt32(selected);

            if (cn == 5) //update button
            {
                cloid = selectedRow.Cells[0].Value.ToString();
                aid = Convert.ToInt16(cloid);
                assesmentUpdate n = new assesmentUpdate(aid);
                this.Hide();
                n.Show();


            }

            else if (cn == 6) //delete button
            {


                string cid = selectedRow.Cells[0].Value.ToString();

                string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection_string);
                con.Open();

                //            string query = "INSERT INTO Rubric(CloId,Details) VALUES(g,'" + textBox1.Text.ToString() + "')";

                SqlCommand command = new SqlCommand(" Delete  FROM Assessment WHERE Id='" + cid + "'", con);

                SqlCommand c1 = new SqlCommand("select Id from assessmentComponent where AssessmentId='" + cid + "'", con);
                var d = c1.ExecuteReader();

                List<int> list = new List<int>();

                while (d.Read())
                {
                    list.Add(d.GetInt32(0));
                    //    count++;

                }
                d.Close();
                for (int i = 0; i < list.Count; i++)
                {
                    SqlCommand c2ommand = new SqlCommand(" Delete  FROM AssessmentComponent WHERE Id=" + list[i], con);
                    c2ommand.ExecuteNonQuery();
                }


                //SqlCommand c1ommand = new SqlCommand(" Delete  FROM Rubric WHERE CloId='" + cid + "'", con);
                //c1ommand.ExecuteNonQuery();

                command.ExecuteNonQuery();


                MessageBox.Show("Assessment deleted Succesfully");
                ViewAssessment n = new ViewAssessment();
                this.Hide();
                n.Show();







            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
         assessmentmainpage n = new assessmentmainpage();

            this.Hide();
            n.Show();
        }
    }
}
