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
    public class DiseaseReadRepository : ReadRepository<Disease>, IDiseaseReadRepository
    {
        public DiseaseReadRepository(ClinicManagementAPIDbContext context) : base(context)
        {
        }
    }
}
