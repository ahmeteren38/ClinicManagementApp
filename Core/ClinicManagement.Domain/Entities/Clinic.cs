using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }

    }
}
