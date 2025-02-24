using ClinicManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.DAL.Context
{
    public class ClinicManagementDbContext : DbContext
    {
        public ClinicManagementDbContext(DbContextOptions options) : base(options) 
        { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicalHistory> PatientMedicalHistories { get; set; }
        public DbSet<PatientMedicine> PatientMedicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PatientMedicine için bileşik birincil anahtar (composite key) oluşturuluyor:
            modelBuilder.Entity<PatientMedicine>()
                .HasKey(pm => new { pm.PatientId, pm.MedicineId }); // Composite key: PatientId + MedicineId

            // Patient ve PatientMedicine arasındaki ilişkiyi kuruyoruz:
            modelBuilder.Entity<PatientMedicine>()
                .HasOne(pm => pm.Patient)  // PatientMedicine sınıfındaki Patient özelliği ile ilişki
                .WithMany(p => p.PatientMedicines)  // Patient sınıfındaki PatientMedicines koleksiyonu ile ilişki
                .HasForeignKey(pm => pm.PatientId);  // PatientMedicine sınıfındaki PatientId ile ilişki

            // Medicine ve PatientMedicine arasındaki ilişkiyi kuruyoruz:
            modelBuilder.Entity<PatientMedicine>()
                .HasOne(pm => pm.Medicine)  // PatientMedicine sınıfındaki Medicine özelliği ile ilişki
                .WithMany(m => m.PatientMedicines)  // Medicine sınıfındaki PatientMedicines koleksiyonu ile ilişki
                .HasForeignKey(pm => pm.MedicineId);  // PatientMedicine sınıfındaki MedicineId ile ilişki
        }






    }
}
