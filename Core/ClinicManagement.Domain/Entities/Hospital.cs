using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Clinic> Clinics { get; set; }
        public string Description { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
