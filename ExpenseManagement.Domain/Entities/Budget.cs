using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Entities
{
    public class Budget
    {
        public Guid Id {  get; set; } = Guid.NewGuid();
        public double Balance { get; set; } = 0;
    }
}
