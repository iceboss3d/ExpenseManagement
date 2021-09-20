using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Domain.Entities
{
    public class Budget
    {
        public string Id {  get; set; } = Guid.NewGuid().ToString();
        public double Balance { get; set; } = 0;
    }
}
