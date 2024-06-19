using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChamadoSystemBackend.Models;
using ChamadoSystemBackend.Services;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Retorna todos os tickets.
        /// </summary>
        /// <returns>Lista de tickets.</returns>
        [HttpGet]
        [SwaggerOperation("Listar Tickets")]
        [SwaggerResponse(200, "Lista de tickets encontrada", typeof(List<Ticket>))]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _ticketService.GetTicketsAsync();
            return Ok(tickets);
        }

        /// <summary>
        /// Retorna um ticket específico pelo ID.
        /// </summary>
        /// <param name="id">ID do ticket.</param>
        /// <returns>Informações do ticket.</returns>
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

        /// <summary>
        /// Cria um novo ticket.
        /// </summary>
        /// <param name="ticket">Dados do novo ticket a ser criado.</param>
        /// <returns>Novo ticket criado.</returns>
        [HttpPost]
        [SwaggerOperation("Criar Ticket")]
        [SwaggerResponse(201, "Ticket criado com sucesso", typeof(Ticket))]
        public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
        {
            var createdTicket = await _ticketService.CreateTicketAsync(ticket);
            return CreatedAtAction(nameof(GetTicket), new { id = createdTicket.Id }, createdTicket);
        }

        /// <summary>
        /// Atualiza um ticket existente.
        /// </summary>
        /// <param name="id">ID do ticket a ser atualizado.</param>
        /// <param name="ticket">Dados atualizados do ticket.</param>
        /// <returns>Código de resposta indicando sucesso.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation("Atualizar Ticket")]
        [SwaggerResponse(204, "Ticket atualizado com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            await _ticketService.UpdateTicketAsync(ticket);
            return NoContent();
        }

        /// <summary>
        /// Deleta um ticket existente.
        /// </summary>
        /// <param name="id">ID do ticket a ser deletado.</param>
        /// <returns>Código de resposta indicando sucesso.</returns>
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
