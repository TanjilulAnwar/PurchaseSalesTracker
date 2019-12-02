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
    public partial class ProductCatalogueUi : Form
    {
        ProductManager _productManager = new ProductManager();
        Product product;

        public ProductCatalogueUi()
        {
            InitializeComponent();
        }

        private bool isEmptyValidation(string item)
        {
            bool isEmpty = false;
            if(string.IsNullOrWhiteSpace(item))
            {
                isEmpty = true;

            }
            return isEmpty;
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
         
         new CustomerPartyUi().Show();
        }

        private void ProductCatalogueUi_Load(object sender, EventArgs e)
        {

            codeTextBox.MaxLength = 4;
            categoryComboBox.DataSource = _productManager.ComboDisplay();
            showDataGridView.DataSource = _productManager.Display();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            product = new Product();

            if (Convert.ToInt32(categoryComboBox.SelectedValue)==0)
            {
                MessageBox.Show("Please select a Category");
                return;
            }
            if(isEmptyValidation(codeTextBox.Text)||isEmptyValidation(nameTextBox.Text)||isEmptyValidation(reorderTextBox.Text)||isEmptyValidation(descriptionTextBox.Text))
            {
                    MessageBox.Show("Field Cannot be Empty");
                    return;
            }
            try
            {
                Convert.ToInt32(reorderTextBox.Text);
            }
            catch
            {
                MessageBox.Show("invalid input in Re-order field");
                return;
            }

            product.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            product.Code = codeTextBox.Text;
            if(_productManager.CheckCode(product))
            {
                MessageBox.Show("Code already exist");
                return;
            }
            product.Name = nameTextBox.Text;
            if (_productManager.CheckName(product))
            {
                MessageBox.Show("Name already exist");
                return;
            }
            product.ReOrderLevel = Convert.ToInt32(reorderTextBox.Text);
            product.Description = descriptionTextBox.Text;

            if(_productManager.Add(product))
            {
                MessageBox.Show("Product Inserted");
                categoryComboBox.SelectedValue = 0;
                codeTextBox.Clear();
                nameTextBox.Clear();
                reorderTextBox.Clear();
                descriptionTextBox.Clear();
                showDataGridView.DataSource = _productManager.Display();
            }
            else
            {
                MessageBox.Show("Failed to insert");
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 1).ToString();
        
          
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                product.ID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value);
               
                try
                {
                   Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["reOrderLevelDataGridViewTextBoxColumn"].Value);

                }
                catch
                {
                    MessageBox.Show("Invalid Input ");
                    return;
                }
                product.ReOrderLevel = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["reOrderLevelDataGridViewTextBoxColumn"].Value);
                product.Name = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value);
                product.Code = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["codeDataGridViewTextBoxColumn"].Value);

                product.Description = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["descriptionDataGridViewTextBoxColumn"].Value);
                if (_productManager.Update(product))
                {
                    MessageBox.Show("Updated");
                    showDataGridView.DataSource = _productManager.Display();
                }
                else
                {
                    MessageBox.Show("Update failed");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string item = searchTextBox.Text;
            if (string.IsNullOrWhiteSpace(item))
            {
                showDataGridView.DataSource = _productManager.Display();
            }
            else
            {
                showDataGridView.DataSource = _productManager.Search(item);
            }
        }
    }
}
