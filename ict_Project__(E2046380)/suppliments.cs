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
    public partial class suppliments : Form
    {
        SqlConnection con;
        int index;
        public suppliments()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = ConnectionManager.GetConnection();
            con.Open();
            string query = "insert into SupplimentTB values ('" + txtCode.Text + "','" + txtSname.Text + "','" + txtPrice.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            MessageBox.Show("Suppliment Added !");
            cmd.ExecuteNonQuery();
            con.Close();
            txtCode.Text = "";
            txtSname.Text = "";
            txtPrice.Text = "";



            try
            {
                using (con = ConnectionManager.GetConnection())
                {
                    dgvDisplay2.Rows.Clear();
                    con.Open();
                    string query1 = "Select * From SupplimentTB";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query1.ToString(), con);
                    DataTable dtbl5 = new DataTable();
                    sqlDa.Fill(dtbl5);

                    for (int i = 2; i <= dtbl5.Rows.Count; i++)
                    {
                        dgvDisplay2.Rows.Add(dtbl5.Rows[i - 1][0].ToString(), dtbl5.Rows[i - 1][1].ToString(), dtbl5.Rows[i - 1][2].ToString());

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void suppliments_Load(object sender, EventArgs e)
        {
            try
            {
                using (con = ConnectionManager.GetConnection())
                {
                    dgvDisplay2.Rows.Clear();
                    con.Open();
                    string query1 = "Select * From SupplimentTB";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query1.ToString(), con);
                    DataTable dtbl5 = new DataTable();
                    sqlDa.Fill(dtbl5);

                    for (int i = 2; i <= dtbl5.Rows.Count; i++)
                    {
                        dgvDisplay2.Rows.Add(dtbl5.Rows[i - 1][0].ToString(), dtbl5.Rows[i - 1][1].ToString(), dtbl5.Rows[i - 1][2].ToString());

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            con = ConnectionManager.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from SupplimentTB where SupplimentCode='" + dgvDisplay2.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
            cmd.ExecuteNonQuery();
            dgvDisplay2.Rows.RemoveAt(dgvDisplay2.SelectedRows[0].Index);
            con.Close();

            MessageBox.Show("Item Deleted !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCode.Text = "";
            txtSname.Text = "";
            txtPrice.Text = "";
        }

        private void dgvDisplay2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dgvDisplay2.Rows[index];
            txtCode.Text = row.Cells[0].Value.ToString();
            txtSname.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[2].Value.ToString();
        }
    }
}
