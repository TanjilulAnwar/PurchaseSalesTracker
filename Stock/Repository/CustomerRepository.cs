using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Stock.Model;
namespace Stock.Repository
{
    class CustomerRepository
    {
        public bool Add(Customer customer)
        {
            bool isAdded = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Insert Into Customers(Code,Name,Address,Email,Contact,LoyaltyPoint) Values ('{customer.Code}','{customer.Name.ToUpper()}','{customer.Address}','{customer.Email}','{customer.Contact}',{customer.LoyaltyPoint})";
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

        public bool CheckCode(Customer customer)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Customers WHERE Code='{customer.Code}'";
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


        public bool CheckEmail(Customer customer)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Customers WHERE Email='{customer.Email}'";
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


        public bool CheckContact(Customer customer)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Customers WHERE Contact='{customer.Contact}'";
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


        public List<Customer> Display()
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


        public bool Update(Customer customer)
        {
            bool isUpdated = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Update Customers set Code = '{customer.Code}', Name= '{customer.Name.ToUpper()}',LoyaltyPoint= {customer.LoyaltyPoint},Email='{customer.Email}',Contact='{customer.Contact}',Address='{customer.Address}' where ID = {customer.ID}";
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


        public List<Customer> Search(string item)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"Select * from Customers WHERE (Name LIKE '%{item}%') OR (Code LIKE '%{item}%') OR (Contact LIKE '%{item}%')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Customer> customers = new List<Customer>();

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



    }
}
