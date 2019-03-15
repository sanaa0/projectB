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
    public partial class cloMain : Form
    {
        public cloMain()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewCLO n = new NewCLO();
            this.Hide();
            n.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewClo n = new ViewClo();
   
            this.Hide();
            MessageBox.Show(" on this page select the CLO you want ot update");
            n.Show();

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewClo n = new ViewClo();
            this.Hide();
            MessageBox.Show(" on this page select the CLO you want ot Delete");
            n.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ViewClo n = new ViewClo();

            this.Hide();
            n.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            assesmentMain asses = new assesmentMain();
            this.Hide();
            asses.Show();


        }
    }
}
