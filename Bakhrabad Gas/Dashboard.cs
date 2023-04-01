using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakhrabad_Gas
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
