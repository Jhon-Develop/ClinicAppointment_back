using ClinicAppointments.Models;
using ClinicAppointments.Services;
using ClinicAppointments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations; 

namespace ClinicAppointments.Controllers
{
    [Route("api/v1/specialties")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        // GET: api/v1/specialties
        [SwaggerOperation(
            Summary = "Get all specialties",
            Description = "Retrieves a list of all specialties in the system."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved all specialties")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _specialtyService.GetAllAsync());
        }

        // GET: api/v1/specialties/{id}
        [SwaggerOperation(
            Summary = "Get specialty by ID",
            Description = "Retrieves the details of a specialty specified by the ID."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the specialty")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Specialty not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _specialtyService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return error message if specialty is not found
            }
        }

        // POST: api/v1/specialties
        [SwaggerOperation(
            Summary = "Create a new specialty",
            Description = "Creates a new specialty with the provided details."
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "Specialty successfully created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Specialty specialty)
        {
            try
            {
                var createdSpecialty = await _specialtyService.CreateAsync(specialty);
                return CreatedAtAction(nameof(Get), new { id = createdSpecialty.Id }, createdSpecialty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return bad request if creation fails
            }
        }

        // PUT: api/v1/specialties/{id}
        [SwaggerOperation(
            Summary = "Update an existing specialty",
            Description = "Updates the details of an existing specialty by its ID."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Specialty successfully updated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Specialty not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Specialty specialty)
        {
            try
            {
                var updatedSpecialty = await _specialtyService.UpdateAsync(id, specialty);
                return Ok(updatedSpecialty);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return error message if the specialty is not found
            }
        }

        // DELETE: api/v1/specialties/{id}
        [SwaggerOperation(
            Summary = "Delete a specialty by ID",
            Description = "Deletes the specialty identified by the specified ID."
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Specialty successfully deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Specialty not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _specialtyService.DeleteAsync(id);
                return NoContent(); // Return NoContent status after successful deletion
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return NotFound if the specialty is not found
            }
        }
    }
}
