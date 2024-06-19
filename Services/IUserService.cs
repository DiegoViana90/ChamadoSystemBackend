// ChamadoSystemBackend\Services\IUserService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ChamadoSystemBackend.DTOs;

namespace ChamadoSystemBackend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<IEnumerable<UserDto>> GetUsersByNameAsync(string name);
    }
}
