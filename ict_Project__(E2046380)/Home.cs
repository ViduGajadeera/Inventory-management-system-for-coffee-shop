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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void uSERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rEGISTRATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form staffReg = new Staff_Registration();
            staffReg.Show();
            

        }

        private void aDDITEMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addItem = new Add_item();
            addItem.Show();
        }

        private void oRDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addOrder = new Order_Management();
            addOrder.Show();
        }

        private void sUPPLIERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form supplier = new SupplierDetails_Management();
            supplier.Show();
        }

        private void aDDONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form suppliment = new suppliments();
            suppliment.Show();
        }
    }
}
