using ClinicAppointments.Models;
using ClinicAppointments.Services;
using ClinicAppointments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicAppointments.Controllers
{
    [Route("api/v1/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/v1/roles
        [SwaggerOperation(
            Summary = "Get all roles",
            Description = "Retrieves a list of all roles in the system."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved all roles")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAllAsync());
        }

        // GET: api/v1/roles/{id}
        [SwaggerOperation(
            Summary = "Get role by ID",
            Description = "Retrieves the role details for the specified role ID."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the role")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Role not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _roleService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return the error message if the role is not found
            }
        }

        // POST: api/v1/roles
        [SwaggerOperation(
            Summary = "Create a new role",
            Description = "Creates a new role with the provided details."
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "Role successfully created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role role)
        {
            try
            {
                var createdRole = await _roleService.CreateAsync(role);
                return CreatedAtAction(nameof(Get), new { id = createdRole.Id }, createdRole);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return bad request if role creation fails
            }
        }

        // PUT: api/v1/roles/{id}
        [SwaggerOperation(
            Summary = "Update an existing role",
            Description = "Updates the details of an existing role specified by the role ID."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully updated the role")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Role not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role role)
        {
            try
            {
                var updatedRole = await _roleService.UpdateAsync(id, role);
                return Ok(updatedRole);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return not found if the role does not exist
            }
        }

        // DELETE: api/v1/roles/{id}
        [SwaggerOperation(
            Summary = "Delete a role by ID",
            Description = "Deletes the role with the specified role ID from the system."
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Role successfully deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Role not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _roleService.DeleteAsync(id);
                return NoContent(); // Return NoContent status after successful deletion
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Return not found if the role does not exist
            }
        }
    }
}
