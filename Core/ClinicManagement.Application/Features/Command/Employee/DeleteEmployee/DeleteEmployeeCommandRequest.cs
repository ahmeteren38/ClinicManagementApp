using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommandRequest : IRequest<DeleteEmployeeCommandResponse>
    {
        public int EmployeeId { get; set; }
    }
}
