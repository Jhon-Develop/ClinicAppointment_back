using ClinicAppointments.Models;
using ClinicAppointments.Repositories;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicAppointments.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            return await _roleRepository.CreateAsync(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _roleRepository.DeleteAsync(id);
        }

        public async Task<Role> UpdateAsync(int id, Role role)
        {
            return await _roleRepository.UpdateAsync(id, role);
        }
    }
}
