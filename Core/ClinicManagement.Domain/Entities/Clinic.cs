using ClinicManagement.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string GSM { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
