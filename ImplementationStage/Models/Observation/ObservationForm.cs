using MedicalInstitution.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInstitution
{
	class ObservationForm
	{
		#region private variables
		private Guid id;
		private Guid clinicianId;
		private Guid patientId;
		private Guid protocolId;
		private Guid observationFormTypeId;
		#endregion

		#region public methods
		public ObservationForm(Guid clinicianId, Guid patientId, Guid protocolId)
		{
			this.clinicianId = clinicianId;
			this.patientId = patientId;
			this.protocolId = protocolId;
		}

		public ObservationForm(Guid clinicianId, Guid patientId, Guid protocolId, Guid observationFormTypeId) : this(clinicianId, patientId, protocolId) {
			this.observationFormTypeId = observationFormTypeId;
		}

		internal Guid Add() {
			string queryString = @"INSERT INTO dbo.ObservationForm(ClinicianId, PatientId, ProtocolId) OUTPUT INSERTED.ID " + 
				"VALUES (" + this.clinicianId + ", " + this.patientId + ", " + this.protocolId + ")";
			return DatabaseConnection.ModifyRecords(queryString);
		}
		#endregion
	}
}
