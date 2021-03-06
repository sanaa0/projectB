﻿using System;
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
    public partial class AssesmentComponentUpdate : Form
    {
        int cid;
        public AssesmentComponentUpdate(int aid)
        {
            InitializeComponent();
            cid = aid;
        }

        private void AssesmentComponentUpdate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet.Assessment);
            // TODO: This line of code loads data into the 'projectBDataSet.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet.Rubric);

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
           // SqlDataReader dr = null;
            //   string query = "SELECT * FROM Student WHERE Id={0},studentid";
            SqlCommand cmd = new SqlCommand("SELECT * FROM AssessmentComponent WHERE Id=" + cid, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();

            d.Read();


            textBox1.Text = d[1].ToString(); textBox2.Text = d[3].ToString();
            comboBox2.Text = d[6].ToString();   // already shows the data stored previously
            comboBox1.Text = d[2].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            int a = Convert.ToInt32(comboBox2.Text);
            SqlCommand cmd = new SqlCommand("select sum(TotalMarks) from AssessmentComponent where AssessmentId = '" + a + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader d = cmd.ExecuteReader();

            d.Read();

            int b = Convert.ToInt32(d[0]);
            string bb = b.ToString();
            MessageBox.Show("the total assessments components added upto now is '" + bb + "' ");

            d.Close();

            SqlCommand cmd1 = new SqlCommand("select TotalMarks from Assessment where Id = '" + a + "'", con);
            cmd1.CommandType = CommandType.Text;
            SqlDataReader d1 = cmd1.ExecuteReader();

            d1.Read();

            int b1 = Convert.ToInt32(d1[0]);
            string bb1 = b1.ToString();
            MessageBox.Show("the total marks reserved for this assessment are '" + bb1 + "'");
            int l = Convert.ToInt32(textBox2.Text);
            int aa = l + b;
            string aaa = aa.ToString();
            MessageBox.Show("when you try to add this assessment your total will become '" + aaa + "'");



            if (b1 < aa)
            {
                MessageBox.Show("your limit of assesment has reached you can not add any more components to this");


                d1.Close();
            }
            else

            {
                d1.Close();

                string q1uery = "UPDATE AssessmentComponent SET Name='" + textBox1.Text.ToString() + "' , RubricId= '" + comboBox1.Text.ToString() + "', TotalMarks='" + textBox2.Text.ToString() + "',DateUpdated='" + DateTime.Now + "', AssessmentId='" + comboBox2.Text.ToString() + "' where Id='" + cid + "'";
            SqlCommand c1ommand = new SqlCommand(q1uery, con);
            c1ommand.ExecuteNonQuery();
            MessageBox.Show(" Assessment successfully updated");
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assessmentmainpage n = new assessmentmainpage();

            this.Hide();
            n.Show();
        }
    }
}
