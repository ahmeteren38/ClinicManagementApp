using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Clinic.AddClinic
{
    public class AddClinicCommandHandler : IRequestHandler<AddClinicCommandRequest, AddClinicCommandResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IClinicWriteRepository _clinicWriteRepository;

        public AddClinicCommandHandler(IClinicReadRepository clinicReadRepository,
            IClinicWriteRepository clinicWriteRepository)
        {
            _clinicReadRepository = clinicReadRepository;
            _clinicWriteRepository = clinicWriteRepository;
        }

        public async Task<AddClinicCommandResponse> Handle(AddClinicCommandRequest request, CancellationToken cancellationToken)
        {
           var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if(clinic != null)
            {
                throw new Exception(BussinessConstants.ClinicAlreadyExist);
            }

           var result = await _clinicWriteRepository.AddAsync(new()
            {
              Name = request.Name,
              Address = request.Address,
              City = request.City,
              GSM = request.GSM,
            });

            if(result == null)
            {
                throw new Exception(BussinessConstants.ClinicCouldNotAdd);
            }

            await _clinicWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.ClinicAddedSuccessfully,
                Succeeded = true
            };


        }
    }
}
