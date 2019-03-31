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

namespace projectB
{
    public partial class ViewAttendance : Form
    {
        DateTime d;
        public ViewAttendance(DateTime p)
        {
            InitializeComponent();
            d = p.Date;
        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
            string connection_string = "Data Source=DESKTOP-FA5LU48;Initial Catalog=ProjectB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection_string);
            con.Open();

            String query = "SELECT FirstName,LastName,RegistrationNumber,Name as Attendance,ClassAttendance.AttendanceDate FROM [Student] JOIN StudentAttendance ON StudentAttendance.StudentId = [Student].Id  JOIN Lookup on Lookup.LookupId = StudentAttendance.AttendanceStatus join ClassAttendance on ClassAttendance.Id=StudentAttendance.AttendanceId where ClassAttendance.AttendanceDate='"+d+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter VD = new SqlDataAdapter(cmd);
            DataTable table = new DataTable(cmd.ToString());

            VD.Fill(table);
            dataGridView1.DataSource = table; //showing required data in dataGrid
        }


        private void button1_Click(object sender, EventArgs e)
        {
            assesmentMain n = new assesmentMain();
            this.Hide();
            n.Show();
        }

       
    }
    }

