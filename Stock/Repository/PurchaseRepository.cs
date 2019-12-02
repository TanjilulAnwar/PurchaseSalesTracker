using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Stock.Model;

namespace Stock.Repository
{
    class PurchaseRepository
    {

            public bool PurchaseAdd(Purchase purchase)
            {
                bool isAdded = false;
                try
                {
                    //Connection
                    SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                    //Command 
                    string commandString = $"Insert Into Purchase(Date,Code,InvoiceNo,SupplierID) Values ('{purchase.Date}','{purchase.Code}','{purchase.InvoiceNo}',{purchase.SupplierID})";
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

        public bool ProductAdd(PurchasedProduct purchasedProduct)
        {
            bool isAdded = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Insert Into PurchasedProducts(PurchaseCode,ProductCode,MfgDate,ExpDate,Quantity,UnitPrice,TotalPrice,MRP,Remarks) Values ('{purchasedProduct.PurchaseCode}','{purchasedProduct.ProductCode}','{purchasedProduct.MfgDate}','{purchasedProduct.ExpDate}',{purchasedProduct.Quantity},{purchasedProduct.UnitPrice},{purchasedProduct.TotalPrice},{purchasedProduct.MRP},'{purchasedProduct.Remarks}')";
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







        public string fetchPreviousCode()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"SELECT TOP 1 * FROM Purchase ORDER BY ID DESC ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Purchase purchase = new Purchase();


            while (sqlDataReader.Read())
            {
               purchase.Code = sqlDataReader["Code"].ToString();
               
            }
            //Close
            sqlConnection.Close();
            if (purchase.Code == null)
            {
                purchase.Code = "2019-0001";
               
            }
            else
            {
                string sub = purchase.Code.Substring(5, 4);
                int c = Convert.ToInt32(sub);
                c++;
                string s = c.ToString("0000");
                purchase.Code = "2019-" + s;
               

            }



            return purchase.Code;
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


        public List<Supplier> SupplierComboDisplay()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = @"select * from Suppliers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();

            Supplier select = new Supplier();
            select.Name = "<--Select Supplier-->";
            select.ID = 0;
            suppliers.Add(select);
            while (sqlDataReader.Read())
            {
                Supplier supplier = new Supplier();


                supplier.ID = Convert.ToInt32(sqlDataReader["ID"]);

                supplier.Code = sqlDataReader["Code"].ToString();
                supplier.Name = sqlDataReader["Name"].ToString();
                supplier.Address = sqlDataReader["Address"].ToString();
                supplier.Email = sqlDataReader["Email"].ToString();
                supplier.Contact = sqlDataReader["Contact"].ToString();
                supplier.ContactPerson = sqlDataReader["ContactPerson"].ToString();

                suppliers.Add(supplier);


            }

            //Close
            sqlConnection.Close();

            return suppliers;



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


        public List<PurchasedProduct> SearchPurchasedProducts(string item)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"select * FROM PurchasedProducts WHERE (PurchaseCode LIKE '{item}%') OR (ProductCode LIKE '%{item}%') ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<PurchasedProduct> pruchasedProducts = new List<PurchasedProduct>();

            while (sqlDataReader.Read())
            {
                PurchasedProduct purchasedProduct = new PurchasedProduct();
                purchasedProduct.ID = Convert.ToInt32(sqlDataReader["ID"]);
                purchasedProduct.PurchaseCode = sqlDataReader["PurchaseCode"].ToString();
                purchasedProduct.ProductCode = sqlDataReader["ProductCode"].ToString();
                purchasedProduct.MfgDate = Convert.ToDateTime(sqlDataReader["MfgDate"]);
                purchasedProduct.ExpDate = Convert.ToDateTime(sqlDataReader["ExpDate"]);
                purchasedProduct.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                purchasedProduct.UnitPrice = Convert.ToDouble(sqlDataReader["UnitPrice"]);
                purchasedProduct.TotalPrice = Convert.ToDouble(sqlDataReader["TotalPrice"]);

                purchasedProduct.Remarks = sqlDataReader["Remarks"].ToString();
                pruchasedProducts.Add(purchasedProduct);


            }

            return pruchasedProducts;



        }




    }
    }
