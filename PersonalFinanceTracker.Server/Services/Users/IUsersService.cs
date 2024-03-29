using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Models.InputModels;

namespace PersonalFinanceTracker.TransactionsRestApi.Services.Users
{
    public interface IUsersService
    {
        Task<UserEntity?> GetByIdAsync(string id);
        Task<UserEntity?> GetByUserNameAsync(string userName);
        Task<int> CreateAsync(UserEntity createUserModel);
    }
}
