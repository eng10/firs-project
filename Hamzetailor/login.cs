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

namespace Hamzetailor
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text==""|| PasswordTb.Text=="")
            {
                MessageBox.Show("Geli Username kaaga iyo Password Kaaga");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count (*) from user1 where Uname='" + UnameTb.Text + "' and Upassword='" + PasswordTb.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                   mainform obj = new mainform();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Uu KHaldan yahay Username kagu Ama Password kagu");

                }
                con.Close();
            }
           

            



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
