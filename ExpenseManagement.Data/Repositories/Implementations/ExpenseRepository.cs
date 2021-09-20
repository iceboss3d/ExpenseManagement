using ExpenseManagement.Data.Contexts;
using ExpenseManagement.Data.Repositories.Abstractions;
using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Repositories.Implementations
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseManagementDbContext _dbContext;

        public ExpenseRepository(ExpenseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Expense> Create(Expense expense)
        {
            await _dbContext.Expenses.AddAsync(expense);
            await _dbContext.SaveChangesAsync();
            return expense;
        }

        public Expense GetExpense(string expenseId)
        {
            return _dbContext.Expenses.FirstOrDefault(expense =>  expense.Id == expenseId);
        }

        public List<Expense> GetExpenses()
        {
            return _dbContext.Expenses.ToList();
        }

        public  bool UpdateStatus(string expenseId, ExpenseStatus status)
        {
            Expense expense = _dbContext.Expenses.FirstOrDefault( expense => expense.Id == expenseId);
            if (expense == null)
            {
                throw new ArgumentNullException("No Expense Found");
            }
            expense.Status = status;
            _dbContext.Expenses.Update(expense);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
