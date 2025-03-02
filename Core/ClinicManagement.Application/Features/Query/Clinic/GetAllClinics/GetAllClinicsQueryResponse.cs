using ClinicManagement.Application.DTOs.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Clinic.GetAllClinics
{
    public class GetAllClinicsQueryResponse
    {
        public bool Succeeded { get; set; }
        public List<GetAllClinicsResponseDTO> Clinics { get; set; }
    }
}
