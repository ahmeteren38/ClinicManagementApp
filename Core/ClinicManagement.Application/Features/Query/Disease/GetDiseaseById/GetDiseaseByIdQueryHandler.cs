using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Disease.GetDiseaseById
{
    public class GetDiseaseByIdQueryHandler : IRequestHandler<GetDiseaseByIdQueryRequest, GetDiseaseByIdQueryResponse>
    {
        readonly IDiseaseReadRepository _diseaseReadRepository;
        readonly IDiseaseWriteRepository _diseaseWriteRepository;
        public GetDiseaseByIdQueryHandler(IDiseaseReadRepository diseaseReadRepository, IDiseaseWriteRepository diseaseWriteRepository)
        {
            _diseaseReadRepository = diseaseReadRepository;
            _diseaseWriteRepository = diseaseWriteRepository;
        }

        public async Task<GetDiseaseByIdQueryResponse> Handle(GetDiseaseByIdQueryRequest request, CancellationToken cancellationToken)
        {
          var disease = await _diseaseReadRepository.GetAll().Where(d => d.Id == request.DiseaseId).FirstOrDefaultAsync();
            if (disease == null) 
            {
                throw new Exception(BussinessConstants.DiseaseCouldNotFind);
            }

            return new GetDiseaseByIdQueryResponse
            {
                Name = disease.Name,
                Description = disease.Description,
                PatientId = disease.PatientId,
            };
        }
    }
}
