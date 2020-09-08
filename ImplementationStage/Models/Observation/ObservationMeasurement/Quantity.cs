using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class Quantity
	{
		#region private variables
		private Guid unitId;
		private double quantity;
		#endregion

		#region public methods
		public Quantity(Guid unitId, double quantity) {
			this.unitId = unitId;
			this.quantity = quantity;
		}

		internal Guid Add() {
			string queryString = @"INSERT INTO dbo.Quantity(Quantity) OUTPUT INSERTED.ID VALUES (" + this.quantity + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
		#endregion
	}
}
