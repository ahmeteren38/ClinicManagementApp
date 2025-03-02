using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Clinic.GetClinicById
{
    public class GetClinicByIdQueryHandler : IRequestHandler<GetClinicByIdQueryRequest, GetClinicByIdQueryResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IClinicWriteRepository _clinicWriteRepository;

        public GetClinicByIdQueryHandler(IClinicReadRepository clinicReadRepository, IClinicWriteRepository clinicWriteRepository)
        {
            _clinicReadRepository = clinicReadRepository;
            _clinicWriteRepository = clinicWriteRepository;
        }

        public async Task<GetClinicByIdQueryResponse> Handle(GetClinicByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if(clinic == null)
            {
                return new()
                {
                    Succeeded = false,
                    Message = BussinessConstants.ClinicCouldNotFind,
                };
            }

            return new GetClinicByIdQueryResponse()
            {
                Name = clinic.Name,
                Address = clinic.Address,
                City = clinic.City,
                GSM = clinic.GSM,
            };


        }
    }
}
