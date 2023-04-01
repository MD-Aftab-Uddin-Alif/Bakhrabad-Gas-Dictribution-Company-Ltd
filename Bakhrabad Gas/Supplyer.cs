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

namespace Bakhrabad_Gas
{
    public partial class Supplyer : Form
    {
        public Supplyer()
        {
            InitializeComponent();
            ShowSupplyer();

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

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee Obj = new Employee();
            this.Hide();
            Obj.Show();
        }

        private void GoEmployee_Click(object sender, EventArgs e)
        {
            Employee Obj = new Employee();
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

        private void ShowSupplyer()
        {
            Con.Open();
            string Query = "Select * from SupplyerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DSvSupplyer.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtSupplyerName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtGender.SelectedIndex = 0;
            txtPassword.Text = "";
            Key = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtSupplyerName.Text==""||txtAddress.Text==""||txtMobileNo.Text==""||txtGender.SelectedIndex==-1||txtPassword.Text=="")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SupplyerTbl(SupplyerName,Address,MobileNo,JoinDate,Gender,Password)values(@SN,@SA,@SMN,@SD,@SG,@SP)", Con);
                    cmd.Parameters.AddWithValue("@SN", txtSupplyerName.Text);
                    cmd.Parameters.AddWithValue("@SA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@SMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@SD", txtJoinDate.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SP", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplyer added successfylly");
                    Con.Close();
                    ShowSupplyer();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void DSvSupplyer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSupplyerName.Text = DSvSupplyer.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text= DSvSupplyer.SelectedRows[0].Cells[2].Value.ToString();
            txtMobileNo.Text= DSvSupplyer.SelectedRows[0].Cells[3].Value.ToString();
            txtJoinDate.Text= DSvSupplyer.SelectedRows[0].Cells[4].Value.ToString();
            txtGender.SelectedItem= DSvSupplyer.SelectedRows[0].Cells[5].Value.ToString();
            txtPassword.Text= DSvSupplyer.SelectedRows[0].Cells[6].Value.ToString();
            if(txtSupplyerName.Text=="")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DSvSupplyer.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Key==0)
            {
                MessageBox.Show("Select the Supplyer");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from SupplyerTbl where SupplyerId=@Skey", Con);
                    cmd.Parameters.AddWithValue("@Skey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplyer deleted successfully");
                    Con.Close();
                    ShowSupplyer();
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
            if (txtSupplyerName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtGender.SelectedIndex == -1 || txtPassword.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update SupplyerTbl Set SupplyerName=@SN,Address=@SA,MobileNo=@SMN,JoinDate=@SD,Gender=@SD,Password=@SP where SupplyerID=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SN", txtSupplyerName.Text);
                    cmd.Parameters.AddWithValue("@SA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@SMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@SD", txtJoinDate.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", txtGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SP", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplyer updated successfylly");
                    Con.Close();
                    ShowSupplyer();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
