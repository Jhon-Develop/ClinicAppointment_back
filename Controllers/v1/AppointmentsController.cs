using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicAppointments.Controllers.v1
{
    [ApiController]
    [Route("api/v1/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        // Constructor injection for the appointment service
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // Endpoint to create a new appointment
        [SwaggerOperation(
            Summary = "Create a new appointment",
            Description = "This endpoint creates a new appointment based on the provided data"
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "Appointment created successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(appointmentDto);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment); // Return created appointment
        }

        // Endpoint to retrieve an appointment by its ID
        [SwaggerOperation(
            Summary = "Get appointment by ID",
            Description = "This endpoint retrieves an appointment by its unique ID"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Appointment retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Appointment not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound(); // Return not found if appointment doesn't exist
            }
            return appointment; // Return the found appointment
        }

        // Endpoint to retrieve all appointments
        [SwaggerOperation(
            Summary = "Get all appointments",
            Description = "This endpoint retrieves all appointments in the system"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Appointments retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointmentsAsync();
            return Ok(appointments); // Return all appointments
        }

        // Endpoint to update an existing appointment
        [SwaggerOperation(
            Summary = "Update an existing appointment",
            Description = "This endpoint updates an existing appointment based on the provided data"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Appointment updated successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Appointment not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int id, [FromBody] AppointmentDto appointmentDto)
        {
            var appointment = await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);
            if (appointment == null)
            {
                return NotFound(); // Return not found if appointment doesn't exist
            }
            return Ok(appointment); // Return updated appointment
        }

        // Endpoint to delete an appointment by its ID
        [SwaggerOperation(
            Summary = "Delete an appointment by ID",
            Description = "This endpoint deletes an appointment based on its unique ID"
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Appointment deleted successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Appointment not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _appointmentService.DeleteAppointmentAsync(id);
            if (!result)
            {
                return NotFound(); // Return not found if appointment doesn't exist
            }
            return NoContent(); // Return no content if deletion is successful
        }
    }
}
