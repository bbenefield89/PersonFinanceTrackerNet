namespace PersonalFinanceTracker.TransactionsRestApi.Entities
{
    public class FinancialSummaryEntity
    {
        public string Id { get; set; }
        public decimal AccountBalance { get; set; }
        public decimal ExpensesThisMonth { get; set; }
        public decimal IncomeThisMonth { get; set; }
        public string UsertId { get; set; }
        public UserEntity User { get; set; }
    }
}
