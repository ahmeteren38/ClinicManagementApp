using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Domain.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string MedicineFirm { get; set; }
        public List<PatientMedicine> PatientMedicines { get; set; }
    }
}
