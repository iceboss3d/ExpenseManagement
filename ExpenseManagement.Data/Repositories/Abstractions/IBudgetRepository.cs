using ExpenseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Repositories.Abstractions
{
    public interface IBudgetRepository
    {
        Task<Budget> GetBudget();
        bool Update(double amount);
        bool ReduceBalance(double amount);
    }
}
