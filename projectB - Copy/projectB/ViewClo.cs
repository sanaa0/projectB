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
    public partial class ViewClo : Form
    {
        public string cloid;
        public ViewClo()
        {
            InitializeComponent();
        }

        private void ViewClo_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// buttons selected on base of content click
            /// </summary>
            // TODO: This line of code loads data into the 'projectBDataSet.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet.Clo);
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT * FROM Clo";
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

            if (cn == 6) //update
            {
                cloid = selectedRow.Cells[0].Value.ToString();
                new_ruberic r = new new_ruberic(Convert.ToInt32(cloid));
                this.Hide();
                r.Show();

            }

            else if (cn == 4) //add rubric
            {

                string rid = selectedRow.Cells[0].Value.ToString();
                int id = Convert.ToInt32(rid);
                UpdateClo ur = new UpdateClo(id);
                this.Hide();
                ur.Show();








            }

            else if (cn == 5) //delete
            {
                try { 

                string cid = selectedRow.Cells[0].Value.ToString();

                string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection_string);
                con.Open();

                //            string query = "INSERT INTO Rubric(CloId,Details) VALUES(g,'" + textBox1.Text.ToString() + "')";

                SqlCommand c1 = new SqlCommand("select Id from Rubric where Cloid='" + cid + "'", con);
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
                    SqlCommand c2ommand = new SqlCommand(" Delete  FROM RubricLevel WHERE RubricId=" + list[i], con);
                    c2ommand.ExecuteNonQuery();
                }

                SqlCommand command = new SqlCommand(" Delete  FROM Clo WHERE Id='" + cid + "'", con);


                //for(int j = 0; j < count; j++)
                //{

                //}


                SqlCommand c1ommand = new SqlCommand(" Delete  FROM Rubric WHERE CloId='" + cid + "'", con);
                c1ommand.ExecuteNonQuery();




                command.ExecuteNonQuery();


                MessageBox.Show("Clo deleted Succesfully");
                ViewClo v = new ViewClo();
                this.Hide();
                v.Show(); }

                catch {
                    MessageBox.Show("there is an assessment which uses this clo cant delete");
                }
            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cloMain asses = new cloMain();
            this.Hide();
            asses.Show();

        }
    }
}
