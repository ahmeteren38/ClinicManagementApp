using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Persistance.Contexts
{
    public class ClinicManagementAPIDbContext : DbContext
    {
        public ClinicManagementAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patient> Patients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appointment ve Patient arasında bir one-to-one ilişki
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient) // Appointment bir Patient'e sahip
                .WithOne(p => p.Appointment) // Patient bir Appointment'a sahip
                .HasForeignKey<Appointment>(a => a.PatientId); // AppointmentId foreign key olarak belirleniyor

            // Patient modeli üzerinde başka bir foreign key tanımlamaya gerek yok
            // Çünkü Appointment'daki PatientId zaten bu ilişkiyi kuruyor
        }
    }



}
