// ChamadoSystemBackend\Services\AuthService.cs
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChamadoSystemBackend.Data;
using ChamadoSystemBackend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ChamadoSystemBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public AuthResponse Authenticate(string email, string password)
        {
            Console.WriteLine($"Tentando autenticar usuário com email: {email}");

            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                Console.WriteLine($"Usuário não encontrado para o email: {email}");
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new AuthResponse
            {
                Token = tokenString,
                User = user
            };
        }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
    }
}
