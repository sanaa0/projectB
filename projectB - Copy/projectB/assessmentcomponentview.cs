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
    public partial class assessmentcomponentview : Form
    { /// <summary>
    /// 
    /// </summary>
        int aid;
        int cloid;
        public assessmentcomponentview()
        {
            InitializeComponent();
         //   cloid = gid;
        }

        private void assessmentcomponentview_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.AssessmentComponent' table. You can move, or remove it, as needed.
            this.assessmentComponentTableAdapter.Fill(this.projectBDataSet.AssessmentComponent);
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT * FROM AssessmentComponent";
            SqlCommand cmd = new SqlCommand(query, con);



            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd); 
     

            DataSet ds = new DataSet();

            da.Fill(ds, "ss");

            dataGridView1.DataSource = ds.Tables["ss"]; //datasource to gridview

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) 

        {

            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

            string selected = dataGridView1.CurrentCell.ColumnIndex.ToString();
            int cn = Convert.ToInt32(selected);

            if (cn == 7) // if the update is clicked.
                
            {
                string ccloid = selectedRow.Cells[0].Value.ToString();
                aid = Convert.ToInt16(ccloid);
                AssesmentComponentUpdate n = new AssesmentComponentUpdate(aid);
                this.Hide();
                n.Show();


            }

            else if (cn == 8)
            {
                /// <summary>
                /// adds new assessment component
                /// </summary>

                string cid = selectedRow.Cells[0].Value.ToString();

                string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection_string);
                con.Open();

                //            string query = "INSERT INTO Rubric(CloId,Details) VALUES(g,'" + textBox1.Text.ToString() + "')";

                SqlCommand command = new SqlCommand(" Delete  FROM AssessmentComponent WHERE Id='" + cid + "'", con);
                // SqlCommand c1ommand = new SqlCommand(" Delete  FROM Rubric WHERE CloId='" + cid + "'", con);
                //c1ommand.ExecuteNonQuery();

                command.ExecuteNonQuery();


                MessageBox.Show("AssessmentComponent deleted Succesfully");
                assessmentcomponentview n = new assessmentcomponentview();
                this.Hide();
                n.Show();







            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            assessmentmainpage n = new assessmentmainpage
                ();

            this.Hide();
            n.Show();
        }
    }
}
