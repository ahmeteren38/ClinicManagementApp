using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Patient.GetPatientById
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQueryRequest, GetPatientByIdQueryResponse>
    {
        readonly IPatientReadRepository _patientReadRepository;

        public GetPatientByIdQueryHandler(IPatientReadRepository patientReadRepository)
        {
            _patientReadRepository = patientReadRepository;
        }

        public async Task<GetPatientByIdQueryResponse> Handle(GetPatientByIdQueryRequest request, CancellationToken cancellationToken)
        {
           var patient = await _patientReadRepository.GetAll().Where(p => p.Id == request.PatientId).FirstOrDefaultAsync();
            if (patient == null) 
            {
                throw new Exception(BussinessConstants.PatientCouldNotFind);
            }

            return new()
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Birthday = patient.Birthday,
                Gender = patient.Gender,
                Description = patient.Description,
                IdentityNumber = patient.IdentityNumber,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                Address = patient.Address,
                ClinicId = patient.ClinicId,
            };//controller
        }
    }
}
