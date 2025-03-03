using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Disease.UpdateDisease
{
    public class UpdateDiseaseCommandHandler : IRequestHandler<UpdateDiseaseCommandRequest, UpdateDiseaseCommandResponse>
    {
        readonly IPatientReadRepository _patientReadRepository;
        readonly IDiseaseReadRepository _diseaseReadRepository;
        readonly IDiseaseWriteRepository _diseaseWriteRepository;

        public UpdateDiseaseCommandHandler(IDiseaseReadRepository diseaseReadRepository,
            IPatientReadRepository patientReadRepository,
            IDiseaseWriteRepository diseaseWriteRepository)
        {
            _diseaseReadRepository = diseaseReadRepository;
            _patientReadRepository = patientReadRepository;
            _diseaseWriteRepository = diseaseWriteRepository;
        }

        public async Task<UpdateDiseaseCommandResponse> Handle(UpdateDiseaseCommandRequest request, CancellationToken cancellationToken)
        {
          var patient = await _patientReadRepository.GetAll().Where(p => p.Id == request.PatientId).FirstOrDefaultAsync();
            if (patient == null) 
            {
                throw new Exception(BussinessConstants.PatientCouldNotFind);
            }

            var disease = await _diseaseReadRepository.GetAll().Where(d => d.Id == request.DiseaseId).FirstOrDefaultAsync();
            if (disease == null)
            {
                throw new Exception(BussinessConstants.DiseaseCouldNotFind);
            }

            disease.Name = request.Name;
            disease.PatientId = request.PatientId;
            disease.Description = request.Description;

            _diseaseWriteRepository.Update(disease);

           await _diseaseWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.DiseaseSuccessfullyUpdated,
                Succeeded = true,
            };
        }
    }
}
