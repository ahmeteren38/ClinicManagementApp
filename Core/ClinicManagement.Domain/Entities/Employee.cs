using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public DateTime JobStartDate { get; set; }
        public DateTime? JobEndDate { get; set; }
        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }

    }
}
