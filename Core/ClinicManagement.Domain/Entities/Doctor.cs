using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MedicalTitle { get; set; }
        public string Specialization { get; set; }
        public int ClinicId {get; set; }
        public Clinic Clinic {get; set; }
        public Hospital Hospital { get; set; }
        public int HospitalId {get; set; }
        public List<Patient> Patients { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
