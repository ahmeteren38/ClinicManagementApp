using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Clinic.DeleteClinic
{
    public class DeleteClinicCommandRequest : IRequest<DeleteClinicCommandResponse>
    {
        public int ClinicId { get; set; }
    }
}
