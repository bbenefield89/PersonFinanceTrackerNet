using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.TransactionsRestApi.Entities;
using System.Security.Claims;

namespace PersonalFinanceTracker.TransactionsRestApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class FinancialSummaryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<FinancialSummaryEntity>> GetByUserId()
        {
            var userId = ClaimTypes.NameIdentifier;

            return Ok(userId);
        }
    }
}
