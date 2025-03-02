using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Clinic.UpdateClinic
{
    public class UpdateClinicCommandHandler : IRequestHandler<UpdateClinicCommandRequest, UpdateClinicCommandResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IClinicWriteRepository _clinicWriteRepository;

        public UpdateClinicCommandHandler(IClinicReadRepository clinicReadRepository,
            IClinicWriteRepository clinicWriteRepository)
        {
            _clinicReadRepository = clinicReadRepository;
            _clinicWriteRepository = clinicWriteRepository;
        }

        public async Task<UpdateClinicCommandResponse> Handle(UpdateClinicCommandRequest request, CancellationToken cancellationToken)
        {
          var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if(clinic == null)
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

            clinic.Name = request.Name;
            clinic.Address = request.Address;
            clinic.City = request.City;
            clinic.GSM = request.GSM;

            _clinicWriteRepository.Update(clinic);

            await _clinicWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.ClinicUpdatedSuccessfully,
                Succeeded = true,
            };
        }
    }
}
