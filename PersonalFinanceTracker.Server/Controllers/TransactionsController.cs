using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using PersonalFinanceTracker.TransactionsRestApi.Services;

namespace PersonalFinanceTracker.TransactionsRestApi
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetAllAsync()
        {
            var transactions = await _transactionsService.GetAllAsync();
            return Ok(transactions);
        }
    }
}
