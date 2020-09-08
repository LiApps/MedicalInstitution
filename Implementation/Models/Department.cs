using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.Models
{
	class Department
	{
		private Guid id;
		private string name;
		private string description;

		public Department(string name, string description)
		{
			this.name = name;
			this.description = description;
		}
	}
}
