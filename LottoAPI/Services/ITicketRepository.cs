using LottoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LottoAPI.Services
{
    public interface ITicketRepository 
    {

        Ticket CreateTickets(int numberOfLines);

        IEnumerable<Ticket> GetTickets();

        Ticket GetTicket(int ticketId);

        Ticket UpdateTicket(List<Ticket> tickets);

        int GetTicketStatus(int ticketId);
    }
}
