using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Data;
using PersonalFinanceTracker.TransactionsRestApi.Entities;

namespace PersonalFinanceTracker.TransactionsRestApi.Services
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
