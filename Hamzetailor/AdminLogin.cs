using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamzetailor
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(PasswordTb.Text == "")
        {
                MessageBox.Show("Geli Admin Password ka");

        }
            else if(PasswordTb.Text == "12345")
            {
                dashboard main = new dashboard();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wuu Qaldan yahay Password kaagu");
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {
            dashboard obj = new dashboard();
            obj.Show();
            this.Hide();
        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
