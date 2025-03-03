using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Disease.DeleteDisease
{
    public class DeleteDiseaseCommandRequest : IRequest<DeleteDiseaseCommandResponse>
    {
        public int DiseaseId { get; set; }
    }
}
