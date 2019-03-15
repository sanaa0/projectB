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
    public partial class studentMain : Form
    {
        public studentMain()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            newStudent ns = new newStudent();
            this.Hide();
            ns.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            view_students vs = new view_students();
            this.Hide();
            MessageBox.Show("On this page you can select the student you want to edit the details of");
            vs.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            view_students vs = new view_students();
            this.Hide();
            MessageBox.Show("On this page you can select the student you want to Delete ");
            vs.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            view_students vs = new view_students();
            this.Hide();
          //  MessageBox.Show("On this page you can select the student you want to Delete ");
            vs.Show();
        }
    }
}
