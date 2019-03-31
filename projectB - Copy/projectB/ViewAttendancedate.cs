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
    public partial class ViewAttendancedate : Form
    {
        public ViewAttendancedate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewAttendance n = new ViewAttendance(dateTimePicker1.Value.Date);
            this.Hide();
            n.Show();
        }
    }
}
