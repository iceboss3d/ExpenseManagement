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
        public Guid Id {  get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description {  get; set; }
        public double Amount {  get; set; }
        public ExpenseStatus Status {  get; set; }
        public DateTime Created {  get; set; }

    }
}
