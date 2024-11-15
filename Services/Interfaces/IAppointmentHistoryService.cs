using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;

namespace ClinicAppointments.Services.Interfaces
{
    public interface IAppointmentHistoryService
    {
        Task<IEnumerable<AppointmentHistory>> GetAllAsync();
        Task<AppointmentHistory> GetByIdAsync(int id);
        Task<IEnumerable<AppointmentHistory>> GetByAppointmentIdAsync(int appointmentId);
        Task<AppointmentHistory> CreateAsync(AppointmentHistory appointmentHistory);
        Task<bool> DeleteAsync(int id);
    }
}