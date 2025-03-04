using ClinicManagement.Application.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Employee.GetAllEmployees
{
    public class GetAllEmployeesQueryResponse
    {
        public bool Succeeded { get; set; }
        public List<GetAllEmployeesRequestDTO> Employees { get; set; }
    }
}
