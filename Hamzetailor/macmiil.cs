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

namespace Hamzetailor
{
    public partial class macmiil : Form
    {
        public macmiil()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate ()
        {
            con.Open ();
            string Query = "select * from customers ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con );
            SqlCommandBuilder builder = new SqlCommandBuilder( sda );
            var ds= new DataSet ();
            sda.Fill (ds);
            salDVG.DataSource=ds.Tables[0];

            con.Close ();
        }
        private void reset ()
        {
            custnameTb.Text = "";
            custPhoneTb.Text = "";
            CustAddTb.Text = "";
            custAge.Text = "";
            genCb.SelectedIndex = -1;
            key = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (custnameTb.Text ==""|| custAge.Text == "" || genCb.SelectedIndex == -1 || custPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
       else
            {
                try
                {
                      con.Open();
                    string query = "insert into customers values ('" + custnameTb.Text + "'," + custAge.Text + ",'" + genCb.SelectedItem.ToString() + "','" + custPhoneTb.Text + "','" + CustAddTb.Text + "')";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Macmiilku Wuu Save Garoobay");
                      con.Close();
                    reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void CustomersDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            custnameTb.Text = salDVG.SelectedRows[0].Cells[1].Value.ToString();
            custAge.Text = salDVG.SelectedRows[0].Cells[2].Value.ToString();
            genCb.SelectedItem = salDVG.SelectedRows[0].Cells[3].Value.ToString();
            custPhoneTb.Text = salDVG.SelectedRows[0].Cells[4].Value.ToString();
            CustAddTb.Text = salDVG.SelectedRows[0].Cells[5].Value.ToString();
            if (custnameTb.Text == "")
            {
                key = 0;
            }
            else

            {
                key = Convert.ToInt32(salDVG.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (custnameTb.Text == "" || custAge.Text == "" || genCb.SelectedIndex == -1 || custPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update  customers set cusName= '" + custnameTb.Text+"',cusAge='"+custAge.Text+"',cusGender='"+genCb.SelectedItem.ToString()+"',cusPhone='"+custPhoneTb.Text+"',cusAdd='"+CustAddTb.Text+"' where Idcus="+key+";";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Macmiilka Waxbaa Laga Bedelay Xogtiisa");
                    con.Close();
                    reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Delete from  customers where Idcus=" + key + ";";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show(" Xogtaadii Waala Tir-Tiray");
                    con.Close();
                    reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            mainform main = new mainform();
            main.Show();
            this.Hide();
        }
        private void SearchData()
        {
            con.Open();
            string Query = "select * from customers where cusName like '%" + SearchTb + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            salDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void searchTb_TextChanged(object sender, EventArgs e) 
        {
            SearchData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void macmiil_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
