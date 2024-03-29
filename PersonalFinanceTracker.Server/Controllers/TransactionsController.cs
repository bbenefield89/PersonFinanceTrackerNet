using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Services.Transactions;

namespace PersonalFinanceTracker.TransactionsRestApi
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionEntity>>> GetAllAsync()
        {
            var transactions = await _transactionsService.GetAllAsync();
            return Ok(transactions);
        }
    }
}
