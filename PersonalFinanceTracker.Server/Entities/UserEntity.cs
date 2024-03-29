namespace PersonalFinanceTracker.TransactionsRestApi.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
    }
}
