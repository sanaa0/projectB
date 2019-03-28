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
    public partial class assessmentViseResult : Form
    {
        public assessmentViseResult()
        {
            InitializeComponent();
        }

        private void assessmentViseResult_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet.Assessment);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            string selected = dataGridView1.CurrentCell.ColumnIndex.ToString();
            int cn = Convert.ToInt32(selected);
            string studentid = selectedRow.Cells[0].Value.ToString();
            int p = Convert.ToInt32(studentid);



            if (cn == 2)
            {

                AssessmentViseResult1 n = new AssessmentViseResult1(p);
                this.Hide();
                n.Show();
            }
        }
    }
}
