using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Command.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
