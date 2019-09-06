using LottoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LottoAPI.Services
{
    public interface ITicketRepository 
    {

        Task CreateTicketsAsync(int numberOfLines);

        Task<IEnumerable<Ticket>> GetTicketsAsync();

        Task<Ticket> GetTicketAsync(int ticketId);

        Ticket UpdateTicket(TicketForUpdateDto tickets, int id);

        Task<IEnumerable<TicketLines>> GetTicketLineStatus(int ticketId);

        bool TicketExists(int ticketId);
    }
}
