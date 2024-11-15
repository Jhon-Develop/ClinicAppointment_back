using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;

namespace ClinicAppointments.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientAsync(int id);
    }
}