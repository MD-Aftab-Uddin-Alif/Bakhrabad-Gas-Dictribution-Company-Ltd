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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            this.Hide();
            Obj.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtAdminPassword.Text=="")
            {

            }else if(txtAdminPassword.Text=="Admin")
            {
                Dashboard Obj = new Dashboard();
                this.Hide();
                Obj.Show();
            }else
            {
                MessageBox.Show("You have entered wrong Admin Password");
                txtAdminPassword.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
