using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChamadoSystemBackend.Models;
using ChamadoSystemBackend.Services;
using Swashbuckle.AspNetCore.Annotations;
using ChamadoSystemBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChamadoSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [SwaggerOperation("Listar Tickets")]
        [SwaggerResponse(200, "Lista de tickets encontrada", typeof(List<Ticket>))]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Buscar Ticket por ID")]
        [SwaggerResponse(200, "Ticket encontrado", typeof(Ticket))]
        [SwaggerResponse(404, "Ticket não encontrado")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
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
    return CreatedAtAction(nameof(GetTicket), new { id = createdTicket.Id }, createdTicket);
}

        [HttpPut("{id}")]
        [SwaggerOperation("Atualizar Ticket")]
        [SwaggerResponse(204, "Ticket atualizado com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketUpdateDto ticketDto)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.Title = ticketDto.Title;
            ticket.Description = ticketDto.Description;
            ticket.UserId = ticketDto.UserId;

            await _ticketService.UpdateTicketAsync(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Deletar Ticket")]
        [SwaggerResponse(204, "Ticket deletado com sucesso")]
        [SwaggerResponse(404, "Ticket não encontrado")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await _ticketService.DeleteTicketAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
