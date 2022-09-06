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
    public partial class purchase : Form
    {
        public purchase()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from iib";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void reset()
        {
            custname.Text = "";
            Pprice.Text = "";
            Ptybe.Text = "";
            PAdd.Text = "";
        }
        int key = 0;
        private void CustomersDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            custname.Text = PDVG.SelectedRows[0].Cells[1].Value.ToString();
            PAdd.Text = PDVG.SelectedRows[0].Cells[2].Value.ToString();
            Pprice.Text = PDVG.SelectedRows[0].Cells[3].Value.ToString();
            Ptybe.Text = PDVG.SelectedRows[0].Cells[4].Value.ToString();
            if (custname.Text == "")
            {
                key = 0;
            }
            else

            {
                key = Convert.ToInt32(PDVG.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (custname.Text == "" || Pprice.Text == "" ||  Ptybe.Text == "" || PAdd.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into iib values ('" + custname.Text + "'," + PAdd.Text + ",'"  + Pprice.Text + "','" + Ptybe.Text + "')";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show(" Waala Save gareeyey");
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
            if (custname.Text == "" || PAdd.Text == "" || Pprice.Text == "" || Ptybe.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update  iib set PName= '" + custname.Text + "',PAdd='" + PAdd.Text + "',Pprice='" + Pprice.Text + "',Ptybe='" + Ptybe.Text +  "' where PId=" + key + ";";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show(" Waxbaa Laga Bedelay Xogta");
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
                    string query = "Delete from  iib where PId=" + key + ";";
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
            dashboard main = new dashboard();
            main.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate(); 
        }

        private void purchase_Load(object sender, EventArgs e)
        {

        }
    }
}
