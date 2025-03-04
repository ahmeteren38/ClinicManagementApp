using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IClinicReadRepository _clinicReadRepository;

        public UpdateEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository,
            IEmployeeWriteRepository employeeWriteRepository,
            IClinicReadRepository clinicReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _clinicReadRepository = clinicReadRepository;
        }

        public async Task<UpdateEmployeeCommandResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
          var clinic = await _clinicReadRepository.GetAll().Where(c => c.Id == request.ClinicId).FirstOrDefaultAsync();
            if (clinic == null) 
            {
                throw new Exception(BussinessConstants.ClinicCouldNotFind);
            }

           var employee = await _employeeReadRepository.GetAll().Where(e => e.Id == request.EmployeeId).FirstOrDefaultAsync();
            if (employee == null) 
            {
                throw new Exception(BussinessConstants.EmployeeCouldNotFind);
            }

            employee.Name = request.Name;
            employee.Surname = request.Surname;
            employee.Birthday = request.Birthday;
            employee.IdentityNumber = request.IdentityNumber;
            employee.Job = request.Job;
            employee.ClinicId = request.ClinicId;

            _employeeWriteRepository.Update(employee);

            await _employeeWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.EmployeeUpdatedSuccessfully,
                Succeeded = true,
            };

        }
    }
}
