using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.Models.Observation
{
	class Patient
	{
		private Guid id;
		private string fullName;

		public Patient(string fullName) {
			this.fullName = fullName;
		}
		internal Guid Add() {
			string queryString = @"INSERT INTO dbo.Patient(FullName) OUTPUT INSERTED.ID VALUES (" + this.fullName + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
	}
}
