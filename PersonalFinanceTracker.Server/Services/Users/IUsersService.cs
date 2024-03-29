using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Utilities;

namespace PersonalFinanceTracker.TransactionsRestApi.Services.Users
{
    public interface IUsersService
    {
        Task<ControllerServiceResult<UserEntity>> GetByIdAsync(string id);
        Task<UserEntity?> GetByUserNameAsync(string userName);
        Task<ControllerServiceResult<UserEntity>> CreateAsync(UserEntity createUserModel);
    }
}
