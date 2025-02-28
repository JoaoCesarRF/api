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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            
      
                var token = await _authService.LoginAsync(user.Username, user.Password);
                return !string.IsNullOrEmpty(token) ? Ok(new { token }) : Unauthorized();
        }
    }
}
