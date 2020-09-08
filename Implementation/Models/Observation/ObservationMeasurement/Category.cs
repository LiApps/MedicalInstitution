using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class Category
	{
		private Guid id;
		private string name;
		private string description;

		public Category(string name, string description) {
			this.name = name;
			this.description = description;
		}
	}
}
