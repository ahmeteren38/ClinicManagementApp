using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Features.Query.Employee.GetAllEmployees
{
    public class GetAllEmployeesQueryRequest : IRequest<GetAllEmployeesQueryResponse>
    {
    }
}
