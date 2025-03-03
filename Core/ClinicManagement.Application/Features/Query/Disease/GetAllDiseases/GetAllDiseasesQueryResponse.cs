using ClinicManagement.Application.DTOs.Disease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Disease.GetAllDiseases
{
    public class GetAllDiseasesQueryResponse
    {
        public bool Succeeded { get; set; }
        public List<GetAllDiseasesResponseDTO> Diseases { get; set; }
    }
}
