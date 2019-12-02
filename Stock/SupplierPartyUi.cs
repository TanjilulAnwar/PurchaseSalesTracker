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
    public partial class SupplierPartyUi : Form
    {

        SupplierManager _supplierManager = new SupplierManager();
        Supplier supplier = new Supplier();

        public SupplierPartyUi()
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

        private void SupplierPartyUi_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _supplierManager.Display();
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

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            
            if (isEmptyValidation(codeTextBox.Text) || isEmptyValidation(nameTextBox.Text) || isEmptyValidation(addressTextBox.Text) || isEmptyValidation(emailTextBox.Text) || isEmptyValidation(contactTextBox.Text) || isEmptyValidation(contactPersonTextBox.Text))
            {
                MessageBox.Show("Field Cannot be Empty");
                return;
            }
            supplier.Name = nameTextBox.Text;
            supplier.Code = codeTextBox.Text;
            if (_supplierManager.CheckCode(supplier))
            {
                MessageBox.Show("Code Exists!!");
                return;
            }
           supplier.Email = emailTextBox.Text;
            if (!IsValidEmail(supplier.Email))
            {
                MessageBox.Show("Email not valid!");
                return;
            }
            if (_supplierManager.CheckEmail(supplier))
            {
                MessageBox.Show("Email Exists!!");
                return;
            }
            supplier.Contact = contactTextBox.Text;
            if (_supplierManager.CheckContact(supplier))
            {
                MessageBox.Show("Contact Exists!!");
                return;
            }
            supplier.Address = addressTextBox.Text;

            supplier.ContactPerson = contactPersonTextBox.Text;
            if (_supplierManager.Add(supplier))
            {
                MessageBox.Show("Added Succesfully");
                showDataGridView.DataSource = _supplierManager.Display();
            }
            else
            {
                MessageBox.Show("failed");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string item = searchtextBox.Text;
            if (string.IsNullOrWhiteSpace(item))
            {
                showDataGridView.DataSource = _supplierManager.Display();
            }
            else
            {
                showDataGridView.DataSource = _supplierManager.Search(item);
            }
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 1).ToString();
        }

        private void showDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8/*Column number that the edit button is given */ && e.RowIndex >= 0)
            {
                supplier.ID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value);

            
                supplier.ContactPerson = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["contactPersonDataGridViewTextBoxColumn"].Value);
                supplier.Name = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value);
                supplier.Code = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["codeDataGridViewTextBoxColumn"].Value);
                supplier.Email = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["emailDataGridViewTextBoxColumn"].Value);
               supplier.Contact = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["contactDataGridViewTextBoxColumn"].Value);
                supplier.Address = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["addressDataGridViewTextBoxColumn"].Value);
                if (_supplierManager.Update(supplier))
                {
                    MessageBox.Show("Updated");
                    showDataGridView.DataSource = _supplierManager.Display();
                }
                else
                {
                    MessageBox.Show("Update failed");
                }
            }
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
