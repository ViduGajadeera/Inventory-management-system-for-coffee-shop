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

namespace ict_Project___E2046380_
{
    public partial class Order_Management : Form
    {
        SqlConnection con;
        ConnectionManager objcon = new ConnectionManager();
        
        public Order_Management()
        {
            InitializeComponent();

        }
        int orderNo=0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Order_Management_Load(object sender, EventArgs e)

        {
            
            cmbAddOn.Text = string.Empty;

            orderNo = orderNo + 1;
            txtOrderNo.Text = orderNo.ToString();


            con = ConnectionManager.GetConnection();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Add_Items ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd1.ExecuteNonQuery();
            con.Close();

            cmbProduct.DataSource = ds.Tables[0];
            cmbProduct.DisplayMember = "Item";
            cmbProduct.ValueMember = "";

            txtPrice.Text = "";
            cmbProduct.Text = string.Empty;


            con = ConnectionManager.GetConnection();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select SupplimentName from SupplimentTB ", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            cmd2.ExecuteNonQuery();
            con.Close();

            cmbAddOn.DataSource = ds1.Tables[0];
            cmbAddOn.DisplayMember = "SupplimentName";
            cmbAddOn.ValueMember = "";





        }



        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                orderNo = orderNo + 1;
                txtOrderNo.Text = orderNo.ToString();

                int total = 0, x;

                for (x = 0; x < dgvDisplay3.Rows.Count; ++x)
                {
                    total += Convert.ToInt32(dgvDisplay3.Rows[x].Cells[3].Value);
                }
                MessageBox.Show(total.ToString());

                dgvDisplay3.Rows.Clear();


            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            int grandTotal, qnt, price;
            price = Convert.ToInt32(txtPrice.Text);
            qnt = int.Parse(txtQuantity.Text);
            grandTotal = price * qnt;

            string product="";
            if(cmbProduct.SelectedIndex>=0 && cmbAddOn.SelectedIndex==0)
            {
                product = cmbProduct.Text;
            }
            else if(cmbAddOn.SelectedIndex>=0 && cmbProduct.SelectedIndex==0)
            {
                product = cmbAddOn.Text;
            }
            else
            {
                MessageBox.Show("Please select one product at a time !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDisplay3.Rows.Clear();
            }

            dgvDisplay3.Rows.Add(orderNo,product,txtQuantity.Text, grandTotal) ;
            txtQuantity.Text = "";
            cmbProduct.SelectedIndex = 0;
            cmbAddOn.Text = string.Empty;
            txtPrice.Text = "";

       

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (con = ConnectionManager.GetConnection())
                {
                    string orderItem = cmbProduct.GetItemText(cmbProduct.SelectedItem);

                    con.Open();
                    string query = "Select Price From Add_items where Item='" + orderItem + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                    {
                        txtPrice.Text =ds.Tables[0].Rows[i-1][0].ToString();
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDisplay3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index;
            //index = e.RowIndex;
            //DataGridViewRow row = dgvDisplay3.Rows[index];
            //txtOrderNo.Text = row.Cells[0].Value.ToString();
            //cmbProduct.Text = row.Cells[1].Value.ToString();
            //txtQuantity.Text = row.Cells[2].Value.ToString();
            //txtPrice.Text = row.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dgvDisplay3.Rows.RemoveAt(dgvDisplay3.SelectedRows[0].Index);
        }

        private void cmbAddOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (con = ConnectionManager.GetConnection())
                {
                    string addOn = cmbAddOn.GetItemText(cmbAddOn.SelectedItem);

                    con.Open();
                    string query = "Select PacketPrice From SupplimentTB where SupplimentName='" + addOn + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 1; i <= ds.Tables[0].Rows.Count; i++)
                    {
                        txtPrice.Text = ds.Tables[0].Rows[i - 1][0].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
