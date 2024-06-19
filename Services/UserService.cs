using System.Collections.Generic;
using System.Linq;
using ChamadoSystemBackend.DTOs;
using ChamadoSystemBackend.Models;
using ChamadoSystemBackend.Data;

namespace ChamadoSystemBackend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _context.Users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
            }).ToList();
        }

        public UserDto GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }

        public UserDto CreateUser(CreateUserDto createUserDto)
        {
            var newUser = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                Role = createUserDto.Role
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return new UserDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Role = newUser.Role
            };
        }
    }
}
