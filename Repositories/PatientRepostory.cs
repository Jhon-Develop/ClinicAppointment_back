using ClinicAppointments.Database;
using ClinicAppointments.Models;
using ClinicAppointments.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear un nuevo paciente
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        // Obtener un paciente por su ID
        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
                                .Where(p => p.Id == id)
                                .FirstOrDefaultAsync();
        }

        // Obtener todos los pacientes
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        // Actualizar un paciente
        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        // Eliminar un paciente
        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
