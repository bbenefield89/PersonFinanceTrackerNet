using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Entities;

namespace PersonalFinanceTracker.TransactionsRestApi.Data.Repositories
{
    public class InMemDbTransactionRepository : ITransactionRepository
    {
        private readonly InMemDbContext _context;

        public InMemDbTransactionRepository(InMemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
