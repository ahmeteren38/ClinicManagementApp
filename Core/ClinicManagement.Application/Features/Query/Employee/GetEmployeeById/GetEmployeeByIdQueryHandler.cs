using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Employee.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQueryRequest, GetEmployeeByIdQueryResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeReadRepository employeeReadRepository,
            IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<GetEmployeeByIdQueryResponse> Handle(GetEmployeeByIdQueryRequest request, CancellationToken cancellationToken)
        {
          var employee = await _employeeReadRepository.GetAll().Where(e => e.Id == request.EmployeeId).FirstOrDefaultAsync();
            if (employee == null) 
            {
                throw new Exception(BussinessConstants.EmployeeCouldNotFind);
            }

            return new()
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Birthday = employee.Birthday,
                IdentityNumber = employee.IdentityNumber,
                Job = employee.Job,
                ClinicId = employee.ClinicId,
            };
        }
    }
}
