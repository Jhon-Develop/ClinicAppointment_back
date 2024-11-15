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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los roles
        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        // Obtener un rol por ID
        public async Task<Role> GetByIdAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                throw new KeyNotFoundException($"Role with ID {id} not found.");
            return role;
        }

        // Crear un nuevo rol
        public async Task<Role> CreateAsync(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating role: " + ex.Message);
            }
        }

        // Eliminar un rol
        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                throw new KeyNotFoundException($"Role with ID {id} not found.");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        // Actualizar un rol
        public async Task<Role> UpdateAsync(int id, Role role)
        {
            var existingRole = await _context.Roles.FindAsync(id);
            if (existingRole == null)
                throw new KeyNotFoundException($"Role with ID {id} not found.");

            existingRole.Name = role.Name;
            existingRole.Description = role.Description;

            await _context.SaveChangesAsync();
            return existingRole;
        }
    }
}
