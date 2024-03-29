namespace PersonalFinanceTracker.TransactionsRestApi.Models.InputModels
{
    public class CreateUserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
