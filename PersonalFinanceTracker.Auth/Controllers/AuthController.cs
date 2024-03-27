using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Auth.Entities;
using PersonalFinanceTracker.Auth.Models.InputModels;
using PersonalFinanceTracker.Auth.Services;

namespace PersonalFinanceTracker.Auth.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtService _jwtService;

        public AuthController(
            UserManager<User> userManager,
            IConfiguration configuration,
            JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = _jwtService.GenerateJwtToken(user);

                return Ok(new { 
                    Token = token,
                    Message = "Success" 
                });
            }

            return Unauthorized(new
            {
                Message = "Authentication failed. Wrong username or password"
            });
        }
    }
}
