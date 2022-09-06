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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
          
            FillstId();
            populate();
            FillstName();
            fillstpassword();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillstId()

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select stId From StaffTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("stId", typeof(int));
            dt.Load(rdr);
            stId.ValueMember = "stId";
            stId.DataSource = dt;

            con.Close();

        }
        private void FillstName()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select stName From StaffTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("stName", typeof(string));
            dt.Load(rdr);
            Uname.ValueMember = "stName";
            Uname.DataSource = dt;
            con.Close();
        }
        private void fillstpassword()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select stpassword From StaffTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("stpassword", typeof(string));
            dt.Load(rdr);
            upassword.ValueMember = "stpassword";
            upassword.DataSource = dt;
            con.Close();
        }

        private void populate()
        {
            con.Open();
            string Query = "select * from user1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UDGV.DataSource = ds.Tables[0];

            con.Close();
        }
        private void reset()
        {
           Key = 0;
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {

           
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
        int Key=0;
        private void UDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (stId.SelectedIndex == -1 || upassword.SelectedIndex == -1 || Uname.SelectedIndex == -1 )
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into user1 values ('" + stId.SelectedValue.ToString() + "','" + upassword.SelectedValue.ToString() + "','" + Uname.SelectedValue.ToString() + "')";
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

        private void Upasswprd_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
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
                    string query = "  delete from user1 =  where stId = " + Key + ";";
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
    }
}
