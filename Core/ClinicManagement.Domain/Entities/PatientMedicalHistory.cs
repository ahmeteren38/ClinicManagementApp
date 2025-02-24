using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class PatientMedicalHistory
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Diagnosis { get; set; } 
        public DateTime DiagnosisDate { get; set; } 
        public string Treatment { get; set; } 

    }
}
