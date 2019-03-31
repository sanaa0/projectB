using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web
    ;




namespace projectB
{
    public partial class view_students : Form
    {
        public view_students()
        {
            InitializeComponent();
        }
        SqlDataAdapter dr = new SqlDataAdapter();
        DataTable dt = new DataTable();
        private void view_students_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'projectBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet.Student);

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "SELECT * FROM Student";
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
            string studentid = selectedRow.Cells[0].Value.ToString();



            if (cn == 7)
            {
               
                Updaye_student r = new Updaye_student(Convert.ToInt32(studentid));
                this.Hide();
                r.Show();
            }

            else if (cn==8)
            {

                string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection_string);
                con.Open();

                SqlCommand c1ommand = new SqlCommand(" Delete  FROM StudentResult WHERE StudentId='" + studentid + "'", con);
                c1ommand.ExecuteNonQuery();

                SqlCommand c2ommand = new SqlCommand(" Delete  FROM StudentAttendance WHERE StudentId='" + studentid + "'", con);
                c2ommand.ExecuteNonQuery();

                SqlCommand command = new SqlCommand(" Delete  FROM Student WHERE Id='" + studentid + "'", con);
                command.ExecuteNonQuery();
                MessageBox.Show("User deleted");
                view_students n = new view_students();
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

        private void button1_Click(object sender, EventArgs e)
        {
            newStudent asses = new newStudent();
            this.Hide();
            asses.Show();
        }
    }
}
