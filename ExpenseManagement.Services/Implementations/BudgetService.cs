using ExpenseManagement.Data.Repositories.Abstractions;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Implementations
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }
        public bool AllocateBudget(double amount)
        {
            try
            {
                bool result = _budgetRepository.Update(amount);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Budget> ViewBudget()
        {
            try
            {
                Budget budget = await _budgetRepository.GetBudget();
                return budget;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
