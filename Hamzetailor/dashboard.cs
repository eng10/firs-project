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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
           dashboard main = new dashboard();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            macmiil main = new macmiil();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Dalabaad main = new Dalabaad();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            payment main = new payment();
            main.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dashboard main = new dashboard();
            main.Show();
            this.Hide();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            payment main = new payment();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            purchase main = new purchase();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            sal main = new sal();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            shaqaale main = new shaqaale();
            main.Show();
            Hide();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            Alabta main = new Alabta();
            main.Show();
            Hide();
        }
    }
}
