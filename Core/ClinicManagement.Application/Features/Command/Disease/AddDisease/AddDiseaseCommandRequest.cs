using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Disease.AddDisease
{
    public class AddDiseaseCommandRequest : IRequest<AddDiseaseCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
    }
}
