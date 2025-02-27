using ClinicManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public DateTime? AppointmentUpdatedDate { get; set; }
        public DateTime? AppointmentDeletedDate { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

    }
}
