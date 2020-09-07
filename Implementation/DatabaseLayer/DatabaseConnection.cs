using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.DatabaseLayer
{
	public class DatabaseConnection
	{        
        private static string dbConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MedicalInstitution;"
                + "Integrated Security=SSPI";

        //public static void ExecuteNonQueryCommand(string queryString) {
        //    using (var connection = new SqlConnection(dbConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(queryString, connection);
        //        command.Connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}

        public static SqlDataReader ExecuteQueryCommand(SqlConnection connection, string queryString)
        {            
            connection.Open();
            SqlCommand command = new SqlCommand(queryString, connection);
            var reader = command.ExecuteReader();
            return reader;
        }

        public static Guid ExecuteNonQueryCommand(string commandText)
        {
            var connection = new SqlConnection(dbConnectionString);

            connection.Open();
            SqlCommand command = new SqlCommand();
            
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = commandText;
            command.Connection = connection;

            var quantityId = command.ExecuteNonQuery();
            connection.Close();

            return Guid.Empty;
        }
    }
}
