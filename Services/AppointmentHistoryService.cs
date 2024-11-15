using ClinicAppointments.Models;
using ClinicAppointments.Repositories;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services.Interfaces;

namespace ClinicAppointments.Services
{
    public class AppointmentHistoryService : IAppointmentHistoryService
    {
        private readonly IAppointmentHistoryRepository _repository;

        public AppointmentHistoryService(IAppointmentHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AppointmentHistory>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AppointmentHistory> GetByIdAsync(int id)
    {
        var appointmentHistory = await _repository.GetByIdAsync(id);
        
        if (appointmentHistory == null)
        {
            throw new KeyNotFoundException($"Appointment history with id {id} not found.");
        }

        return appointmentHistory;
    }

        public async Task<IEnumerable<AppointmentHistory>> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _repository.GetByAppointmentIdAsync(appointmentId);
        }

        public async Task<AppointmentHistory> CreateAsync(AppointmentHistory appointmentHistory)
        {
            return await _repository.CreateAsync(appointmentHistory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
