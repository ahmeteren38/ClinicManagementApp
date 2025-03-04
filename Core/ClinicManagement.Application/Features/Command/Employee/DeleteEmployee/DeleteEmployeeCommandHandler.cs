using ClinicManagement.Application.Constans;
using ClinicManagement.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        public DeleteEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }

        public async Task<DeleteEmployeeCommandResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
          var employee = await _employeeReadRepository.GetAll().Where(e => e.Id == request.EmployeeId).FirstOrDefaultAsync();
            if (employee == null) 
            {
                throw new Exception(BussinessConstants.EmployeeCouldNotFind);    
            };

            _employeeWriteRepository.Remove(employee);

            await _employeeWriteRepository.SaveAsync();

            return new()
            {
                Message = BussinessConstants.EmployeeDeletedSuccessfully,
                Succeeded = true,
            };
        }
    }
}
