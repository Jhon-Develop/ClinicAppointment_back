using ClinicAppointments.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Database;

namespace ClinicAppointments.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los doctores
        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        // Obtener un doctor por ID
        public async Task<Doctor> GetByIdAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");
            return doctor;
        }

        // Crear un nuevo doctor
        public async Task<Doctor> CreateAsync(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
                return doctor;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating doctor: " + ex.Message);
            }
        }

        // Eliminar un doctor por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Doctor> UpdateAsync(int id, Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(id);
            if (existingDoctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found.");

            // Actualizamos solo los campos modificables
            existingDoctor.Name = doctor.Name;
            existingDoctor.Phone = doctor.Phone;
            existingDoctor.Email = doctor.Email;

            // Guardamos los cambios
            await _context.SaveChangesAsync();
            return existingDoctor;
        }
    }
}
