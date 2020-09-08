using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	interface IObservationController
	{
		void CreateObservationForm(Guid clinicianId, Guid patientId, Guid protocolId, Guid observationFormTypeId);
		Guid AddQualitativeObservationToForm(Guid formId, Guid phenomenonTypeId, string measurementValue);
		Guid AddQuantitativeObservationToForm(Guid formId, Guid phenomenonTypeId, Guid unitId, double measurementValue);
		List<Guid> FindFormObservation(Guid formId, Guid phenomenonTypeId, string observationValue, bool isMeasurement);
		bool UpdateFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId, Observation observation);
		bool UpdateObservationForm(Guid formId, string fieldName, string value);
		bool DeleteFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId);
		bool DeleteObservationForm();
	}
}
