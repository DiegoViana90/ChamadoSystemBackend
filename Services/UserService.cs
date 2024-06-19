// ChamadoSystemBackend\Services\UserService.cs
using System.Collections.Generic;
using System.Linq;
using ChamadoSystemBackend.Data;
using ChamadoSystemBackend.DTOs;
using ChamadoSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChamadoSystemBackend.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await _context.Users
                .Select(u => new UserDto { Id = u.Id, Email = u.Email, Role = u.Role, Name = u.Name })
                .ToListAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserDto { Id = user.Id, Email = user.Email, Role = user.Role, Name = user.Name };
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var newUser = new User
            {
                Email = createUserDto.Email,
                Role = createUserDto.Role,
                Name = createUserDto.Name,
                Password = createUserDto.Password
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new UserDto { Id = newUser.Id, Email = newUser.Email, Role = newUser.Role, Name = newUser.Name };
        }

        public async Task<IEnumerable<UserDto>> GetUsersByNameAsync(string name)
        {
            return await _context.Users
                .Where(u => EF.Functions.Like(u.Name, $"%{name}%"))
                .Select(u => new UserDto { Id = u.Id, Email = u.Email, Role = u.Role, Name = u.Name })
                .ToListAsync();
        }
    }
}
