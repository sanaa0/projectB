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
    public partial class StudentMarkSheet : Form
    {
        public StudentMarkSheet()
        {
            InitializeComponent();
        }

        private void StudentMarkSheet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet.Student);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
           string cloid = selectedRow.Cells[0].Value.ToString();
            int ccloid = Convert.ToInt32(cloid);
            ResultMarking n = new ResultMarking(ccloid);
            this.Hide();
            n.Show();

        }
    }
}
