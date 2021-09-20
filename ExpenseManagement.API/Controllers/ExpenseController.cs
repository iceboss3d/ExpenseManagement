using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExpenseManagement.API.Controllers
{
    [Controller]
    [Route("api/v1/expense")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        [Route("add-expense")]
        [Authorize(Roles = "Regular")]
        public async Task<ActionResult<Expense>> AddExpense([FromBody] ExpenseDTO expenseDTO)
        {
            try
            {
                var result = await _expenseService.AddExpense(expenseDTO);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("expense-status")]
        [Authorize(Roles = "Regular")]
        public ActionResult<string> GetExpenseStatus(string expenseId)
        {
            try
            {
                var status = _expenseService.GetExpenseStatus(expenseId);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("update-status")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateStatus(string expenseId, string status)
        {
            try
            {
                bool result = await _expenseService.UpdateStatus(expenseId, status);
                if (result)
                {
                    return Ok("Expense Updated");
                }
                return BadRequest("Expense not Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
