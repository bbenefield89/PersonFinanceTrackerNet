using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Entities;

namespace PersonalFinanceTracker.TransactionsRestApi.Data
{
    public class InMemDbContext : DbContext
    {
        public virtual DbSet<Transaction> Transactions { get; set; }

        public InMemDbContext() { }

        public InMemDbContext(DbContextOptions<InMemDbContext> options) : base(options)
        {
        }
    }
}
