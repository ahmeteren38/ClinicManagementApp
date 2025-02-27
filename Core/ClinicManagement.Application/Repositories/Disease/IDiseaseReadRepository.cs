using ClinicManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Application.Repositories
{
    public interface IDiseaseReadRepository : IReadRepository<Disease>
    {
    }
}
