// ChamadoSystemBackend\Services\UserService.cs
using System.Collections.Generic;
using System.Linq;
using ChamadoSystemBackend.DTOs;

namespace ChamadoSystemBackend.Services
{
    public class UserService : IUserService
    {
        private static List<UserDto> _users = new List<UserDto>
        {
            new UserDto { Id = 1, Email = "user1@example.com", Role = "user" },
            new UserDto { Id = 2, Email = "user2@example.com", Role = "user" },
            new UserDto { Id = 3, Email = "support1@example.com", Role = "support" }
        };

        public IEnumerable<UserDto> GetUsers()
        {
            return _users;
        }

        public UserDto GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            var newUser = new UserDto
            {
                Id = _users.Count + 1,
                Email = createUserDto.Email,
                Role = createUserDto.Role
            };
            _users.Add(newUser);
            return newUser;
        }
    }
}
