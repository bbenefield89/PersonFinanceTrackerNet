using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Auth.Entities;

namespace PersonalFinanceTracker.Auth.Data
{
    public class InMemDbContext : IdentityDbContext<User>
    {
        public InMemDbContext(DbContextOptions<InMemDbContext> options) : base(options) { }
    }
}
