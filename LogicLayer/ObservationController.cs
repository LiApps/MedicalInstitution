using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class ObservationController : IObservationController
	{
		#region private
		private Guid CreateMeasurement(Guid phenomenonTypeId, Guid unitId, double quantity) {
			var quantityObservation = new Quantity(unitId, quantity);
			var quantityId = quantityObservation.CreateQuantity(quantityObservation);
			var measurement = new Measurement(phenomenonTypeId, quantityId);
			return measurement.Create(measurement);
		}
		private Guid CreateCategoryObservation(Guid phenomenonTypeId, string categoryValue)
		{
			var categoryObservation = new CategoryObservation(phenomenonTypeId, categoryValue);
			return categoryObservation.Create(categoryObservation);
		}
		private Guid AddObservationToForm(Guid formId, Guid phenomenonTypeId, Guid categoryObservationId)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region public
		public void CreateObservationForm(Guid clinicianId, Guid patientId, Guid protocolId, Guid observationFormTypeId)
		{
			var form = new ObservationForm(clinicianId, patientId, protocolId, observationFormTypeId);
			form.Create(form);
		}
		public Guid AddQualitativeObservationToForm(Guid formId, Guid phenomenonTypeId, string measurementValue)
		{
			var categoryObservationId = CreateCategoryObservation(phenomenonTypeId, measurementValue);
			return AddObservationToForm(formId, phenomenonTypeId, categoryObservationId);
		}

		public Guid AddQuantitativeObservationToForm(Guid formId, Guid phenomenonTypeId, Guid unitId, double measurementValue)
		{
			var measurementId = CreateMeasurement(phenomenonTypeId, unitId, measurementValue);
			return AddObservationToForm(formId, phenomenonTypeId, measurementId);
		}
		public Guid FindFormObservation(Guid formId, Guid phenomenonTypeId, string observationValue)
		{
			return Guid.Empty;
		}
		public void UpdateFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId, Observation observation)
		{
			
		}

		public void UpdateObservationForm(Guid formId, string fieldName, string value)
		{
			
		}
		public void DeleteFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId)
		{
			
		}

		public void DeleteObservationForm()
		{
		}

		#endregion
	}
}
