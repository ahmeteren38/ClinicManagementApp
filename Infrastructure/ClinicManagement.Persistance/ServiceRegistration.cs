using ClinicManagement.Application.Repositories;
using ClinicManagement.Persistance.Contexts;
using ClinicManagement.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) 
        {
            services.AddDbContext<ClinicManagementAPIDbContext>(options => options.UseSqlServer("Server=AEC;Database=ClinicManagementAPIDb;Integrated Security=True;TrustServerCertificate=True;"));

            services.AddScoped<IAppointmentReadRepository, AppointmentReadRepository>();
            services.AddScoped<IAppointmentWriteRepository, AppointmentWriteRepository>();
            services.AddScoped<IClinicReadRepository, ClinicReadRepository>();
            services.AddScoped<IClinicWriteRepository, ClinicWriteRepository>();
            services.AddScoped<IDiseaseReadRepository, DiseaseReadRepository>();
            services.AddScoped<IDiseaseWriteRepository, DiseaseWriteRepository>();
            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
            services.AddScoped<IPatientReadRepository, PatientReadRepository>();
            services.AddScoped<IPatientWriteRepository, PatientWriteRepository>();

        }
    }
}
