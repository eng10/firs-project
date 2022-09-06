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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Alabta obj = new Alabta();
            this.Hide();
            obj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            macmiil obj = new macmiil();
            this.Hide();
            obj.Show();
        }

        private void EmpPicBox_Click(object sender, EventArgs e)
        {
            Dalabaad obj = new Dalabaad();
            this.Hide();
            obj.Show();
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            this.Hide();
            obj.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
