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
    public partial class viewRubricLevels : Form
    {
        public int cid;
        public viewRubricLevels(int rid)
        {
            InitializeComponent();
            cid = rid;
        }

        private void viewRubricLevels_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.RubricLevel' table. You can move, or remove it, as needed.
            this.rubricLevelTableAdapter.Fill(this.projectBDataSet.RubricLevel);


            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT * FROM RubricLevel WHERE RubricId=" + cid;
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
            if (cn == 4)
            {

                string rid = selectedRow.Cells[0].Value.ToString();
                int id = Convert.ToInt32(rid);
                RubricLevelUpdate ur = new RubricLevelUpdate(id);
                this.Hide();
                ur.Show();








            }
            else if (cn == 5)
            {
                try
                {
                    string rid = selectedRow.Cells[0].Value.ToString();

                    string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
                    SqlConnection con = new SqlConnection(connection_string);
                    con.Open();

                    //            string query = "INSERT INTO Rubric(CloId,Details) VALUES(g,'" + textBox1.Text.ToString() + "')";

                    SqlCommand command = new SqlCommand(" Delete  FROM RubricLevel WHERE Id='" + rid + "'", con);

                    command.ExecuteNonQuery();

                    MessageBox.Show("RubricLevel deleted Succesfully");
                    viewRubricLevels n = new viewRubricLevels(cid);
                    this.Hide();
                    n.Show();
                }
                catch
                {
                    MessageBox.Show("this is used in result can not delete it");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }
    }
}
