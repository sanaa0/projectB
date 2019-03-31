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
    public partial class Updateattendance_date : Form
    {
        public Updateattendance_date()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d = dateTimePicker1.Value;
            AttendanceUpdate ad = new AttendanceUpdate(d);
            this.Hide();
            ad.Show();
        }
    }
}
