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
    public partial class Staff_Registration : Form
    {
        SqlConnection con;
        public Staff_Registration()
        {
            InitializeComponent();
        }
       
        string gender;

        private void Staff_Registration_Load(object sender, EventArgs e)
        {
            using (con = ConnectionManager.GetConnection())
            {
                dgvEmp.Rows.Clear();
                con.Open();
                string query = "Select * From Staff_Registration";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query.ToString(), con);
                DataTable dtbl4 = new DataTable();
                sqlDa.Fill(dtbl4);

                for (int i = 1; i <= dtbl4.Rows.Count; i++)
                {
                    dgvEmp.Rows.Add(dtbl4.Rows[i - 1][0].ToString(), dtbl4.Rows[i - 1][1].ToString(), dtbl4.Rows[i - 1][2].ToString(), dtbl4.Rows[i - 1][3].ToString(), dtbl4.Rows[i - 1][4].ToString(), dtbl4.Rows[i - 1][5].ToString(), dtbl4.Rows[i - 1][6].ToString(), dtbl4.Rows[i - 1][7].ToString(), dtbl4.Rows[i - 1][8].ToString(), dtbl4.Rows[i - 1][9].ToString(), dtbl4.Rows[i - 1][10].ToString());


                }


            }
            //if (cmbEmpType.SelectedIndex == 1 || cmbEmpType.SelectedIndex == 2)
            //{
            //    groupBox1.Enabled = true;
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (radioFemale.Checked)
            {
                gender = "Female";
            }
            else if (radioMale.Checked)
            {
                gender = "Male";
            }
            try
            {

                con = ConnectionManager.GetConnection();

                {

                    con.Open();
                    string query = "insert into Staff_Registration values ('" + txtEmpID.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtAddress.Text + "','" + this.dtpDOB.Text + "','" + gender + "','" + txtNIC.Text + "','" + txtUserName.Text + "','" + txtEMPpassword.Text + "','" + cmbEmpType.Text + "','" + this.dtpJoinedDate.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    MessageBox.Show("New Admin Added !!!");
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtEmpID.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtAddress.Text = "";
                    //txtAge.Text = "";
                    txtNIC.Text = "";
                    txtUserName.Text = "";
                    txtEMPpassword.Text = "";
                    //cmbEmpType.SelectedIndex = 0;
                    txtEmpID.Focus();


                    try
                    {
                        using (con = ConnectionManager.GetConnection())
                        {
                            dgvEmp.Rows.Clear();
                            con.Open();
                            string query2 = "Select * From Staff_Registration";
                            SqlDataAdapter sqlDa = new SqlDataAdapter(query2.ToString(), con);
                            DataTable dtbl4 = new DataTable();
                            sqlDa.Fill(dtbl4);

                            for (int i = 1; i <= dtbl4.Rows.Count; i++)
                            {
                                dgvEmp.Rows.Add(dtbl4.Rows[i - 1][0].ToString(), dtbl4.Rows[i - 1][1].ToString(), dtbl4.Rows[i - 1][2].ToString(), dtbl4.Rows[i - 1][3].ToString(), dtbl4.Rows[i - 1][4].ToString(), dtbl4.Rows[i - 1][5].ToString(), dtbl4.Rows[i - 1][6].ToString(), dtbl4.Rows[i - 1][7].ToString(), dtbl4.Rows[i - 1][8].ToString(), dtbl4.Rows[i - 1][9].ToString(), dtbl4.Rows[i - 1][10].ToString());

                                if (i == dtbl4.Rows.Count)
                                {
                                    MessageBox.Show("updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            con = ConnectionManager.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from Staff_Registration where Employee_ID='" + dgvEmp.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
            cmd.ExecuteNonQuery();
            dgvEmp.Rows.RemoveAt(dgvEmp.SelectedRows[0].Index);
            con.Close();

            MessageBox.Show("Employee Deleted !!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
