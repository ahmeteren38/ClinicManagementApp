using ClinicManagement.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClinicManagementDbContext>
    {
        public ClinicManagementDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ClinicManagementDbContext> builder = new();
            builder.UseSqlServer("Server=AEC;Database=ETicaretAPIDb;Integrated Security=True;TrustServerCertificate=True;");

            return new ClinicManagementDbContext(builder.Options);
        }
    }
}
