using ClinicManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }
        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }
        public Appointment Appointment { get; set; }
        public int AppointmentId { get; set; }
        public List<Disease> Diseases { get; set; }
    }
}
