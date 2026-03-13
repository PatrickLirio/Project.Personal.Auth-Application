using backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Application.DTOs;


namespace backend.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            try
            {

                var result = await _userService.RegisterAsync(request);

                // 201 Created — standard HTTP status for resource creation 

                return CreatedAtAction(nameof(Register), result);

            }

            catch (InvalidOperationException ex)

            {

                // 409 Conflict — email or username already exists 

                return Conflict(new { message = ex.Message });

            }
        }

        // POST /api/auth/login 

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)

        {
            try
            {
                var result = await _userService.LoginAsync(request);
                // 200 OK — login was successful, return the token 
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                // 401 Unauthorized — bad credentials 
                return Unauthorized(new { message = ex.Message });

            }

        }
    }
}
