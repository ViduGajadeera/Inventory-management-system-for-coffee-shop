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
    public partial class SupplierDetails_Management : Form
    {
        SqlConnection con;
        public SupplierDetails_Management()
        {
            InitializeComponent();
        }

        private void SupplierDetails_Management_Load(object sender, EventArgs e)
        {
            try
            {
                using (con = ConnectionManager.GetConnection())
                {
                    dgvSuppliers.Rows.Clear();
                    con.Open();
                    string query = "Select * From Supplier_Details";
                    SqlDataAdapter sqlData = new SqlDataAdapter(query.ToString(), con);
                    DataTable dtbl5 = new DataTable();
                    sqlData.Fill(dtbl5);

                    for (int i = 1; i <= dtbl5.Rows.Count; i++)
                    {
                        dgvSuppliers.Rows.Add(dtbl5.Rows[i - 1][0].ToString(), dtbl5.Rows[i - 1][1].ToString(), dtbl5.Rows[i - 1][2].ToString(), dtbl5.Rows[i - 1][3].ToString());


                    }


                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con = ConnectionManager.GetConnection();
                {
                    con.Open();
                    string query = "insert into Supplier_Details values ('" + txtID.Text + "','" + txtName.Text + "','" + txtContact.Text + "','" +txtCreditPeriod.Text +  "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    MessageBox.Show("New Supplier Added !!!");
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            using (con = ConnectionManager.GetConnection())
            {
                dgvSuppliers.Rows.Clear();
                con.Open();
                string query = "Select * From Supplier_Details";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query.ToString(), con);
                DataTable dtbl5 = new DataTable();
                sqlDa.Fill(dtbl5);

                for (int i = 1; i <= dtbl5.Rows.Count; i++)
                {
                    dgvSuppliers.Rows.Add(dtbl5.Rows[i - 1][0].ToString(), dtbl5.Rows[i - 1][1].ToString(), dtbl5.Rows[i - 1][2].ToString(), dtbl5.Rows[i - 1][3].ToString());


                }


            }
            txtID.Text = "";
            txtName.Text = "";
            txtCreditPeriod.Text = "";
            txtContact.Text = "";


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = ConnectionManager.GetConnection();
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete from Supplier_Details where Supplier_ID='" + dgvSuppliers.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                cmd.ExecuteNonQuery();
                dgvSuppliers.Rows.RemoveAt(dgvSuppliers.SelectedRows[0].Index);
                con.Close();

                txtContact.Text = "";
                txtCreditPeriod.Text = "";
                txtID.Text = "";
                txtName.Text = "";
                txtID.Focus();


                MessageBox.Show("Supplier Deleted !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    }
   

    
        

