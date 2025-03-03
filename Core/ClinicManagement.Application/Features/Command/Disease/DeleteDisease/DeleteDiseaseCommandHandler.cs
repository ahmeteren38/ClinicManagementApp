using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Disease.DeleteDisease
{
    public class DeleteDiseaseCommandHandler : IRequestHandler<DeleteDiseaseCommandRequest, DeleteDiseaseCommandResponse>
    {
        readonly IDiseaseReadRepository _diseaseReadRepository;
        readonly IDiseaseWriteRepository _diseaseWriteRepository;

        public DeleteDiseaseCommandHandler(IDiseaseWriteRepository diseaseWriteRepository, IDiseaseReadRepository diseaseReadRepository)
        {
            _diseaseWriteRepository = diseaseWriteRepository;
            _diseaseReadRepository = diseaseReadRepository;
        }

        public async Task<DeleteDiseaseCommandResponse> Handle(DeleteDiseaseCommandRequest request, CancellationToken cancellationToken)
        {
          var disease = await _diseaseReadRepository.GetAll().Where(d => d.Id == request.DiseaseId).FirstOrDefaultAsync();
            if (disease == null) 
            {
                return new()
                {
                    Message = BussinessConstants.DiseaseCouldNotDelete,
                    Succeeded = false,
                };
            }

            _diseaseWriteRepository.Remove(disease);

            await _diseaseWriteRepository.SaveAsync();

            return new() 
            {
                Message = BussinessConstants.DiseaseSuccessfullyDeleted,
                Succeeded = true
            };
        }
    }
}
