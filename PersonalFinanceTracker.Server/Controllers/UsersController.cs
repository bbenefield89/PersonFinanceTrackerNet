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
                Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
                UserName = User.FindFirstValue(ClaimTypes.Name),
                Email = User.FindFirstValue(ClaimTypes.Email),
                Transactions = new List<TransactionEntity>(),
            };

            var existingUser = await _usersService.GetByIdAsync(user.Id);
            if (existingUser.Success)
            {
                return Conflict(new
                {
                    Status = "Error",
                    Message = "User already exists",
                });
            }

            var createUserResponse = await _usersService.CreateAsync(user);
            if (!createUserResponse.Success)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    createUserResponse.Message,
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createUserResponse.Data.Id },
                createUserResponse.Data);
        }
    }
}
