using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock.Model;
using Stock.BLL;

namespace Stock
{
    public partial class PurchaseUi : Form
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        Purchase purchase;
        Product product = new Product();
        BindingList<PurchasedProduct> tempList;
        int id;



        public PurchaseUi()
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
          
          new SalesUi().Show();

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


        private void submitButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(supplierComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a supplier");
                return;
            }
            if(isEmptyValidation(billNoTextBox.Text))
            {
                MessageBox.Show("Input a Bll number please");
                return;
            }
            purchase.Code = _purchaseManager.fetchPreviousCode();
            purchase.InvoiceNo = billNoTextBox.Text;
            purchase.Date = purchaseDateTimePicker.Value;
            purchase.SupplierID = Convert.ToInt32(supplierComboBox.SelectedValue);

            bool productAdded = false;
            if (_purchaseManager.PurchaseAdd(purchase))
            {
                
                foreach(var purchasedProduct in purchase.purchasedProducts)
                {
                    productAdded = false;
                    productAdded = _purchaseManager.ProductAdd(purchasedProduct);
                }

                if(productAdded)
                {
                    MessageBox.Show("Added");
                    purchase.purchasedProducts.Clear();
                    tempList.Clear();
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
                MessageBox.Show("Supplier not added");
            }
            
        }

        private void PurchaseUi_Load(object sender, EventArgs e)
        {
            supplierComboBox.DataSource = _purchaseManager.SupplierComboDisplay();
            categoryComboBox.DataSource = _purchaseManager.CategoryComboDisplay();
            showDataGridView.DataSource= tempList;
            codeTextBox.ReadOnly = true;
            availableQuantityextBox.ReadOnly = true;
            previousMRPTextBox.ReadOnly = true;
            previousMRPTextBox.ReadOnly = true;
            previousUnitTextBox.ReadOnly = true;
            totalTextBox.ReadOnly = true;
            MRPTextBox.ReadOnly = true;
        }

        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            product.ID = Convert.ToInt32(productComboBox.SelectedValue);
            codeTextBox.Text = _purchaseManager.fetchProductCode(product);
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            product.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            productComboBox.DataSource = _purchaseManager.ProductComboDisplay(product);

        }
        

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(purchase==null)
            {
                MessageBox.Show("Please select a supplier first");
                return;
            }
            if (Convert.ToInt32(supplierComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a supplier");
                return;
            }
            if (Convert.ToInt32(categoryComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a category");
                return;
            }

            if (Convert.ToInt32(productComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a product");
                return;
            }
            if (isEmptyValidation(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity field empty");
                return;
            }
            if (isEmptyValidation(unitTextBox.Text))
            {
                MessageBox.Show("Unit price field empty");
                return;
            }
            PurchasedProduct purchasedProduct = new PurchasedProduct();
            purchasedProduct.PurchaseCode = _purchaseManager.fetchPreviousCode();
            purchasedProduct.ProductCode = codeTextBox.Text;
            purchasedProduct.MfgDate = mfgDateTimePicker.Value;
            purchasedProduct.ExpDate = expDateTimePicker.Value;
           
            try
            {
                purchasedProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
                purchasedProduct.UnitPrice = Convert.ToDouble(unitTextBox.Text);
                purchasedProduct.TotalPrice = Convert.ToDouble(totalTextBox.Text);
                purchasedProduct.MRP = Convert.ToDouble(MRPTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }

            purchasedProduct.Remarks = remarksTextBox.Text;


            purchase.purchasedProducts.Add(purchasedProduct);
            tempList.Add(purchasedProduct);
            showDataGridView.DataSource = tempList;
        }

        private void unitTextBox_TextChanged(object sender, EventArgs e)
        {
            responsivePrice();
           
        }

        private void responsivePrice()
        {
            try
            {
                PurchasedProduct purchasedProduct = new PurchasedProduct();
                purchasedProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
                purchasedProduct.UnitPrice = Convert.ToDouble(unitTextBox.Text);
                totalTextBox.Text = Convert.ToString(purchasedProduct.UnitPrice * purchasedProduct.Quantity);
                MRPTextBox.Text = Convert.ToString((purchasedProduct.UnitPrice + (purchasedProduct.UnitPrice * 25 / 100)));

            }
            catch
            {
                if (string.IsNullOrEmpty(unitTextBox.Text) || string.IsNullOrEmpty(quantityTextBox.Text))
                {
                    totalTextBox.Text = null;
                    MRPTextBox.Text = null;
                }
            }
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            responsivePrice();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string item = searchTextBox.Text;
            if (string.IsNullOrWhiteSpace(item))
            {
                showDataGridView.DataSource = null;
            }
            else
            {
                showDataGridView.DataSource = _purchaseManager.SearchPurchasedProducts(item);
            }
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           


        }

        private void delete()
        {
          


            purchase.purchasedProducts.RemoveAt(id-1);
               tempList.RemoveAt(id-1);
                showDataGridView.DataSource = tempList;
        
            
        }


        private void edit()
        {

           
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells["SLNO"].Value = (e.RowIndex + 1).ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void supplierComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            purchase = new Purchase();
            tempList = new BindingList<PurchasedProduct>();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void showDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void showDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            if (e.RowIndex >= 0 && e.ColumnIndex == 11)
            {
                DataGridViewRow row = showDataGridView.Rows[e.RowIndex];
               

                PurchasedProduct purchasedproduct2 = new PurchasedProduct();

                int i = Convert.ToInt32(row.Cells[1].Value.ToString()) - 1;
                purchasedproduct2.ID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.ProductCode = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["productCodeDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.PurchaseCode = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["purchaseCodeDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.MfgDate = Convert.ToDateTime(showDataGridView.Rows[e.RowIndex].Cells["mfgDateDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.ExpDate = Convert.ToDateTime(showDataGridView.Rows[e.RowIndex].Cells["expDateDataGridViewTextBoxColumn1"].Value.ToString());

                purchasedproduct2.Quantity = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["quantityDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.UnitPrice = Convert.ToDouble(showDataGridView.Rows[e.RowIndex].Cells["unitPriceDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.TotalPrice = Convert.ToDouble(showDataGridView.Rows[e.RowIndex].Cells["totalPriceDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.MRP = Convert.ToDouble(showDataGridView.Rows[e.RowIndex].Cells["mRPDataGridViewTextBoxColumn1"].Value.ToString());
                purchasedproduct2.Remarks = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["remarksDataGridViewTextBoxColumn1"].Value.ToString());

                purchase.purchasedProducts[i] = purchasedproduct2;
                tempList[i] = purchasedproduct2;
                showDataGridView.DataSource = tempList;



                //PurchasedProduct purchasedProduct = new PurchasedProduct();

                //int i = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["SL"].Value) - 1;
                //purchasedProduct.ID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value);




                //purchasedProduct.PurchaseCode = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["purchaseCode"].Value);
                //purchasedProduct.ProductCode = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["productCode"].Value);
                //purchasedProduct.MfgDate = Convert.ToDateTime(showDataGridView.Rows[e.RowIndex].Cells["mfgDate"].Value);
                //purchasedProduct.ExpDate = Convert.ToDateTime(showDataGridView.Rows[e.RowIndex].Cells["expDate"].Value);
                //purchasedProduct.Quantity = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["quantity"].Value);
                //purchasedProduct.UnitPrice = Convert.ToDouble(showDataGridView.Rows[e.RowIndex].Cells["unitPrice"].Value);
                //purchasedProduct.TotalPrice = Convert.ToDouble(showDataGridView.Rows[e.RowIndex].Cells["totalPrice"].Value);
                //purchasedProduct.MRP = Convert.ToDouble(showDataGridView.Rows[e.RowIndex].Cells["mRP"].Value);
                //purchasedProduct.Remarks = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["remarks"].Value);

                //purchase.purchasedProducts[i] = purchasedProduct;
                //MessageBox.Show("Updated");
                //tempList[i] = purchasedProduct;
                //showDataGridView.DataSource = tempList;

            }

        }

        private void showDataGridView_MouseClick(object sender, MouseEventArgs e)
        {

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
    }
}
