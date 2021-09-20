using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExpenseManagement.API.Controllers
{
    [Controller]
    [Route("api/v1/budget")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        [Route("balance")]
        [Authorize(Roles = "Regular")]
        public async Task<ActionResult<double>> GetBalance()
        {
            try
            {
                Budget budget = await _budgetService.ViewBudget();
                return budget.Balance;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("allocate")]
        [Authorize(Roles = "Admin")]
        public ActionResult AllocateBudget(double amount)
        {
            try
            {
                var result = _budgetService.AllocateBudget(amount);
                if (result)
                {
                    return Ok("Budget Allocated Successfully");
                }
                return BadRequest("Budget not allocated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
