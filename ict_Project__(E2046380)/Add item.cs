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
    public partial class Add_item : Form
    {
        SqlConnection con;
        ConnectionManager objcon = new ConnectionManager();
        int index;
        public Add_item()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = ConnectionManager.GetConnection();
            con.Open();
            string query = "insert into Add_items values ('"+txtCode.Text+"','" + txtName.Text + "','" + txtPrice.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            MessageBox.Show("Item Added !");
            cmd.ExecuteNonQuery();
            con.Close();

            txtName.Text = "";
            txtPrice.Text = "";
            //cmbCategory.Text = "";
            txtCode.Text = "";


            try
            {
                using (con = ConnectionManager.GetConnection())
                {
                    dgvDisplay.Rows.Clear();
                    con.Open();
                    string query1 = "Select * From Add_items";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query1.ToString(), con);
                    DataTable dtbl3 = new DataTable();
                    sqlDa.Fill(dtbl3);

                    for (int i = 2; i <= dtbl3.Rows.Count; i++)
                    {
                        dgvDisplay.Rows.Add(dtbl3.Rows[i - 1][0].ToString(), dtbl3.Rows[i - 1][1].ToString(), dtbl3.Rows[i - 1][2].ToString());

                        if (i == dtbl3.Rows.Count)
                        {
                            MessageBox.Show("Item table is updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow newData = dgvDisplay.Rows[index];
            newData.Cells[0].Value = txtCode.Text;
            newData.Cells[1].Value = txtName.Text;
            newData.Cells[2].Value = txtPrice.Text;
            
            txtName.Text = "";
            txtPrice.Text = "";
           // cmbCategory.Text = "";

        }

      

        private void btnDelete_Click(object sender, EventArgs e)
        {

            con = ConnectionManager.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from Add_items where Item_Code='" + dgvDisplay.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
            cmd.ExecuteNonQuery();
            dgvDisplay.Rows.RemoveAt(dgvDisplay.SelectedRows[0].Index);
            con.Close();

            MessageBox.Show("Item Deleted !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
         
        }

        private void dgvDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dgvDisplay.Rows[index];
            txtCode.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[2].Value.ToString();
        }

        private void Add_item_Load(object sender, EventArgs e)
        {
            try
            {
                using (con = ConnectionManager.GetConnection())
                {
                    dgvDisplay.Rows.Clear();
                    con.Open();
                    string query = "Select * From Add_items";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query.ToString(), con);
                    DataTable dtbl3 = new DataTable();
                    sqlDa.Fill(dtbl3);

                    for (int i = 2; i <= dtbl3.Rows.Count; i++)
                    {
                        dgvDisplay.Rows.Add(dtbl3.Rows[i - 1][0].ToString(), dtbl3.Rows[i - 1][1].ToString(), dtbl3.Rows[i - 1][2].ToString());

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
