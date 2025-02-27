using ClinicManagement.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClinicManagementAPIDbContext>
    {
        public ClinicManagementAPIDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClinicManagementAPIDbContext>();
            optionsBuilder.UseSqlServer("Server=AEC;Database=ClinicManagementAPIDb;Integrated Security=True;TrustServerCertificate=True;");

            return new ClinicManagementAPIDbContext(optionsBuilder.Options);
        }
    }
}
