using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Data;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Utilities;

namespace PersonalFinanceTracker.TransactionsRestApi.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly InMemDbContext _context;

        public UsersService(InMemDbContext context)
        {
            _context = context;
        }

        public async Task<ControllerServiceResult<UserEntity>> GetByIdAsync(string id)
        {
            try
            {
                var user = await _context.Users.FindAsync((UserEntity user) => user.Id == id);
                return ControllerServiceResult<UserEntity>
                    .FromSuccess(user);
            }
            catch (Exception)
            {
                return ControllerServiceResult<UserEntity>
                    .FromError("User could not be found");
            }
        }

        public async Task<UserEntity?> GetByUserNameAsync(string userName)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(user => 
                    user.UserName == userName);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<ControllerServiceResult<UserEntity>> CreateAsync(UserEntity user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return ControllerServiceResult<UserEntity>
                    .FromSuccess(user);
            }
            catch (Exception e)
            {
                return ControllerServiceResult<UserEntity>
                    .FromError("Could not create user at this time: " + e.ToString());
            }
        }
    }
}
