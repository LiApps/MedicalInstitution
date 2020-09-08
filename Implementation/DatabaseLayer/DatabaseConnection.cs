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

        public static SqlConnection GetNewSqlConnection() {
            return new SqlConnection(dbConnectionString);
        }
        private static SqlCommand GetCommand(SqlConnection connection, string commandText) {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = commandText;
            command.Connection = connection;
            return command;
        }

		public static SqlDataReader GetRecords(SqlConnection connection, string commandText) {            
            connection.Open();
            SqlCommand command = GetCommand(connection, commandText);
            var reader = command.ExecuteReader();

            return reader;
        }

        public static Guid ModifyRecords(string commandText) {
            var connection = GetNewSqlConnection();
            connection.Open();

            var command = GetCommand(connection, commandText);
            command.ExecuteNonQuery();            
            var insertedId = GetInsertedId(command);

            connection.Close();

            return insertedId;
        }

		private static Guid GetInsertedId(SqlCommand command) {
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return Guid.Parse(reader["Id"].ToString());
        }
	}
}
