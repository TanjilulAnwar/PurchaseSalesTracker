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
    public partial class CategoryCatalogueUi : Form
    {
        CategoryManager _categoryManager = new CategoryManager();

        Category category ;

        public CategoryCatalogueUi()
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

        private void CategoryCatalogueUi_Load(object sender, EventArgs e)
        {
            codeTextBox.MaxLength = 4;

            showDataGridView.DataSource = _categoryManager.Display();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
         
           new ProductCatalogueUi().Show();
            

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            category = new Category();

            if (string.IsNullOrWhiteSpace(codeTextBox.Text)||string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Field empty!");
                return;
            }
            category.Code = codeTextBox.Text;
            if (_categoryManager.CheckCode(category))
            {
                MessageBox.Show("Code Already Exist!");
                return;
            }
            category.Name = nameTextBox.Text;
            if (_categoryManager.CheckName(category))
            {
                MessageBox.Show("Name Already Exist!");
                return;
            }
            if (_categoryManager.Add(category))
            {
                MessageBox.Show("Inserted");
                codeTextBox.Clear();
                nameTextBox.Clear();
                showDataGridView.DataSource = _categoryManager.Display();
            }
            else
            {
                MessageBox.Show("Failed to Insert");
            }
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 1).ToString();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                category.Name = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value);
                category.Code = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["codeDataGridViewTextBoxColumn"].Value);
                category.ID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value);

               if(_categoryManager.Update(category))
                {
                    MessageBox.Show("Updated");
                    showDataGridView.DataSource = _categoryManager.Display();
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
                showDataGridView.DataSource = _categoryManager.Display();
            }
            else
            {
                showDataGridView.DataSource = _categoryManager.Search(item);
            }
        }
    }
}
