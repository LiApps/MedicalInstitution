using MedicalInstitution.DatabaseLayer;
using Microsoft.Data.SqlClient;
using System;

namespace MedicalInstitution
{
	class Program
	{
		public enum Allergen
		{
			Eggs = 1,
			Peanuts = 2,
			Shellfish = 4,
			Strawberries = 8,
			Tomatoes = 16,
			Chocolate = 32,
			Pollen = 64,
			Cats = 128
		}

		static void Main(string[] args)
		{
			//CreatePatient();
			//FindPatientByFullName();
			//FindFormByType();
			//using (var connection = new SqlConnection(dbConnectionString))

			string queryString = "SELECT Id FROM dbo.MedicalInstitution;";
			DatabaseConnection.ExecuteNonQueryCommand(queryString);

		}
	}
}
