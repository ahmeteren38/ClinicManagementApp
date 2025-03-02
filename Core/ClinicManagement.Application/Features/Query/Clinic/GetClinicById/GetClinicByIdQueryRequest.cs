using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Clinic.GetClinicById
{
    public class GetClinicByIdQueryRequest : IRequest<GetClinicByIdQueryResponse>
    {
        public int ClinicId { get; set; }
    }
}
