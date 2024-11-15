using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;

namespace ClinicAppointments.Repositories.Interfaces
{
    public interface IRoleRepository 
    {
        Task<List<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
        Task<bool> DeleteAsync(int id);
        Task<Role> UpdateAsync(int id, Role role);
    }
}