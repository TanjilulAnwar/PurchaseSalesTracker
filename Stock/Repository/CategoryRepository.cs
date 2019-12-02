using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Model;
using System.Data;
using System.Data.SqlClient;

namespace Stock.Repository
{
    class CategoryRepository
    {

        public bool Add(Category category)
        {
            bool isAdded = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Insert Into Categories(Code,Name) Values ('{category.Code}','{category.Name.ToUpper()}')";
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

        public bool CheckCode(Category category)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Categories WHERE Code='{category.Code}'";
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

        public bool CheckName(Category category)
        {
            bool exists = false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"SELECT * FROM Categories WHERE Name='{category.Name.ToUpper()}'";
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

        public bool Update(Category category)
        {
            bool isUpdated= false;
            try
            {
                //Connection
                SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

                //Command 
                string commandString = $"Update Categories set Code = '{category.Code}', Name= '{category.Name.ToUpper()}' where ID = {category.ID}";
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

        public List<Category> Display()
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"Select * from Categories";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Category> categories = new List<Category>();

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

        public List<Category> Search(string item)
        {
            //Connection
            SqlConnection sqlConnection = new SqlConnection(Connection.ConnectionString);

            //Command
            string commandString = $"SELECT * FROM Categories WHERE (NAME LIKE '{item}%') OR (Code LIKE '{item}%')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //open
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<Category> categories = new List<Category>();

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
