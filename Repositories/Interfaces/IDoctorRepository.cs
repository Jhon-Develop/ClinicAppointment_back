using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;

namespace ClinicAppointments.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> CreateAsync(Doctor doctor);
        Task<bool> DeleteAsync(int id);
        Task<Doctor> UpdateAsync(int id, Doctor doctor);
    }
}