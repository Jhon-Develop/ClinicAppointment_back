using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Seeders
{
    public class SpecialtySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>().HasData(
                new Specialty { Id = 1, Name = "Cardiology", Description = "Cardiology" },
                new Specialty { Id = 2, Name = "Dermatology", Description = "Dermatology" },
                new Specialty { Id = 3, Name = "Gastroenterology", Description = "Gastroenterology" },
                new Specialty { Id = 4, Name = "General Surgery", Description = "General Surgery" },
                new Specialty { Id = 5, Name = "Neurology", Description = "Neurology" },
                new Specialty { Id = 6, Name = "Pediatrics", Description = "Pediatrics" },
                new Specialty { Id = 7, Name = "Plastic Surgery", Description = "Plastic Surgery" },
                new Specialty { Id = 8, Name = "Psychiatry", Description = "Psychiatry" },
                new Specialty { Id = 9, Name = "Urology", Description = "Urology" }
            );
        }
    }
}