using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicAppointments.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // Crear un nuevo paciente
        public async Task<Patient> CreatePatientAsync(PatientDto patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                Document = patientDto.Document,
                Phone = patientDto.Phone,
                Address = patientDto.Address,
                DateBorn = patientDto.DateBorn,
                CreatedAt = DateTimeOffset.UtcNow
            };

            return await _patientRepository.AddPatientAsync(patient);
        }

        // Obtener un paciente por su ID
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        // Obtener todos los pacientes
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _patientRepository.GetPatientsAsync();
        }

        // Actualizar un paciente
        public async Task<Patient> UpdatePatientAsync(int id, PatientDto patientDto)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return null;
            }

            patient.Name = patientDto.Name;
            patient.Document = patientDto.Document;
            patient.Phone = patientDto.Phone;
            patient.Address = patientDto.Address;
            patient.DateBorn = patientDto.DateBorn;

            return await _patientRepository.UpdatePatientAsync(patient);
        }

        // Eliminar un paciente
        public async Task<bool> DeletePatientAsync(int id)
        {
            return await _patientRepository.DeletePatientAsync(id);
        }
    }
}
