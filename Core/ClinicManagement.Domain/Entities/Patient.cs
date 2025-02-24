using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
        public class Patient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Birthday { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Diagnosis { get; set; }
            public string Description { get; set; }
            public string IdNumber { get; set; }
            public string MotherName { get; set; }
            public string FatherName { get; set; }
            public int DoctorId { get; set; }
            public Doctor Doctor { get; set; } 
            public List<PatientMedicalHistory> MedicalHistories { get; set; }
            public List<PatientMedicine> PatientMedicines { get; set; }
        
    }
}
