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
    public partial class CustomerPartyUi : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        Customer customer;
        public CustomerPartyUi()
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

            new SupplierPartyUi().Show();
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
            customer = new Customer();


            try
            {
                customer.LoyaltyPoint = Convert.ToInt32(loyaltyPointTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Loyalty Point");
                return;
            }
            
            if (isEmptyValidation(codeTextBox.Text) || isEmptyValidation(nameTextBox.Text) || isEmptyValidation(addressTextBox.Text) || isEmptyValidation(emailTextBox.Text)|| isEmptyValidation(contactTextBox.Text)|| isEmptyValidation(loyaltyPointTextBox.Text))
            {
                MessageBox.Show("Field Cannot be Empty");
                return;
            }
            customer.Name = nameTextBox.Text;
            customer.Code = codeTextBox.Text;
            if(_customerManager.CheckCode(customer))
            {
                MessageBox.Show("Code Exists!!");
                return;
            }
            customer.Email = emailTextBox.Text;
            if(!IsValidEmail(customer.Email))
            {
                MessageBox.Show("Email not valid!");
                return;
            }
            if (_customerManager.CheckEmail(customer))
            {
                MessageBox.Show("Email Exists!!");
                return;
            }
            customer.Contact = contactTextBox.Text;
            if (_customerManager.CheckContact(customer))
            {
                MessageBox.Show("Contact Exists!!");
                return;
            }
            customer.Address = addressTextBox.Text;
           
           
            


            if (_customerManager.Add(customer))
            {
                MessageBox.Show("Added Succesfully");
                showDataGridView.DataSource = _customerManager.Display();

            }
            else
            {
                MessageBox.Show("failed");
            }



        }

        private void contactTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerPartyUi_Load(object sender, EventArgs e)
        {
            loyaltyPointTextBox.Text = "0";
            loyaltyPointTextBox.Enabled = false;
            showDataGridView.DataSource = _customerManager.Display();
            codeTextBox.MaxLength = 4;
            contactTextBox.MaxLength = 11;
        }

        private void loyaltyPointTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loyaltyPointTextBox_Click(object sender, EventArgs e)
        {
            
        }

        private void loyaltyPointTextBox_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void loyaltyPointTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void loyaltyPointTextBox_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            loyaltyPointTextBox.Enabled = true;
            if(string.IsNullOrWhiteSpace(codeTextBox.Text))
            {
                loyaltyPointTextBox.Enabled = false;
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
                customer.ID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value);

                try
                {
                    Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["loyaltyPointDataGridViewTextBoxColumn"].Value);

                }
                catch
                {
                    MessageBox.Show("Invalid Input ");
                    return;
                }
                customer.LoyaltyPoint = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells["loyaltyPointDataGridViewTextBoxColumn"].Value);
                customer.Name = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value);
                customer.Code = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["codeDataGridViewTextBoxColumn"].Value);
                customer.Email = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["emailDataGridViewTextBoxColumn"].Value);
                customer.Contact = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["contactDataGridViewTextBoxColumn"].Value);
                customer.Address = Convert.ToString(showDataGridView.Rows[e.RowIndex].Cells["addressDataGridViewTextBoxColumn"].Value);
                if (_customerManager.Update(customer))
                {
                    MessageBox.Show("Updated");
                    showDataGridView.DataSource = _customerManager.Display();
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
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                showDataGridView.DataSource = _customerManager.Search(item);
            }
        }
    }
}
