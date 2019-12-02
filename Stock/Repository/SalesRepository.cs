using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Stock.Model;

namespace Stock.Repository
{
    class SalesRepository
    {

        public bool SalesAdd(Sales sales)
        {
            bool isAdded = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Insert Into Sales(CustomerCode,Code,Date) Values ('{sales.CustomerCode}','{sales.Code}','{sales.Date}')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //Close
                sqlConnection.Close();


            }
            catch
            {
                isAdded = false;
            }

            return isAdded;
        }

        public List<Customer> CustomerComboDisplay()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"Select * from Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            Customer select = new Customer();
            select.Name = "<--Select Customer-->";
            select.ID = 0;
            customers.Add(select);
            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();


                customer.ID = Convert.ToInt32(sqlDataReader["ID"]);

                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Email = sqlDataReader["Email"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.LoyaltyPoint = Convert.ToInt32(sqlDataReader["LoyaltyPoint"]);

                customers.Add(customer);


            }
            //Close
            sqlConnection.Close();
            return customers;



        }

        public string fetchPreviousCode()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"SELECT TOP 1 * FROM Sales ORDER BY ID DESC ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Sales sales = new Sales();


            while (sqlDataReader.Read())
            {
                sales.Code = sqlDataReader["Code"].ToString();

            }
            //Close
            sqlConnection.Close();
            if (sales.Code == null)
            {
                sales.Code = "2019-0001";
               
            }
            else
            {
                string sub = sales.Code.Substring(5, 4);
                int c = Convert.ToInt32(sub);
                c++;
                string s = c.ToString("0000");
                sales.Code = "2019-" + s;
               

            }

            return sales.Code;
        }

        public string fetchCustomerCode(Customer customer)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"SELECT * FROM Customers where ID ={customer.ID}";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            Customer customer2 = new Customer();

            while (sqlDataReader.Read())
            {
                customer2.Code = sqlDataReader["Code"].ToString();

            }
            //Close
            sqlConnection.Close();
           

            return customer2.Code;
        }





        public int FetchLoyaltyPoint(Customer customer)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"Select * from Customers where ID ={customer.ID}";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int loyalty=0;
            while (sqlDataReader.Read())
            {
                Customer customer2 = new Customer();


              
                customer2.LoyaltyPoint = Convert.ToInt32(sqlDataReader["LoyaltyPoint"]);

                loyalty = customer2.LoyaltyPoint;

            }
            //Close
            sqlConnection.Close();

            return loyalty;



        }


        public List<Category> CategoryComboDisplay()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = @"select * from Categories";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Category> categories = new List<Category>();

            Category select = new Category();
            select.Name = "<--Select Category-->";
            select.ID = 0;
            categories.Add(select);
            while (sqlDataReader.Read())
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(sqlDataReader["ID"]);
                category.Code = sqlDataReader["Code"].ToString();
                category.Name = sqlDataReader["Name"].ToString();
                categories.Add(category);

            }
            //Close
            sqlConnection.Close();

            return categories;



        }

        public List<Product> ProductComboDisplay(Product product)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"select * from Products where CategoryID= {product.CategoryID}";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Product> products = new List<Product>();

            Product select = new Product();
            select.Name = "<--Select Product-->";
            select.ID = 0;
            products.Add(select);
            while (sqlDataReader.Read())
            {
                Product product2 = new Product();
                product2.ID = Convert.ToInt32(sqlDataReader["ID"]);
                product2.Code = sqlDataReader["Code"].ToString();
                product2.Name = sqlDataReader["Name"].ToString();
                products.Add(product2);

            }
            //Close
            sqlConnection.Close();

            return products;



        }


        public bool ProductAdd(SalesProduct salesProduct)
        {
            bool isAdded = true;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Insert Into SalesProducts(SalesCode,ProductName,ProductCode,CustomerName,SalesDate,Quantity,MRP,TotalMRP) Values ('{salesProduct.SalesCode}','{salesProduct.ProductName}','{salesProduct.ProductCode}','{salesProduct.CustomerName}','{salesProduct.SalesDate}',{salesProduct.Quantity},{salesProduct.MRP},{salesProduct.TotalMRP})";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //Close
                sqlConnection.Close();


            }
            catch
            {
                isAdded = false;
            }

            return isAdded;
        }



        public string fetchProductCode(Product product)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"SELECT * FROM Products where ID= {product.ID}";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            Product product2 = new Product();

            while (sqlDataReader.Read())
            {

                product2.Code = sqlDataReader["Code"].ToString();

            }
            //Close
            sqlConnection.Close();

            return product2.Code;
        }

    }
}
