using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.Models
{
	class Protocol
	{
		private Guid id;
		private string name;
		private string description;

		public Protocol(string name, string description) {
			this.name = name;
			this.description = description;
		}
		internal Guid Add() {
			string queryString = @"INSERT INTO dbo.Protocol(Name, Description) OUTPUT INSERTED.ID VALUES (" + this.name + ", " + this.description + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
	}
}
