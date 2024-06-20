using ChamadoSystemBackend.DTOs;
using ChamadoSystemBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChamadoSystemBackend.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int id);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task<bool> DeleteTicketAsync(int id);
        Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId);
    }
}
