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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        
        }
        SqlConnection con;
        string admin, cashier;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                admin = radioAdmin.Text;
                cashier = radioCashier.Text;
                con = ConnectionManager.GetConnection();
                if (radioAdmin.Checked)
                {

                    string query1 = ("Select count (*) from Staff_Registration where Username='" + txtUserId.Text + "'and Password='" + txtPassword.Text + "'and Employee_type='" + radioAdmin.Text + "'");
                    SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows[0][0].ToString() == "1")
                    {
                        Form home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    if (txtPassword.Text == "" && txtUserId.Text == "")
                    {
                        MessageBox.Show("Please enter Username and Password !!!");
                    }
                    else if (txtUserId.Text == "")
                    {
                        MessageBox.Show("Please input a valid Username !!!");
                    }
                    else if (txtPassword.Text == "")
                    {
                        MessageBox.Show("Please input a password !!!");
                    }
                    else if (dtbl.Rows[0][0].ToString() != "1")
                    {
                        MessageBox.Show("Username or password is incorrect !!!");
                    }

                }
                else if (radioCashier.Checked)
                {
                    string query2 = ("Select count (*) from Staff_Registration where Username='" + txtUserId.Text + "'and Password='" + txtPassword.Text + "'and Employee_type='" + radioCashier.Text + "'");
                    SqlDataAdapter sda = new SqlDataAdapter(query2, con);
                    DataTable dtbl1 = new DataTable();
                    sda.Fill(dtbl1);
                    if (dtbl1.Rows[0][0].ToString() == "1")
                    {
                        Form cashier_login = new Order_Management();
                        cashier_login.Show();
                        this.Hide();
                    }
                    if (txtPassword.Text == "" && txtUserId.Text == "")
                    {
                        MessageBox.Show("Please enter Username and Password !!!");
                    }
                    else if (txtUserId.Text == "")
                    {
                        MessageBox.Show("Please input a valid Username !!!");
                    }
                    else if (txtPassword.Text == "")
                    {
                        MessageBox.Show("Please input a password !!!");
                    }
                    else if (dtbl1.Rows[0][0].ToString() != "1")
                    {
                        MessageBox.Show("Plase input the correct employee type !");
                    }

                }
                else
                {
                    MessageBox.Show("Plase input the correct employee type !");
                }


                txtUserId.Text = "";
                txtPassword.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
