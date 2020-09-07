using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class Measurement : Observation
	{
		private Guid phenomenonTypeId;
		private Guid quantityId;

		public Measurement(Guid phenomenonTypeId, Guid quantityId)
		{
			this.phenomenonTypeId = phenomenonTypeId;
			this.quantityId = quantityId;
		}

		internal Guid Create(Measurement observation)
		{

			return Guid.Empty;
		}
	}
}
