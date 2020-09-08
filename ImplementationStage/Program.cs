using MedicalInstitution.DatabaseLayer;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace MedicalInstitution
{
	class Program
	{
		public enum Allergen
		{
			Eggs = 1,
			Peanuts = 2,
			Shellfish = 4,
			Strawberries = 8,
			Tomatoes = 16,
			Chocolate = 32,
			Pollen = 64,
			Cats = 128
		}
		static void Main(string[] args) {
			var medicalInstitutionController = new MedicalInstitutionController();
			
			medicalInstitutionController.AddTestData();

			var userInputAllergies = medicalInstitutionController.GetUserAllergiesInput();
			medicalInstitutionController.AddAllergies(userInputAllergies);

			var userInput = medicalInstitutionController.GetUserSearchInput();
			medicalInstitutionController.FindObservationByUserInput(userInput);


		}
	}
}
