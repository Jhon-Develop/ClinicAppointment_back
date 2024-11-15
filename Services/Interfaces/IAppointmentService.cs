using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;

namespace ClinicAppointments.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointmentAsync(AppointmentDto appointmentDto);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> UpdateAppointmentAsync(int id, AppointmentDto appointmentDto);
        Task<bool> DeleteAppointmentAsync(int id);
    }
}