using MedicalInstitution.DatabaseLayer;
using MedicalInstitution.Models;
using MedicalInstitution.Models.Observation;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicalInstitution.Program;

namespace MedicalInstitution
{
	class MedicalInstitutionController
	{
		#region private
		private Guid AddFormData() {
			var employer = new Employer("Katrin Johnson");
			var employerId = employer.Add();

			var patient = new Patient("John John");
			var patientId = patient.Add();

			var protocol = new Protocol("heart disease", "The protocol can be applied to...");
			var protocolId = protocol.Add();

			var observationForm = new ObservationForm(employerId, patientId, protocolId);
			var observationFormId = observationForm.Add();

			return observationFormId;
		}

		private Guid AddObservationToForm(Guid formId, Guid phenomenonTypeId, double quantityValue) {
			var quantity = new Quantity(Guid.Empty, quantityValue);
			var quantityId = quantity.Add();
			var measurement = new Measurement(formId, phenomenonTypeId, quantityId);
			return measurement.Add();
		}

		private Guid AddPhenomenonType(string name, string description) {
			var phenomenonType = new PhenomenonType(name, description);
			return phenomenonType.Add();
		}
		private void AddAllergy(string allergy) {
			var observationName = string.Empty;

			if (Int32.TryParse(allergy, out int observationValue)) {
				observationName = GetAllergyByScore(observationValue);
			} else {
				observationValue = GetAllergyByName(allergy);
			}

			AddAllergyAsObservation(Guid.Empty, observationName, observationValue);
		}

		private void AddAllergyAsObservation(Guid formId, string observationName, int observationValue)	{
			var phenomenonTypeId = GetPhenomenonTypeId(observationName);
			var quantityId = GetQuantityId(observationValue);

			var measurementObservation = new Measurement(formId, phenomenonTypeId, quantityId);
			measurementObservation.Add();
		}

		private Guid GetQuantityId(int observationValue) {
			var quantity = new Quantity(Guid.Empty, observationValue);
			return quantity.Add();
		}

		private string GetPhenomenonSelectQueryText(string observationName) {
			var querySelectPart = "SELECT Id FROM dbo." + ObservationConstants.PhenomenonTypeTableName;
			var queryConditionPart = " WHERE Name" + observationName;
			return querySelectPart + queryConditionPart;
		}
		private Guid GetPhenomenonTypeId(string observationName) {
			var fullQueryText = GetPhenomenonSelectQueryText(observationName);

			var typeId = ReadPhenomenonType(fullQueryText);
			if (typeId == Guid.Empty) {
				var type = new PhenomenonType(observationName, string.Empty);
				typeId = type.Add();
			}
			return typeId;
		}
		private int GetAllergyByName(String allergyName) {
			return (int)Enum.Parse(typeof(Allergen), allergyName);
		}

		private string GetAllergyByScore(int allergyScore) {
			return Enum.GetName(typeof(Allergen), allergyScore);
		}

		private void FindObservationByMeasurement(string allergyValue) {
			IObservationController observationController = new ObservationController();
			var observationList = observationController.FindFormObservation(Guid.Empty, Guid.Empty, allergyValue, true);
			if (observationList.Count > 0) {
				Console.WriteLine("Yes, it is");
			} else {
				Console.WriteLine("No, it is not");
			}
		}

		private Guid ReadPhenomenonType(string fullQueryText) {
			using (var connection = DatabaseConnection.GetNewSqlConnection()) {
				var reader = DatabaseConnection.GetRecords(connection, fullQueryText);
				while (reader.Read()) {
					return Guid.Parse(reader["Id"].ToString());
				}
			}

			return Guid.Empty;
		}

		#endregion

		#region public methods
		public void AddTestData() {
			var formId = AddFormData();

			var phenomenonTypeIdPollenAllergy = AddPhenomenonType("Pollen", "Allergy on Pollen");
			var phenomenonTypeIdCatsAllergy = AddPhenomenonType("Eggs", "Allergy on Milk");

			AddObservationToForm(formId, phenomenonTypeIdPollenAllergy, 64);
			AddObservationToForm(formId, phenomenonTypeIdCatsAllergy, 128);
		}
		public string GetUserSearchInput() {
			Console.WriteLine("Please, write down patient`s space-separated allergen name or score you would like to find");
			var allergens = Console.ReadLine();

			return allergens;
		}
		public string GetUserAllergiesInput() {
			Console.WriteLine("Please, write down patient`s space-separated allergens name or scores you would like to find");
			Console.WriteLine("Names and scores can be mixed");
			var allergens = Console.ReadLine();

			return allergens;
		}
		public void AddAllergies(string userInputAllergies) {
			String[] allergies = userInputAllergies.Split(" ");

			for (int i = 0; i < allergies.Length; i++) {
				AddAllergy(allergies[i]);
			}
		}

		public void FindObservationByCategory(string allergyName) {
			IObservationController observationController = new ObservationController();
			var observationList = observationController.FindFormObservation(Guid.Empty, Guid.Empty, allergyName, true);
			if (observationList.Count > 0) {
				Console.WriteLine("Yes, it is");
			} else {
				Console.WriteLine("No, it is not");
			}
		}

		public void FindObservationByUserInput(string userInput) {
			if (Int32.TryParse(userInput, out int observationValue)) {
				FindObservationByMeasurement(userInput);
			} else {
				FindObservationByCategory(userInput);
			}
		}
		#endregion

	}
}
