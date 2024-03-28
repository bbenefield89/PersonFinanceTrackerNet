using PersonalFinanceTracker.TransactionsRestApi.Entities;

namespace PersonalFinanceTracker.TransactionsRestApi.Services
{
    public interface ITransactionsService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
    }
}
