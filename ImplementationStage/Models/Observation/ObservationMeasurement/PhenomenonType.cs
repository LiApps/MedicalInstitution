using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class PhenomenonType
	{
		private Guid id;
		private string name;
		private string description;

		public PhenomenonType(string name, string description)
		{
			this.name = name;
			this.description = description;
		}

		internal Guid Add() {
			string queryString = @"INSERT INTO dbo.PhenomenonType(Name) OUTPUT INSERTED.ID VALUES (" + this.name + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
		internal Guid Get(string name) {
			var querySelectPart = "SELECT Id FROM dbo.PhenomenonType";
			var queryConditionPart = " WHERE Name" + name;
			var fullQueryText = querySelectPart + queryConditionPart;

			using (var connection = DatabaseConnection.GetNewSqlConnection())
			{
				var reader = DatabaseConnection.GetRecords(connection, fullQueryText);
				while (reader.Read()) {
					return Guid.Parse(reader["Id"].ToString());
				}
			}

			return Guid.Empty;
		}
	}
}
