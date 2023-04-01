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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
            ShowBill();
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
        private void ShowBill()
        {
            Con.Open();
            string Query = "Select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DSVBill.DataSource = ds.Tables[0];
            Con.Close();
        }
        int key = 0;
        private void Reset()
        {
            txtUserName.Text = "";
            txtStoveType.Text = "";
            txtUserId.Text = "";
            txtPrice.Text = "";
            txtBurner.Text = "";
            key = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BillTbl(UserName,UserId,Type,Burner,Price)values(@UN,@UI,@T,@B,@P)", Con);
                    cmd.Parameters.AddWithValue("@UN", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@UI", txtUserId.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@P", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@T", txtStoveType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@B", txtBurner.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill added successfylly");
                    Con.Close();
                    ShowBill();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void txtUserId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }
        private void DSvSupplyList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserName.Text = DSVBill.SelectedRows[0].Cells[1].Value.ToString();
            txtUserId.SelectedItem = DSVBill.SelectedRows[0].Cells[2].Value.ToString();
            txtStoveType.SelectedItem = DSVBill.SelectedRows[0].Cells[3].Value.ToString();
            txtBurner.SelectedItem = DSVBill.SelectedRows[0].Cells[4].Value.ToString();
            txtPrice.Text = DSVBill.SelectedRows[0].Cells[5].Value.ToString();
            if (txtUserName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DSVBill.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        Bitmap bmp;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
