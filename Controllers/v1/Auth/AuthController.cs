using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ClinicAppointments.Controllers.v1.Auth
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        // Constructor injection for the AuthService
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Endpoint for user registration
        [SwaggerOperation(
            Summary = "Register a new user",
            Description = "This endpoint allows you to register a new user with email, password, and other required details"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Registration successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request or invalid input")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return bad request if validation fails
            }

            try
            {
                // Attempt to register the user using the provided data
                await _authService.RegisterAsync(registerDto);
                return Ok(); // Return OK if registration is successful
            }
            catch (Exception ex)
            {
                // Catch any exceptions and return the error message
                return BadRequest(ex.Message);
            }
        }

        // Endpoint for user login
        [SwaggerOperation(
            Summary = "User login",
            Description = "This endpoint allows users to log in using their email and password"
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Login successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid credentials or bad request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return bad request if model is invalid
            }

            try
            {
                // Attempt to log the user in and retrieve the token
                var token = await _authService.LoginAsync(loginDto);
                return Ok(new { token }); // Return the generated token
            }
            catch (Exception ex)
            {
                // Catch any exceptions and return the error message
                return BadRequest(ex.Message);
            }
        }
    }
}
