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
    public partial class resultassesmentStudent : Form
    {
        public resultassesmentStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }

    }
}
