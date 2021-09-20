using ExpenseManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Entities
{
    public class Expense
    {
        public string Id {  get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description {  get; set; }
        public double Amount {  get; set; }
        public ExpenseStatus Status { get; set; } = ExpenseStatus.Pending;
        public DateTime Created {  get; set; } = DateTime.Now;

    }
}
