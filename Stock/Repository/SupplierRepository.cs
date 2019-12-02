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
    class SupplierRepository
    {

        public bool Add(Supplier supplier)
        {
            bool isAdded = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Insert Into Suppliers(Code,Name,Address,Email,Contact,ContactPerson) Values ('{supplier.Code}','{supplier.Name.ToUpper()}','{supplier.Address}','{supplier.Email}','{supplier.Contact}','{supplier.ContactPerson}')";
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

        public bool CheckCode(Supplier supplier)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Suppliers WHERE Code='{supplier.Code}'";
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


        public bool CheckEmail(Supplier supplier)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Supplierss WHERE Email='{supplier.Email}'";
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


        public bool CheckContact(Supplier supplier)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Suppliers WHERE Contact='{supplier.Contact}'";
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


        public List<Supplier> Display()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"Select * from Suppliers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();

            while (sqlDataReader.Read())
            {
                Supplier supplier = new Supplier();


                supplier.ID = Convert.ToInt32(sqlDataReader["ID"]);

                supplier.Code = sqlDataReader["Code"].ToString();
                supplier.Name = sqlDataReader["Name"].ToString();
               supplier.Address = sqlDataReader["Address"].ToString();
                supplier.Email = sqlDataReader["Email"].ToString();
                supplier.Contact = sqlDataReader["Contact"].ToString();
                supplier.ContactPerson = sqlDataReader["ContactPerson"].ToString() ;

                suppliers.Add(supplier);


            }
            //Close
            sqlConnection.Close();

            return suppliers;



        }



        public bool Update(Supplier supplier)
        {
            bool isUpdated = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Update Suppliers set Code = '{supplier.Code}', Name= '{supplier.Name.ToUpper()}',ContactPerson= '{supplier.ContactPerson}',Email='{supplier.Email}',Contact='{supplier.Contact}', Address='{supplier.Address}' where ID = {supplier.ID}";
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




        public List<Supplier> Search(string item)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"Select * from Suppliers WHERE (Name LIKE '%{item}%') OR (Code LIKE '%{item}%') OR (Contact LIKE '%{item}%')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Supplier> suppliers = new List<Supplier>();

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










    }
}
