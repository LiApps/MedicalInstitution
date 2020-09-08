using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	/*
	 * Specification with low coupling, because I used a lot primitive types instead classes,
	 * therefore it is easy to use the component without knowing of special model classes and implementation.
	 */
	interface IObservationController
	{
		void CreateObservationForm(Guid clinicianId, Guid patientId, Guid protocolId, Guid observationFormTypeId);
		Guid AddQualitativeObservationToForm(Guid formId, Guid phenomenonTypeId, string measurementValue);
		Guid AddQuantitativeObservationToForm(Guid formId, Guid phenomenonTypeId, Guid unitId, double measurementValue);
		/*
		 * List is better here, because for now, the function can back more than one record and this can be 
		 * processed as special case error and means to data integrity violation.
		 * Can be covered with ObservationResult class.
		 * Even better with extended ObservationResult class with error field etc.
		 */
		List<Guid> FindFormObservation(Guid formId, Guid phenomenonTypeId, string observationValue, bool isMeasurement);
		bool UpdateFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId, Observation observation);
		bool UpdateObservationForm(Guid formId, string fieldName, string value);
		bool DeleteFormObservation(Guid formId, Guid phenomenonTypeId, Guid observationId);
		bool DeleteObservationForm();
	}
}
