using ClinicAppointments.Models;
using ClinicAppointments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicAppointments.Controllers
{
    [ApiController]
    [Route("api/v1/appointment-histories")]
    public class AppointmentHistoryController : ControllerBase
    {
        private readonly IAppointmentHistoryService _service;

        // Constructor injection for the AppointmentHistoryService
        public AppointmentHistoryController(IAppointmentHistoryService service)
        {
            _service = service;
        }

        // Endpoint to get all appointment histories
        [SwaggerOperation(
            Summary = "Get all appointment histories",
            Description = "This endpoint retrieves all the appointment histories from the system"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Appointment histories retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var histories = await _service.GetAllAsync();
            return Ok(histories); // Return all appointment histories
        }

        // Endpoint to get an appointment history by its ID
        [SwaggerOperation(
            Summary = "Get appointment history by ID",
            Description = "This endpoint retrieves a specific appointment history by its unique ID"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Appointment history retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Appointment history not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var appointmentHistory = await _service.GetByIdAsync(id);
                return Ok(appointmentHistory); // Return the found appointment history
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); // Return not found if ID does not exist
            }
        }

        // Endpoint to get appointment histories by appointment ID
        [SwaggerOperation(
            Summary = "Get appointment histories by appointment ID",
            Description = "This endpoint retrieves all appointment histories associated with a given appointment ID"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Appointment histories retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No appointment histories found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetByAppointmentId(int appointmentId)
        {
            var histories = await _service.GetByAppointmentIdAsync(appointmentId);
            if (histories == null || histories.Count() == 0)
            {
                return NotFound(new { message = "No appointment histories found for the given appointmentId." });
            }
            return Ok(histories); // Return the found appointment histories
        }

        // Endpoint to create a new appointment history
        [SwaggerOperation(
            Summary = "Create a new appointment history",
            Description = "This endpoint allows you to create a new appointment history in the system"
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "Appointment history created successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost]
        public async Task<IActionResult> Create(AppointmentHistory appointmentHistory)
        {
            try
            {
                var created = await _service.CreateAsync(appointmentHistory);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created); // Return the created appointment history
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message }); // Return bad request if there's an issue with the input
            }
        }

        // Endpoint to delete an appointment history by ID
        [SwaggerOperation(
            Summary = "Delete appointment history by ID",
            Description = "This endpoint deletes a specific appointment history by its ID"
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Appointment history deleted successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Appointment history not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = "Appointment history not found." });
            }

            return NoContent(); // Return no content if deletion is successful
        }
    }
}
