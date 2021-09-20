using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Repositories.Abstractions
{
    public interface IAuthenticationRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(UserDTO userDTO);
    }
}
