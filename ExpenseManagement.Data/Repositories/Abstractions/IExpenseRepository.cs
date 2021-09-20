using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Repositories.Abstractions
{
    public interface IExpenseRepository
    {
        Task<Expense> Create(Expense expense);
        Expense GetExpense(string expenseId);
        List<Expense> GetExpenses();
        bool UpdateStatus(string expenseId, ExpenseStatus status);
    }
}
