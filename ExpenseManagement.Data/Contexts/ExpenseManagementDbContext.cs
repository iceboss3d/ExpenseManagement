using ExpenseManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Contexts
{
    public class ExpenseManagementDbContext : IdentityDbContext<User>
    {
        public ExpenseManagementDbContext(DbContextOptions<ExpenseManagementDbContext> options): base(options)
        {

        }

        public ExpenseManagementDbContext()
        {

        }

        public DbSet<Expense> Expenses {  get; set; }
        public DbSet<Budget> Budgets {  get; set; }
    }
}
