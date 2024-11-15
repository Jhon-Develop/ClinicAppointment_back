using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Seeders
{
    public class DoctorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. John Doe", Phone = "123456789", Email = "johndoe@gmail.com" },
                new Doctor { Id = 2, Name = "Dr. Jane Doe", Phone = "987654321", Email = "janedoe@gmail.com" },
                new Doctor { Id = 3, Name = "Dr. Mary Doe", Phone = "876543210", Email = "marydoe@gmail.com" },
                new Doctor { Id = 4, Name = "Dr. Peter Doe", Phone = "765432198", Email = "peterdoe@gmail.com" }
            );
        }
    }
}