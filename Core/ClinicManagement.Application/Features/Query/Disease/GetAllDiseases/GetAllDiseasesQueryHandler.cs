using ClinicManagement.Application.DTOs.Disease;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Disease.GetAllDiseases
{
    public class GetAllDiseasesQueryHandler : IRequestHandler<GetAllDiseasesQueryRequest, GetAllDiseasesQueryResponse>
    {
        readonly IDiseaseReadRepository _diseaseReadRepository;

        public GetAllDiseasesQueryHandler(IDiseaseReadRepository diseaseReadRepository)
        {
            _diseaseReadRepository = diseaseReadRepository;
        }

        public async Task<GetAllDiseasesQueryResponse> Handle(GetAllDiseasesQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllDiseasesResponseDTO> diseaseList = new List<GetAllDiseasesResponseDTO>();
          var diseases = await _diseaseReadRepository.GetAll().ToListAsync();
            foreach (var disease in diseases) 
            {
                GetAllDiseasesResponseDTO getAllDiseasesResponseDTO = new GetAllDiseasesResponseDTO();
                getAllDiseasesResponseDTO.Name = disease.Name;
                getAllDiseasesResponseDTO.Description = disease.Description;
                getAllDiseasesResponseDTO.PatientId = disease.PatientId;

                diseaseList.Add(getAllDiseasesResponseDTO);
            }

            return new()
            {
                Succeeded = true,
                Diseases = diseaseList
            };

        }
    }
}
