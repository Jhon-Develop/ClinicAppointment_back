using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations; // Import the Swagger annotations

namespace ClinicAppointments.Controllers.v1
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/v1/users
        [SwaggerOperation(
            Summary = "Create a new user",
            Description = "Creates a new user with the provided data."
        )]
        [SwaggerResponse(StatusCodes.Status201Created, "User successfully created")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid user data")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is null."); // Return BadRequest if user data is null
            }

            var user = await _userService.CreateUserAsync(userDto);
            if (user == null)
            {
                return BadRequest("Error creating user."); // Return BadRequest if the user couldn't be created
            }

            return CreatedAtAction(nameof(GetUserByIdAsync), new { id = user.Id }, user); // Return Created status with the location of the new user
        }

        // GET: api/v1/users/{id}
        [SwaggerOperation(
            Summary = "Get a user by ID",
            Description = "Retrieves a user by their ID from the system."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "User successfully retrieved")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found."); // Return NotFound if the user is not found
            }

            return Ok(user); // Return Ok with the user details
        }

        // GET: api/v1/users
        [SwaggerOperation(
            Summary = "Get all users",
            Description = "Retrieves a list of all users in the system."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved all users")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users); // Return Ok with the list of all users
        }

        // PUT: api/v1/users/{id}
        [SwaggerOperation(
            Summary = "Update a user",
            Description = "Updates the user data with the provided information."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "User successfully updated")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid user data")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is null."); // Return BadRequest if the update data is null
            }

            var updatedUser = await _userService.UpdateUserAsync(id, userDto);
            if (updatedUser == null)
            {
                return NotFound($"User with ID {id} not found."); // Return NotFound if the user is not found
            }

            return Ok(updatedUser); // Return Ok with the updated user data
        }

        // DELETE: api/v1/users/{id}
        [SwaggerOperation(
            Summary = "Delete a user",
            Description = "Deletes a user by their ID from the system."
        )]
        [SwaggerResponse(StatusCodes.Status204NoContent, "User successfully deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound($"User with ID {id} not found."); // Return NotFound if the user is not found
            }

            return NoContent(); // Return NoContent status after successful deletion
        }
    }
}
