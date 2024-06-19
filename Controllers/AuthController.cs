// ChamadoSystemBackend\Controllers\AuthController.cs
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
        /// <returns>Token JWT se a autenticação for bem-sucedida.</returns>
        [HttpPost("login")]
        [SwaggerOperation("Autenticação de Usuário")]
        [SwaggerResponse(200, "Token JWT gerado com sucesso", typeof(AuthResponseDto))]
        [SwaggerResponse(401, "Usuário não autorizado")]
        public IActionResult Login([FromBody] AuthRequestDto request)
        {
            var token = _authService.Authenticate(request.Email, request.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new AuthResponseDto { Token = token });
        }
    }
}
