using Microsoft.AspNetCore.Mvc;
using ChamadoSystemBackend.DTOs;
using ChamadoSystemBackend.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace ChamadoSystemBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retorna todos os usuários.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        [HttpGet]
        [SwaggerOperation("Listar Usuários")]
        [SwaggerResponse(200, "Lista de usuários encontrada", typeof(List<UserDto>))]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        /// <summary>
        /// Retorna um usuário específico pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>Informações do usuário.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation("Buscar Usuário por ID")]
        [SwaggerResponse(200, "Usuário encontrado", typeof(UserDto))]
        [SwaggerResponse(404, "Usuário não encontrado")]
        public ActionResult<UserDto> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="createUserDto">Dados do novo usuário a ser criado.</param>
        /// <returns>Novo usuário criado.</returns>
        [HttpPost]
        [SwaggerOperation("Criar Usuário")]
        [SwaggerResponse(201, "Usuário criado com sucesso", typeof(UserDto))]
        public ActionResult<UserDto> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var createdUser = _userService.CreateUser(createUserDto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }
    }
}
