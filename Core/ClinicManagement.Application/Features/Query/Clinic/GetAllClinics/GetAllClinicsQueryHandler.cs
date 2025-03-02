using ClinicManagement.Application.DTOs.Clinic;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Clinic.GetAllClinics
{
    public class GetAllClinicsQueryHandler : IRequestHandler<GetAllClinicsQueryRequest, GetAllClinicsQueryResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IClinicWriteRepository _clinicWriteRepository;
        public GetAllClinicsQueryHandler(IClinicReadRepository clinicReadRepository, IClinicWriteRepository clinicWriteRepository)
        {
            _clinicReadRepository = clinicReadRepository;
            _clinicWriteRepository = clinicWriteRepository;
        }

        public async Task<GetAllClinicsQueryResponse> Handle(GetAllClinicsQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllClinicsResponseDTO> clinicList = new List<GetAllClinicsResponseDTO>();

            var clinics = await _clinicReadRepository.GetAll().ToListAsync();
            foreach (var clinic in clinics)
            {
                GetAllClinicsResponseDTO getAllClinicsResponseDTO = new GetAllClinicsResponseDTO();
                getAllClinicsResponseDTO.Name = clinic.Name;
                getAllClinicsResponseDTO.Address = clinic.Address;
                getAllClinicsResponseDTO.City = clinic.City;

                clinicList.Add(getAllClinicsResponseDTO);
            }

            return new()
            {
                Succeeded = true,
                Clinics = clinicList
            };

        }
    }
}
