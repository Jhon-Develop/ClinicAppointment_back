using ClinicAppointments.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Seeders
{
    public class AppointmentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment 
                { 
                    Id = 1, 
                    Date = new DateOnly(2024, 11, 10), 
                    Reason = "Consulta de Oncología", 
                    Notes = "Chequeo inicial", 
                    Status = "Pendiente", 
                    PatientId = 1, 
                    DoctorId = 1, 
                    SpecialtyId = 1 
                },
                new Appointment 
                { 
                    Id = 2, 
                    Date = new DateOnly(2024, 11, 12), 
                    Reason = "Consulta Cardiológica", 
                    Notes = "Prevención", 
                    Status = "Confirmada", 
                    PatientId = 2, 
                    DoctorId = 2, 
                    SpecialtyId = 2 
                },
                new Appointment 
                { 
                    Id = 3, Date = new DateOnly(2024, 11, 15), 
                    Reason = "Consulta Neurológica", 
                    Notes = "Dolor de cabeza recurrente", 
                    Status = "Pendiente", 
                    PatientId = 3, 
                    DoctorId = 3, 
                    SpecialtyId = 3 
                },
                new Appointment 
                { 
                    Id = 4, 
                    Date = new DateOnly(2024, 11, 05), 
                    Reason = "Consulta Pediátrica", 
                    Notes = "Revisión general", 
                    Status = "Cancelada", 
                    PatientId = 4, 
                    DoctorId = 4, 
                    SpecialtyId = 4 
                }
            );
        }
    }
}
