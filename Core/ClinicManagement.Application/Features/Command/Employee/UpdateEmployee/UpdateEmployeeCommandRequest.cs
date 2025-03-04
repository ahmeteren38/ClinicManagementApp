using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandRequest : IRequest<UpdateEmployeeCommandResponse>
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string IdentityNumber { get; set; }
        public string Job { get; set; }
        public int ClinicId { get; set; }
    }
}
