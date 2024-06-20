using Microsoft.AspNetCore.Mvc;
using ChamadoSystemBackend.Services;
using ChamadoSystemBackend.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace ChamadoSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Realiza o login de um usuário e retorna um token JWT válido.
        /// </summary>
        /// <param name="request">Dados de autenticação do usuário.</param>
        /// <returns>Token JWT e detalhes do usuário se a autenticação for bem-sucedida.</returns>
        [HttpPost("login")]
        [SwaggerOperation("Autenticação de Usuário")]
        [SwaggerResponse(200, "Token JWT gerado com sucesso", typeof(AuthResponseDto))]
        [SwaggerResponse(401, "Usuário não autorizado")]
        public IActionResult Login([FromBody] AuthRequestDto request)
        {
            var authResponse = _authService.Authenticate(request.Email, request.Password);
            if (authResponse == null)
            {
                return Unauthorized();
            }

            var authResponseDto = new AuthResponseDto
            {
                Token = authResponse.Token,
                User = new UserDto
                {
                    Id = authResponse.User.Id,
                    Name = authResponse.User.Name,
                    Email = authResponse.User.Email,
                    Role = authResponse.User.Role
                }
            };

            return Ok(authResponseDto);
        }
    }
}
