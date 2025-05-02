using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeNamespace;

namespace EmployeeApplication
{
    public partial class frmEmployeeDatabase : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-05TAS7N\\SQLEXPRESS01;Database=myDB;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
        public frmEmployeeDatabase()
        {
            InitializeComponent();
        }

        private void frmEmployeeDatabase_Load(object sender, EventArgs e)
        {
            loading();
        }
        public void loading()
        {
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            int id = employee.EmployeesID = Convert.ToInt32(txtboxEmployeeID.Text);
            string fname = employee.FirstName = Convert.ToString(txtboxFname.Text);
            string lname = employee.LastName = Convert.ToString(txtboxLname.Text);
            string position = employee.Postions = Convert.ToString(txtboxPosition.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO tbl_Employee(id, firstName, lastName, position) Values ('"+ id + "','"+
                fname +"','"+ lname +"','"+ position + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            loading();
        }
    }
}

namespace EmployeeNamespace
{
    public class Employee
    {
        private int EmployeeID;
        private string Fname, Lname, Position;

        public Employee()
        {
            EmployeeID = 0;
            Fname = "";
            Lname = "";
            Position = "";
        }

        public Employee(int ID, string fname, string lname, string position)
        {
            this.EmployeeID = ID;
            this.Fname = fname;
            this.Lname = lname;
            this.Position = position;
        }

        public int EmployeesID
        {
            get
            { 
            return EmployeeID;
            }
            set
            {
                EmployeeID = value; 
            }
        }
        public string FirstName
        {
            get
            {
                return Fname;
            }
            set
            {

                this.Fname = value;
            }
        }
        public string LastName
        {
            get
            {
                return Lname;
            }
            set
            {
                this.Lname = value;
            }
        }
        public string Postions
        {
            get
            {
                return Position;
            }
            set
            {
                this.Position = value;
            }
        }
    }
}
