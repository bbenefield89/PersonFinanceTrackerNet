using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Auth.Entities;
using PersonalFinanceTracker.Auth.Models.InputModels;
using PersonalFinanceTracker.Auth.Services;

namespace PersonalFinanceTracker.Auth.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class AccountCreationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtService _jwtService;

        public AccountCreationController(
            UserManager<User> userManager,
            JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Status = "Error", Message = "User already exists" });
            }

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return Ok(new {
                    Statuts = "Error",
                    Errors = errors,
                    Message = "User creation failed"
                });
            }

            var createdUser = await _userManager.FindByNameAsync(model.Username);
            var token = _jwtService.GenerateJwtToken(createdUser);

            return StatusCode(
                StatusCodes.Status201Created, 
                new
                {
                    Token = token,
                    Message = "Success"
                });
        }
    }
}
