using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;

namespace ClinicAppointments.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> CreateAsync(DoctorDto doctorDto);
        Task<bool> DeleteAsync(int id);
        Task<Doctor> UpdateAsync(int id, DoctorDto doctorDto);
    }
}