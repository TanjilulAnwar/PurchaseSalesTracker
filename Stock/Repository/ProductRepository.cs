using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Stock.Model;
using System.Threading.Tasks;

namespace Stock.Repository
{
    class ProductRepository
    {
        public bool Add(Product product)
        {
            bool isAdded = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Insert Into Products(CategoryID,Code,Name,ReOrderLevel,Description) Values ({product.CategoryID},'{product.Code}','{product.Name.ToUpper()}',{product.ReOrderLevel},'{product.Description}')";
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

        public bool CheckCode(Product product)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Products WHERE Code='{product.Code}'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            }
            catch 
            {

            }

            return exists;


        }

        public bool CheckName(Product product)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM products WHERE Name='{product.Name.ToUpper()}'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            }
            catch 
            {

            }

            return exists;


        }

        public List<Product> Display()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"select prod.ID, prod.CategoryID,prod.Code,prod.Name,prod.ReOrderLevel,prod.Description, cat.Name AS Category FROM Products AS prod LEFT JOIN Categories AS cat ON cat.ID = prod.CategoryID";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Product> products = new List<Product>();

            while (sqlDataReader.Read())
            {
                Product product = new Product();


                product.ID = Convert.ToInt32(sqlDataReader["ID"]);
                product.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                product.Code = sqlDataReader["Code"].ToString();
                product.Name = sqlDataReader["Name"].ToString();
                product.CategoryName = sqlDataReader["Category"].ToString();
                product.ReOrderLevel = Convert.ToInt32(sqlDataReader["ReOrderLevel"]);
                product.Description= sqlDataReader["Description"].ToString();
                products.Add(product);


            }
            //Close
            sqlConnection.Close();
            return products;



        }

        public bool Update(Product product)
        {
            bool isUpdated = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Update Products set Code = '{product.Code}', Name= '{product.Name.ToUpper()}',ReOrderLevel= {product.ReOrderLevel},Description ='{product.Description}' where ID = {product.ID}";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isUpdated = true;
                }

                //Close
                sqlConnection.Close();


            }
            catch 
            {
                isUpdated = false;
            }

            return isUpdated;
        }

        public List<Product> Search(string item)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"select prod.ID, prod.CategoryID,prod.Code,prod.Name,prod.ReOrderLevel,prod.Description, cat.Name AS Category FROM Products AS prod LEFT JOIN Categories AS cat ON cat.ID = prod.CategoryID WHERE (prod.Name LIKE '{item.ToUpper()}%') OR (prod.Code LIKE '{item.ToUpper()}%')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Product> products = new List<Product>();

            while (sqlDataReader.Read())
            {
                Product product = new Product();


                product.ID = Convert.ToInt32(sqlDataReader["ID"]);
                product.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                product.Code = sqlDataReader["Code"].ToString();
                product.Name = sqlDataReader["Name"].ToString();
               product.CategoryName = sqlDataReader["Category"].ToString();
                product.ReOrderLevel = Convert.ToInt32(sqlDataReader["ReOrderLevel"]);
                product.Description = sqlDataReader["Description"].ToString();
                products.Add(product);


            }

            return products;



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
            select.Name = "-Select Category-";
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


    }
}
