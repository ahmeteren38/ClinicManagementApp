using ClinicManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Disease.UpdateDisease
{
    public class UpdateDiseaseCommandRequest : IRequest<UpdateDiseaseCommandResponse>
    {
        public int DiseaseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
    }
}
