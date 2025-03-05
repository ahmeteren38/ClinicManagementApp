using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Disease.AddDisease
{
    public class AddDiseaseCommandHandler : IRequestHandler<AddDiseaseCommandRequest, AddDiseaseCommandResponse>
    {
        readonly IDiseaseReadRepository _diseaseReadRepository;
        readonly IDiseaseWriteRepository _diseaseWriteRepository;
        readonly IPatientReadRepository _patientReadRepository;

        public AddDiseaseCommandHandler(IDiseaseWriteRepository diseaseWriteRepository, IDiseaseReadRepository diseaseReadRepository, IPatientReadRepository patientReadRepository)
        {
            _diseaseWriteRepository = diseaseWriteRepository;
            _diseaseReadRepository = diseaseReadRepository;
            _patientReadRepository = patientReadRepository;
        }

        public async Task<AddDiseaseCommandResponse> Handle(AddDiseaseCommandRequest request, CancellationToken cancellationToken)
        {
            var patient = await _patientReadRepository.GetAll().Where(p => p.Id == request.PatientId).FirstOrDefaultAsync();
            if (patient == null) 
            {
                throw new Exception(BussinessConstants.PatientCouldNotFind);
            }

          var diesase = await _diseaseReadRepository.GetAll().Where(d => d.Name == request.Name).FirstOrDefaultAsync();
            if (diesase != null) 
            {
                return new()
                {
                    Message = BussinessConstants.DiseaseAlreadyExist,
                    Succeeded = false,
                };
            }

            var lastDisease = await _diseaseReadRepository.GetAll().OrderByDescending(d => d.Name).FirstOrDefaultAsync();

            int newDiseaseId = lastDisease != null ? lastDisease.Id + 1 : 1;


            var result = await _diseaseWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
                PatientId = request.PatientId
            });

            if(result == null)
            {
                return new()
                {
                    Message = BussinessConstants.DiseaseCouldNotAdd,
                    Succeeded = false,
                };
            }

           await _diseaseWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.DiseaseSuccessfullyAdded,
                Succeeded = true,
                DiseaseId = newDiseaseId
            };
        }
    }
}
