using ExpenseManagement.Data.Contexts;
using ExpenseManagement.Data.Repositories.Abstractions;
using ExpenseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Repositories.Implementations
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ExpenseManagementDbContext _dbContext;

        public BudgetRepository(ExpenseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Budget> GetBudget()
        {
            Budget budget = _dbContext.Budgets.FirstOrDefault();
            if(budget == null)
            {
                Budget newBudget = new Budget();
                await _dbContext.Budgets.AddAsync(newBudget);
                await _dbContext.SaveChangesAsync();
                return newBudget;
            }
            
            return budget;
        }

        public bool Update(double amount)
        {
            Budget budget = _dbContext.Budgets.FirstOrDefault();
            budget.Balance += amount;
            _dbContext.Budgets.Update(budget);
            _dbContext.SaveChanges();
            return true;
        }

        public bool ReduceBalance(double amount)
        {
            Budget budget = _dbContext.Budgets.FirstOrDefault();
            budget.Balance -= amount;
            _dbContext.Budgets.Update(budget);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
