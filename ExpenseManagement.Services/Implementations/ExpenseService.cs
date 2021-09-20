using AutoMapper;
using ExpenseManagement.Data.Repositories.Abstractions;
using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Domain.Enums;
using ExpenseManagement.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Implementations
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        private readonly IBudgetRepository _budgetRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IMapper mapper, IBudgetRepository budgetRepository)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
            _budgetRepository = budgetRepository;
        }
        public async Task<Expense> AddExpense(ExpenseDTO expenseDTO)
        {
            try
            {
                Expense expense = _mapper.Map<Expense>(expenseDTO);
                Budget budget = await _budgetRepository.GetBudget();
                if(budget.Balance - expense.Amount < 0)
                {
                    throw new ArgumentException("Expense greater than budget balance");
                }
                await _expenseRepository.Create(expense);
                return expense;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Expense GetExpense(string id)
        {
            try
            {
                Expense expense = _expenseRepository.GetExpense(id);
                if(expense == null)
                {
                    throw new ArgumentNullException("Enitity not Found");
                }
                return expense;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Expense> GetExpenses()
        {
            try
            {
                return _expenseRepository.GetExpenses();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetExpenseStatus(string id)
        {
            try
            {
                Expense expense = _expenseRepository.GetExpense(id);
                if (expense == null)
                {
                    throw new ArgumentNullException("Enitity not Found");
                }
                return expense.Status == ExpenseStatus.Approved ? "Approved" : expense.Status == ExpenseStatus.Rejected ? "Rejected" : "Pending";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateStatus(string id, string status)
        {
            try
            {
                Expense expense = _expenseRepository.GetExpense(id);
                if(expense == null)
                {
                    throw new ArgumentNullException("Enitity not Found");
                }
                if(status != "Approved" && status != "Rejected")
                {
                    throw new ArgumentException("Invalid Status");
                }
                if(status == "Approved")
                {
                    Budget budget = await _budgetRepository.GetBudget();
                    double newBalance = budget.Balance - expense.Amount;
                    if (newBalance < 0)
                    {
                        throw new ArgumentException("Expense exceeds budget");
                    }
                    _budgetRepository.ReduceBalance(newBalance);
                }
                bool result = _expenseRepository.UpdateStatus(id, status == "Approved" ? ExpenseStatus.Approved : ExpenseStatus.Rejected);
                return result;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
