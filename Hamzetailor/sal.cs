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
    public partial class sal : Form
    {
        public sal()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from salar ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            storDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void reset()
        {
            Namest.Text = "";
            quantyCb.Text = "";
            typeCb.Text = "";
            key = 0;
        }

        private void store_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Namest.Text == "" || typeCb.Text == "" || quantyCb.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into salar values ('" + Namest.Text + "','" + typeCb.Text + "','" + quantyCb.Text + "')";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Alaabta waala illaaliyey");
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
        private void storDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Namest.Text = storDVG.SelectedRows[0].Cells[1].Value.ToString();
            quantyCb.Text = storDVG.SelectedRows[0].Cells[2].Value.ToString();
            typeCb.Text = storDVG.SelectedRows[0].Cells[3].Value.ToString();
            if (Namest.Text == "")
            {
                key = 0;
            }
            else

            {
                key = Convert.ToInt32(storDVG.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (Namest.Text == "" || quantyCb.Text == "" || typeCb.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update  salar set Sname= '" + Namest.Text + "',Sphone='" + typeCb.Text + "' ,Sempol= '" + quantyCb.Text + "' where Idsal=" + key + ";";
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
                    string query = "Delete from  salar where Idsal= " + key + ";";
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
            dashboard home = new dashboard();
            home.Show();
            Hide();
        }

        int key = 0;
        private void storDVG_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Namest.Text = storDVG.SelectedRows[0].Cells[1].Value.ToString();
            quantyCb.Text = storDVG.SelectedRows[0].Cells[2].Value.ToString();
            typeCb.Text = storDVG.SelectedRows[0].Cells[3].Value.ToString();
            if (Namest.Text == "")
            {
                key = 0;
            }
            else

            {
                key = Convert.ToInt32(storDVG.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
