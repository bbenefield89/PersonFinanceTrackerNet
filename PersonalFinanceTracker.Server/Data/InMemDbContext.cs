using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Server.Entities;

namespace PersonalFinanceTracker.Server.Data
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
