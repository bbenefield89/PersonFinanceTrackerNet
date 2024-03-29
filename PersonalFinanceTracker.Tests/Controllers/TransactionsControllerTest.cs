using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Services.Transactions;

namespace PersonalFinanceTracker.TransactionsRestApi.Tests.Controllers
{
    public class TransactionsControllerTest
    {
        [Fact]
        public async Task GetAllAsync_ReturnAllTransactions()
        {
            var transactions = new List<TransactionEntity>
            {
                new TransactionEntity { Id = 1, Date = DateTime.Now, Amount = 100, Type = "Type", Category = "Category" },
                new TransactionEntity { Id = 2, Date = DateTime.Now, Amount = 5000, Type = "Type", Category = "Category" }
            };

            var mockService = new Mock<ITransactionsService>();
            mockService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(transactions);

            var controller = new TransactionsController(mockService.Object);
            var result = await controller.GetAllAsync();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actual = Assert.IsAssignableFrom<IEnumerable<TransactionEntity>>(okResult.Value);
            var expected = 2;

            Assert.Equal(expected, actual.Count());
        }
    }
}
