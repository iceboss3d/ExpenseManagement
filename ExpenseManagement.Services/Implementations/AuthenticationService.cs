using AutoMapper;
using ExpenseManagement.Data.Repositories.Abstractions;
using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;
using ExpenseManagement.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IMapper mapper, UserManager<User> userManager, ITokenGenerator tokenGenerator)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<UserResponseDTO> AddUser(UserDTO userDTO)
        {
            User user = await _authenticationRepository.AddUser(userDTO);
            UserResponseDTO userResponse = _mapper.Map<UserResponseDTO>(user);
            return userResponse;
        }

        public async Task<UserResponseDTO> Login(UserLoginDTO userLoginDTO)
        {
            User user = await _authenticationRepository.GetUserByEmail(userLoginDTO.Email);
            if (user == null)
            {
                throw new AccessViolationException("Invalid Credentials");
            }

            if(await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                UserResponseDTO userResponse = _mapper.Map<UserResponseDTO>(user);
                userResponse.Token = await _tokenGenerator.Generatetoken(user);
                return userResponse;
            }
            throw new AccessViolationException("Invalid Credentials");
        }
    }
}
