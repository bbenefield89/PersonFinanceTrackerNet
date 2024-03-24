using PersonalFinanceTracker.Server.Entities;

namespace PersonalFinanceTracker.Server.Data.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();

        //Task<Transaction?> GetById(int id);

        //Task Create(Transaction transaction);

        //Task<Transaction?> Update(Transaction transaction);

        //Task<bool> DeleteById(int id);
    }
}
