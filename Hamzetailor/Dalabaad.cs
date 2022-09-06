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
    public partial class Dalabaad : Form
    {
        public Dalabaad()
        {
            InitializeComponent();
           
            populate();
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\School\Documents\hamza.mdf;Integrated Security=True;Connect Timeout=30");
        public void readPrevius()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Good  WHERE Gname= '" + BalanceTb.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtPrevoiusQty.Text = (dr["Gquantity"].ToString());
            }






            double prevQty, Qty, JustQuty;
            double.TryParse(txtPrevoiusQty.Text, out prevQty);
            double.TryParse(BalanceTb.Text, out Qty);


            JustQuty = prevQty - Qty;
            txtUpdatedQty.Text = JustQuty.ToString();

        }

        private void populate()
        {
            con.Open();
            string Query = "select * from Dalab";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OrdersDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void Heerka()
        {
            con.Open();
            string Query = "select * from Dalab where Status='"+FillterCb.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            OrdersDVG.DataSource = ds.Tables[0];

            con.Close();
        }
        private void reset()
        {
            Gname.SelectedIndex = -1;
            AmountTb.Text = "";
            BalanceTb.Text = "";
            StatusCb.SelectedIndex = -1;
            Key = 0;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (CustIdCb.SelectedIndex == -1 || Gname.SelectedIndex == -1 || StaffCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1 || AmountTb.Text == "" ||BalanceTb.Text=="")
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into Dalab values (" + CustIdCb.SelectedValue.ToString() + ",'" + Gname.SelectedValue.ToString() + "','" +RecDate.Value.Date + "','" + StaffCb.SelectedValue.ToString() + "'," + AmountTb.Text + ",'"+BalanceTb.Text+"','"+StatusCb.SelectedItem.ToString()+"')";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Alaabta Waa La save gareeyey");
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
        
        private void OrdersDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustIdCb.SelectedItem = OrdersDVG.SelectedRows[0].Cells[1].Value.ToString();
            Gname.SelectedValue = OrdersDVG.SelectedRows[0].Cells[2].Value.ToString();
            RecDate.Text = OrdersDVG.SelectedRows[0].Cells[3].Value.ToString();
            StaffCb.SelectedValue = OrdersDVG.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = OrdersDVG.SelectedRows[0].Cells[5].Value.ToString();
            BalanceTb.Text = OrdersDVG.SelectedRows[0].Cells[6].Value.ToString();
            StatusCb.SelectedItem = OrdersDVG.SelectedRows[0].Cells[7].Value.ToString();


            if (BalanceTb.Text == "")
            {
                Key = 0;
            }
            else

            {
                Key = Convert.ToInt32(OrdersDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            mainform main = new mainform();
            main.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

            if (Key == 0)
             {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    String Status = "Ladiray";
                    con.Open();
                    string query = "update  Dalab set Status= '" + Status + "' where OrdId =" + Key + ";";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Dalabaadka Waa La diray");
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

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Wax Xog ahi Kuma jirto Fadlan Xog ku shubo");
            }
            else
            {
                try
                {
                    String Status = "Laga Noqday";
                    con.Open();
                    string query = "update  Dalab set Status= '" + Status + "' where OrdId =" + Key + ";";
                    SqlCommand Cmd = new SqlCommand(query, con);
                    Cmd.ExecuteNonQuery();
                    MessageBox.Show("Dalabaadka Waa Laga Noqday");
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Heerka();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            populate();
        }

       
   

        private void Dalabaad_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StaffCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClothtybeCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BalanceTb_TextChanged(object sender, EventArgs e)
        {
            readPrevius();
        }
    }
} 