using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            
            if (user.Username == "admin" && user.Password == "password")
            {
                var token = _authService.LoginAsync(user.Username, user.Password);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
