using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Clinic.DeleteClinic
{
    public class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommandRequest, DeleteClinicCommandResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IClinicWriteRepository _clinicWriteRepository;

        public DeleteClinicCommandHandler(IClinicWriteRepository clinicWriteRepository,
            IClinicReadRepository clinicReadRepository)
        {
            _clinicWriteRepository = clinicWriteRepository;
            _clinicReadRepository = clinicReadRepository;
        }

        public async Task<DeleteClinicCommandResponse> Handle(DeleteClinicCommandRequest request, CancellationToken cancellationToken)
        {
          var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();

            if(clinic == null)
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

            _clinicWriteRepository.Remove(clinic);

           await _clinicWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.ClinicDeletedSuccessfully,
                Succeeded = true,
            };
        }
    }
}
