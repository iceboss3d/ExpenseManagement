using AutoMapper;
using ExpenseManagement.Data.Repositories.Abstractions;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Services.Abstractions;
using ExpenseManagement.Services.Implementations;
using Moq;
using System;
using Xunit;

namespace ExpenseManagement.Test
{
    public class ExpenseTest
    {
        private readonly IExpenseRepository expenseRepository;
        private readonly IMapper mapper;
        private readonly IBudgetRepository budgetRepository;

        public ExpenseTest(IExpenseRepository expenseRepository, IMapper mapper, IBudgetRepository budgetRepository)
        {
            this.expenseRepository = expenseRepository;
            this.mapper = mapper;
            this.budgetRepository = budgetRepository;
        }
        [Fact]
        public async void UpdateStatus()
        {
            Mock<IExpenseService> mock = new Mock<IExpenseService>();
            mock.Setup(x => x.UpdateStatus("621e1e32-1f85-4f51-a7f2-0b2d193778f8", "Approved")).ReturnsAsync(true);
            ExpenseService service = new ExpenseService(expenseRepository, mapper, budgetRepository);
            bool result = await service.UpdateStatus("621e1e32-1f85-4f51-a7f2-0b2d193778f8", "Approved");
            Assert.True(result);
        }

        [Fact]
        public void GetExpenseStatusShouldThrowError()
        {
            Mock<IExpenseService> mock = new Mock<IExpenseService>();
            mock.Setup(x => x.GetExpenseStatus("invalid-expense-id")).Throws(new ArgumentNullException("Enitity not Found"));
            ExpenseService service = new ExpenseService(expenseRepository, mapper, budgetRepository);
            string result = service.GetExpenseStatus("621e1e32-1f85-4f51-a7f2-0b2d193778f8");
            Assert.NotEqual("Pending", result);
        }
    }
}
