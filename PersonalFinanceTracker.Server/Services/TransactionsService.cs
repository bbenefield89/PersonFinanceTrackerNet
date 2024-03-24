using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Server.Data;
using PersonalFinanceTracker.Server.Entities;

namespace PersonalFinanceTracker.Server.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly InMemDbContext _context;

        public TransactionsService(InMemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
