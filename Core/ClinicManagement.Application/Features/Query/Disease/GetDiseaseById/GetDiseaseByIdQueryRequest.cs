using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Disease.GetDiseaseById
{
    public class GetDiseaseByIdQueryRequest : IRequest<GetDiseaseByIdQueryResponse>
    {
        public int DiseaseId { get; set; }
    }
}
