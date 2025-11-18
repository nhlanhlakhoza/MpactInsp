using backendMpact.DTO;
using backendMpact.Models;
using backendMpact.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendMpact.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(RegisterRequest request)
        {
            // Check if user already exists
            var exists = await _service.UserExists(request.Email);
            if (exists)
            {
                return BadRequest("User already exists with this email");
            }

            // Create user
             await _service.CreateUser(request);
            return Ok("User created successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var loginResponse = await _service.Login(request);
                return Ok(loginResponse); // returns token + message
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
