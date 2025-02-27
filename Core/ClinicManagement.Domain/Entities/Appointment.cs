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
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }
        public string Description { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Disease Disease { get; set; }
        public int DiseaseId { get; set; }
    }
}
