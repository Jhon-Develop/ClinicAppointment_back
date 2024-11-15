using ClinicAppointments.Models;
using ClinicAppointments.Services.Interfaces;
using ClinicAppointments.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicAppointments.Controllers
{
    [ApiController]
    [Route("api/v1/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        // Constructor for DoctorController
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        // Endpoint to get all doctors
        [SwaggerOperation(
            Summary = "Get all doctors",
            Description = "This endpoint retrieves all doctors in the system."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Doctors retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _service.GetAllAsync();
            return Ok(doctors);
        }

        // Endpoint to get a doctor by ID
        [SwaggerOperation(
            Summary = "Get a doctor by ID",
            Description = "This endpoint retrieves a doctor by their unique ID."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Doctor retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Doctor not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var doctor = await _service.GetByIdAsync(id);
                return Ok(doctor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // Endpoint to create a new doctor
        [SwaggerOperation(
            Summary = "Create a new doctor",
            Description = "This endpoint creates a new doctor using the provided doctor details."
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "Doctor created successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoctorDto doctorDto)
        {
            try
            {
                var createdDoctor = await _service.CreateAsync(doctorDto);
                return CreatedAtAction(nameof(GetById), new { id = createdDoctor.Id }, createdDoctor);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Endpoint to update an existing doctor
        [SwaggerOperation(
            Summary = "Update an existing doctor",
            Description = "This endpoint updates an existing doctor's details."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Doctor updated successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Doctor not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DoctorDto doctorDto)
        {
            try
            {
                var updatedDoctor = await _service.UpdateAsync(id, doctorDto);
                return Ok(updatedDoctor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Endpoint to delete a doctor by ID
        [SwaggerOperation(
            Summary = "Delete a doctor by ID",
            Description = "This endpoint deletes a doctor based on their unique ID."
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Doctor deleted successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Doctor not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound(new { message = "Doctor not found" });
                }
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
