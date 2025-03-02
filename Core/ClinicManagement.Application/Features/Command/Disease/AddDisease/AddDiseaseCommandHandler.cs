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

        public AddDiseaseCommandHandler(IDiseaseWriteRepository diseaseWriteRepository, IDiseaseReadRepository diseaseReadRepository)
        {
            _diseaseWriteRepository = diseaseWriteRepository;
            _diseaseReadRepository = diseaseReadRepository;
        }

        public async Task<AddDiseaseCommandResponse> Handle(AddDiseaseCommandRequest request, CancellationToken cancellationToken)
        {
          var diesase = await _diseaseReadRepository.GetAll().Where(d => d.Name == request.Name).FirstOrDefaultAsync();
            if (diesase != null) 
            {
                return new()
                {
                    Message = BussinessConstants.DiseaseAlreadyExist,
                    Succeeded = false,
                };
            }

          var result = await _diseaseWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Description = request.Description,
            });

            if(result == null)
            {
                return new()
                {
                    Message = BussinessConstants.DiseaseCouldNotAdd,
                    Succeeded = false,
                };
            }

            return new()
            {
                Message = BussinessConstants.DiseaseSuccessfullyAdded,
                Succeeded = true,
            };
        }
    }
}
