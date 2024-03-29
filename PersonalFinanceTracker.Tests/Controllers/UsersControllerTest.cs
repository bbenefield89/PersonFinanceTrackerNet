using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalFinanceTracker.TransactionsRestApi.Controllers;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Services.Users;
using PersonalFinanceTracker.TransactionsRestApi.Utilities;
using System.Security.Claims;

namespace PersonalFinanceTracker.TransactionsRestApi.Tests.Controllers
{
    public class UsersControllerTest
    {
        private readonly Mock<IUsersService> _usersServiceMock;
        private readonly UsersController _usersController;

        public UsersControllerTest()
        {
            _usersServiceMock = new Mock<IUsersService>();
            _usersController = new UsersController(_usersServiceMock.Object);

            var userClaims = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "Brandork"),
                new Claim(ClaimTypes.Email, "bsquared18@gmail.com"),
            }, "mock"));

            _usersController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userClaims },
            };
        }

        [Fact]
        public async Task Create_UserExists_Return409Conflict()
        {
            _usersServiceMock
                .Setup(s => s.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(ControllerServiceResult<UserEntity>.FromSuccess(new UserEntity()));

            var result = await _usersController.Create();
            var statusCodeResult = Assert.IsType<ConflictObjectResult>(result);

            Assert.Equal(StatusCodes.Status409Conflict, statusCodeResult.StatusCode);
            Assert.Contains("User already exists", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task Create_FailToCreate_Return400BadRequest()
        {
            _usersServiceMock
                .Setup(s => s.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(ControllerServiceResult<UserEntity>.FromError("Fail"));

            _usersServiceMock
                .Setup(s => s.CreateAsync(It.IsAny<UserEntity>()))
                .ReturnsAsync(ControllerServiceResult<UserEntity>.FromError("Could not create user"));

            var result = await _usersController.Create();
            var statusCodeResult = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal(StatusCodes.Status400BadRequest, statusCodeResult.StatusCode);
            Assert.Contains("Could not create user", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task Create_Success_Return201Created()
        {
            var user = new UserEntity
            {
                Id = "1",
                UserName = "Brandork",
                Email = "bsquared18@gmail.com",
                Transactions = new List<TransactionEntity>(),
            };

            _usersServiceMock
                .Setup(s => s.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(ControllerServiceResult<UserEntity>.FromError("Fail"));

            _usersServiceMock
                .Setup(s => s.CreateAsync(It.IsAny<UserEntity>()))
                .ReturnsAsync(ControllerServiceResult<UserEntity>.FromSuccess(user));

            var result = await _usersController.Create();
            var statusCodeResult = Assert.IsType<CreatedAtActionResult>(result);

            Assert.Equal(StatusCodes.Status201Created, statusCodeResult.StatusCode);
            Assert.Contains("Brandork", ((UserEntity)statusCodeResult.Value).UserName);
        }
    }
}
