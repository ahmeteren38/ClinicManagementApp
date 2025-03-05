using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Disease.AddDisease
{
    public class AddDiseaseCommandResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public int DiseaseId { get; set; }
    }
}
