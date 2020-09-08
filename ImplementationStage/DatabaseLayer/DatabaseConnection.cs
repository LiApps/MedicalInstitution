using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.DatabaseLayer
{
    /*
     * Instead such work with DB it can be used "EntityFramework" etc.
     * It is simple class to work with DB without embellishments, very simple without hard logic.
     * I`ve decided that working with DB is better then with Lists.
     */
    public class DatabaseConnection
	{        
        /*
         * Use according to Parnas information hiding,
         * because database catalog etc. can change and client musn`t care about and recompile.
         */
        private static string dbConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MedicalInstitution;"
                + "Integrated Security=SSPI";
        /*
         * Need when use Reader and need to close connection bymyself.
         */
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

        /*
         * Here should be added reader checking, because if no records, then try to take "Id" of nothing.
         */
		private static Guid GetInsertedId(SqlCommand command) {
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return Guid.Parse(reader["Id"].ToString());
        }
	}
}
