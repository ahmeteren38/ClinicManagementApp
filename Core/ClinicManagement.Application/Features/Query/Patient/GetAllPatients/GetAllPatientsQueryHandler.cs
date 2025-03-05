using ClinicManagement.Application.DTOs.Patient;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClinicManagement.Application.Features.Query.Patient.GetAllPatients
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQueryRequest, GetAllPatientsQueryResponse>
    {
        readonly IPatientReadRepository _patientReadRepository;

        public GetAllPatientsQueryHandler(IPatientReadRepository patientReadRepository)
        {
            _patientReadRepository = patientReadRepository;
        }

        public async Task<GetAllPatientsQueryResponse> Handle(GetAllPatientsQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllPatientsRequestDTO> patientList = new List<GetAllPatientsRequestDTO>(); 
          var patients = await _patientReadRepository.GetAll().ToListAsync();

            foreach (var patient in patients)
            {
                GetAllPatientsRequestDTO getAllPatientsResponseDTO = new GetAllPatientsRequestDTO();
                getAllPatientsResponseDTO.Name = patient.Name;
                getAllPatientsResponseDTO.Surname = patient.Surname;
                getAllPatientsResponseDTO.Birthday = patient.Birthday;
                getAllPatientsResponseDTO.Gender = patient.Gender;
                getAllPatientsResponseDTO.IdentityNumber = patient.IdentityNumber;
                getAllPatientsResponseDTO.Address = patient.Address;
                getAllPatientsResponseDTO.PhoneNumber = patient.PhoneNumber;
                getAllPatientsResponseDTO.Description = patient.Description;
                getAllPatientsResponseDTO.Email = patient.Email;
                getAllPatientsResponseDTO.ClinicId = patient.ClinicId;

                patientList.Add(getAllPatientsResponseDTO);
            }

            return new()
            {
                Succeeded = true,
                Patients = patientList,
            };
        }
    }
}
