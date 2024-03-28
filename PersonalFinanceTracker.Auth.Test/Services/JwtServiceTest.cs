using Microsoft.Extensions.Configuration;
using Moq;
using PersonalFinanceTracker.Auth.Entities;
using PersonalFinanceTracker.Auth.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PersonalFinanceTracker.Auth.Test.Services
{
    public class JwtServiceTest
    {
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly JwtService _jwtService;

        public JwtServiceTest() { 
            _configurationMock = new Mock<IConfiguration>();
            _jwtService = new JwtService(_configurationMock.Object);
        }

        [Fact]
        public void GenerateJwtToken_ReturnJwtString()
        {
            _configurationMock
                .Setup(c => c["JWT:Secret"])
                .Returns("super_secret_we_need_a_longer_secret");

            _configurationMock
                .Setup(c => c["JWT:ExpirationInMinutes"])
                .Returns("60");

            var user = new User { Id = "1", UserName = "Brandork" };
            var tokenString = _jwtService.GenerateJwtToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenString);

            Assert.NotNull(token);
            Assert.True(
                token.Claims.Any(c => c.Type == "nameid" && c.Value == user.Id),
                "JWT should contain NameIdentifier claim with correct user Id");
            Assert.True(
                token.Claims.Any(claim => claim.Type == "unique_name" && claim.Value == user.UserName),
                "Jwt should contain Name claim with correct user name");
        }
    }
}
