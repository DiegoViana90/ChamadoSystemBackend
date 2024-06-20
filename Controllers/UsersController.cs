using Microsoft.AspNetCore.Mvc;
using ChamadoSystemBackend.DTOs;
using ChamadoSystemBackend.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        [SwaggerOperation("Listar Usuários")]
        [SwaggerResponse(200, "Lista de usuários encontrada", typeof(List<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Buscar Usuário por ID")]
        [SwaggerResponse(200, "Usuário encontrado", typeof(UserDto))]
        [SwaggerResponse(404, "Usuário não encontrado")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [SwaggerOperation("Criar Usuário")]
        [SwaggerResponse(201, "Usuário criado com sucesso", typeof(UserDto))]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var createdUser = await _userService.CreateUserAsync(createUserDto);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("search")]
        [SwaggerOperation("Buscar Usuários por Nome")]
        [SwaggerResponse(200, "Usuários encontrados", typeof(List<UserDto>))]
        [SwaggerResponse(404, "Nenhum usuário encontrado")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByName([FromQuery] string name)
        {
            var users = await _userService.GetUsersByNameAsync(name);
            if (users == null || !users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Deletar Usuário por ID")]
        [SwaggerResponse(204, "Usuário deletado com sucesso")]
        [SwaggerResponse(404, "Usuário não encontrado")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
                       return Ok("Usuário deletado com sucesso!");
        }
    }
}
