namespace PersonalFinanceTracker.TransactionsRestApi.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
