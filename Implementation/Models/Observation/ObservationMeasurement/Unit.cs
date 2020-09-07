using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class Unit
	{
		private Guid id;
		private string name;
		private string description;

		public Unit(string name, string description)
		{
			this.name = name;
			this.description = description;
		}
	}
}
