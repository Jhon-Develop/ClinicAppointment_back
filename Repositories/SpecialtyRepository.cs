using ClinicAppointments.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ClinicAppointments.Database;
using ClinicAppointments.Repositories.Interfaces;

namespace ClinicAppointments.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialtyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las especialidades
        public async Task<List<Specialty>> GetAllAsync()
        {
            return await _context.Specialties.ToListAsync();
        }

        // Obtener una especialidad por ID
        public async Task<Specialty> GetByIdAsync(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null)
                throw new KeyNotFoundException($"Specialty with ID {id} not found.");
            return specialty;
        }

        // Crear una nueva especialidad
        public async Task<Specialty> CreateAsync(Specialty specialty)
        {
            try
            {
                _context.Specialties.Add(specialty);
                await _context.SaveChangesAsync();
                return specialty;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating specialty: " + ex.Message);
            }
        }

        // Eliminar una especialidad
        public async Task<bool> DeleteAsync(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null)
                throw new KeyNotFoundException($"Specialty with ID {id} not found.");

            _context.Specialties.Remove(specialty);
            await _context.SaveChangesAsync();
            return true;
        }

        // Actualizar una especialidad
        public async Task<Specialty> UpdateAsync(int id, Specialty specialty)
        {
            var existingSpecialty = await _context.Specialties.FindAsync(id);
            if (existingSpecialty == null)
                throw new KeyNotFoundException($"Specialty with ID {id} not found.");

            existingSpecialty.Name = specialty.Name;
            existingSpecialty.Description = specialty.Description;

            await _context.SaveChangesAsync();
            return existingSpecialty;
        }
    }
}
