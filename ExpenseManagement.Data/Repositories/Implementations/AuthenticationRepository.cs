using AutoMapper;
using ExpenseManagement.Data.Repositories.Abstractions;
using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Data.Repositories.Implementations
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AuthenticationRepository(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<User> AddUser(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password);
            await _userManager.AddToRoleAsync(user, "Regular");
            if (!result.Succeeded)
            {
                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }
                throw new MissingFieldException(errors);
            }
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            return user;
        }


    }
}
