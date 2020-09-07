using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class Quantity
	{
		private Guid unitId;
		private double quantity;

		public Quantity(Guid unitId, double quantity)
		{
			this.unitId = unitId;
			this.quantity = quantity;
		}

		internal Guid CreateQuantity(Quantity quantity)
		{
			string queryString = "INSERT " + quantity.unitId + "," + quantity.quantity + "," + "Id INTO dbo.Quantity;";
			var quantityId = DatabaseConnection.ExecuteNonQueryCommand(queryString);
			return quantityId;
		}
	}
}
