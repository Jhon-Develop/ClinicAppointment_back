using System;
using ClinicAppointments.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Seeders
{
    public class AppointmentHistorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentHistory>().HasData(
                // AppointmentId 1
                new AppointmentHistory { Id = 1, AppointmentId = 1, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), Action = "Consulta", Remarks = "Estoy muy enfermo", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 2, AppointmentId = 1, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), Action = "Consulta", Remarks = "Estoy muy enfermo", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 3, AppointmentId = 1, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)), Action = "Consulta", Remarks = "Dolor constante de cabeza", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 4, AppointmentId = 1, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(10)), Action = "Consulta", Remarks = "Chequeo general", CreatedAt = DateTimeOffset.UtcNow },

                // AppointmentId 2
                new AppointmentHistory { Id = 5, AppointmentId = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), Action = "Consulta", Remarks = "Problemas respiratorios", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 6, AppointmentId = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)), Action = "Consulta", Remarks = "Prevención", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 7, AppointmentId = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(7)), Action = "Consulta", Remarks = "Visión borrosa", CreatedAt = DateTimeOffset.UtcNow },

                // AppointmentId 3
                new AppointmentHistory { Id = 8, AppointmentId = 3, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), Action = "Consulta", Remarks = "Sin complicaciones", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 9, AppointmentId = 3, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(8)), Action = "Consulta", Remarks = "Dolor en los oídos", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 10, AppointmentId = 3, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(15)), Action = "Consulta", Remarks = "Sarpullido en la piel", CreatedAt = DateTimeOffset.UtcNow },

                // AppointmentId 4
                new AppointmentHistory { Id = 11, AppointmentId = 4, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), Action = "Consulta", Remarks = "Chequeo general", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 12, AppointmentId = 4, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(6)), Action = "Consulta", Remarks = "Revisión rutinaria", CreatedAt = DateTimeOffset.UtcNow },
                new AppointmentHistory { Id = 13, AppointmentId = 4, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(9)), Action = "Consulta", Remarks = "Control de diabetes", CreatedAt = DateTimeOffset.UtcNow }
            );
        }
    }
}
