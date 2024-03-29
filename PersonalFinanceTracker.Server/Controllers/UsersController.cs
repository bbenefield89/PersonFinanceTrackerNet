using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Services.Users;
using System.Security.Claims;

namespace PersonalFinanceTracker.TransactionsRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetById([FromRoute] string userId)
        {
            var user = await _usersService.GetByIdAsync(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var user = new UserEntity
            {
                Id = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                UserName = User.FindFirstValue(ClaimTypes.Name)!,
                Email = User.FindFirstValue(ClaimTypes.Email)!,
            };

            var existingUser = await _usersService.GetByIdAsync(user.Id);
            if (existingUser != null)
            {
                return Conflict(new
                {
                    Status = "Error",
                    Message = "User already exists",
                });
            }

            var createUserResp = await _usersService.CreateAsync(user);
            var isUserCreated = createUserResp > 0;

            if (!isUserCreated)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    Message = "Failed to create new user"
                });
            }

            var createdUser = await _usersService.GetByUserNameAsync(user.UserName);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdUser!.Id },
                createdUser);
        }
    }
}
