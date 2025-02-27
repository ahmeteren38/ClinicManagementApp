using ClinicManagement.Application.Repositories;
using ClinicManagement.Domain.Entities;
using ClinicManagement.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Persistance.Repositories
{
    public class EmployeeReadRepository : ReadRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(ClinicManagementAPIDbContext context) : base(context)
        {
        }
    }
}
