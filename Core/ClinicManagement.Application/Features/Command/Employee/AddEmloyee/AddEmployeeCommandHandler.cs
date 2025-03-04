using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Employee.AddEmloyee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandRequest, AddEmployeeCommandResponse>
    {
        readonly IClinicReadRepository _clinicReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;

        public AddEmployeeCommandHandler(IClinicReadRepository clinicReadRepository,
            IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _clinicReadRepository = clinicReadRepository;
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<AddEmployeeCommandResponse> Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
          var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if (clinic == null) 
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

            var result = await _employeeWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Surname = request.Surname,
                Birthday = request.Birthday,
                IdentityNumber = request.IdentityNumber,
                Job = request.Job,
                ClinicId = request.ClinicId,
            });
            
            if(result == null)
            {
                throw new Exception(BussinessConstants.EmployeeCouldNotAdd);
            }

           await _employeeWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.EmployeeAddedSuccessfully,
                Succeeded = true,
            };

        }
    }
}
