using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.Models
{
	class Staff
	{
		private Guid id;
		private Guid medInstituteDepartmentId;
		private Guid employerId;

		public Staff(Guid medInstituteDepartmentId, Guid employerId)
		{
			this.medInstituteDepartmentId = medInstituteDepartmentId;
			this.employerId = employerId;
		}
	}
}
