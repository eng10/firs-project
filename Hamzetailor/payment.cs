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
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from payment ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomersDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void reset()
        {
            Ptybe.Text = "";
            Pblance.Text = "";
            Pdate.Text = "";
            Pmony.Text = "";
            key = 0;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void custPhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void payment_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" || Ptybe.Text == "" || Pdate.Text == ""|| Pblance .Text == "" || Pmony.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into payment values ('" + ID.Text + "','" + Ptybe.Text + "','" + Pblance.Text + "','" + Pdate.Text + "','" + Pmony.Text + "')";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show(" Kharashka waala  Keydiyey");
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
                    string query = "Delete from  payment where Idpy=" + key + ";";
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
        int key = 0;
        private void CustomersDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            ID.Text = CustomersDVG.SelectedRows[0].Cells[1].Value.ToString();
            Pmony.Text = CustomersDVG.SelectedRows[0].Cells[4].Value.ToString();
            Ptybe.Text = CustomersDVG.SelectedRows[0].Cells[1].Value.ToString();
            Pdate.Text = CustomersDVG.SelectedRows[0].Cells[3].Value.ToString();
            Pblance.Text = CustomersDVG.SelectedRows[0].Cells[2].Value.ToString();
            if (ID.Text == "")
            {
                key = 0;
            }
            else

            {
                key = Convert.ToInt32(CustomersDVG.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            mainform main = new mainform();
            main.Show();
            this.Hide();
        }
    }
}
