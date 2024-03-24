using PersonalFinanceTracker.Server.Entities;

namespace PersonalFinanceTracker.Server.Services
{
    public interface ITransactionsService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
    }
}
