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
    public partial class assesmentMain : Form
    {
        public assesmentMain()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            studentMain f = new studentMain();
            this.Hide();
            f.Show();
            
         
            
           
        }

        private void assesmentMain_Load(object sender, EventArgs e)
        {
            assessmentmainpage n = new assessmentmainpage();
            this.Hide();
            n.Show() ;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cloMain au = new cloMain();
            this.Hide();
            au.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewClo d = new ViewClo();
            this.Hide();
            MessageBox.Show("Select the CLO on this page you want to work a rubric against");
            d.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewCLO
                ns = new NewCLO ();
            this.Hide();
            ns.Show();

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            assessmentmainpage n = new assessmentmainpage();

            this.Hide();
            n.Show();
        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MarkAttendance n = new MarkAttendance();
            this.Hide();
            n.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ra1 n = new ra1();
            this.Hide();
            n.Show();
        }
    }
}
