using backendMpact.DTO;
using backendMpact.Models;
using backendMpact.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backendMpact.Controllers
{
    [ApiController]
    [Route("api/users")]
    [IgnoreAntiforgeryToken] 
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

            // Get the logged-in admin's email from the JWT token
            var addedByEmail = User.FindFirstValue(ClaimTypes.Email);
            // Check if user already exists
            var exists = await _service.UserExists(request.Email);
            if (exists)
            {
                return BadRequest("User already exists with this email");
            }

            // Create user
             await _service.CreateUser(request,addedByEmail);
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
