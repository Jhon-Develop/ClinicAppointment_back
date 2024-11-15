using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Seeders;
using ClinicAppointments.Services;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentHistory> AppointmentHistories { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoleSeeder.Seed(modelBuilder);
            DoctorSeeder.Seed(modelBuilder);
            SpecialtySeeder.Seed(modelBuilder);
            PatientSeeder.Seed(modelBuilder);
            AppointmentSeeder.Seed(modelBuilder);
            AppointmentHistorySeeder.Seed(modelBuilder);

            var passwordHasher = new PasswordHasher();
            var userSeeder = new UserSeeder(passwordHasher);
            userSeeder.Seed(modelBuilder);
        }
    }
}