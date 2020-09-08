﻿using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class ObservationController : IObservationController
	{
		#region private
		private string GetObservationSelectQueryText(bool isMeasurement) {
			var tableName = isMeasurement ? ObservationConstants.MeasurementTableName : ObservationConstants.CategoryObservationTableName;
			return "SELECT Id FROM dbo." + tableName;
		}

		private string GetObservationSelectQueryText(Guid formId, bool isMeasurement, Guid phenomenonTypeId, string observationValue) {
			var querySelectPart = GetObservationSelectQueryText(isMeasurement);
			var queryConditionPart = " WHERE FormId =" + formId + " AND ObservationValue =" + observationValue;

			return querySelectPart + " " + queryConditionPart + "; ";
		}
		#endregion

		#region public
		public void CreateObservationForm(Guid clinicianId, Guid patientId, Guid protocolId, Guid observationFormTypeId) {
			var form = new ObservationForm(clinicianId, patientId, protocolId, observationFormTypeId);
			form.Add();
		}
		public Guid AddQualitativeObservationToForm(Guid formId, Guid phenomenonTypeId, string observationValue) {
			var categoryObservation = new CategoryObservation(phenomenonTypeId, observationValue);
			return categoryObservation.Create();
		}

		public Guid AddQuantitativeObservationToForm(Guid formId, Guid phenomenonTypeId, Guid unitId, double observationValue) {
			var quantityObservation = new Quantity(unitId, observationValue);
			var quantityId = quantityObservation.Add();
			var measurement = new Measurement(formId, phenomenonTypeId, quantityId);
			return measurement.Add();
		}
		public List<Guid> FindFormObservation(Guid formId, Guid phenomenonTypeId, string observationValue, bool isMeasurement) {
			var fullQueryText = GetObservationSelectQueryText(formId, isMeasurement, phenomenonTypeId, observationValue);
			var observationList = new List<Guid>();

			using (var connection = DatabaseConnection.GetNewSqlConnection()) {
				var reader = DatabaseConnection.GetRecords(connection, fullQueryText);
				while (reader.Read()) {
					observationList.Add(Guid.Parse(reader["Id"].ToString()));
				}
			}

			return observationList;
		}

		public bool UpdateFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId, Observation observation) {
			return false;	
		}

		public bool UpdateObservationForm(Guid formId, string fieldName, string value) {
			return false;
		}
		public bool DeleteFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId) {
			return false;
		}

		public bool DeleteObservationForm() {
			return false;
		}

		#endregion
	}
}
