using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Patient.DeletePatient
{
    public class DeletePatientCommandRequest : IRequest<DeletePatientCommandResponse>
    {
        public int PatientId { get; set; }
    }
}
