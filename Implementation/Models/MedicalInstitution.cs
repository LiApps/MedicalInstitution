using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.Models
{
	class MedicalInstitution
	{
		private Guid id;
		private string name;
		private string description;

		public MedicalInstitution(string name, string description)
		{
			this.name = name;
			this.description = description;
		}
	}
}
