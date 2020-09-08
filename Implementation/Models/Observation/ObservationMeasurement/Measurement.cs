using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class Measurement : Observation
	{
		private Guid formId;
		private Guid phenomenonTypeId;
		private Guid quantityId;

		public Measurement(Guid formId, Guid phenomenonTypeId, Guid quantityId) {
			this.formId = formId;
			this.phenomenonTypeId = phenomenonTypeId;
			this.quantityId = quantityId;
		}

		internal Guid Add() {
			string queryString = @"INSERT INTO dbo.Measurement(QuantityId) OUTPUT INSERTED.ID VALUES (" + this.quantityId + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
	}
}
