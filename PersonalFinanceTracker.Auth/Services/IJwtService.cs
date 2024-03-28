using PersonalFinanceTracker.Auth.Entities;

namespace PersonalFinanceTracker.Auth.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
    }
}
