using ClinicManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string IdentityNumber { get; set; }
        public string Job { get; set; }
        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
