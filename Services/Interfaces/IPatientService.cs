using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;

namespace ClinicAppointments.Services.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> CreatePatientAsync(PatientDto patientDto);
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> UpdatePatientAsync(int id, PatientDto patientDto);
        Task<bool> DeletePatientAsync(int id);
    }
}