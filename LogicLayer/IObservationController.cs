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
		Guid FindFormObservation(Guid formId, Guid phenomenonTypeId, string observationValue);
		void UpdateFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId, Observation observation);
		void UpdateObservationForm(Guid formId, string fieldName, string value);
		void DeleteFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId);
		void DeleteObservationForm();
	}
}
