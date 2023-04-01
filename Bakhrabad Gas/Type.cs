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
using System.Data.SqlClient;


namespace Bakhrabad_Gas
{
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
            ShowType();
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
        private void ShowType()
        {
            Con.Open();
            string Query = "Select * from TypeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DSVType.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            txtArea.Text = "";
            txtStoveType.SelectedIndex = 0;
            txtBurner.Text = "";
            txtSupplyType.SelectedIndex = 0;
            Key = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtArea.Text == "" || txtStoveType.SelectedIndex == -1 || txtBurner.Text == "" || txtSupplyType.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TypeTbl(Area,StoveType,Burner,SupplyType)values(@AR,@S,@B,@ST)", Con);
                    cmd.Parameters.AddWithValue("@AR", txtArea.Text);
                    cmd.Parameters.AddWithValue("@S", txtStoveType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@B", txtBurner.Text);
                    cmd.Parameters.AddWithValue("@ST", txtSupplyType.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Type added successfylly");
                    Con.Close();
                    ShowType();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void DSVType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtArea.Text = DSVType.SelectedRows[0].Cells[1].Value.ToString();
            txtStoveType.SelectedItem =DSVType.SelectedRows[0].Cells[2].Value.ToString();
            txtBurner.Text = DSVType.SelectedRows[0].Cells[3].Value.ToString();
            txtSupplyType.SelectedItem = DSVType.SelectedRows[0].Cells[4].Value.ToString();
            if (txtArea.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DSVType.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select the Type");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from TypeTbl where TypeId=@Tkey", Con);
                    cmd.Parameters.AddWithValue("@Tkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Type deleted successfully");
                    Con.Close();
                    ShowType();
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
            if (txtArea.Text == "" || txtStoveType.SelectedIndex == -1 || txtBurner.Text == "" || txtSupplyType.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update TypeTbl Set Area=@AR,StoveType=@S,Burner=@B,SupplyType=@ST where TypeID=@TKey", Con);
                    cmd.Parameters.AddWithValue("@AR", txtArea.Text);
                    cmd.Parameters.AddWithValue("@S", txtStoveType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@B", txtBurner.Text);
                    cmd.Parameters.AddWithValue("@ST", txtSupplyType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Type updated successfylly");
                    Con.Close();
                    Show();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void txtSupplyType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtBurner_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtStoveType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
