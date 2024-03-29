using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Data;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Models.InputModels;

namespace PersonalFinanceTracker.TransactionsRestApi.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly InMemDbContext _context;

        public UsersService(InMemDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Users.FindAsync((UserEntity user) => user.Id == id);
            }
            catch (Exception)
            {
                return null;
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

        public async Task<int> CreateAsync(UserEntity user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
