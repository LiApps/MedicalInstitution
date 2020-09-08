using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.Models
{
	class Employer
	{
		private Guid id;
		private string fullName;

		public Employer(string fullName) {
			this.fullName = fullName;
		}
		internal Guid Add() {
			string queryString = @"INSERT INTO dbo.Employer(FullName) OUTPUT INSERTED.ID VALUES (" + this.fullName + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
	}
}
