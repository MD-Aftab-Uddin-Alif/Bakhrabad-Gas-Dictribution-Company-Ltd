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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            ShowUser();
            GetType();
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

        private void ShowUser()
        {
            Con.Open();
            string Query = "Select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DSVUsers.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtUserName.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtArea.Text = "";
            txtStoveType.Text="";
            txtBurner.Text = "";
            txtSupplyType.Text="";
            txtPassword.Text = "";
            Key = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtArea.SelectedIndex == -1 || txtBurner.SelectedIndex == -1 || txtStoveType.SelectedIndex == -1 || txtSupplyType.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl(UserName,Address,MobileNo,Area,StoveType,Burner,SupplyType,Connection,Password)values(@UN,@UA,@UMN,@UAR,@US,@UB,@UST,@UC,@UP)", Con);
                    cmd.Parameters.AddWithValue("@UN", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@UA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@UMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@UAR", txtArea.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@US", txtStoveType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UB", txtBurner.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UST", txtSupplyType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UC", txtCD.Value.Date);
                    cmd.Parameters.AddWithValue("@UP", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfylly");
                    Con.Close();
                    ShowUser();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Key = 0;
        private void DSVUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserName.Text = DSVUsers.SelectedRows[0].Cells[1].Value.ToString();
            txtAddress.Text = DSVUsers.SelectedRows[0].Cells[2].Value.ToString();
            txtMobileNo.Text = DSVUsers.SelectedRows[0].Cells[3].Value.ToString();
            txtArea.SelectedItem = DSVUsers.SelectedRows[0].Cells[4].Value.ToString();
            txtStoveType.SelectedItem = DSVUsers.SelectedRows[0].Cells[5].Value.ToString();
            txtBurner.SelectedItem = DSVUsers.SelectedRows[0].Cells[6].Value.ToString();
            txtSupplyType.SelectedItem = DSVUsers.SelectedRows[0].Cells[7].Value.ToString();
            txtCD.Text = DSVUsers.SelectedRows[0].Cells[8].Value.ToString();
            txtPassword.Text = DSVUsers.SelectedRows[0].Cells[9].Value.ToString();
            if (txtUserName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DSVUsers.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the User");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from UserTbl where UserId=@Ukey", Con);
                    cmd.Parameters.AddWithValue("@Ukey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User deleted successfully");
                    Con.Close();
                    ShowUser();
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
            if (txtUserName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtArea.SelectedIndex==-1 || txtBurner.SelectedIndex==-1 || txtStoveType.SelectedIndex==-1 || txtSupplyType.SelectedIndex==-1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update UserTbl Set UserName=@UN,Address=@UA,MobileNo=@UMN,Area=@UAR,StoveType=@US,Burner=@UB,SupplyType=@UST,Connection=@UC,Password=@UP where UserID=@UKey", Con);
                    cmd.Parameters.AddWithValue("@UN", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@UA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@UMN", txtMobileNo.Text);
                    cmd.Parameters.AddWithValue("@UAR", txtArea.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@US", txtStoveType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UB", txtBurner.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UST", txtSupplyType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UC", txtCD.Value.Date);
                    cmd.Parameters.AddWithValue("@UP", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supplyer updated successfylly");
                    Con.Close();
                    ShowUser();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
