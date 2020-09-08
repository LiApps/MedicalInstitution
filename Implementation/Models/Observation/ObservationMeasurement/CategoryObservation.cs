using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class CategoryObservation : Observation
	{
		private Guid phenomenonTypeId;
		private string measurementValue;

		public CategoryObservation(Guid phenomenonTypeId, string measurementValue) {
			this.phenomenonTypeId = phenomenonTypeId;
			this.measurementValue = measurementValue;
		}

		internal Guid Create() {
			string queryString = @"INSERT INTO dbo.CategoryObservation(MeasurementValue) OUTPUT INSERTED.ID VALUES (" + this.measurementValue + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
	}
}
