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
    public class DiseaseWriteRepository : WriteRepository<Disease>, IDiseaseWriteRepository
    {
        public DiseaseWriteRepository(ClinicManagementAPIDbContext context) : base(context)
        {
        }
    }
}
