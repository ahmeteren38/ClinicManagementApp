using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClinicManagement.Application.Features.Command.Patient.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommandRequest, UpdatePatientCommandResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IPatientReadRepository _patientReadRepository;
        readonly IPatientWriteRepository _patientWriteRepository;
        public UpdatePatientCommandHandler(IClinicReadRepository clinicReadRepository,
            IPatientReadRepository patientReadRepository,
            IPatientWriteRepository patientWriteRepository)
        {
            _clinicReadRepository = clinicReadRepository;
            _patientReadRepository = patientReadRepository;
            _patientWriteRepository = patientWriteRepository;
        }

        public async Task<UpdatePatientCommandResponse> Handle(UpdatePatientCommandRequest request, CancellationToken cancellationToken)
        {
          var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if (clinic == null) 
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

            var patient = await _patientReadRepository.GetAll().Where(p => p.Id == request.PatientId).FirstOrDefaultAsync();
            if(patient == null)
            {
                throw new Exception(BussinessConstants.PatientCouldNotFind);
            }

            patient.Name = request.Name;
            patient.Surname = request.Surname;
            patient.Birthday = request.Birthday;
            patient.IdentityNumber = request.IdentityNumber;
            patient.Address = request.Address;
            patient.Description = request.Description;
            patient.PhoneNumber = request.PhoneNumber;
            patient.Email = request.Email;
            patient.ClinicId = request.ClinicId;

            _patientWriteRepository.Update(patient);

           await _patientWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.PatientSuccessfullyUpdated,
                Succeeded = true
            };

        }
    }
}
