using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;

namespace ClinicAppointments.Services.Interfaces
{
    public interface ISpecialtyService
    {
        Task<List<Specialty>> GetAllAsync();
        Task<Specialty> GetByIdAsync(int id);
        Task<Specialty> CreateAsync(Specialty specialty);
        Task<bool> DeleteAsync(int id);
        Task<Specialty> UpdateAsync(int id, Specialty specialty);
    }
}