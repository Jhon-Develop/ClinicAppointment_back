using ClinicAppointments.Models;
using ClinicAppointments.Repositories;
using ClinicAppointments.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ClinicAppointments.Services.Interfaces;
using ClinicAppointments.Repositories.Interfaces;

namespace ClinicAppointments.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        // Obtener todos los doctores
        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        // Obtener un doctor por ID
        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        // Crear un nuevo doctor
        public async Task<Doctor> CreateAsync(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Phone = doctorDto.Phone,
                Email = doctorDto.Email,
                CreatedAt = DateTimeOffset.UtcNow
            };

            return await _doctorRepository.CreateAsync(doctor);
        }

        // Eliminar un doctor por ID
        public async Task<bool> DeleteAsync(int id)
        {
            return await _doctorRepository.DeleteAsync(id);
        }

        public async Task<Doctor> UpdateAsync(int id, DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Phone = doctorDto.Phone,
                Email = doctorDto.Email
            };

            return await _doctorRepository.UpdateAsync(id, doctor);
        }
    }
}
