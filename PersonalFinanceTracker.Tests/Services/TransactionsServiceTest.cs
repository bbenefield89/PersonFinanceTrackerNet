using Moq;
using Moq.EntityFrameworkCore;
using PersonalFinanceTracker.TransactionsRestApi.Data;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Services.Transactions;

namespace PersonalFinanceTracker.TransactionsRestApi.Tests.Services
{
    public class TransactionsServiceTest
    {
        [Fact]
        public async void GetAllAsync_ShouldReturnAllTransactions()
        {
            var transactions = new List<TransactionEntity>
            {
                new TransactionEntity { Id = 1, Date = DateTime.Now, Amount = 100, Type = "Type", Category = "Category" },
                new TransactionEntity { Id = 2, Date = DateTime.Now, Amount = 5000, Type = "Type", Category = "Category" }
            };

            var mockContext = new Mock<InMemDbContext>();

            mockContext
                .Setup(context => context.Transactions)
                .ReturnsDbSet(transactions);

            var service = new TransactionsService(mockContext.Object);
            var result = await service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
