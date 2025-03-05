using ClinicManagement.Application.DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Patient.GetAllPatients
{
    public class GetAllPatientsQueryResponse
    {
        public bool Succeeded { get; set; }
        public List<GetAllPatientsRequestDTO> Patients { get; set; }
    }
}
