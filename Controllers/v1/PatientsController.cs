using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicAppointments.Controllers
{
    [Route("api/v1/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Create a new patient
        [SwaggerOperation(
            Summary = "Create a new patient",
            Description = "This endpoint creates a new patient with the provided patient data."
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "Patient created successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid patient data")]
        [HttpPost]
        public async Task<IActionResult> CreatePatientAsync([FromBody] PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest("Patient data is null.");
            }

            var patient = await _patientService.CreatePatientAsync(patientDto);
            if (patient == null)
            {
                return BadRequest("Error creating patient.");
            }

            return CreatedAtAction(nameof(GetPatientByIdAsync), new { id = patient.Id }, patient);
        }

        // Get a patient by their ID
        [SwaggerOperation(
            Summary = "Get a patient by ID",
            Description = "This endpoint retrieves a patient by their unique ID."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Patient retrieved successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Patient not found")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByIdAsync(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            return Ok(patient);
        }

        // Get all patients
        [SwaggerOperation(
            Summary = "Get all patients",
            Description = "This endpoint retrieves all patients from the system."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Patients retrieved successfully")]
        [HttpGet]
        public async Task<IActionResult> GetPatientsAsync()
        {
            var patients = await _patientService.GetPatientsAsync();
            return Ok(patients);
        }

        // Update an existing patient
        [SwaggerOperation(
            Summary = "Update an existing patient",
            Description = "This endpoint updates the details of an existing patient."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Patient updated successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Patient not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid patient data")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientAsync(int id, [FromBody] PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest("Patient data is null.");
            }

            var updatedPatient = await _patientService.UpdatePatientAsync(id, patientDto);
            if (updatedPatient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            return Ok(updatedPatient);
        }

        // Delete a patient by ID
        [SwaggerOperation(
            Summary = "Delete a patient by ID",
            Description = "This endpoint deletes a patient based on their unique ID."
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Patient deleted successfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Patient not found")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientAsync(int id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (!result)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
