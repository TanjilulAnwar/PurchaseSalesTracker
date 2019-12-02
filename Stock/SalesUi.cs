using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock.BLL;
using Stock.Model;
namespace Stock
{
    public partial class SalesUi : Form
    {
        SalesManager _salesManager = new SalesManager();
        Sales sales ;
        BindingList<SalesProduct> SalesProdList;
        Customer customer;
        int id ;
        public SalesUi()
        {
            InitializeComponent();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crossButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
         
          new PurchaseUi().Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void SalesUi_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _salesManager.CustomerComboDisplay();
            categoryComboBox.DataSource = _salesManager.CategoryComboDisplay();
            
            LoyaltytextBox.ReadOnly = true;
            availableQuantityTextBox.ReadOnly = true;
            grandtotalTextBox.ReadOnly = true;
            discountAmountTextBox.ReadOnly = true;
            discountTextBox.ReadOnly = true;
            payableAmounttextBox.ReadOnly = true;
            totalMRPTextBox.ReadOnly = true;
            
        }

        private void customerComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            customer = new Customer();
            sales = new Sales();
            sales.salesProducts = new List<SalesProduct>();
            SalesProdList = new BindingList<SalesProduct>();
            customer.ID = Convert.ToInt32(customerComboBox.SelectedValue);
            LoyaltytextBox.Text = Convert.ToString(_salesManager.FetchLoyaltyPoint(customer));
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(sales==null)
            {
                MessageBox.Show("Please select a customer");
                return;
            }
            if (Convert.ToInt32(customerComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a customer");
                return;
            }
            customer.ID = Convert.ToInt32(customerComboBox.SelectedValue);
            sales.Code = _salesManager.fetchPreviousCode();
            sales.CustomerCode = _salesManager.fetchCustomerCode(customer);
            sales.Date = salesDateTimePicker.Value;
            bool x = false;

            if (_salesManager.SalesAdd(sales))
            {
                MessageBox.Show("Added");

                foreach (var salesProduct in sales.salesProducts)
                {
                   
                    x = _salesManager.ProductAdd(salesProduct);

                }
                if (x)
                {
                    MessageBox.Show("Product Added");
                    sales.salesProducts.Clear();
                    SalesProdList.Clear();
                    showDataGridView.DataSource = null;
                    return;
                }
                else
                {
                    MessageBox.Show("Product Add failed");
                }
            }
            else
            {
                MessageBox.Show("Not Added");
            }

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            ProductComboBox.DataSource = _salesManager.ProductComboDisplay(product);
        }


        private bool isEmptyValidation(string item)
        {
            bool isEmpty = false;
            if (string.IsNullOrWhiteSpace(item))
            {
                isEmpty = true;

            }
            return isEmpty;
        }




        private void addButton_Click(object sender, EventArgs e)
        {
            if (sales == null)
            {
                MessageBox.Show("Please select a customer");
                return;
            }
            if (Convert.ToInt32(customerComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a customer");
                return;
            }


            if (Convert.ToInt32(categoryComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a category");
                return;
            }

            if (Convert.ToInt32(ProductComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a product");
                return;
            }
            if (isEmptyValidation(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity field empty");
                return;
            }
            if (isEmptyValidation(mrpTextBox.Text))
            {
                MessageBox.Show("Unit price field empty");
                return;
            }
            try
            {
                Convert.ToInt32(quantityNtextBox.Text);
                Convert.ToDouble(mrpTextBox.Text);
            }
            catch
            {
                MessageBox.Show("invalid input");
                return;
            }

            SalesProduct salesProduct = new SalesProduct();
            Product product = new Product();
            product.ID = Convert.ToInt32(ProductComboBox.SelectedValue);
            
            ////////////


            salesProduct.SalesCode = _salesManager.fetchPreviousCode();

            salesProduct.ProductName = this.ProductComboBox.GetItemText(this.ProductComboBox.SelectedItem);
           
            salesProduct.ProductCode = _salesManager.fetchProductCode(product);

            salesProduct.CustomerName =  this.customerComboBox.GetItemText(this.customerComboBox.SelectedItem);
            salesProduct.SalesDate = salesDateTimePicker.Value;

            salesProduct.Quantity = Convert.ToInt32(quantityNtextBox.Text);

            salesProduct.MRP = Convert.ToDouble(mrpTextBox.Text);
            salesProduct.TotalMRP = Convert.ToDouble(totalMRPTextBox.Text);



            ///////////
            sales.salesProducts.Add(salesProduct);
            SalesProdList.Add(salesProduct);

            showDataGridView.DataSource = SalesProdList;

            double grandtotal = 0;
            int loyalty = Convert.ToInt32(LoyaltytextBox.Text);
            double discount;
            /////
            foreach (var salesproduct in SalesProdList)
            {
                grandtotal += salesproduct.TotalMRP;
            }

            grandtotalTextBox.Text = Convert.ToString(grandtotal);
            discount = loyalty / 100;
            discountTextBox.Text = Convert.ToString(discount);
            //reset loyalty point//loyalty =loyalty-loyalty/10;

            double discountamount = grandtotal * discount / 100;
            double payableamount = grandtotal-discountamount;
            discountAmountTextBox.Text = Convert.ToString(discountamount);
            payableAmounttextBox.Text = Convert.ToString(payableamount);






        }


        private void responsivePrice()
        {
            try
            {
                SalesProduct salesProducts = new SalesProduct();

               salesProducts.Quantity = Convert.ToInt32(quantityNtextBox.Text);
               salesProducts.MRP = Convert.ToDouble(mrpTextBox.Text);
                totalMRPTextBox.Text = Convert.ToString(salesProducts.Quantity * salesProducts.MRP);
               

            }
            catch
            {
                if (string.IsNullOrEmpty(mrpTextBox.Text) || string.IsNullOrEmpty(quantityNtextBox.Text))
                {
                    totalMRPTextBox.Text = null;
                  
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            responsivePrice();
        }

        private void mrpTextBox_TextChanged(object sender, EventArgs e)
        {
            responsivePrice();
        }


        private void delete()
        {



            sales.salesProducts.RemoveAt(id - 1);
            SalesProdList.RemoveAt(id - 1);
            showDataGridView.DataSource = SalesProdList;


        }

        private void showDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete entry?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                delete();
            }
            else if (dr == DialogResult.No)
            {
                //Nothing to do
            }
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
