using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Patient.AddPatient
{
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommandRequest, AddPatientCommandResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IPatientReadRepository _patientReadRepository;
        readonly IPatientWriteRepository _patientWriteRepository;

        public AddPatientCommandHandler(IPatientReadRepository patientReadRepository,
            IPatientWriteRepository patientWriteRepository,
            IClinicReadRepository clinicReadRepository)
        {
            _patientReadRepository = patientReadRepository;
            _patientWriteRepository = patientWriteRepository;
            _clinicReadRepository = clinicReadRepository;
        }

        public async Task<AddPatientCommandResponse> Handle(AddPatientCommandRequest request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if (clinic == null) 
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

          var patient = await _patientReadRepository.GetAll().Where(p => p.IdentityNumber == request.IdentityNumber).FirstOrDefaultAsync();
            if (patient != null) 
            {
                throw new Exception(BussinessConstants.PatientAlreadyExist);
            }

          var result = await _patientWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Surname = request.Surname,
                Birthday = request.Birthday,
                Gender = request.Gender,
                Description = request.Description,
                IdentityNumber = request.IdentityNumber,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                ClinicId = request.ClinicId,
            });

            if(result == null)
            {
                throw new Exception(BussinessConstants.PatientCouldNotAdd);
            }

           await _patientWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.PatientSuccessfullyAdded,
                Succeeded = true,
            };
        }
    }
}
