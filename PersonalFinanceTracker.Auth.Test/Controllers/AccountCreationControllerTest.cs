using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalFinanceTracker.Auth.Controllers;
using PersonalFinanceTracker.Auth.Entities;
using PersonalFinanceTracker.Auth.Models.InputModels;
using PersonalFinanceTracker.Auth.Services;

namespace PersonalFinanceTracker.Auth.Test.Controllers
{
    public class AccountCreationControllerTest
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly Mock<IJwtService> _jwtServiceMock;
        private readonly AccountCreationController _controller;

        public AccountCreationControllerTest()
        {
            var userStoreMock = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            _jwtServiceMock = new Mock<IJwtService>();
            _controller = new AccountCreationController(
                _userManagerMock.Object,
                _jwtServiceMock.Object);
        }

        [Fact]
        public async Task RegisterUser_UserExists_Return500Error()
        {
            var registerModel = new RegisterModel
            {
                Username = "Brandork",
                Email = "email@gmail.com",
                Password = "P455w0rd!",
            };

            _userManagerMock
                .Setup(s => s.FindByNameAsync(registerModel.Username))
                .ReturnsAsync(new User());

            var result = await _controller.RegisterUser(registerModel);
            var statusCodeResult = Assert.IsType<ObjectResult>(result);

            Assert.Equal(StatusCodes.Status409Conflict, statusCodeResult.StatusCode);
            Assert.Contains("User already exists", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task RegisterUser_CreationFailed_Return400BadRequest()
        {
            var registerModel = new RegisterModel
            {
                Username = "Brandork",
                Email = "email@gmail.com",
                Password = "P455w0rd!",
            };

            _userManagerMock
                .Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            _userManagerMock
                .Setup(s => s.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed());

            var result = await _controller.RegisterUser(registerModel);
            var statusCodeResult = Assert.IsType<BadRequestObjectResult>(result);

            Assert.Equal(StatusCodes.Status400BadRequest, statusCodeResult.StatusCode);
            Assert.Contains("User creation failed", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task RegisterUser_CreationSuccess_Return201Created()
        {
            var registerModel = new RegisterModel
            {
                Username = "Brandork",
                Email = "email@gmail.com",
                Password = "P455w0rd!",
            };

            _userManagerMock
                .Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            _userManagerMock
                .Setup(s => s.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            _jwtServiceMock
                .Setup(s => s.GenerateJwtToken(It.IsAny<User>()))
                .Returns("some_jwt_string");

            var result = await _controller.RegisterUser(registerModel);
            var statusCodeResult = Assert.IsType<ObjectResult>(result);

            Assert.Equal(StatusCodes.Status201Created, statusCodeResult.StatusCode);
            Assert.Contains("some_jwt_string", statusCodeResult.Value.ToString());
        }
    }
}
