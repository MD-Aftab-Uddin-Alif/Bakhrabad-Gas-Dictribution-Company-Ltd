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
using static System.Windows.Forms.MonthCalendar;

namespace Bakhrabad_Gas
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            ShowEmployee();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Desktop\Bakhrabad Gas\Bakhrabad Gas\GasDB.mdf;Integrated Security=True");

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            this.Hide();
            Obj.Show();
        }

        private void GsDashboard_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            this.Hide();
            Obj.Show();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            Type Obj = new Type();
            this.Hide();
            Obj.Show();
        }

        private void GoType_Click(object sender, EventArgs e)
        {
            Type Obj = new Type();
            this.Hide();
            Obj.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            this.Hide();
            Obj.Show();
        }

        private void GoAbashik_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            this.Hide();
            Obj.Show();
        }

        private void btnSupplyer_Click(object sender, EventArgs e)
        {
            Supplyer Obj = new Supplyer();
            this.Hide();
            Obj.Show();
        }

        private void GoBanijjik_Click(object sender, EventArgs e)
        {
            Supplyer Obj = new Supplyer();
            this.Hide();
            Obj.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            Bill Obj = new Bill();
            this.Hide();
            Obj.Show();
        }

        private void GoBill_Click(object sender, EventArgs e)
        {
            Bill Obj = new Bill();
            this.Hide();
            Obj.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            this.Hide();
            Obj.Show();
        }

        private void GoLogout_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            this.Hide();
            Obj.Show();
        }

        private void ShowEmployee()
        {
            Con.Open();
            string Query = "Select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DSVEmployee.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtEmployeeName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtGender.SelectedIndex = 0;
            txtDesignation.Text = "";
            Key = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtGender.SelectedIndex == -1 || txtDesignation.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl(EmployeeName,Address,MobileNo,Gender,Designation,JoinDate)values(@EN,@EA,@EMN,@EG,@ED,@EJD)", Con);
                    cmd.Parameters.AddWithValue("@EN", txtEmployeeName.Text);
                    cmd.Parameters.AddWithValue("@EA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@EMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@EJD", txtJoinDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EG", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", txtDesignation.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee added successfylly");
                    Con.Close();
                    ShowEmployee();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void DSVEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmployeeName.Text = DSVEmployee.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = DSVEmployee.SelectedRows[0].Cells[2].Value.ToString();
            txtMobileNo.Text = DSVEmployee.SelectedRows[0].Cells[3].Value.ToString();
            txtGender.SelectedItem = DSVEmployee.SelectedRows[0].Cells[4].Value.ToString();
            txtDesignation.Text = DSVEmployee.SelectedRows[0].Cells[5].Value.ToString();
            txtJoinDate.Text = DSVEmployee.SelectedRows[0].Cells[6].Value.ToString();
            if (txtEmployeeName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DSVEmployee.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Employee");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from EmployeeTbl where EmployeeId=@Ekey", Con);
                    cmd.Parameters.AddWithValue("@Ekey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted successfully");
                    Con.Close();
                    ShowEmployee();
                    Reset();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtGender.SelectedIndex == -1 || txtDesignation.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update EmployeeTbl Set EmployeeName=@EN,Address=@EA,MobileNo=@EMN,JoinDate=@EJD,Gender=@EG,Designation=@ED where EmployeeID=@EKey", Con);
                    cmd.Parameters.AddWithValue("@EN", txtEmployeeName.Text);
                    cmd.Parameters.AddWithValue("@EA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@EMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@EJD", txtJoinDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EG", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", txtDesignation.Text);
                    cmd.Parameters.AddWithValue("@EKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee updated successfylly");
                    Con.Close();
                    ShowEmployee();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
