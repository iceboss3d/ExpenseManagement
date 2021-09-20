using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Abstractions
{
    public interface IExpenseService
    {
        Task<Expense> AddExpense(ExpenseDTO expenseDTO);
        string GetExpenseStatus(string id);
        Expense GetExpense(string id);
        List<Expense> GetExpenses();
        bool UpdateStatus (string id, string status);
    }
}
