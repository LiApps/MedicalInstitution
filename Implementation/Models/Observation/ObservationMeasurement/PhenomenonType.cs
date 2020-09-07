using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class PhenomenonType
	{
		private Guid id;
		private string name;
		private string description;

		public PhenomenonType(string name, string description)
		{
			this.name = name;
			this.description = description;
		}
	}
}
