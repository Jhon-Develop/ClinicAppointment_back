using ClinicAppointments.Models;
using ClinicAppointments.Repositories;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicAppointments.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;

        public SpecialtyService(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }

        public async Task<List<Specialty>> GetAllAsync()
        {
            return await _specialtyRepository.GetAllAsync();
        }

        public async Task<Specialty> GetByIdAsync(int id)
        {
            return await _specialtyRepository.GetByIdAsync(id);
        }

        public async Task<Specialty> CreateAsync(Specialty specialty)
        {
            return await _specialtyRepository.CreateAsync(specialty);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _specialtyRepository.DeleteAsync(id);
        }

        public async Task<Specialty> UpdateAsync(int id, Specialty specialty)
        {
            return await _specialtyRepository.UpdateAsync(id, specialty);
        }
    }
}
