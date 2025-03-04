using ClinicManagement.Application.DTOs.Employee;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Employee.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQueryRequest, GetAllEmployeesQueryResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetAllEmployeesQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<GetAllEmployeesQueryResponse> Handle(GetAllEmployeesQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllEmployeesRequestDTO> employeeList = new List<GetAllEmployeesRequestDTO>();
           var employees = await _employeeReadRepository.GetAll().ToListAsync();

            foreach (var employee in employees) 
            {
                GetAllEmployeesRequestDTO getAllEmployeesRequestDTO = new GetAllEmployeesRequestDTO();
                getAllEmployeesRequestDTO.Name = employee.Name;
                getAllEmployeesRequestDTO.Surname = employee.Surname;
                getAllEmployeesRequestDTO.Birthday = employee.Birthday;
                getAllEmployeesRequestDTO.IdentityNumber = employee.IdentityNumber;
                getAllEmployeesRequestDTO.Job = employee.Job;
                getAllEmployeesRequestDTO.ClinicId = employee.ClinicId;

                employeeList.Add(getAllEmployeesRequestDTO);
            }

            return new()
            {
                Employees = employeeList,
                Succeeded = true
            };

        }
    }
}
