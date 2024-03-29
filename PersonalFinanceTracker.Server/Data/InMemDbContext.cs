using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Entities;

namespace PersonalFinanceTracker.TransactionsRestApi.Data
{
    public class InMemDbContext : DbContext
    {
        public virtual DbSet<TransactionEntity> Transactions { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        public InMemDbContext() { }

        public InMemDbContext(DbContextOptions<InMemDbContext> options) : base(options)
        {
        }
    }
}
