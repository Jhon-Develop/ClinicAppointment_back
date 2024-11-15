using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Seeders
{
    public class UserSeeder
    {
        private readonly IPasswordHasher _passwordHasher;

        public UserSeeder(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@admin.com",
                    PasswordHash = _passwordHasher.HashPassword("123456"),
                    RoleId = 1,
                    DoctorId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Receptionist Nicolas",
                    Email = "receptionistNicolas@receptionist.com",
                    PasswordHash = _passwordHasher.HashPassword("123456"),
                    RoleId = 2,
                    DoctorId = null
                },
                new User
                {
                    Id = 3,
                    Name = "Receptionist Javier",
                    Email = "receptionistJavier@receptionist.com",
                    PasswordHash = _passwordHasher.HashPassword("123456"),
                    RoleId = 2,
                    DoctorId = null
                },
                new User
                {
                    Id = 4,
                    Name = "Receptionist Mariana",
                    Email = "receptionistMariana@receptionist.com",
                    PasswordHash = _passwordHasher.HashPassword("123456"),
                    RoleId = 2,
                    DoctorId = null
                },
                new User
                {
                    Id = 5,
                    Name = "Receptionist Jhon",
                    Email = "receptionistJhon@receptionist.com",
                    PasswordHash = _passwordHasher.HashPassword("123456"),
                    RoleId = 2,
                    DoctorId = null
                }
            );
        }
    }
}