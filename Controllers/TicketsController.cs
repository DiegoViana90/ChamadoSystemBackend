using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChamadoSystemBackend.Services;
using Swashbuckle.AspNetCore.Annotations;
using ChamadoSystemBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using ChamadoSystemBackend.Models;

namespace ChamadoSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public TicketsController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }

        [HttpGet]
        [SwaggerOperation("Listar Tickets")]
        [SwaggerResponse(200, "Lista de tickets encontrada", typeof(List<TicketDto>))]
        public async Task<IActionResult> GetTicketsAsync(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            IEnumerable<Ticket> ticketsFromService;

            if (user.Role == "support" || user.Role == "Support")
            {
                ticketsFromService = await _ticketService.GetTicketsAsync();
            }
            else
            {
                ticketsFromService = await _ticketService.GetTicketsByUserIdAsync(user.Id);
            }

            return Ok(ticketsFromService);
        }

        [HttpPost]
        [SwaggerOperation("Criar Ticket")]
        [SwaggerResponse(201, "Ticket criado com sucesso", typeof(Ticket))]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreateDto ticketDto)
        {
            var ticket = new Ticket
            {
                Title = ticketDto.Title,
                Description = ticketDto.Description,
                UserId = ticketDto.UserId,
                IsClosed = false
            };

            var createdTicket = await _ticketService.CreateTicketAsync(ticket);
            var message = $"Ticket {createdTicket.Id} criado com sucesso";

            return Ok(message);
        }

        // [HttpGet("{id}")]
        // [SwaggerOperation("Buscar Ticket por ID")]
        // [SwaggerResponse(200, "Ticket encontrado", typeof(TicketDto))]
        // [SwaggerResponse(404, "Ticket não encontrado")]
        // public async Task<IActionResult> GetTicketByIdAsync(int id)
        // {
        //     var ticket = await _ticketService.GetTicketByIdAsync(id);
        //     if (ticket == null)
        //     {
        //         return NotFound();
        //     }

        //     var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        //     var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        //     if (userRole == "user" && ticket.UserId != userId)
        //     {
        //         return Forbid();
        //     }

        //     return Ok(ticket);
        // }

        // [HttpDelete("{id}")]
        // [SwaggerOperation("Deletar Ticket")]
        // [SwaggerResponse(204, "Ticket deletado com sucesso")]
        // [SwaggerResponse(404, "Ticket não encontrado")]
        // public async Task<IActionResult> DeleteTicketAsync(int id)
        // {
        //     var ticket = await _ticketService.GetTicketByIdAsync(id);
        //     if (ticket == null)
        //     {
        //         return NotFound();
        //     }

        //     var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        //     var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        //     if (userRole == "user" && ticket.UserId != userId)
        //     {
        //         return Forbid();
        //     }

        //     var result = await _ticketService.DeleteTicketAsync(id);
        //     if (!result)
        //     {
        //         return NotFound();
        //     }

        //     return NoContent();
        // }

        // [HttpPut("{id}")]
        // [SwaggerOperation("Atualizar Ticket")]
        // [SwaggerResponse(204, "Ticket atualizado com sucesso")]
        // [SwaggerResponse(400, "Requisição inválida")]
        // public async Task<IActionResult> UpdateTicketAsync(int id, [FromBody] TicketUpdateDto ticketDto)
        // {
        //     var ticket = await _ticketService.GetTicketByIdAsync(id);
        //     if (ticket == null)
        //     {
        //         return NotFound();
        //     }

        //     var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
        //     var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        //     if (userRole == "user" && ticket.UserId != userId)
        //     {
        //         return Forbid();
        //     }

        //     ticket.Title = ticketDto.Title;
        //     ticket.Description = ticketDto.Description;
        //     ticket.UserId = ticketDto.UserId;

        //     await _ticketService.UpdateTicketAsync(ticket);
        //     return NoContent();
        // }
    }
}
