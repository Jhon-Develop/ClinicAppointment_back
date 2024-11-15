using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Seeders
{
    public class PatientSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "John Doe", Document = "123456789", Phone = "987654321", Address = "123 Main St", DateBorn = new DateOnly(1985, 5, 20) },
                new Patient { Id = 2, Name = "Jane Doe", Document = "876543210", Phone = "765432198", Address = "456 Main St", DateBorn = new DateOnly(1990, 8, 15) },
                new Patient { Id = 3, Name = "Mary Doe", Document = "654321987", Phone = "543219876", Address = "789 Main St", DateBorn = new DateOnly(1982, 3, 10) },
                new Patient { Id = 4, Name = "Peter Doe", Document = "543219876", Phone = "432198765", Address = "1011 Main St", DateBorn = new DateOnly(1975, 11, 30) },
                new Patient { Id = 5, Name = "John Doe", Document = "123456789", Phone = "987654321", Address = "123 Main St", DateBorn = new DateOnly(1985, 5, 20) }
            );
        }
    }
}
