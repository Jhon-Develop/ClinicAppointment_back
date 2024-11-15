using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Seeders
{
    public class RoleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "Admin Role" },
                new Role { Id = 2, Name = "Employee", Description = "Employee Role" },
                new Role { Id = 3, Name = "User", Description = "User Role" }
            );
        }
    }
}