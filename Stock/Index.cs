using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CategoryCatalogueUi().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ProductCatalogueUi().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CustomerPartyUi().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new SupplierPartyUi().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new PurchaseUi().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new SalesUi().Show();
        }
    }
}
