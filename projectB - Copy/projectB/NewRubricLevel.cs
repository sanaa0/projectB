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

        private void NewRubricLevel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            //            string query = "INSERT INTO Rubric(CloId,Details) VALUES(g,'" + textBox1.Text.ToString() + "')";

            SqlCommand command = new SqlCommand("INSERT INTO RubricLevel(RubricId,Details,MeasurementLevel) VALUES(" + cid + ",'" + textBox1.Text.ToString() + "','"+comboBox1.Text+"')", con);

            command.ExecuteNonQuery();

            

            MessageBox.Show("RubricLevels Added Succesfully");
            NewRubricLevel n = new NewRubricLevel(cid);
            this.Hide();
            n.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }
    }
}
