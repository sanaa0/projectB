using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectB
{
    public partial class assessmentmainpage : Form
    {
        public assessmentmainpage()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            assesmentAdd n = new assesmentAdd();

            this.Hide();
            n.Show();
        }

        private void assessmentmainpage_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Select the assessment you want to update");

            ViewAssessment n = new ViewAssessment();
            this.Hide();
            n.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            MessageBox.Show("Select the assessment you want to Delete");
            ViewAssessment n = new ViewAssessment();
            this.Hide();
            n.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewAssesment n = new NewAssesment();
            this.Hide();
            n.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            MessageBox.Show("Select the assessmentComponent you want to update");
            assessmentcomponentview n = new assessmentcomponentview();
            this.Hide();
            n.Show();

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            MessageBox.Show("Select the assessmentComponent you want to delete");
            assessmentcomponentview n = new assessmentcomponentview();
            this.Hide();
            n.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();

            this.Hide();
            n.Show();


        }
    }
}
