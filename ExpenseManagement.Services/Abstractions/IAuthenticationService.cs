using ExpenseManagement.Domain.DTOs;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.Abstractions
{
    public interface IAuthenticationService
    {
        Task<UserResponseDTO> Login(UserLoginDTO userLoginDTO);
        Task<UserResponseDTO> AddUser(UserDTO userDTO);
    }
}
