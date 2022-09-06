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
    public partial class shaqaale : Form
    {
        public shaqaale()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from StaffTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StaffDGV.DataSource = ds.Tables[0];

            con.Close();
        }

        private void staff_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void reset()
        {
            staffName.Text = "";
            StaffPhone.Text = "";
            Stpassword.Text = "";
            GenCb.SelectedIndex = -1;
            StaffAdd.Text = "";
            Key = 0;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (staffName.Text == "" || StaffPhone.Text == "" || StaffAdd.Text == "" || GenCb.SelectedIndex ==  -1 || StaffAdd.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into StaffTbl values ('" + staffName.Text + "','" + StaffPhone.Text + "','" + StaffAdd.Text + "','" + GenCb.SelectedItem.ToString() + "','" + StaffAdd.Text + "')";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Shaqaaluhu Wuu Save Garoobay");
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
        int Key = 0;
        private void StaffDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            staffName.Text = StaffDGV.SelectedRows[0].Cells[1].Value.ToString();
            StaffPhone.Text = StaffDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenCb.SelectedItem = StaffDGV.SelectedRows[0].Cells[3].Value.ToString();
            StaffAdd.Text = StaffDGV.SelectedRows[0].Cells[4].Value.ToString();
            Stpassword.Text = StaffDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (staffName.Text == "")
            {
                Key = 0;
            }
            else

            {
                Key = Convert.ToInt32(StaffDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            dashboard home = new dashboard();
            home.Show ();   
            this.Hide ();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Delete from  StaffTbl where stId=" + Key + ";";
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
            if (Key == 0)
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Delete from  user1 where Iduser=" + Key + ";";
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


        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (staffName.Text == "" || StaffPhone.Text == "" || Stpassword.Text == "" || GenCb.SelectedIndex == -1 || StaffAdd.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update  StaffTbl set stName= '" + staffName.Text + "',stAdd='" + Stpassword.Text + "',stsex='" + GenCb.SelectedItem.ToString() + "',stphone='" + StaffPhone.Text + "',stpassword='" + StaffAdd.Text + "' where stId=" + Key + ";";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Shaqaalaha Waxbaa Laga Bedelay Xogtiisa");
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
        private void SearchData()
        {
            con.Open();
            string Query = "select * from StaffTbl where stName like '%" + SearchTb + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StaffDGV.DataSource = ds.Tables[0];

            con.Close();
        }
        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
         SearchData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void StaffAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
