using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Database;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<Appointment> CreateAppointmentAsync(AppointmentDto appointmentDto)
    {
        var appointment = new Appointment
        {
            PatientId = appointmentDto.PatientId,
            DoctorId = appointmentDto.DoctorId,
            Date = appointmentDto.Date,
            Status = appointmentDto.Status,
            CreatedAt = DateTimeOffset.UtcNow
        };

        return await _appointmentRepository.AddAppointmentAsync(appointment);
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id)
    {
        return await _appointmentRepository.GetAppointmentByIdAsync(id);
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
    {
        return await _appointmentRepository.GetAppointmentsAsync();
    }

    public async Task<Appointment> UpdateAppointmentAsync(int id, AppointmentDto appointmentDto)
    {
        var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return null;
        }

        appointment.Date = appointmentDto.Date;
        appointment.Status = appointmentDto.Status;

        return await _appointmentRepository.UpdateAppointmentAsync(appointment);
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
        return await _appointmentRepository.DeleteAppointmentAsync(id);
    }
    }
}