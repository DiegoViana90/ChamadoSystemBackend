// ChamadoSystemBackend\Services\IUserService.cs
using System.Collections.Generic;
using ChamadoSystemBackend.DTOs;

namespace ChamadoSystemBackend.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUserById(int id);
        UserDto CreateUser(CreateUserDto createUserDto);
    }
}
