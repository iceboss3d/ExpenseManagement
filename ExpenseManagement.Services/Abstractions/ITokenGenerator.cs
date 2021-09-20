using ExpenseManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Abstractions
{
    public interface ITokenGenerator
    {
        Task<string> Generatetoken(User user);
    }
}
