using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class ObservationForm
	{
		private Guid id;
		private Guid clinicianId;
		private Guid patientId;
		private Guid protocolId;
		private Guid observationFormTypeId;

		public ObservationForm(Guid clinicianId, Guid patientId, Guid protocolId)
		{
			this.clinicianId = clinicianId;
			this.patientId = patientId;
			this.protocolId = protocolId;
		}

		public ObservationForm(Guid clinicianId, Guid patientId, Guid protocolId, Guid observationFormTypeId) : this(clinicianId, patientId, protocolId)
		{
			this.observationFormTypeId = observationFormTypeId;
		}

		internal void Create(ObservationForm form)
		{
			throw new NotImplementedException();
		}
	}
}
