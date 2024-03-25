using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Auth.Entities;
using PersonalFinanceTracker.Auth.Models.InputModels;

namespace PersonalFinanceTracker.Auth.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class AccountCreationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AccountCreationController(UserManager<User> userManager)
        {
            _userManager = userManager;
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

            return Ok(new { Status = "Success", Message = "User created successfully" });
        }
    }
}
