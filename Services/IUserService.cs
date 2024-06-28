using ChamadoSystemBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChamadoSystemBackend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<IEnumerable<UserDto>> GetUsersByNameAsync(string name);
        Task DeleteUserAsync(int id);
        Task UpdateUserPasswordAsync(UpdatePasswordDto updatePasswordDto); 
    }
}
