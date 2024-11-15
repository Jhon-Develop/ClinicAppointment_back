using ClinicAppointments.Database;
using ClinicAppointments.Models;
using ClinicAppointments.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Repositories
{
    public class AppointmentHistoryRepository : IAppointmentHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentHistory>> GetAllAsync()
        {
            return await _context.AppointmentHistories.Include(ah => ah.Appointment).ToListAsync();
        }

        public async Task<AppointmentHistory> GetByIdAsync(int id)
        {
            var appointmentHistory = await _context.AppointmentHistories
                .FirstOrDefaultAsync(ah => ah.Id == id);

            if (appointmentHistory == null)
            {
                throw new KeyNotFoundException($"Appointment history with id {id} not found.");
            }

            return appointmentHistory;
        }

        public async Task<IEnumerable<AppointmentHistory>> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _context.AppointmentHistories
                .Where(ah => ah.AppointmentId == appointmentId)
                .ToListAsync();
        }

        public async Task<AppointmentHistory> CreateAsync(AppointmentHistory appointmentHistory)
        {
            // Verificar si la cita asociada existe
            var appointmentExists = await _context.Appointments.AnyAsync(a => a.Id == appointmentHistory.AppointmentId);
            if (!appointmentExists)
                throw new InvalidOperationException("The associated appointment does not exist.");

            _context.AppointmentHistories.Add(appointmentHistory);
            await _context.SaveChangesAsync();
            return appointmentHistory;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointmentHistory = await _context.AppointmentHistories.FindAsync(id);
            if (appointmentHistory == null)
                return false;

            _context.AppointmentHistories.Remove(appointmentHistory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
