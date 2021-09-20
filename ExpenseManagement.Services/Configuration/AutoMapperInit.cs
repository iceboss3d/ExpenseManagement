using AutoMapper;
using ExpenseManagement.Domain.DTOs;
using ExpenseManagement.Domain.Entities;

namespace ExpenseManagement.Services.Configuration
{
    public class AutoMapperInit : Profile
    {
        public AutoMapperInit()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
        }
    }
}
