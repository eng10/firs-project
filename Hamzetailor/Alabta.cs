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
    public partial class Alabta : Form
    {
        public Alabta()
        {
            InitializeComponent();
            populate();
        }

        private void UpdateGoods()
        {
            throw new NotImplementedException();
        }
        

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            con.Open();
            string Query = "select * from Good ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            GDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void reset()
        {
            id.Text = "";
            Gname.Text = "";
            Gquant.Text = "";
            GtybeCb.Text = "";
            Gprice.Text = "";
            Gcom.Text = "";
            GAdd.Text = "";
            Key = 0;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Alabta_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || Gname.Text == "" || GtybeCb.SelectedIndex == -1 || GAdd.Text == "" || Gcom.Text == "" || Gquant.Text == "" || Gprice.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into Good values ('" + id.Text + "','" + Gname.Text + "','" + GtybeCb.SelectedItem.ToString() + "','" + GAdd.Text + "','" + Gcom.Text + "','" + Gquant.Text + "','" + Gprice.Text + "')";
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

        private void ShowData_Bought()
        {
            throw new NotImplementedException();
        }

        int Key = 0;

        public object BalanceTb { get; private set; }

        private void GDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {

            id.Text = GDVG.SelectedRows[0].Cells[1].Value.ToString();
            Gname.Text = GDVG.SelectedRows[0].Cells[1].Value.ToString();
            GtybeCb.SelectedItem = GDVG.SelectedRows[0].Cells[2].Value.ToString();
            GAdd.Text = GDVG.SelectedRows[0].Cells[3].Value.ToString();
            Gcom.Text = GDVG.SelectedRows[0].Cells[4].Value.ToString();
            Gquant.Text = GDVG.SelectedRows[0].Cells[5].Value.ToString();
            Gprice.Text = GDVG.SelectedRows[0].Cells[6].Value.ToString();

            if (Gname.Text == "")
            {
                Key = 0;
            }
            else

            {
                Key = Convert.ToInt32(GDVG.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || Gname.Text == "" || GtybeCb.SelectedIndex == -1 || GAdd.Text == "" || Gcom.Text == "" || Gquant.Text == "" || Gprice.Text == "")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update  Good set Idgoods= '" + id.Text + "'Gname= '" + Gname.Text + "',Gtybe='" + GtybeCb.SelectedIndex.ToString() + "' ,Gadd= '" + GAdd.Text + "',Gcom= '" + Gcom.Text + "',Gquantity= '" + Gquant.Text + "',Gprice= '" + Gprice.Text + "' where Idgoods=" + Key + ";";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Alaabta Waxbaa Laga Bedelay Xogteeda");
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
            if (Key == 0)
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Delete from  Good where Idgoods= " + Key + ";";
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

        private void Gname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUpdatedQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void Gquant_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
