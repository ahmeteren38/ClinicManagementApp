using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.DTOs.Disease
{
    public class GetAllDiseasesResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
    }
}
