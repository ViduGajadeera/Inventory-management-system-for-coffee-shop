using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ict_Project___E2046380_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value <= 5)

            {
                lblLoad.Text = "The coffee shop.....";

            }
            else if (progressBar1.Value <= 10)
            {
                lblLoad.Text = "Please wait.....";
            }
            else if (progressBar1.Value <= 20)
            {
                lblLoad.Text = "Welcome to the system.....";
            }
            else if (progressBar1.Value <= 25)
            {
                lblLoad.Text = "Please wait.....";
            }
            else if (progressBar1.Value <= 35)
            {
                lblLoad.Text = "The coffee shop.....";
            }
            else if (progressBar1.Value <= 50)
            {
                lblLoad.Text = "Welcome to the system.....";
            }
            else if (progressBar1.Value <= 70)
            {
                lblLoad.Text = "The coffee shop.....";
            }

            else if (progressBar1.Value <= 90)
            {
                lblLoad.Text = "Please wait.....";
            }

            else if (progressBar1.Value <= 99)
            {
                lblLoad.Text = "Welcome to the system.....";
            }
            progressBar1.Value = progressBar1.Value + 2;


            if (progressBar1.Value >= 100)
            {
                timer1.Enabled = false;
                Form login = new LogIn();
                login.Show();
                this.Hide();
            }
        }
    }
}
