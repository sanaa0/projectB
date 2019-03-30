using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Xml;
using System.Web;
using iTextSharp.text.pdf.draw;

namespace projectB
{
    public partial class CWR : Form
    {
        public CWR()
        {
            InitializeComponent();
        }

        private void CWR_Load(object sender, EventArgs e)
        {

            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();
            /*   String q1uery = "Create View AssessmentWiseResult AS SELECT RegistrationNumber, StudentName,Title, AssessmentId, Sum(ObtainedMarks) As AssessmentMarks FROM((SELECT RegistrationNumber, StudentName, R1.AssessmentId, Title, Name, MeasurementLevel / maxi * TotalMarks AS ObtainedMarks  FROM(select  AssessmentComponent.AssessmentId, AssessmentComponent.Name, Assessment.Title, RegistrationNumber, FirstName + ' ' + LastName AS StudentName, AssessmentComponent.TotalMarks, MeasurementLevel, RubricMeasurementId FROM AssessmentComponent JOIN StudentResult ON AssessmentComponent.id = StudentResult.AssessmentComponentId JOIN Student ON Student.Id = StudentResult.StudentId JOIN RubricLevel ON RubricLevel.Id = StudentResult.RubricMeasurementId join Assessment on Assessment.Id = AssessmentComponent.AssessmentId) R1 JOIN(select Id, Max(MeasurementLevel) as maxi from RubricLevel group by Id)  R2 ON R1.RubricMeasurementId = R2.Id)) R3 group by RegistrationNumber, StudentName, AssessmentId, Title";
               SqlCommand c1md = new SqlCommand(q1uery, con);
               c1md.ExecuteNonQuery();*/

            string query = "SELECT RegistrationNumber, StudentName,CLO_id, Name, Sum(MeasurementLevel) As CLOMarks FROM((SELECT RegistrationNumber, StudentName, R1.Id as CLO_id, r1.Name, R1.MeasurementLevel  FROM(select  clo.Id, Clo.Name, RegistrationNumber, FirstName + ' ' + LastName AS StudentName, MeasurementLevel, RubricMeasurementId FROM Clo JOIN Rubric ON Clo.id = Rubric.CloId  JOIN RubricLevel ON Rubric.Id = RubricLevel.RubricId JOIN StudentResult ON RubricLevel.Id = StudentResult.RubricMeasurementId join Student on Student.Id = StudentResult.StudentId) R1 JOIN(select Id, Max(MeasurementLevel) as maxi from RubricLevel group by Id)  R2 ON R1.RubricMeasurementId = R2.Id)  ) R3 group by RegistrationNumber, StudentName, CLO_id, Name";




;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter VD = new SqlDataAdapter(cmd);
            DataTable table = new DataTable(cmd.ToString());

            VD.Fill(table);
            dataGridView1.DataSource = table;

        }

        public void exportFunc(DataGridView dgw, string filename)
        {
            /// <summary>
            ///  pdf function
            /// </summary>
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.ColumnCount);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font Text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, Text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), Text));
                }
            }

            var savefiledialogue = new SaveFileDialog();
            savefiledialogue.FileName = filename;
            savefiledialogue.DefaultExt = ".pdf";
            if (savefiledialogue.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialogue.FileName, FileMode.Create))
                {
                    // Document c = new Document(pageSize.A4, 10f, 10f, 10f, 0f);
                    Document pdfdoc = new Document(PageSize.A4, 10, 10, 0, 0);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();

                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            exportFunc(dataGridView1, "Result");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }
    }
}
