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
    public partial class NewCLO : Form
    {
        public NewCLO()
        {
            InitializeComponent();
        }

        private void NewCLO_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            string query = "INSERT INTO Clo(Name,DateCreated,DateUpdated) VALUES('" + textBox1.Text.ToString() + "','" + DateTime.Now + "','" + DateTime.Now  +"')";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();

            MessageBox.Show("CLO Added Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cloMain n = new cloMain();
            this.Hide();
            n.Show();
        }
    }
}
