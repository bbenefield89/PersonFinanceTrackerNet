using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalFinanceTracker.Auth.Controllers;
using PersonalFinanceTracker.Auth.Entities;
using PersonalFinanceTracker.Auth.Models.InputModels;
using PersonalFinanceTracker.Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Auth.Test.Controllers
{
    public class AuthControllerTest
    {
        private readonly Mock<UserManager<User>> _userManager;
        private readonly Mock<IJwtService>_jwtService;
        private readonly AuthController _authController;

        public AuthControllerTest()
        {
            var userStoreMock = new Mock<IUserStore<User>>();
            _userManager = new Mock<UserManager<User>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            _jwtService = new Mock<IJwtService>();
            _authController = new AuthController(_userManager.Object, _jwtService.Object);
        }

        [Fact]
        public async Task Login_CorrectCredentials_Return200Ok()
        {
            var user = new User { };

            _userManager
                .Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            _userManager
                .Setup(s => s.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            _jwtService
                .Setup(s => s.GenerateJwtToken(It.IsAny<User>()))
                .Returns("some_jwt_string");

            var result = await _authController.Login(new LoginModel());
            var statusCodeResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(StatusCodes.Status200OK, statusCodeResult.StatusCode);
            Assert.Contains("Token = some_jwt_string", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task Login_UserDoesNotExist_Return401Unauthorized()
        {
            _userManager
                .Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            var result = await _authController.Login(new LoginModel());
            var statusCodeResult = Assert.IsType<UnauthorizedObjectResult>(result);

            Assert.Equal(StatusCodes.Status401Unauthorized, statusCodeResult.StatusCode);
            Assert.Contains("Authentication failed", statusCodeResult.Value.ToString());
        }

        [Fact]
        public async Task Login_UserExists_WrongCredentials_Return401Unauthorized()
        {
            _userManager
                .Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new User());

            _userManager
                .Setup(s => s.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(false);

            var result = await _authController.Login(new LoginModel());
            var statusCodeResult = Assert.IsType<UnauthorizedObjectResult>(result);

            Assert.Equal(StatusCodes.Status401Unauthorized, statusCodeResult.StatusCode);
            Assert.Contains("Authentication failed", statusCodeResult.Value.ToString());
        }
    }
}
