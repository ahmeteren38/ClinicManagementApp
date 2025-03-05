using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Patient.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommandRequest, DeletePatientCommandResponse>
    {
        readonly IPatientReadRepository _patientReadRepository;
        readonly IPatientWriteRepository _patientWriteRepository;
        public DeletePatientCommandHandler(IPatientReadRepository patientReadRepository, IPatientWriteRepository patientWriteRepository)
        {
            _patientReadRepository = patientReadRepository;
            _patientWriteRepository = patientWriteRepository;
        }

        public async Task<DeletePatientCommandResponse> Handle(DeletePatientCommandRequest request, CancellationToken cancellationToken)
        {
          var patient = await _patientReadRepository.GetAll().Where(p => p.Id == request.PatientId).FirstOrDefaultAsync();
            if (patient == null) 
            {
                throw new Exception(BussinessConstants.PatientCouldNotFind);
            }

            _patientWriteRepository.Remove(patient);

           await _patientWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.PatientSuccessfullyDeleted,
                Succeeded = true
            };//controller yaz test et :=)

        }
    }
}
