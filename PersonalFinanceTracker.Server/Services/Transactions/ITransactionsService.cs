using PersonalFinanceTracker.TransactionsRestApi.Entities;

namespace PersonalFinanceTracker.TransactionsRestApi.Services.Transactions
{
    public interface ITransactionsService
    {
        Task<IEnumerable<TransactionEntity>> GetAllAsync();
    }
}
