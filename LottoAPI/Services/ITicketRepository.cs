using LottoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LottoAPI.Services
{
    public interface ITicketRepository 
    {
        void CreateTickets(int numberOfLines);

        Task<IEnumerable<Ticket>> GetTicketsAsync();

        Task<Ticket> GetTicketAsync(int ticketId);

        Ticket AmendTicket(int id, int numberOfNewLines);

        Task<IEnumerable<TicketLines>> GetTicketLineStatus(int ticketId);

        bool TicketExists(int ticketId);

        bool HasStatusBeenChecked(int id);
    }
}
