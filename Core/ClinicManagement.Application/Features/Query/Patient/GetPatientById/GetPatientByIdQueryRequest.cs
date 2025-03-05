using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Patient.GetPatientById
{
    public class GetPatientByIdQueryRequest : IRequest<GetPatientByIdQueryResponse>
    {
        public int PatientId { get; set; }
    }
}
