using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution.Models.Observation
{
	class MedicalInstitutionDepartment
	{
		private Guid id;
		private Guid medicalInstituteId;
		private Guid departmentId;

		public MedicalInstitutionDepartment(Guid medicalInstituteId, Guid departmentId)
		{
			this.medicalInstituteId = medicalInstituteId;
			this.departmentId = departmentId;
		}
	}
}
